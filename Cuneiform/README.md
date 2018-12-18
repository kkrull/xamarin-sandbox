# Xamarin Cuneiform

It's the earliest form of written [`Xamarin.Forms`][xamarin-forms] (according to me).

Right now I can make about as much sense of it, as I can about actual [Cuneiform][cuneiform-og].
But hang tight, folks, it's gonna be great.


[cuneiform-og]: https://en.wikipedia.org/wiki/Cuneiform
[xamarin-forms]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/


## Configuration

Cognito needs to be set up in the AWS console or otherwise, with a user pool and a client ID, in a region
(assumed to be US East 1).  **The source file containing this information is intentionally left out of source control**,
lest this information fall into the wrong hands.

To fix this:

1. Create a C# file `Cuneiform.Private.StaticCognitoCongiruation`.
1. Implement `IConfigureCognito`.
1. Fill in the values required by the interface.

After that, you should be able to build.


## Build

Build in Debug mode, targeting the iPhoneSimulator platform.


## Running Android on the Android Emulator

Target a device with a [sufficient version of Android][xamarin-requirements] (19 or later, as of this writing).

Make sure you're targeting the `iPhoneSimulator`.  
Running in debug mode, on Android, targeting other platforms such as `Any CPU` seems to result in an endless stream of
log messages about thread priorities.

Note also that `docker-engine` may need to be stopped, at least if you are running from Visual Studio for Mac.

[xamarin-requirements]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/get-started/installation


## Running iOS on the iOS Simulator

The sample application seems to run well on iPhone 7 (iOS 12.1).
