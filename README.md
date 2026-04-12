# 480-project-2
Team members: Isabelle Below and Katie Linnenkamp

##1. Dot product


##2. Linear Interpolation


##3. Particles
  When caught by a gargoyle or ghost, the player disappears and a particle effect plays. This was accomplished by altering the GameEnding script. First, the player's movement is disabled, then the SkinnedMeshRenderer is disabled to make the player disappear, then the death particles play, and the walking sound effect stops. All of these things were accomplished by creating new public variables and linking the appropriate assets to them. To prevent the ending screen from playing immediately, I also had to add a timer. This makes the end screen play after 1 second.

##4. Sound Effects

