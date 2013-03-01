iCade Unity
=======================

Add iCade controller support to your Unity iOS project. Includes a C# script for detecting buttons.

Usage
-----
Create an empty object in your Unity scene called iCadeObject. Add ICade.cs script to the object. Other scripts can check for iCade button presses via ICade.instance.isDown(string name), ICade.instance.justPressed(string name), ICade.instance.justReleased(string name).

In your Xcode project, add the files that begin with iCade to the Classes folder. Open AppController.mm from this repo, and copy/paste the lines of code to the correct places in the Unity generated AppController.mm of your project.

----

iCadeReaderView.h, iCadeReaderView.m and iCadeState.h slightly modified (retains/releases delegate) from https://github.com/scarnie/iCade-iOS

