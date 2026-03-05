import RPi.GPIO as GPIO
from time import sleep

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BOARD)

led1 = 29
led2 = 31

GPIO.setup(led1, GPIO.OUT)
GPIO.setup(led2, GPIO.OUT)

while True:
    GPIO.output(led1, True)
    GPIO.output(led2, False)
    sleep(1)

    GPIO.output(led1, False)
    GPIO.output(led2, True)
    sleep(1)