//
//  iCadeUnityLink.m
//  Unity-iPhone
//
//  Created by Matthew Klundt on 12/11/12.
//
//

#import "iCadeUnityLink.h"
#import "iCadeState.h"

@implementation iCadeUnityLink

- (void) stateChanged:(iCadeState)state {
	//NSLog(@"State Changed!");
	
}

- (void) buttonDown:(iCadeState)button {
	//NSLog(@"Button Press!");
	switch (button) {
		case iCadeJoystickDown:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "DOWN");
			break;
		case iCadeJoystickUp:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "UP");
			break;
		case iCadeJoystickLeft:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "LEFT");
			break;
		case iCadeJoystickRight:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "RIGHT");
			break;
		case iCadeButtonA:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "SELECT");
			break;
		case iCadeButtonB:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "L");
			break;
		case iCadeButtonC:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "START");
			break;
		case iCadeButtonD:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "R");
			break;
		case iCadeButtonE:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "Y");
			break;
		case iCadeButtonF:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "B");
			break;
		case iCadeButtonG:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "X");
			break;
		case iCadeButtonH:
			UnitySendMessage("iCadeObject", "iCadeKeyPress", "A");
			break;
		default:
			break;
	}
}

- (void) buttonUp:(iCadeState)button {
	//NSLog(@"Button Release!");
	switch (button) {
		case iCadeJoystickDown:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "DOWN");
			break;
		case iCadeJoystickUp:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "UP");
			break;
		case iCadeJoystickLeft:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "LEFT");
			break;
		case iCadeJoystickRight:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "RIGHT");
			break;
		case iCadeButtonA:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "SELECT");
			break;
		case iCadeButtonB:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "L");
			break;
		case iCadeButtonC:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "START");
			break;
		case iCadeButtonD:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "R");
			break;
		case iCadeButtonE:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "Y");
			break;
		case iCadeButtonF:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "B");
			break;
		case iCadeButtonG:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "X");
			break;
		case iCadeButtonH:
			UnitySendMessage("iCadeObject", "iCadeKeyRelease", "A");
			break;
		default:
			break;
	}
}

@end
