## Project Name: *Pro Driver*
This is my first personal project developed with the Unity 3D Engine. It is a simple driving game where the player will try to reach the goal without hitting the obstacles on the route. 
# Project Member: 
* **Edward Ou** : Project Design, Coding, Scene Design

# Project Components
* [x] Menu Scene
  - [x] Start Button - Connected with the main game scene
  - [x] High Score Button - Connected with the high score scene where a list of the players' score will be displayed
  - [x] Quit Button - Exit the game when clicked
* [ ] High Score Scene
  - [x] Title
  - [x] Display one player with the highest score (Temporary)
  - [ ] Display history scores
* [x] Game Manager
  - [x]  Pass player name from menu scene to main game scene
  - [x]  Keep a copy of the highest score in all games and the corresponding player name
  - [x]  Save a single highest score and the corresponding player name to a json file
  - [x]  Load a single highest score and the corresponding player name from a json file
* [x] Main game scene
  - [x] Building the race track
    - [x] Ground
    - [x] Side Walls - Left, right, and end of track
    - [x] Goal - Goal line, Two Pillars, Goal Sign
  - [x] Player Control
    - [x] Move forward/backward
    - [x] Turn left/right
    - [x] Speed control
    - [x] Disable player control when game is over
  - [x] Deduct player's score when hit an obstacle
  - [x] Sound effects when the player hit an obstacle
  - [x] Particle effect when the player hit a special kind of obstacle
  - [x] Display current speed when game is not over
  - [x] Display current score
  - [x] Display the name of current player
  - [x] Display the highest score of all players
  - [x] Display message when game is end : Game Over when the player fails and Congratulations when the player succeeds
