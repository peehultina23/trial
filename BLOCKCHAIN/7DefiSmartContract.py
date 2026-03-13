Practical 7 (in this prac only 1 account needs to be used)

7A
Ethereum in finance (defi)

Create a basic defi application
CREATING A SMART CONTRACT USING ERC (DEFI)

Open Remix IDE → Create new blank workspace (name it "erc")
Create new file → name it Mytoken.sol

CODE FOR MyToken : 

// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

import "@openzeppelin/contracts/token/ERC20/ERC20.sol";

contract MyToken is ERC20 {
    constructor() ERC20("MyToken", "MTK") {
        _mint(msg.sender, 1_000_000 ether);
    }
}

'''Go to Solidity Compiler → Click Compile Mytoken.sol
Go to Deploy & Run Transactions
Make sure Account 1 is selected
Click Deploy
Scroll down in Deployed Contracts → 
click balanceOf → paste Account 1's address → shows big number
Click totalSupply -> should show same big number'''

7B

STAKE AN ETHEREUM USING ADDRESS TOKEN (DEFI)

In the same workspace, create a new file → name it Stake.sol

CODE FOR Stake :

// SPDX-License-Identifier: MIT
pragma solidity ^0.8.20;

import "@openzeppelin/contracts/token/ERC20/IERC20.sol";

contract SimpleStaking {
    IERC20 public token;
    mapping(address => uint256) public stakes;

    constructor(address _token) {
        token = IERC20(_token);
    }

    function stake(uint256 amount) external {
        require(amount > 0, "Zero amount");
        token.transferFrom(msg.sender, address(this), amount);
        stakes[msg.sender] += amount;
    }

    function unstake(uint256 amount) external {
        require(stakes[msg.sender] >= amount, "Not enough stake");
        stakes[msg.sender] -= amount;
        token.transfer(msg.sender, amount);
    }
}

'''Go to Solidity Compiler → Click Compile Stake.sol
Go to Deploy & Run Transactions
Then copy that 99.999 wala account ka address > paste it in _token, which is under deploy and click on transact 

Then scroll down, under SIMPLESTAKING > click on token 

The address there should be the same address which was paster under deploy in _token'''