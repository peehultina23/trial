// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

contract Donation {
    uint public total;
    function donate() public payable {
        total += msg.value;
    }
    function getBalance() public view returns(uint) {
        return address(this).balance;
    }
}
