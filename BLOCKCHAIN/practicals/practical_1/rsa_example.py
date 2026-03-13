from Crypto.PublicKey import RSA
from Crypto.Cipher import PKCS1_OAEP

# Generate RSA key pair
key = RSA.generate(2048)

private_key = key
public_key = key.publickey()

# Create cipher objects
encryptor = PKCS1_OAEP.new(public_key)
decryptor = PKCS1_OAEP.new(private_key)

# Message to encrypt
message = b"hello RSA!"

# Encrypt
encrypted = encryptor.encrypt(message)
print("encrypted:", encrypted)

# Decrypt
decrypted = decryptor.decrypt(encrypted)
print("decrypted:", decrypted.decode())
