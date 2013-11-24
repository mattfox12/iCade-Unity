iCade Unity
=======================

Add iCade controller support to your Unity iOS project. Includes a C# script for detecting buttons.


Usage
-----
In your Xcode project, add the files that begin with iCade to the Classes folder. Open AppController.mm from this repo, and copy/paste the lines of code to the correct places in the Unity generated AppController.mm of your project.

In MonoDevelop, simply use Input.GetKeyDown(KeyCode.JoystickButton#)), Input.GetKeyUp(KeyCode.JoystickButton#)) or Input.GetKey(KeyCode.JoystickButton#)). The corresponding button numbers are shown in iCade8-bitty.png.

----

iCadeReaderView.h, iCadeReaderView.m and iCadeState.h slightly modified (retains/releases delegate) from https://github.com/scarnie/iCade-iOS

