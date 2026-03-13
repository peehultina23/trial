'''Practical 6 

 AIM : Smart contract solidity basics, writing and deploying

smart contracts
On google > search “remix side” > select on the first link that comes > select this : Remix Online IDE, see: https://remix.ethereum.org  

Create new workspace on the right > on the left > select the files icon which is the file explorer > create > new file : tytoken 

CODE for tytoken : '''

// SPDX-License-Identifier: MIT
pragma solidity ^0.8.31;


contract tytoken {
    string public name = "tyToken";
    string public symbol = "TYSD";
    uint256 public totalSupply;
    mapping(address => uint256) public balanceOf;

    constructor(uint256 initialSupply) {
        totalSupply = initialSupply;
        balanceOf[msg.sender] = initialSupply;

    }

    function transfer(address toWhom, uint256 value) public 
    returns(bool success) {
        require(balanceOf[msg.sender] >= value, "Insufficient Balance");
        balanceOf[msg.sender] -= value;
        balanceOf[toWhom] += value;
        return true;

    }

    
}

'''On the left > in solidity compiler > compile > then right below that go to deploy > in accounts > select the first account > Deploy : 1000000 > click on deploy > now in accounts > select the second account and just copy it > switch back to the first account we just deployed and scroll down > in deployed contracts in transfer function > paste account 2 and put value : 20000 > click on transact > paste account 1 in balanceOf and call it 

Output should be : uint256 980000'''