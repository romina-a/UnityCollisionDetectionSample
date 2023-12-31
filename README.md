# Unity Collision Detection Sample

This Unity project provides two scenes, "Physical" and "Kinematic," for comparing collision detection behaviour between non-kinematic Rigid Bodies and Kinematic Rigid Bodies. 

Each scene contains a shape sorting cube and an object that can be placed inside the cube. When a collision with the object is detected, the shape sorting cube changes colour. Users can interact with both the cube and the object by grabbing them using the mouse. The interaction is designed in a way that does not affect the objects' rotation and position along the Z-axis in world space.

## Summary of Observations

| Setting                        | Collision Detection Method      | Pro                             | Con                             |
| ------------------------------ | ------------------------------- | ------------------------------- | ------------------------------- |
| Non-Kinematic Rigid Bodies     | `OnCollisionEnter`              | Accurate Physical Interaction   | Inaccurate Collision Detection  |
| Kinematic Rigid Bodies         | `OnTriggerEnter`                | Accurate Collision Detection    | No physics                      |


**Non-kinematic Collision Detection**

[![Watch the video](https://img.youtube.com/vi/vKjjESzeR_c/0.jpg)](https://youtu.be/vKjjESzeR_c)


**Kinematic Collision Detection**

[![Watch the video](https://img.youtube.com/vi/6WwQa8x1Oys/0.jpg)](https://youtu.be/6WwQa8x1Oys)



## Question

**Why is collision detection not accurate with non-kinematic rigid bodies, and is there a solution to combine accurate physics and accurate collision detection?**

