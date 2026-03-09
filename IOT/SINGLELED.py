import RPi.GPIO as GPIO
from time import sleep

GPIO.setwarnings(False)
GPIO.setmode(GPIO.BOARD)

led = 29

GPIO.setup(led, GPIO.OUT)

while True:
    GPIO.output(led, True)
    sleep(1)
    GPIO.output(led, False)
    sleep(1)