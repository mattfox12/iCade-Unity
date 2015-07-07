// add these after the other #imports at the top of the document
#import "iCadeReaderView.h"
#import "iCadeUnityLink.h"


// find this function, and just add the iCade code before the end of the function
- (void) startUnity:(UIApplication*)application
{
	/*
	  Existing code stays here. Do not delete the given code!!!
	*/
	
	// add iCade
	iCadeReaderView *iCadeReader = [[iCadeReaderView alloc] initWithFrame:CGRectZero];
	iCadeUnityLink *iCade = [[iCadeUnityLink alloc] init];
	[iCadeReader setDelegate:iCade];
	[application.keyWindow.rootViewController.view addSubview:iCadeReader];
	[iCadeReader setActive:YES];
}