#include <MFRC522.h>
#include <SPI.h>

#define RST_PIN D1
#define SS_PIN  D2

// Create MFRC522 instance
MFRC522 mfrc522(SS_PIN, RST_PIN);  

// Some variabels we need
byte block, len, buffer[18];

// MFR buffer for status code
MFRC522::StatusCode status;

// Buffer for reader mode
String reader_mode;

void setup() {
    Serial.begin(9600);   // Initialize serial communications with the PC
    SPI.begin();          // Init SPI bus
    mfrc522.PCD_Init();   // Init MFRC522 card
}

void loop() {
    // Reset the loop if no new card present on the sensor/reader. This saves the entire process when idle
    if ( ! mfrc522.PICC_IsNewCardPresent()) {
        return;
    }
    
    // Select one of the cards
    if ( ! mfrc522.PICC_ReadCardSerial()) {
        return;
    }
  
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

        exit_card();
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
     exit_card();
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
    
           exit_card();
        }

        // Write block
        status = mfrc522.MIFARE_Write(block, buffer, 16);
        if (status != MFRC522::STATUS_OK) {
            Serial.print("Write failed!");
            return;
        }
        else {
            Serial.print("Write success!");
            exit_card();
        }            
    }
}

void exit_card() {
    // End
    Serial.print(" ");
    // Delay for changing card(s)
    delay(1000);
        
    // Stop reading the card
    mfrc522.PICC_HaltA();
    mfrc522.PCD_StopCrypto1();
}
