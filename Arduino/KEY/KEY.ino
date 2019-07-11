#include <MFRC522.h>
#include <SPI.h>

#define RST_PIN D1  // Configurable, see typical pin layout above
#define SS_PIN  D2  // Configurable, see typical pin layout above

MFRC522 mfrc522(SS_PIN, RST_PIN);  // Create MFRC522 instance.

MFRC522::MIFARE_Key keyA;
MFRC522::MIFARE_Key keyB;

MFRC522::MIFARE_Key newKeyA = {keyByte: {0xE0, 0xE1, 0xE2, 0xE3, 0xE4, 0xE5}};
MFRC522::MIFARE_Key newKeyB = {keyByte: {0x70, 0x65, 0x72, 0x70, 0x75, 0x73}};

/** 
   Initialize.
*/
void setup() {
    Serial.begin(9600);   // Initialize serial communications with the PC
    while (!Serial);      // Do nothing if no serial port is opened (added for Arduinos based on ATMEGA32U4)
    SPI.begin();          // Init SPI bus
    mfrc522.PCD_Init();   // Init MFRC522 card

    // Prepare the key
    // using FFFFFFFFFFFFh which is the default at chip delivery from the factory
    
//    for (byte i = 0; i < MFRC522::MF_KEY_SIZE; i++) {
//        keyA.keyByte[i] = 0xFF;
//        keyB.keyByte[i] = 0xFF;
//    }

      keyA.keyByte[0] = 0xA0;
      keyA.keyByte[1] = 0xA1;
      keyA.keyByte[2] = 0xA2;
      keyA.keyByte[3] = 0xA3;
      keyA.keyByte[4] = 0xA4;
      keyA.keyByte[5] = 0xA5;

      keyB.keyByte[0] = 0x70;
      keyB.keyByte[1] = 0x65;
      keyB.keyByte[2] = 0x72;
      keyB.keyByte[3] = 0x70;
      keyB.keyByte[4] = 0x75;
      keyB.keyByte[5] = 0x73;

    Serial.println(F("Scan a MIFARE Classic PICC to demonstrate read and write."));
    Serial.print(F("Using key (for A and B):"));
    dump_byte_array(keyA.keyByte, MFRC522::MF_KEY_SIZE);
    Serial.println();
    }

    /**
     Main loop.
    */
    void loop() {
    // Look for new cards
    if (!mfrc522.PICC_IsNewCardPresent())
        return;

    // Select one of the cards
    if (!mfrc522.PICC_ReadCardSerial())
        return;

    // Show some details of the PICC (that is: the tag/card)
    Serial.print(F("Card UID:"));
    dump_byte_array(mfrc522.uid.uidByte, mfrc522.uid.size);
    Serial.println();
    Serial.print(F("PICC type: "));
    MFRC522::PICC_Type piccType = mfrc522.PICC_GetType(mfrc522.uid.sak);
    Serial.println(mfrc522.PICC_GetTypeName(piccType));

    // Check for compatibility
    if (piccType != MFRC522::PICC_TYPE_MIFARE_MINI
        && piccType != MFRC522::PICC_TYPE_MIFARE_1K
        && piccType != MFRC522::PICC_TYPE_MIFARE_4K) {
        Serial.println(F("This sample only works with MIFARE Classic cards."));
        return;
    }

    // change keys in section 15 block 63
    if (!MIFARE_SetKeys(&keyA, &keyB, &newKeyA, &newKeyB, 0)) {
        return;
    }

    // Halt PICC
    mfrc522.PICC_HaltA();
    // Stop encryption on PCD
    mfrc522.PCD_StopCrypto1();
    }

    /**
     Helper routine to dump a byte array as hex values to Serial.
    */
    void dump_byte_array(byte* buffer, byte bufferSize) {
    for (byte i = 0; i < bufferSize; i++) {
        Serial.print(buffer[i] < 0x10 ? " 0" : " ");
        Serial.print(buffer[i], HEX);
    }
    }

    bool MIFARE_SetKeys(MFRC522::MIFARE_Key* oldKeyA, MFRC522::MIFARE_Key* oldKeyB,
                        MFRC522::MIFARE_Key* newKeyA, MFRC522::MIFARE_Key* newKeyB,
                        int sector) {
    MFRC522::StatusCode status;
    byte trailerBlock = sector * 4 + 3;
    byte buffer[18];
    byte size = sizeof(buffer);

    // Authenticate using key A
    Serial.println(F("Authenticating using key A..."));
    status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, trailerBlock, oldKeyA, &(mfrc522.uid));
    if (status != MFRC522::STATUS_OK) {
        Serial.print(F("PCD_Authenticate() failed: "));
        Serial.println(mfrc522.GetStatusCodeName(status));
        return false;
    }

    // Show the whole sector as it currently is
    Serial.println(F("Current data in sector:"));
    mfrc522.PICC_DumpMifareClassicSectorToSerial(&(mfrc522.uid), oldKeyA, sector);
    Serial.println();

    // Read data from the block
    Serial.print(F("Reading data from block ")); Serial.print(trailerBlock);
    Serial.println(F(" ..."));
    status = (MFRC522::StatusCode) mfrc522.MIFARE_Read(trailerBlock, buffer, &size);
    if (status != MFRC522::STATUS_OK) {
        Serial.print(F("MIFARE_Read() failed: "));
        Serial.println(mfrc522.GetStatusCodeName(status));
        return false;
    }
    Serial.print(F("Data in block ")); Serial.print(trailerBlock); Serial.println(F(":"));
    dump_byte_array(buffer, 16); Serial.println();
    Serial.println();

    // Authenticate using key B
    Serial.println(F("Authenticating again using key B..."));
    status = (MFRC522::StatusCode)mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_B, trailerBlock, oldKeyB, &(mfrc522.uid));
    if (status != MFRC522::STATUS_OK) {
        Serial.print(F("PCD_Authenticate() failed: "));
        Serial.println(mfrc522.GetStatusCodeName(status));
        return false;
    }

    if (newKeyA != nullptr || newKeyB != nullptr) {
        for (byte i = 0; i < MFRC522::MF_KEY_SIZE; i++) {
        if (newKeyA != nullptr) {
            buffer[i] = newKeyA->keyByte[i];
        }
        if (newKeyB != nullptr) {
            buffer[i+10] = newKeyB->keyByte[i];
        }
        }
    }

    // Write data to the block
    Serial.print(F("Writing data into block ")); Serial.print(trailerBlock);
    Serial.println(F(" ..."));
    status = (MFRC522::StatusCode) mfrc522.MIFARE_Write(trailerBlock, buffer, 16);
    if (status != MFRC522::STATUS_OK) {
        Serial.print(F("MIFARE_Write() failed: "));
        Serial.println(mfrc522.GetStatusCodeName(status));
        return false;
    }
    Serial.println();

    // Read data from the block (again, should now be what we have written)
    Serial.print(F("Reading data from block ")); Serial.print(trailerBlock);
    Serial.println(F(" ..."));
    status = (MFRC522::StatusCode)mfrc522.MIFARE_Read(trailerBlock, buffer, &size);
    if (status != MFRC522::STATUS_OK) {
        Serial.print(F("MIFARE_Read() failed: "));
        Serial.println(mfrc522.GetStatusCodeName(status));
    }
    Serial.print(F("Data in block ")); Serial.print(trailerBlock); Serial.println(F(":"));
    dump_byte_array(buffer, 16); Serial.println();
    return true;
}
