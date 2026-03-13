#Deploy a DApp with User Interface (UI).
Step 1: Environment & Blockchain SetupStart Ganache: Open Ganache and click Quickstart. Note the RPC Server address (e.g., 127.0.0.1:7545).MetaMask Connection:Open MetaMask and Add a custom network.Set the RPC URL to http://127.0.0.1:7545 and Chain ID to 1337 (or 5777).Import Wallet: * In Ganache, click the Key Icon for an account to see the Private Key.In MetaMask, click Import Account and paste that key string to load your test ETH.

Step 2: Project CodesCreate a folder named Blockchain and add these files.

1. Smart Contract (contracts/Add.sol)
Solidity
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

contract Add {
    function add(uint a, uint b) public pure returns (uint) {
        return a + b;
    }
}


2. Deployment Script (migrations/1_deploy.js)
JavaScript
const Add = artifacts.require("Add");

module.exports = function (deployer) {
  deployer.deploy(Add);
};

3. Frontend Interface (index.html)Place this in your main project folder.Note: Update the contractAddress with the one generated after your migration.HTML<!DOCTYPE html>
<html>
<head>
    <title>Blockchain Adder</title>
    <script src="https://cdn.jsdelivr.net/npm/ethers@5.7.2/dist/ethers.min.js"></script>
</head>
<body>
    <h2>Smart Contract Addition</h2>
    <input type="number" id="num1" placeholder="Enter first number">
    <input type="number" id="num2" placeholder="Enter second number">
    <button onclick="connectAndAdd()">Add</button>
    <h3>Result: <span id="result">-</span></h3>

    <script>
        let contract;
        // PASTE YOUR CONTRACT ADDRESS FROM THE TERMINAL HERE
        const contractAddress = "0xc9985C6e9fDA100f8e6BA533D73Ced3ba4307B1e"; 

        const contractABI = [
            {
                "inputs": [
                    { "internalType": "uint256", "name": "a", "type": "uint256" },
                    { "internalType": "uint256", "name": "b", "type": "uint256" }
                ],
                "name": "add",
                "outputs": [{ "internalType": "uint256", "name": "", "type": "uint256" }],
                "stateMutability": "pure",
                "type": "function"
            }
        ];

        async function connectAndAdd() {
            if (typeof window.ethereum === "undefined") {
                alert("Please install MetaMask!");
                return;
            }
            await window.ethereum.request({ method: "eth_requestAccounts" });
            const provider = new ethers.providers.Web3Provider(window.ethereum);
            const signer = provider.getSigner();
            contract = new ethers.Contract(contractAddress, contractABI, signer);

            const a = document.getElementById("num1").value;
            const b = document.getElementById("num2").value;
            try {
                const result = await contract.add(a, b);
                document.getElementById("result").innerText = result.toString();
            } catch (error) {
                console.error(error);
            }
        }
    </script>
</body>
</html>

Configuration: truffle-config.js
module.exports = {
  networks: {
    development: {
      host: "127.0.0.1",
      port: 7545,            // Standard Ganache GUI port
      network_id: "*",       // Match any network id
    },
  },
  compilers: {
    solc: {
      version: "0.8.0",      // Matching the version in your Add.sol
    },
  },
};

Step 3: Execution Commands
Run these in your terminal in order:

Install Lite Server: npm i truffle lite-server.

Compile & Deploy:

npx truffle compile.

npx truffle migrate --reset.

Start UI: npx lite-server.

Quick Execution Steps:Terminal: 
Run npx truffle migrate --reset.
Copy: Find the "contract address" in the terminal and update index.html.
Terminal: Run npx lite-server.
Browser: Go to localhost:3000, click Connect in MetaMask, and enter your numbers.

Step 4: Interacting with the UILaunch: Your browser will open http://localhost:3000.Connect: MetaMask will pop up asking to connect your Imported Account.Calculate: * Enter numbers (e.g., 2 and 2).Click the Add button.The sum will appear instantly next to Result


####
amu Code 
<!doctype html>
<html>
  <head>
    <title>Add Two Numbers using Smart Contract</title>
  </head>
  <body>
    <h2>Addition using Ethereum Smart Contract</h2>

    <input type="number" id="num1" placeholder="Enter first number" />
    <input type="number" id="num2" placeholder="Enter second number" />
    <br /><br />
    <button onclick="addNumbers()">Add using Blockchain</button>

    <h3 id="output"></h3>

    <!-- Web3 -->
    <script src="https://cdn.jsdelivr.net/npm/web3@1.10.0/dist/web3.min.js"></script>

    <script>
      let web3;
      let contract;
      let account;

      // 🔴 PUT YOUR DEPLOYED CONTRACT ADDRESS HERE
      const contractAddress = "PASTE_YOUR_CONTRACT_ADDRESS_HERE";

      // ABI for Add contract
      const abi = [
        {
          inputs: [
            { internalType: "uint256", name: "a", type: "uint256" },
            { internalType: "uint256", name: "b", type: "uint256" },
          ],
          name: "add",
          outputs: [{ internalType: "uint256", name: "", type: "uint256" }],
          stateMutability: "pure",
          type: "function",
        },
      ];

      async function loadWeb3() {
        if (window.ethereum) {
          web3 = new Web3(window.ethereum);
          const accounts = await ethereum.request({
            method: "eth_requestAccounts",
          });
          account = accounts[0];
          contract = new web3.eth.Contract(abi, contractAddress);
        } else {
          alert("MetaMask not detected");
        }
      }

      async function addNumbers() {
        const a = document.getElementById("num1").value;
        const b = document.getElementById("num2").value;

        document.getElementById("output").innerText =
          "Waiting for MetaMask confirmation...";

        // 🔥 SEND TRANSACTION → MetaMask opens → gas shown
        contract.methods
          .add(a, b)
          .send({ from: account })
          .on("receipt", function (receipt) {
            document.getElementById("output").innerText =
              "Transaction successful!\nTx Hash: " + receipt.transactionHash;
          })
          .on("error", function (error) {
            document.getElementById("output").innerText =
              "Transaction failed or rejected";
          });
      }

      loadWeb3();
    </script>
  </body>
</html>