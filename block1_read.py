from smartcard.System import readers
from smartcard.util import toHexString
from smartcard.ATR import ATR
from smartcard.CardType import AnyCardType
import sys


r = readers()
reader = r[0]
connection = reader.createConnection()
connection.connect()


COMMAND = [0xFF, 0x86, 0x00, 0x00, 0x05, 0x01, 0x00, 0x01, 0x60, 0x00] ## Otentikasi
																	   ## [ FF, 86, 00, 00, 05, 01, 00, Block_Number, Type_Key, 00]
																	   ## Type_Key = 60->A, 61->B
data, sw1, sw2 = connection.transmit(COMMAND)

COMMAND = [0xFF, 0xB0, 0x00, 0x01, 0x10]## Read [ FF, B0, 00, Block_Number, Read_Byte ]
										## Read Byte = 16byte-> 10, 4byte->4=04
data, sw1, sw2 = connection.transmit(COMMAND)
print (''.join(chr(i) for i in data))