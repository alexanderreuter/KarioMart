# KarioMart
------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## **Author:**
Alexander Reuter

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## **Unity version: 2022.3.9f1**
Additional packages used: 
* Input System
* TextMeshPro

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## **Assets used:**
* Kenny.nl - Racing Pack 2D
https://www.kenney.nl/assets/racing-pack
* Kenny.nl - UI Pack
https://www.kenney.nl/assets/ui-pack

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## **Sources of inspiration:**
* Youtube series: Pretty Fly games - How to create a 2D Arcade Style Top Down Car Controller in Unity
https://www.youtube.com/watch?v=DVHcOS1E5OQ&list=PLyDa4NP_nvPfmvbC-eqyzdhOXeCyhToko
* Unity documentation - https://docs.unity3d.com/Manual/index.html

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## **How the game should work:**
The game is intended to be loaded through scene 0, which is the main menu. From the main menu select one of the three levels to start the game.
Once in a level, press any button one the keyboard to spawn Player 1. If you wish to play the game with 2 players, press any button on a gamepad to spawn Player 2.
When you're ready to start the game, press enter.
When enter is pressed, a countdown starting from 3 (seconds) is initiated. Once the countdown finish, the race and the race timer starts.
To controll player 1, use WASD for movement and space to boost. 
To controll player 2, use left stick pad (gamepad) for movement and south button (gamepad) to boost. 
To pause the game, press escape. 
To quit the game, go back to the main menu using the pause menu, press quit in the main menu.
The race is finished once one of the players has finished the total laps. 
The winner is then displayed and the user is promted to choose the next level or go back to the main menu.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## **Code structure:**
The code for the game is mainly centered around three scrips, RaceManager, CarController and CheckpointManager.
The purpose of the RaceManager is to store all the data about the race. For example, such as if the game is live, finished or is starting. 
Since the RaceManager is responsable for storing data about the race and there only can be one race at the time, a singleton pattern is used. 
This allows all the other classes to easily get access to the race data and also makes sure that there only can be one instance of the RaceManager.
The purpose of the CarController is to store data for the car/player. Here the phyisics for the car is managed and data such as if the car is boosting, etc., is stored here.
Therfore every car has it's own instance of a CarController.
The CarController is also the class responsible for reading the user input.
The CheckpointManager's purpose is to manage the player's location in relation to the map/race. Data such as the current lap, total laps and whenever a player pass a checkpoint, is stored here.
The CheckpointManager is also using action events to invoke/update the UI in relation to the player, such as displaying the current lap and the winner.
Since the CheckpointManager is in relation to a player, a CheckpointManager can't be intialized without a playerID. 
Therfore, whenever a player is spawned, a CheckpointManager is intialized using the spawned player's playerID (this is managed in the PlayerController).
The CheckpointManager is then registerad in a list in the RaceManager, to store every instance of a CheckpointManager in relation to the current race.

------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
## **Some additional information:**
The game is built on using Unity's new input system. 
The PlayerInputManager component is used to controll spawning of every player based on a prefab of every player.
The maps are built using a grid and tile pallets.



