# GDIM33 Vertical Slice
## Milestone 1 Devlog
The visual scripting graph I used in this game so far was the VSPlayer graph, which acts as a movement controller for the player. The graph uses InputGetAxis as well as TransformTranslate to align the axis of movement with the intended direction in which the player is moving. Furthermore, I also use the VSPlayer graph to link to the state machine. When the player holds down the right click button, the PlayerStateMachine will respond to the player input and adjust based on the logic within the state machine.
<img width="2166" height="1167" alt="image" src="https://github.com/user-attachments/assets/ffa999d8-446a-4eea-be24-41f277f75820" />
On the right I added in the state machine, with the individual states and transitions based on the player actions. When the player holds right click, the camera FOV will decrease, the player speed decreases, and the player gains the ability to fire shots. When the player releases right click, FOV and speed return to normal, and the player can no longer shoot their pistol. I also removed much of what was in the Gun node because much of it was divided between the Gun and the state machine.

## Milestone 2 Devlog
Milestone 2 Devlog goes here.
## Milestone 3 Devlog
Milestone 3 Devlog goes here.
## Milestone 4 Devlog
Milestone 4 Devlog goes here.
## Final Devlog
Final Devlog goes here.
## Open-source assets
- Cite any external assets used here!
