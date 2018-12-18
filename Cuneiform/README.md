# Xamarin Cuneiform

It's the earliest form of written [`Xamarin.Forms`][xamarin-forms] (according to me).

Right now I can make about as much sense of it, as I can about actual [Cuneiform][cuneiform-og].
But hang tight, folks, it's gonna be great.


[cuneiform-og]: https://en.wikipedia.org/wiki/Cuneiform
[xamarin-forms]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/


## How does it work?

### The User Interface

`Xamarin.Forms` is a [MVVM][mvvm-for-xamarin] library that uses [XAML][xaml-for-xamarin], just like you would for a
[WPF application for Windows][wpf].  Views are written in a declarative, XML-like syntax (`XAML`) and bound to a C#
class through the use of a [Binding Context][xaml-binding].  A [ViewModel class][mvvm-view-model] contains properties
for data to be displayed or entered into the user interface and commands to handle events such as button clicks.

The [Xamarin.Forms deep dive][xamarin-deep-dive] is a good place to get familiar with how this all works.


[mvvm-for-xamarin]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/enterprise-application-patterns/mvvm
[mvvm-view-model]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/xaml/xaml-basics/data-bindings-to-mvvm
[wpf]: https://docs.microsoft.com/en-us/dotnet/framework/wpf/getting-started/
[xamarin-deep-dive]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/get-started/hello-xamarin-forms/deepdive?pivots=macos
[xaml-binding]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/xaml/xaml-basics/data-binding-basics
[xaml-for-xamarin]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/xaml/xaml-basics/get-started-with-xaml?tabs=macos


### Building for Mobile Devices

Xamarin seeks to implement a pattern of using a relatively large, shared codebase of .NET code paired with relatively
small amounts of code for each target platform.  In such fashion, this code can then be
[run on a variety of mobile platforms][xamarin-build]:

- Android: Compile .NET sources to the .NET Intermediate Language and run on Mono for Android.
- iOS: Compile .NET sources to iOS-compatible ARM assembly code that runs natively on the device.
- Windows platforms: Using [the UWP process described here][uwp-for-windows].

There are some [restrictions on shared code][xamarin-sharing-code], to ensure compatibility with each target platform.
An project containing shared code can be one of a number of choices:

- a class library targeting .NET Standard
- a Shared Project that gets compiled into each downstream project that depends upon it
- a Portable Class Library (PCL) -- _Note that this approach is now deprecated_.

Builds use the older [MSBuild][msbuild-for-mono] toolset; not the `dotnet` CLI that is used for .NET Core.


[msbuild-for-mono]: https://github.com/mono/linux-packaging-msbuild
[uwp-for-windows]: https://docs.microsoft.com/en-us/windows/uwp/develop/
[xamarin-build]: https://docs.microsoft.com/en-us/xamarin/cross-platform/get-started/introduction-to-mobile-development#how-does-xamarin-work
[xamarin-sharing-code]: https://docs.microsoft.com/en-us/xamarin/cross-platform/app-fundamentals/code-sharing


### Signing in to AWS Cognito

This app signs in to [AWS Cognito][cognito-home] using the [AWS SDK for .NET][awssdk-dotnet] and an
[extension library for authentication][cognito-auth-extension] that implements the
[Secure Remote Password protocol][srp-wikipedia] to authenticate without transmitting the password.

Use of the extension library is documented in [this blog][blog-cognito-auth].


[awssdk-dotnet]: https://docs.aws.amazon.com/sdkfornet/v3/apidocs/
[blog-cognito-auth]: https://www.saltydogtechnology.com/xamarin-forms-aws-cognito/
[cognito-auth-extension]: https://aws.amazon.com/blogs/developer/cognitoauthentication-extension-library-developer-preview/
[cognito-home]: https://aws.amazon.com/cognito/
[srp-wikipedia]: https://en.wikipedia.org/wiki/Secure_Remote_Password_protocol


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
