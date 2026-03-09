from pyfingerprint.pyfingerprint import PyFingerprint
import time

try:
    # Initialize fingerprint sensor
    f = PyFingerprint('/dev/ttyUSB0', 57600, 0xFFFFFFFF, 0x00000000)

    # Verify sensor password
    if not f.verifyPassword():
        raise ValueError('The given fingerprint sensor password is wrong!')

    print("Fingerprint sensor initialized successfully")

except Exception as e:
    print("Failed to initialize fingerprint sensor")
    print("Error:", e)
    exit(1)


# Function to enroll new fingerprint
def enroll():

    print("Place finger on sensor...")

    while not f.readImage():
        pass

    f.convertImage(0x01)

    result = f.searchTemplate()

    positionNumber = result[0]

    if positionNumber >= 0:
        print("Fingerprint already exists at position:", positionNumber)
        return

    print("Remove finger...")
    time.sleep(2)

    print("Place the same finger again...")

    while not f.readImage():
        pass

    f.convertImage(0x02)

    if f.compareCharacteristics() == 0:
        print("Fingerprints do not match")
        return

    f.createTemplate()

    positionNumber = f.storeTemplate()

    print("Fingerprint enrolled successfully at position:", positionNumber)


# Function to search fingerprint
def search():

    print("Place finger to search...")

    while not f.readImage():
        pass

    f.convertImage(0x01)

    result = f.searchTemplate()

    positionNumber = result[0]

    if positionNumber >= 0:
        print("Access Granted - ID:", positionNumber)
    else:
        print("Access Denied")


# Main Program Loop
while True:

    choice = input("Enter E (Enroll) / S (Search) / Q (Quit): ").lower()

    if choice == 'q':
        break

    elif choice == 'e':
        enroll()

    elif choice == 's':
        search()