#include <SPI.h>
#include <MFRC522.h>

#define RST_PIN         D1          // Configurable, see typical pin layout above
#define SS_PIN          D2         // Configurable, see typical pin layout above

MFRC522 mfrc522(SS_PIN, RST_PIN);  // Create MFRC522 instance

bool rfid_tag_present_prev = false;
bool rfid_tag_present = false;
int _rfid_error_counter = 0;
bool _tag_found = false;

// Some variabels we need
byte block, len, buffer[18];

// MFR buffer for status code
MFRC522::StatusCode status;

// Buffer for reader mode
String reader_mode;

void authenticate_key() {
    MFRC522::MIFARE_Key key;
    for (byte i = 0; i < 6; i++) {
        key.keyByte[i] = 0xFF;
    }
    status = mfrc522.PCD_Authenticate(MFRC522::PICC_CMD_MF_AUTH_KEY_A, block, &key, &(mfrc522.uid));
}

void read_card() {
    // Set block 1 as default block to read
    block = 1;
    len = 18;
    
    // Authentication
    authenticate_key();
    
    // Authentication status
    if (status != MFRC522::STATUS_OK) {
        Serial.println("Authentication failed!");
    }
        
    // Read the block 1
    status = mfrc522.MIFARE_Read(block, buffer, &len);
    if (status != MFRC522::STATUS_OK) {
        Serial.println("Reading failed!");
        return;
    }
    
    // Print what's inside the block 1
    for (uint8_t i = 0; i < 16; i++) {
        if (buffer[i] != 32)
            Serial.write(buffer[i]);
    }
    mfrc522.PICC_HaltA();
    mfrc522.PCD_StopCrypto1();
    mfrc522.PCD_Reset();
    delay(100);
    mfrc522.PCD_Init();
}

void write_card() {
    Serial.setTimeout(30000L);

    len = Serial.readBytesUntil('*', (char *) buffer, 18);
      if (len <= 16) {
        for (byte i = len; i < 16; i++)
            buffer[i] = ' ';

        // Select default block to be written
        block = 1;
        
        // Authentication
        authenticate_key();

        // Authentication status
        if (status != MFRC522::STATUS_OK) {
            Serial.println("Authentication failed!");
        }

        // Write block
        status = mfrc522.MIFARE_Write(block, buffer, 16);
        
        if (status != MFRC522::STATUS_OK) {
            Serial.print("Write failed!");
            return;
        }
        else {
            Serial.print("Write success!");
        }            
    }
    mfrc522.PICC_HaltA();
    mfrc522.PCD_StopCrypto1();
    mfrc522.PCD_Reset();
    delay(100);
    mfrc522.PCD_Init();
    
}


void setup() {
  Serial.begin(9600);   // Initialize serial communications with the PC
  while (!Serial);    // Do nothing if no serial port is opened (added for Arduinos based on ATMEGA32U4)
  SPI.begin();      // Init SPI bus
  mfrc522.PCD_Init();   // Init MFRC522
}

void loop() {
  rfid_tag_present_prev = rfid_tag_present;

  _rfid_error_counter += 1;
  if(_rfid_error_counter > 2){
    _tag_found = false;
  }

  // Detect Tag without looking for collisions
  byte bufferATQA[2];
  byte bufferSize = sizeof(bufferATQA);

  // Reset baud rates
  mfrc522.PCD_WriteRegister(mfrc522.TxModeReg, 0x00);
  mfrc522.PCD_WriteRegister(mfrc522.RxModeReg, 0x00);
  // Reset ModWidthReg
  mfrc522.PCD_WriteRegister(mfrc522.ModWidthReg, 0x26);

  MFRC522::StatusCode result = mfrc522.PICC_RequestA(bufferATQA, &bufferSize);

  if(result == mfrc522.STATUS_OK){
    if ( ! mfrc522.PICC_ReadCardSerial()) { //Since a PICC placed get Serial and continue   
      return;
    }
    _rfid_error_counter = 0;
    _tag_found = true;        
  }
  
  rfid_tag_present = _tag_found;
  
  // rising edge
  if (rfid_tag_present && !rfid_tag_present_prev){
    if (Serial.available()) {
     reader_mode = Serial.readStringUntil('#');
     if (reader_mode.equals("write") == true) {
      write_card();
      }
    }
    else {
      read_card();
    }

  }
  
  // falling edge
  if (!rfid_tag_present && rfid_tag_present_prev){
    Serial.print("Done");

  }
}
