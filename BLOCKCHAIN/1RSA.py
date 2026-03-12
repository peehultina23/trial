#A Simple client class that generates private and public key by using built-in python RSA algorithm and test it.

'''Key generation – public and private
Choose 2 large prime nos P &amp; Q.
Calculate N = P * Q
Select the public key (i.e. the encryption key) E such that is not a factor of (P-1) and (Q-1).'''

from Crypto.PublicKey import RSA
from Crypto.Cipher import PKCS1_OAEP

#generate RSA key pair
key = RSA.generate(2048)

private_key = key
public_key = key.publickey()

#create cipher objects
encryptor = PKCS1_OAEP.new(public_key)
decryptor = PKCS1_OAEP.new(private_key)

#message to encyrpt
message= b"Hello RSA!"

#encrypt 
encrypted = encryptor.encrypt(message)
print("Encrypted", encrypted)

#decrypt
decrypted = decryptor.decrypt(encrypted)
print("Decrypted", decrypted.decode())

#------A Simple client class that generates private ledgers and public key ledgers by using built-in python RSA algorithm and test it.

import binascii
from Crypto.PublicKey import RSA
from Crypto.Signature import PKCS1_v1_5
from Crypto import Random


class Client:
    def __init__(self):
        random = Random.new().read
        self._private_key = RSA.generate(1024, random)
        self._public_key = self._private_key.publickey()
        self.signer = PKCS1_v1_5.new(self._private_key)


    @property
    def identity(self):
        return binascii.hexlify(
            self._public_key.export_key(format="DER")
        ).decode("ascii")


TYSD = Client()
print("\nPublic Key:", TYSD.identity)

#-------RSA using Manual way.

p=3
q=11
n=p*q
phi=(p-1)*(q-1)
e = 7
d = 3

def encrypt(m):
    return(m**e)%n

def decrypt(c):
    return(c**d)%n

message = 4
print("Original message:",message)

encrypted = encrypt(message)
print("Encrypted message:",encrypted)
 
decrypted = decrypt(encrypted)
print("Decrypted message:",decrypted)
