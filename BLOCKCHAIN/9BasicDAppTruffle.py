# Interaction with smart contract and web 3

'''Steps
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
