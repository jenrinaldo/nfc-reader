from smartcard.System import readers
from smartcard.util import toHexString
from smartcard.ATR import ATR
from smartcard.CardType import AnyCardType
import sys
import clipboard

# get the reader
r = readers()
# if there's no reader(s) available
if len(r) < 1:
	print ("\nError: No readers available!")
	sys.exit()
# select the first reader
reader = r[0]
# connect with the card
connection = reader.createConnection()
connection.connect()
# authenticate and read sector 0
# COMMAND = [0xFF, 0x86, 0x00, 0x00, 0x05, 0x01, 0x00, 0x04, 0x60, 0x00]
# data, sw1, sw2 = connection.transmit(COMMAND)
# read block 0
COMMAND = [0xFF, 0xB0, 0x00, 0x04, 0x04]
data, sw1, sw2 = connection.transmit(COMMAND)
print ("\nNIM : "+ ''.join(chr(i) for i in data))
NIM = ''.join(chr(i) for i in data)
clipboard.copy(NIM)
text = clipboard.paste()