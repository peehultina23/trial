import binascii
from Crypto.PublicKey import RSA
from Crypto.Cipher import PKCS1_OAEP
from Crypto.Signature import PKCS1_v1_5
from Crypto import Random

class Client:
    def __init__(self):
        random_gen = Random.new().read
        self._private_key = RSA.generate(2048, random_gen)
        self._public_key = self._private_key.publickey()
        self._signer = PKCS1_v1_5.new(self._private_key)

    @property
    def identity(self):
        return binascii.hexlify(
            self._public_key.export_key(format="DER")
        ).decode("ascii")

TYIT = Client()
print("\nPublic key:", TYIT.identity)
