# 480-project-2
Team members: Isabelle Below and Katie Linnenkamp

## 1. Dot product- Katie
  The first part of the dot product element does not actually use a dot product at all. The element is able to tell active distance from the player character, John Lemon, to the exit trigger. This takes the distances on the x, y, z coordinate plane towared the opposite element location and calculates the diagonal straight line distance from the coordinates. It uses m, for meters - its not meters but that is what we are going with, and calculates the new distance whenever the player moves. 
  
  Along with this element, is the dot product element, which focuses more on the exact angle and direction of the exit from the player. Initially I had the arrow correspond with the players direction, which was much more dramatic for a 3rd player game that does not change camera angles, but I wanted the arrow to only point at the exit from the perspective of the camera. This ended up being a lot more subtle because the exit always stays to the right of the player/map. It uses the dot product to calculate the exact angle of the players position (not facing direction) to the exit location and gives a fluid moving arrow to that exact angle. The function is best seen when you are near the exit and walk down the long aisle that runs parallel (up and down) to the exit. It shows the subtle movements of the arrow that the dot product calculates.

## 2. Linear Interpolation


## 3. Particles- Isabelle
  When caught by a gargoyle or ghost, the player disappears and a particle effect plays. This was accomplished by altering the GameEnding script. First, the player's movement is disabled, then the SkinnedMeshRenderer is disabled to make the player disappear, then the death particles play, and the walking sound effect stops. All of these things were accomplished by creating new public variables and linking the appropriate assets to them. To prevent the ending screen from playing immediately, I also had to add a timer. This makes the end screen play after 1 second.

## 4. Sound Effects

