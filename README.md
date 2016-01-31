# Computer
A Von Neumann-esque Computer simulator implementation.

### Computer
All computer simulator functionality is included in the Computer project. Computer builds a class library (.dll), so it can be used in other languages, e.g. Ruby, via COM.
##### Assumptions
This implementation of the computer simulator makes the following assumptions:
- Op-codes are 64-bit unsigned integers where the high-order 32-bits represent the instruction and the lower-order 32-bits represent the instruction operand (if present).
- Instruction operands are 32-bit signed integers.
- Doesn't care about overflow from arithmetic operations (similar to x86's `imul` instruction).

### Computer.Tests
This project contains unit tests for computer components.

### Driver
Driver is a test program that uses the Computer library.
