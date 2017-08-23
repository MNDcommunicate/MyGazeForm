# MyGazeForm

VB.Net modified version of Tobii's GazeAwareForms which was written in C

After a struggle of looking for VB.Net code to make use of the new Tobii EyeTracker 4C and finding nil, I decided to write my own. 
I copied the GazeAwareForms sample program from the SDK TobiiEyeXSdk-DotNet-1.8.498 and converted parts of it to VB.Net and added my own touches.

This is a simple program that makes use of Gaze-Aware Behavior with three buttons, five panels, a picturebox, a scrollbar and a trackbar. 

All of these items are added into a bahaviormap. Most of the behaviour map interactorID's are loaded with a delay time to reduce simple glance errors. Gazing (staring) at the Exit button for two (2) seconds will performclick the button and Exit the application.

I make use of the Microsoft Speech engine to speak when you look at items on the window. The mouse cursor is moved to the item that you look at, after the delay time has passed.

This simple sample, should provide other developers a start point. Happy coding

In the near future I will create an Activatable Behaviour version

