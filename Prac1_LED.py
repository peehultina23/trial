import RPi.GPIO as GPIO
from time import sleep

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BOARD)
led1 = 29
led2 = 31
led3 = 33
led4 = 35

GPIO.setup(led1, GPIO.OUT)
GPIO.setup(led2, GPIO.OUT)
GPIO.setup(led3, GPIO.OUT)  
GPIO.setup(led4, GPIO.OUT)

GPIO.output(led1, False)
GPIO.output(led2, False)
GPIO.output(led3, False)
GPIO.output(led4, False)

def ledpattern(v1, v2, v3, v4):
    GPIO.output(led1, v1)
    GPIO.output(led2, v2)
    GPIO.output(led3, v3)
    GPIO.output(led4, v4)

try:
    while True:
        for _ in range(5):
            ledpattern(1, 0, 0, 0)
            sleep(0.5)
            ledpattern(0, 1, 0, 0)
            sleep(0.5)
            ledpattern(0, 0, 1, 0)
            sleep(0.5)
            ledpattern(0, 0, 0, 1)
            sleep(0.5)
finally:
    GPIO.output(led1, False)
    GPIO.output(led2, False)
    GPIO.output(led3, False)
    GPIO.output(led4, False)
    GPIO.cleanup()
