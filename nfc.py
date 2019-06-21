from smartcard.System import readers
from smartcard.util import toHexString
from smartcard.ATR import ATR
from smartcard.CardType import AnyCardType
import sys
import winreg as reg
import os


def AddToRegistry():
    path = os.path.dirname(os.path.realpath(__file__))
    scriptName = "nfc.py"
    address = os.path.join(path, scriptName)
    key = reg.HKEY_CURRENT_USER
    keyValue = "Software\Microsoft\Windows\CurrentVersion\Run"
    open = reg.OpenKey(key, keyValue, 0, reg.KEY_ALL_ACCESS)
    reg.SetValueEx(open, "any_name", 0, reg.REG_SZ, address)
    reg.CloseKey(open)


def mainProg():
	

while True:
    if __name__ == "__main__":
        AddToRegistry()
        mainProg()

