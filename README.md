# THE CUBE

#### Alexander Charlot | 7/03/2025 | V1.0

- The Cube is a representation of 2x2x2 Rubik's cube written in C#.
  - The cube is displayed through ASCII characters on the command line
    - The color of each face is represented by a letter corresponding to the first letter of that color
  - All inputs are taken through the command line.
- The Cube allows the user to make any rotation of the cube.
  - Each rotation is represented in official Rubik's cube notation. (https://myrubik.com/en/notation/2x2x2).
  - In addition to rotations, the user can also spin or roll the cube as a whole.
- The program also contains options to scramble or reset the cube.

  - Scramble makes a series of random rotations that fall within speed cubing regulation.
    - Currently the numbers corresponding to each rotation are outputted to the console so you can follow along on a physical cube if you wish.
  - Reset returns the cube it its original solved state.

- To run the program, input:
  ```
  dotnet run
  ```
  while in the second cube folder <..>\TheCube\TheCube.
