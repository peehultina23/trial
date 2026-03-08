from time import sleep
import tm1637

try:
    import thread
except ImportError:
    import _thread as thread

# Initialize Display
Display = tm1637.TM1637(CLK=21, DIO=20, brightness=1.0)

try:
    print("Starting clock in the background (press CTRL + C to stop):")

    Display.StartClock(military_time=True)
    sleep(1)

    Display.ShowDoublepoint(False)
    sleep(5)

    Display.StopClock()

except KeyboardInterrupt:
    Display.cleanup()
    
    
    
import time
import tm1637

# Initialize Display
Display = tm1637.TM1637(clk=21, dio=20)

try:
    print("Starting clock (press CTRL + C to stop):")
    while True:
        current_time = time.localtime()
        hours = current_time.tm_hour
        minutes = current_time.tm_min
        Display.numbers(hours, minutes)
        time.sleep(1)
except KeyboardInterrupt:
    Display.clear()