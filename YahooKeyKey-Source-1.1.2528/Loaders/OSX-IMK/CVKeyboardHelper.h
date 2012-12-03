// [AUTO_HEADER]

#import <Cocoa/Cocoa.h>
#import <Carbon/Carbon.h>

@interface CVKeyboardHelper : NSObject
{
	NSMutableArray *_validKeyboardLayouts;
}
+ (CVKeyboardHelper *)sharedSendKey;
- (void)loadValidKeyboardLayouts;
- (NSArray *)validKeyboardLayouts;
- (BOOL)validateKeyboardLayout:(NSString *)layout;
@end
