#import <Foundation/Foundation.h>
#import <UIKit/UIKit.h>
#import <AVFoundation/AVFoundation.h>
extern UIViewController *UnityGetGLViewController();

@interface iOSPlugin: NSObject

@end

@implementation iOSPlugin
+ (void)setTorchToLevel:(float)torchLevel
{
    AVCaptureDevice *device = [AVCaptureDevice defaultDeviceWithMediaType:AVMediaTypeVideo];
    if ([device hasTorch]) {
        [device lockForConfiguration:nil];
        if (torchLevel <= 0.0) {
            [device setTorchMode:AVCaptureTorchModeOff];
        }
        else {
            if (torchLevel >= 1.0)
                torchLevel = AVCaptureMaxAvailableTorchLevel;
            BOOL success = [device setTorchModeOnWithLevel:torchLevel   error:nil];
        }
        [device unlockForConfiguration];
    }
}

@end

extern "C"
{
    void _SetTouchLevel(const float *level)
    {
        [iOSPlugin setTorchToLevel: *level];
    }

    void _TurnOn()
    {
        [iOSPlugin setTorchToLevel: 1.0];
    }

    void _TurnOff()
    {
        [iOSPlugin setTorchToLevel: 0.0];
    }
}
