// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;
contract PiggyBank {
    function deposit() public payable {}
    function getBalance() public view returns(uint) {
        return address(this).balance;
    }
    function withdraw() public {
        (bool success, ) = payable(msg.sender).call{value: address(this).balance}("");
        require(success, "Failed");
    }
}
