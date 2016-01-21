# Voodoos
This is a Unity project for an interactive 3D comic. It comes with UI buttons for navigating the comic and fading between the panels.
Also, it will controll gameobjects that are only used in one specific comic panel and it will display a caption for each panel.

The idea is that you can create any 3D comic with this Unity project.

## Setup

1. Add the *ComisCore* prefab to your scene.

2. Panels:
    - Define the Panels of the comic by adding cameras (See *PanelCamera* gameobject, *PanelTransitionController*).
    - Tag all gameObjects that are panel specific and should not be displayed all the time. (The dafault tag prefix is "Panel", can be changed in the *PanelAssetController* component of *PanelTransitionController*).
    - Beware: The first panel is panel 0 not 1! 

3. Captions:
    - Add images for the caption displayed in each Panel (PanelTransitionController - UiController component).

## Test Scene
The Testscene shows you how to! Have a look at the ComicCore prefab and how everything is wired up there. 

## Main Scene
For your leisure, MainScene contains the basic assets and wiring so that you only need to do the above discribed steps.

## How it works.
The *PanelTransitionController* is the mastermind script behind all the panel transitions. 
The buttons for going to the next or previous scene ask the *PanelTransitionController* to switch to a new comic panel.
The *Fader* is activated and will let the *PanelTransitionController* know when to activate the scene specific gameobjects and switch to
the next camera. At this step also the new caption for the comic scene is displayed.