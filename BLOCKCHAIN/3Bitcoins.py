#Finding Number of Bitcoins by applying the equation over a defined value.

#No. of btc = amt in inr / price of 1 btc in inr

investment = float(input("Enter the initial investment amount: "))
btc_price = float(input("Enter the current price of Bitcoin (BTC): "))

btc_amount = investment / btc_price
print(f"You will get {btc_amount:.8f} BTC")

#------A transaction class to send and receive money and test it.

'''> ACCOUNT CREATE
> USE DEPOSIT = SELFBAL + AMT
> USE WITHDRAW = SELFBAL - AMT
> ENQUIRY
'''
class BankAccount:
    def __init__(self, account_holder, initial_balance=0):
        self.account_holder = account_holder
        self.balance = initial_balance

    def deposit(self, amount):
        if amount > 0:
            self.balance += amount
            print(f"Deposited: ${amount:.2f}")
        else:
            print("Deposit amount must be positive.")

    def withdraw(self, amount):
        if 0 < amount <= self.balance:
            self.balance -= amount
            print(f"Withdrew: ${amount:.2f}")
        else:
            print("Insufficient funds or invalid withdrawal amount.")

def enquiry(account):
    print(f"Account Holder: {account.account_holder}")
    print(f"Current Balance: ${account.balance:.2f}")

# Example usage
account = BankAccount("Peehul", 1000)
account.deposit(500)
account.withdraw(200)
enquiry(account)

