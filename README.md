# Sky-Defender
Unity game project for CS50 Games

Sky Defender is a local 2-player competitive 2D platform game, but it was desgined to be a game for multiple players, where the player with the higher score wins the game.

This game was inspired by games such as Super Smash Bros and Fall Guys.

To score the player must collect fruits and gold coins that show up randomly in the scenery. Fruits are worth 10 points and coins 20 points. The player loses points when he/she takes damage or fall from the platform.

Damage could be caused when colliding with enemies who cross the screen or standing close to the bombs when they explode and break down pieces of the platform, taking away 5 points from the player.
When the player falls off the platform he/she loses half of their points and the game ends, showing the winner (or tie, if both players have the same score).

The players are identified by a blue and a green circle, and they have three lives each, represented by three red hearts. The players can move left, right and jump. They can also push each other and kick bombs, which damage opponents if they go through them, before exploding. The items and enemies spawn speed gradually increases during the game.

Characters' scenarios and assets are from Unity's Asset Store. Some images are from opengameart.org. Music and sound effects are from freesound.org.
The only script downloaded was CharacterController2D.cs. Other scripts, animations and game logic were create for this project.
