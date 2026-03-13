# Calculate number of bitcoins

# input values
investment = float(input("Enter your investment amount: "))
btc_price = float(input("Enter the current price of 1 BTC: "))

# Calculation
btc_amount = investment / btc_price

# output
print(f"You will get {btc_amount:.8f}BTC")
