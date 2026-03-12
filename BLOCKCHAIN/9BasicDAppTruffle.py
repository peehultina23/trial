# Interaction with smart contract and web 3
'''Prac 9 -

Interaction with smart contract and Web 3

STEPS:

Open ganache > quickstart

Metamask > networks > add a custom network

1.Network Name-Localhost 8545
2. Default RPC URL -take rpc url from ganache(rpc server copy paste) 
And add name ganache
3.Chain ID- 1337
4.Currency symbol-ETH
 
Save it.

Click on add wallet > import an account.
Go to any address in ganache > click on its key icon > copy the private key.
Paste the private key in add wallet. > And import. > Switch to this imported wallet.

Go to control panel > programs and features > check node.js version. (uninstall if not 16)
Version should be 16. Go to official node.js site and download 16. Version in .msi 
Set up node.js and install checking all the boxes and agreements. Finish the installation.

Next create a folder called blockchain and open it in VS code.
VS Code > Open New terminal > start typing command:
npm init -y
npm install -g truffle
npm install truffle lite-server
npx truffle init

Next in your vs code folder blockchain> go to folder- contracts > create file add.sol
add.sol:
// SPDX-License-Identifier: MIT
pragma solidity ^0.8.0;

contract Add{
    function add(uint a, uint b) public pure returns (uint)
    {
        return a+b;
    }
}

Then in your folder migrations > create file 1_deploy.js

1_deploy.js:
const Add = artifacts.require("Add");


module.exports = function (deployer) {
  deployer.deploy(Add);
};

Then go to your file truffle-config.js
Around line 60 copy paste this for networks :
  networks: {
    // Useful for testing. The `development` name is special - truffle uses it by default
    // if it's defined here and no other network is specified at the command line.
    // You should run a client (like ganache, geth, or parity) in a separate terminal
    // tab if you use this network and you must also set the `host`, `port` and `network_id`
    // options below to some value.
    //
    development: {
    host: "127.0.0.1",     // Localhost (default: none)
    port: 7545,            // Standard Ethereum port (default: none)
    network_id: "*",       // Any network (default: none)
    },


And around line 107 change:
compilers: {
    solc: {
      version: "0.8.0",      // Fetch exact version from solc-bin (default: truffle's version)
      // docker: true,


Then in yout terminal write commands:
npx truffle compile --all
(Should show compiles contract successfully)
npx truffle migrate --reset
(Should show the 1_deploy.js file getting deployed and a contract address- thats the output.
ACCOUNT should be the one which you imported in metamask)
Then go to metamask > your imported account > some 0.01 eth should be deducted.'''

_______

'''Summary Steps
>Login to Metamask
>Start Ganach> quick start
>In metamask> Custom Network> Add RPC Host address & Local Address name
>Import Wallet
>add address/private key from ganache > import

> Uninstall node js 24
> install node 16.20.2
>open vscode > a newfolder “Blockchain”
>cmd 
Npm init -y
Npm i -g truffle
Npm i truffle lite-server
>changes in version and rpc port address
Npx truffle init
Npx truffle compile  –-all
Npx truffle migrate –reset

>Blockchain Folder> contracts> create 2 file named - 1_deploy.js & Add.sol'''

#1_deploy.js 
const Add = artifacts.require("Add");


module.exports = function (deployer) {
  deployer.deploy(Add);
};

#Add.sol
// SPDX-License-Identifier: MIT

pragma solidity ^0.8.0;

contract Add {
    function add(uint a, uint b) public pure returns (uint) {
        return a + b;
    }
}
