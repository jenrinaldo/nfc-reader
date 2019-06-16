from smartcard.System import readers
from smartcard.util import toHexString
from smartcard.ATR import ATR
from smartcard.CardType import AnyCardType
import sys


r = readers()
reader = r[0]
connection = reader.createConnection()
connection.connect()


COMMAND = [0xFF, 0x86, 0x00, 0x00, 0x05, 0x01, 0x00, int(sys.argv[2]), 0x60, 0x00]
data, sw1, sw2 = connection.transmit(COMMAND)
if (sw1, sw2) == (0x90, 0x0):
    print ("Status: Decryption all sector using key #0 as Key A successful.")
masukan = raw_input("Masukan inputan : ")
x = len(masukan)
bfr = [" "]
COMMAND = [0xFF, 0xD6, 0x00, int(sys.argv[2]), 0x10]

if x <= 16:
    COMMAND.extend([ord(c) for c in masukan])
    for y in range (16-x):
        COMMAND.extend([ord(c) for c in bfr])
    data, sw1, sw2 = connection.transmit(COMMAND)
    print ("Status words: %02X %02X" % (sw1, sw2))
    if (sw1, sw2) == (0x90, 0x0):
        print ("Status: Key is loaded successfully to key #0.")
    elif (sw1, sw2) == (0x63, 0x0):
        print ("Status: Failed to load key.")
        
elif x == 16:
    COMMAND.extend([ord(c) for c in masukan])
    data, sw1, sw2 = connection.transmit(COMMAND)
    print ("Status words: %02X %02X" % (sw1, sw2))
    if (sw1, sw2) == (0x90, 0x0):
        print ("Status: Key is loaded successfully to key #0.")
    elif (sw1, sw2) == (0x63, 0x0):
        print ("Status: Failed to load key.")
    
else :
	print ("masukan Terlalu Banyak")