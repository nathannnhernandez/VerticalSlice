# GDIM33 Vertical Slice
## Milestone 1 Devlog
The visual scripting graph I used in this game so far was the VSPlayer graph, which acts as a movement controller for the player. The graph uses InputGetAxis as well as TransformTranslate to align the axis of movement with the intended direction in which the player is moving. Furthermore, I also use the VSPlayer graph to link to the state machine. When the player holds down the right click button, the EnterADS event fires, triggering a transition into the ADS state, which will adjust the camera fov and limit movement speed. Upon releasing the right click button, the opposite will occur, and the player will return to full FOV and movement.
## Milestone 2 Devlog
### Complicating Gameplay Feature: Dynamic Aggression (Note: I changed this system from a simple rage system that builds with damage to a game controller that creates set pieces, creating more intense moments for the player because I thought it would be a more exciting take on my initial idea.)
### Create a NavMesh and NavMeshAgent system that allows the monster and player to interact with each other and enter combat sequences
Create/Bake navmesh and attach agent to monster

Refer to agent.speed in code in order to create a combat system centered around managing distance rather than dealing damage

From the blick script, decrease the agent.speed for every shot the player lands
### Create a game controller that handles setpieces, observing the actions of the player, and handling the response of the monster
Create serialized fields for key game objects like the monster and the player to later be referred to

Make the game controller a singleton

Create an unorthodox organization style that breaks the code into set pieces (rather than assigning EVERY variable at the top and creating EVERY method at the bottom) which will be more convenient for scalability
### Create the first set piece
Create an ammo pickup (including the inventory and consumable systems that come with it)

Place the monster around the corner from the player

Use gameobject.setactive to put the monster in the scene, setting it to true when the player picks up the ammo
(I haven’t done this yet) play scary sound upon monster spawn

### Other Answers
2. Yes it did help me build my complicating feature for a few reasons. First, I thought my initial idea was pretty lame, and this activity allowed me to readjust my scope. Second, part of the process for creating my complicating feature was creating a NavMesh, which I did in class during the W5 activity, kickstarting the development for my complicating feature. If I were to do them again I would focus on making each small step very simple. I would rather have a lot of simple steps than a few complex steps.

3. I bridged visual coding and C# in this milestone through my cross hair UI element. When the player is in the ADS state, the crosshair UI element is instantiated on screen, and when they enter movement, the UI element is destroyed. I made this work by creating a C# script that created and destroyed the UI element, but because my player controller existed in visual scripting, I had to reference these methods in my player state machine, where, upon transition, I would reference the crosshair script using a graph variable, then connect it to a node which called the relevant method.

4. The required method I chose to implement was NavMesh. The monster should roam and track down the player. When in the free roam state, it moves a bit slow, whereas in the aggravated state, it chases the player at the same speed. While the NavMesh fully functions, I don’t have the monster prefab properly animated yet so he kinda just swims along the floor.

## Milestone 3 Devlog
### Shader Graph
<img width="789" height="703" alt="image" src="https://github.com/user-attachments/assets/15b14592-c34a-4db2-929e-2b9306dab888" />

1. My shader graph works by using a node called tiling and offset to create a vignette around the perimiter of the screen. There are a few parameters, including color is a multiplicand in a series of multiplication nodes. This series combines color, intesity, and power to control the prominance of the vignette. In unity, the shader graph is referenced through c#, changing the _ScreenIntensity parameter whenever the player takes damage.   
#### Side note: For some reason this works in Unity but not in the itch build, but for this milestones purposes, the vignette is in place
2. I improved the gameplay of my game based on playtesting by adjusting my level to direct the player and improve sequencing. Now the player will not be able to leave the first area until they have picked up the ammo, by using a gate prefab. If the player goes left and picks up the heals before the ammo, they won't be able to leave that area until the ammo is picked up. Once the ammo is picked up, the monster will come around the corner and the player will have to escape it.
3. Since the last milestone, I fully animated and the monster which now has multiple movement animations, and attack animation, and a stumble animation if the player shoots the monster three times consecutively. I added a fog particle effect which still needs a bit of work. I incorporated the required vfx and shader graph. I added recoil animations for the gun, and I tweaked some of the buildings within the level. 

