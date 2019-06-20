#include <SPI.h>
#include <MFRC522.h>

#define RST_PIN         D1           // Configurable, see typical pin layout above
#define SS_PIN          D2          // Configurable, see typical pin layout above

MFRC522 mfrc522(SS_PIN, RST_PIN);   // Create MFRC522 instance

void setup() {
  Serial.begin(9600);        // Initialize serial communications with the PC
  SPI.begin();               // Init SPI bus
  mfrc522.PCD_Init();        // Init MFRC522 card
  
}

void loop() {

  // ---------------------- KEY : FFFFFFFFFFFFh at chip delivery from the factory.
  MFRC522::MIFARE_Key key;
  for (byte i = 0; i < 6; i++) key.keyByte[i] = 0xFF;

  // Reset the loop if no new card present on the sensor/reader. This saves the entire process when idle.
  if ( ! mfrc522.PICC_IsNewCardPresent()) {
    return;
  }

  // Select one of the cards
  if ( ! mfrc522.PICC_ReadCardSerial()) {
    return;
  }
  Serial.println(F("\nTulis NIM anda.. "));
  
  Serial.print(F("Card UID: "));    //Dump UID
  for (byte i = 0; i < mfrc522.uid.size; i++) {
    Serial.print(mfrc522.uid.uidByte[i] < 0x10 ? " 0" : " ");
    Serial.print(mfrc522.uid.uidByte[i], HEX);
  }
 
  byte buffer[20];
  byte block;
  MFRC522::StatusCode status;
  byte len;

  Serial.setTimeout(20000L);
  
  Serial.println(F("\nAkhiri dengan tanda bintang"));
  len = Serial.readBytesUntil('*', (char *) buffer, 20) ; // read family name from serial

  if (len <= 16)
  {
    for (byte i = len; i < 16; i++) buffer[i] = ' ';     // pad with spaces
  
    block = 1;
    //Serial.println(F("Authenticating using key A..."));
    status = mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, block, &key, &(mfrc522.uid));
    if (status != MFRC522::STATUS_OK) {
      Serial.print(F("PCD_Authenticate() failed: "));
      Serial.println(mfrc522.GetStatusCodeName(status));
      return;
    }
    else Serial.println(F("PCD_Authenticate() success: "));
    ///////////////////////////////////////////////////////////////////////////////////////////////
    
    // Write block
    status = mfrc522.MIFARE_Write(block, buffer, 16);
    if (status != MFRC522::STATUS_OK) {
      Serial.print(F("MIFARE_Write() failed: "));
      Serial.println(mfrc522.GetStatusCodeName(status));
      return;
    }
    else Serial.println(F("MIFARE_Write() success: "));
    ///////////////////////////////////////////////////////////////////////////////////////////////
  
    Serial.println(" ");
    mfrc522.PICC_HaltA(); // Halt PICC
    mfrc522.PCD_StopCrypto1();  // Stop encryption on PCD 
  }
  else 
  {
    Serial.println("Masukan Terlalu Banyak, Maksimal 16 karakter saja :)");
  }

}
