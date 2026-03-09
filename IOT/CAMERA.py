from picamera import PiCamera
import datetime
import os

# Create folder to save images
os.makedirs('/home/pi/images', exist_ok=True)

camera = PiCamera()
camera.resolution = (1024, 768)

# Capture image with timestamp
camera.capture("/home/pi/images/image_{}.jpg".format(
datetime.datetime.now().strftime("%Y%m%d_%H%M%S")
))

print("Image Captured Successfully")