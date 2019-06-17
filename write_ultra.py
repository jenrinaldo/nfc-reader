from smartcard.System import readers
from smartcard.util import toHexString
from smartcard.ATR import ATR
from smartcard.CardType import AnyCardType
from itertools import islice 
import sys

r = readers()
reader = r[0]
connection = reader.createConnection()
connection.connect()

masukan = list(input("Input NIM : "))
x = len(masukan)
bfr = [" "]

if x <= 16:
    for y in range (16-x):
        masukan.extend(bfr)
    splitted = [masukan[i * 4:(i + 1) * 4] for i in range((len(masukan) + 4 - 1) // 4 )]
else :
    print ("Input Terlalu Banyak!")
    
for page in range(4, 8):
    COMMAND = [0xFF, 0xD6, 0x00, page, 0x04]
    COMMAND.extend([ord(c) for c in splitted[page - 4]])
    data, sw1, sw2 = connection.transmit(COMMAND)
print ("Status words: %02X %02X" % (sw1, sw2))
if (sw1, sw2) == (0x90, 0x0):
    print ("Status: Key is loaded successfully to key #0.")
elif (sw1, sw2) == (0x63, 0x0):
    print ("Status: Failed to load key.")    