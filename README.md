# Il Labirinto di Brodmann

## Description

"Il Labirinto di Brodmann" is an immersive puzzle-horror experience developed for the Meta Quest 2 virtual reality platform. The user finds themselves trapped in a surreal maze shaped like a human brain and must find their way out.

This project was created with the goal of analyzing and defining an efficient, optimized development pipeline for VR applications on mobile hardware. The entire workflow is based on the integration of three key tools: Blender for 3D modeling, Unity as the game engine, and the Meta XR ecosystem for real-time development and testing.

The application fully leverages the immersive potential of VR to create an intense gaming experience, optimized for the hardware limitations of the headset and designed to prevent motion sickness.

![Opening Scene](Images/scene.png)

## Game Concept
The user is trapped in a brain-shaped maze, and the goal is to find a way out. The layout of the areas and the placement of events have been designed to reflect specific cognitive functions, making the experience not only frightening but also conceptually coherent.
*   Fear and Anxiety: Associated with the area representing the amygdala.
*   Disorientation: Located in zones corresponding to the parietal lobe.

Virtual reality is fundamental for the effectiveness of the concept, amplifying the feeling of claustrophobia and the impact of horror elements.
<p align="center"> <img src="Images/brain_sx.png" alt="Left Hemisphere Maze" width="50%"> </p>

## Technical Features

### Development Workflow
The project follows an optimized pipeline to ensure high performance on Meta Quest 2:
1.  3D Modeling (Blender): Creation of low-poly assets to reduce computational load.

2. Texturing and Baking (Blender): Use of baking techniques to “bake” lighting and detail into textures. This allows the use of Unlit materials in Unity, reducing real-time rendering costs.

3.  Assembly and Logic (Unity):
    *   Use of the Universal Render Pipeline (URP), optimized for multi-platform graphics and VR rendering.
    *   Integration of the Meta XR SDK (Core, Interaction, and Audio) to manage tracking, interactions, and spatial audio.

4.  Testing and Deployment:
     *   Meta Quest Link for rapid prototyping and real-time testing from the editor.
     *   Meta Quest Developer Hub (MQDH) for deploying .apk builds and monitoring performance directly on the headset.


### Implemented Optimizations
*   Low-Poly Modeling: Keeping a low polygon count for each model.
*   Texture Baking: Global illumination, shadows, and details are precomputed and saved in a single texture map, drastically reducing GPU load.
*   Level of Detail (LOD): Object complexity is dynamically reduced based on their distance from the camera.
*   Optimized URP Materials: Use of Unlit and Lit URP materials, disabling the most performance-heavy graphical features.

## VR Features
The experience is built around VR mechanics to maximize immersion.

### Navigation
*   To reduce the risk of motion sickness, two locomotion modes have been implemented:
*   Teleportation: Allows instant movement by pointing at a destination. This is the most comfortable solution to prevent motion sickness.
*   Continuous Movement (Smooth Locomotion): Provides a smoother and more immersive experience, controlled via the controller’s analog stick.

### Interaction
*   The user can interact with the surrounding environment in two ways:
*   Direct Interaction: Grabbing and manipulating nearby objects.
*   Ray Interaction: Using a ray projected from the controller to activate objects at a distance, such as opening a chest.

![Interactable Asset](Images/treasure.png)

## Game Elements
*   Hemispheric Mazes: The scene is divided into two mazes representing the right and left hemispheres of the brain.
*   Teleportation Portal: A portal allows the player to move between the two hemispheres, reflecting brain connectivity.
*   Trigger Events: Passing through invisible areas activates scripted events such as ambisonic sounds, shadow appearances, and particle systems (e.g., fog).

| ![Fog in Game](Images/fog.png) | ![Scary shadow](Images/scaring_figure.png) | ![Portal](Images/portal.png) |
| :---: | :---: | :---: |
| Volumetric fog to obstruct vision. | A shadow appears to scare the player. | Portal for moving between hemispheres. |

## Future Developments
The next crucial step is compiling the final build (.apk) and installing it as a standalone application on the Meta Quest 2 via MQDH. This will allow:
*   Evaluating the application’s real performance in a native environment.
*   Monitoring metrics such as FPS and CPU/GPU usage without a PC.
*   Validating the effectiveness of the entire optimized development pipeline.

## Autore
*   **Federica Di Giaimo**
