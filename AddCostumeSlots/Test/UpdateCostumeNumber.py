import sys
sys.path.append("c:\python27\lib")
import struct, binascii

def stringToInt(s):
    current = 0
    for c in s:
        current = (current*256) + ord(c)
    return current

def hexInt(h):
    x = int(h,16)
    if x > 0x7FFFFFFF:
        x -= 0x100000000
    return x

def modifiedCostume(cID, costumeNumber):
    for char in characterParams:
        if char[6] == cID:
            char[7] = costumeNumber;

def getNumber(k):
    numbers = {'mii enemy (brawler)': 62, 'mii enemy (swordsman)': 63, 'mii enemy (gunner)': 64, 'giga mac': 60, 'dr. mario': 36, 'olimar/alph': 26, 'sheik': 17, 'roy': 54, 'yoshi': 7, 'duck hunt': 45, 'bowser jr.': 46, 'pit': 24, 'meta knight': 23, 'cloud': 55, 'mii brawler': 0, 'mii swordsman': 1, 'mii gunner': 2, 'wii fit': 40, 'pac-man': 49, 'game & watch': 19, 'peach': 14, 'R.O.B.': 31, 'megaman': 50, 'fox': 9, 'zelda': 16, 'bayonetta': 56, 'jigglypuff': 35, 'donkey kong': 4, 'shulk': 47, 'ryu': 52, 'toon link': 32, 'sonic': 34, 'mega lucario': 61, 'charizard': 33, 'little mac': 41, 'kirby': 8, 'pikachu': 10, 'villager': 42, 'ness': 13, 'palutena': 43, 'diddy kong': 27, 'mario': 3, 'wario': 22, 'link': 5, 'ike': 29, 'rosalina': 39, 'samus': 6, 'falcon': 12, 'mewtwo': 51, 'lucas': 53, 'ganon': 20, 'giga bowser': 58, 'greninja': 48, 'king dedede': 28, 'dark pit': 38, 'lucina': 37, 'wario man': 59, 'marth': 18, 'zero suit samus': 25, 'bowser': 15, 'corrin': 57, 'lucario': 30, 'luigi': 11, 'robin': 44, 'falco': 21}
    if k[:5] == 'char_':
        return int(k[5:])
    try:
        return numbers[k]
    except KeyError:
        return -1

def saveParam(saveType=0):
    f1 = open('c:/Ilir/Games/WooU/Mod/Title/vol/content/Sm4shBundle/Sm4shExplorer/V0.07.1/AddCostumeSlots/ui_character_db.bin','wb')
    f1.write(binascii.unhexlify('FFFF000000000000'))
    if saveType == 0:
        f1.write(binascii.unhexlify('20'))
        f1.write(((4-len(binascii.unhexlify(hex(characterNumber).lstrip("0x").rstrip("L"))))*chr(0))+binascii.unhexlify(hex(characterNumber).strip("0x").strip("L")))
    for entNum in range(len(characterParams)):
        for valueNum in range(len(characterParams[entNum])):
            f1.write(chr(characterParamType[entNum][valueNum]))
            if characterParamType[entNum][valueNum] == 0x1 or characterParamType[entNum][valueNum] == 0x2:
                f1.write(binascii.unhexlify(hex(characterParams[entNum][valueNum])[2:].zfill(2)))
            if characterParamType[entNum][valueNum] == 0x3 or characterParamType[entNum][valueNum] == 0x4:
                f1.write(((2-len(binascii.unhexlify(hex(characterParams[entNum][valueNum]).lstrip("0x").zfill(4))))*chr(0))+binascii.unhexlify(hex(characterParams[entNum][valueNum]).lstrip("0x").rstrip("L").zfill(8)))
            if characterParamType[entNum][valueNum] == 0x5 or characterParamType[entNum][valueNum] == 0x6:
                f1.write(binascii.unhexlify(('%x' % int(characterParams[entNum][valueNum])).zfill(8)))
            if characterParamType[entNum][valueNum] == 0x7:
                f1.write(binascii.unhexlify("{0:#0{1}x}".format(int(binary(characterParams[entNum][valueNum])),2),10)[2:].zfill(8))
            if characterParamType[entNum][valueNum] == 0x8:
                f1.write(((4-len(binascii.unhexlify(hex(len(characterParams[entNum][valueNum])).lstrip("0x").rstrip("L").zfill(8))))*chr(0))+binascii.unhexlify(hex(len(characterParams[entNum][valueNum])).lstrip("0x").rstrip("L").zfill(8)))
                f1.write(characterParams[entNum][valueNum])

def openParam(fileName):
    f = open(fileName, 'rb')
    print 'fuck'
    f.seek(8)
    fr = ord(f.read(1))
    if fr == 0x20:
        entryNums = stringToInt(f.read(4))
        entries = []
        entryType = []
        temp = ' '
        while temp != '':
            temp = f.read(1)
            if temp != '':
                typeCode = ord(temp)  # typecode
                entryType.append(typeCode)
                if typeCode == 0x1:  # type is 8 bit int (unsigned)
                    entries.append(stringToInt(f.read(1)))
                if typeCode == 0x2:  # type is 8 bit int (signed)
                    entries.append(hexInt(binascii.hexlify(f.read(1))))
                if typeCode == 0x3:  # type is 16 bit int (unsigned)
                    entries.append(stringToInt(f.read(2)))
                if typeCode == 0x4:  # type is 16 bit int (signed)
                    entries.append(hexInt(binascii.hexlify(f.read(2))))
                if typeCode == 0x5:  # type is 32 bit int (unsigned)
                    entries.append(stringToInt(f.read(4)))
                if typeCode == 0x6:  # type is 32 bit int (signed)
                    entries.append(hexInt(binascii.hexlify(f.read(4))))
                if typeCode == 0x7:  # 32 bit float
                    entries.append(struct.unpack('f', f.read(4)))
                if typeCode == 0x8:  # string/string length
                    entries.append(f.read(hexInt(binascii.hexlify(f.read(4)))))
    else:
        entryNums = 1
        entries = []
        entryType = []
        temp = ' '
        skip = True
        while temp != '':
            if not skip:
                temp = f.read(1)
            else:
                temp = ' '
            if temp != '':
                if not skip:
                    typeCode = ord(temp)  # typecode
                else:
                    skip = False
                    typeCode = fr
                entryType.append(typeCode)
                if typeCode == 0x1:  # type is 8 bit int (unsigned)
                    entries.append(stringToInt(f.read(1)))
                if typeCode == 0x2:  # type is 8 bit int (signed)
                    entries.append(hexInt(binascii.hexlify(f.read(1))))
                if typeCode == 0x3:  # type is 16 bit int (unsigned)
                    entries.append(stringToInt(f.read(2)))
                if typeCode == 0x4:  # type is 16 bit int (signed)
                    entries.append(hexInt(binascii.hexlify(f.read(2))))
                if typeCode == 0x5:  # type is 32 bit int (unsigned)
                    entries.append(stringToInt(f.read(4)))
                if typeCode == 0x6:  # type is 32 bit int (signed)
                    entries.append(hexInt(binascii.hexlify(f.read(4))))
                if typeCode == 0x7:  # 32 bit float
                    entries.append(struct.unpack('f', f.read(4)))
                if typeCode == 0x8:  # string/string length
                    entries.append(f.read(hexInt(binascii.hexlify(f.read(4)))))

    group = [entries[i:i + (len(entries) / entryNums)] for i in range(0, len(entries), (len(entries) / entryNums))]
    groupType = [entryType[i:i + (len(entryType) / entryNums)] for i in range(0, len(entryType), (len(entryType) / entryNums))]

    return group, groupType, entryNums

cPath = "",""
try:
    print 'i'
    characterParams, characterParamType, characterNumber = openParam('c:/Ilir/Games/WooU/Mod/Title/vol/content/Sm4shBundle/Sm4shExplorer/V0.07.1/AddCostumeSlots/ui_character_db.bin')
    cPath = 'c:/Ilir/Games/WooU/Mod/Title/vol/content/Sm4shBundle/Sm4shExplorer/V0.07.1/AddCostumeSlots/ui_character_db.bin'
except:
    exit()

print 'w'