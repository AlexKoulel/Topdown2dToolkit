# Topdown2DToolkit

A Unity-based toolkit/framework designed to simplify the creation of 2D top-down games, where players can interact with various in-game objects. This toolkit offers essential features such as camera follow, NPC dialogue, scene warping, and item collection, making it easier to develop interactive and dynamic game worlds.

## Features

- **Top-Down Camera Follow**: A smooth and dynamic camera system that follows the player character, ensuring a consistent view of the game world.
- **Player Interaction**: Players can interact with various types of in-game objects:
    - **NPCs**: When the player interacts with an NPC, a dialogue box is displayed, showing custom text that you can configure.
    - **Warps**: Interacting with specific warp objects teleports the player to different scenes within the game, providing fast travel and scene transitions.
    - **Items**: Players can collect items by interacting with them. These items are added to the player's inventory and saved locally in a JSON file.


## Installation

1. Clone the repository to your local machine:

   ```bash
   git clone https://github.com/AlexKoulel/Topdown2DToolKit.git

2. Open Unity Hub and click **Add->Add project from disk**.
3. Navigate to the directory where you cloned the project, select it and open the project.
4. If the project opens in an empty scene, navigate to **Assets -> Scenes -> base-scene** to load the default scene.

## Demo
To see a demonstration of the toolkit in action, try the [exploration game I developed with this framework](https://ottware.itch.io/beyond-lethe).
