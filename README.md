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

## Final Submission Devlog
### Question 1
The core gameplay loop of Hidden in Heaven involves obtaining resources to help fend off an invasive and foreign robotic creature. The player will collect ammo to slow down the monster, find heals to manage HP, and find notes with lazy writing that explain some of the lore of the world. The player will also trigger certain set pieces that replicate some of the scripted sequences found in horror games or single player experiences in general. This gameplay and content illustrates what a full game would look like by using common survival horror tropes such as resource management, along with curated set pieces, to create exciting sequences throughout a full-length experience. During downtime, players will feel the pressure to stock up on resources in order to be able to handle the upcoming challenges.


### Question 2
<img width="950" height="470" alt="Screenshot 2026-06-11 104018" src="https://github.com/user-attachments/assets/35beecfd-b96c-4423-9337-b5b0338fee1f" />
<img width="878" height="582" alt="Screenshot 2026-06-11 104041" src="https://github.com/user-attachments/assets/7285ca44-c3df-4320-96b0-987db22b86bc" />
<img width="1564" height="941" alt="Screenshot 2026-06-11 104157" src="https://github.com/user-attachments/assets/22e89882-0c0d-49f2-b609-b297fa56dd69" />

In unity, my rendering effect is applied whenever the player takes damage. Whenever the player takes damage, a coroutine starts that sets the intensity and power properties of the effect to 0.75, before decreasing it back down to zero over time. Because I use a multiply node, when the value of intensity is 0, the vignette is active (in unity), and as the intensity increases, the more prominent the blood effect is.


### Question 3
#### My Plan
Brainstorm a unique idea (something has to set it apart, it can’t just be my version of another game)
Find what mechanics will make this game fun or contribute to the artistic theme and meaning (can be just one or both)
Breakdown these mechanics into systems using a bubble diagram with technical terms
Check these systems for scalability, optimize time and effort by ensuring that each system once made can be easily re-implemented
First focus on core systems, health, combat, etc
Second playtest for enjoyability, choose people both in and out of your target audience, understand that, regarding criticism, 1: your game can be bad or 2: they just don’t get what you’re trying to do
Third focus on level design, create intentionally intuitive or unintuitive levels to invoke the intended emotions within the player. Be very particular with sightlines, item placement, enemy placement, etc. This is where scalability becomes super helpful, because now I can use my core systems and mold them to fit the aesthetic of a level
Fourth playtest again, this time focusing on level design, do players consistently behave the same way and is it in the way you intend them to.
When trying to break down a project into specific systems I think about scalability. I would use the bubble diagram breakdowns and note which systems can be turned into a singleton, or will be a parent/child to another system, in order to create a quality foundation, not just in content, but to be built upon later in development. In Hidden in Heaven, I found that using singletons was very helpful for my GameController and my Inventory systems. I was able to easily access these instances from any script, which made the resource management system simple to implement, and creating set pieces very versatile. By breaking down these two systems using a bubble chart, I was able to identify that using a singleton would be the best plan of action, in order to connect all of the game’s other systems back to them. By breaking down my project into smaller pieces I can better understand the scope of my project because I have recognized how time consuming game design is. Throughout this year we would spend an entire week learning and implementing a system into a minigame. By breaking down my game using a bubble diagram, I could point to each of those systems and recognize that each acted like a minigame assignment that I would have to complete in order to finish this vertical slice. With this in mind, and not wanting to make ten minigames, I was able to properly scale my vertical slice. 



