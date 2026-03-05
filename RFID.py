
#TO FIND YOUR CARD ID, RUN THIS CODE AND SCAN YOUR CARD. IT WILL PRINT THE ID IN THE TERMINAL. THEN YOU CAN USE THAT ID IN YOUR MAIN CODE TO CHECK FOR AUTHENTICATION.
import serial
ser = serial.Serial('/dev/serial0', 9600, timeout=1)
print("Scan your card...")
while True:
    data = ser.read(12)
    if data:
        print(data.decode('utf-8').strip())

#MAIN CODE
import serial,time
ser=serial.Serial('/dev/serial0',9600,timeout=1)
AUTHORIZED_CARD="enter_your_card_no"
print("RFID Access System Ready")
print("Tap your card...")
try:
    while True:
        data=ser.read(12)
        if data:
            card_id=data.decode('utf-8').strip()
            print("Card Detected: "+card_id)
            if card_id==AUTHORIZED_CARD:
                print(" Access Granted — Hello!")
            else:
                print(" Access Denied — Nah!")
            time.sleep(1)
except KeyboardInterrupt:
    print("\nExiting program...")
finally:
    ser.close()
