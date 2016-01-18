# Voodoos
This is a Unity project for an interactive 3D comic. It comes with UI buttons for navigating the comic and scene fading.
Also, it will controll gameobjects that are only used in one specific comic scene.

The idea is that you can create any 3D comic with this Unity project.

## Setup
The only things you have to do is:
1. Define the Scenes of the comic by adding and positioning cameras.
2. Add images for the Text displayed in each Scene.
3. Tag all gameObjects that are scene specific and should not be displayed all the time.

## Test Scene
The Testscene shows you how to! Have a look at the SceneController and how everything is wired up there. 

## Main Scene
For your leisure, MainScene contains the basic assets and wiring so that you only need to do the above discribed steps.

## How it works.
The SceneController is the mastermind script behind all the scene transitions. 
The buttons for going to the next or previous scene ask the SceneController to switch to a new comic scene.
The Fader is activated and will let the SceneController know when to activate the scene specific gameobjects and switch to
the next camera. At this step also the new text for the comic scene is displayed.
