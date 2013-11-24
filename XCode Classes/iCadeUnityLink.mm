//
//  iCadeUnityLink.m
//  Unity-iPhone
//
//  Created by Matthew Klundt on 12/11/12.
//
//

#import "iCadeUnityLink.h"
#import "iCadeState.h"
#include "UnityInterface.h"

@implementation iCadeUnityLink

enum JoystickButtonNumbers
{
	BTN_PAUSE = 0,
	BTN_DPAD_UP = 4,
	BTN_DPAD_RIGHT = 5,
	BTN_DPAD_DOWN = 6,
	BTN_DPAD_LEFT = 7,
	BTN_Y = 12,
	BTN_B = 13,
	BTN_A = 14,
	BTN_X = 15,
	BTN_L1 = 8,
	BTN_L2 = 10,
	BTN_R1 = 9,
	BTN_R2 = 11
};

- (id) init {
	self = [super init];
	
	joystickNum = 0; // 0=any, or 1-4 for a specific player
	
	return self;
}


- (void) stateChanged:(iCadeState)state {
	//NSLog(@"State Changed!");
	
}

- (void) setJoystickButton:(int)buttonNum state:(bool)state {
	char buf[128];
	if (joystickNum > 0) {
		// send to specific joystick
		sprintf (buf, "joystick %d button %d", joystickNum, buttonNum);
		UnitySetKeyState (UnityStringToKey (buf), state);
	}
	
	// Mirror button input into virtual joystick 0
	sprintf (buf, "joystick button %d", buttonNum);
	UnitySetKeyState (UnityStringToKey (buf), state);
}

- (void) buttonDown:(iCadeState)button {
	NSLog(@"Button Press!");
	switch (button) {
		case iCadeJoystickDown:
			[self setJoystickButton:BTN_DPAD_DOWN state:true];
			break;
		case iCadeJoystickUp:
			[self setJoystickButton:BTN_DPAD_UP state:true];
			break;
		case iCadeJoystickLeft:
			[self setJoystickButton:BTN_DPAD_LEFT state:true];
			break;
		case iCadeJoystickRight:
			[self setJoystickButton:BTN_DPAD_RIGHT state:true];
			break;
		case iCadeButtonA:
			// there is no SELECT Button for Unity's Joypad, so it is arbitrarily L2
			[self setJoystickButton:BTN_L2 state:true];
			break;
		case iCadeButtonB:
			[self setJoystickButton:BTN_L1 state:true];
			break;
		case iCadeButtonC:
			[self setJoystickButton:BTN_PAUSE state:true];
			break;
		case iCadeButtonD:
			[self setJoystickButton:BTN_R1 state:true];
			break;
		case iCadeButtonE:
			[self setJoystickButton:BTN_Y state:true];
			break;
		case iCadeButtonF:
			[self setJoystickButton:BTN_B state:true];
			break;
		case iCadeButtonG:
			[self setJoystickButton:BTN_X state:true];
			break;
		case iCadeButtonH:
			[self setJoystickButton:BTN_A state:true];
			break;
		default:
			break;
	}
}

- (void) buttonUp:(iCadeState)button {
	NSLog(@"Button Release!");
	switch (button) {
		case iCadeJoystickDown:
			[self setJoystickButton:BTN_DPAD_DOWN state:false];
			break;
		case iCadeJoystickUp:
			[self setJoystickButton:BTN_DPAD_UP state:false];
			break;
		case iCadeJoystickLeft:
			[self setJoystickButton:BTN_DPAD_LEFT state:false];
			break;
		case iCadeJoystickRight:
			[self setJoystickButton:BTN_DPAD_RIGHT state:false];
			break;
		case iCadeButtonA:
			// there is no SELECT Button for Unity's Joypad, so it is arbitrarily L2
			[self setJoystickButton:BTN_L2 state:false];
			break;
		case iCadeButtonB:
			[self setJoystickButton:BTN_L1 state:false];
			break;
		case iCadeButtonC:
			[self setJoystickButton:BTN_PAUSE state:false];
			break;
		case iCadeButtonD:
			[self setJoystickButton:BTN_R1 state:false];
			break;
		case iCadeButtonE:
			[self setJoystickButton:BTN_Y state:false];
			break;
		case iCadeButtonF:
			[self setJoystickButton:BTN_B state:false];
			break;
		case iCadeButtonG:
			[self setJoystickButton:BTN_X state:false];
			break;
		case iCadeButtonH:
			[self setJoystickButton:BTN_A state:false];
			break;
		default:
			break;
	}
}

@end
