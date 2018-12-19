# Xamarin Cuneiform

It's the earliest form of written [`Xamarin.Forms`][xamarin-forms] (according to me).

Right now I can make about as much sense of it, as I can about actual [Cuneiform][cuneiform-og].
But hang tight, folks, it's gonna be great.


[cuneiform-og]: https://en.wikipedia.org/wiki/Cuneiform
[xamarin-forms]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/


## Theory of Operation

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


### Running .NET Code on Mobile Devices

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


## Development

### Environment Setup

[Install Xamarin][xamarin-install] to get started.  This will guide you through the steps to install:

- a free, community edition of Visual Studio
- Android development tools, including the [Android Emulator][android-emulator]
- Xcode development tools for iOS (Apple) devices, including the [iOS Simulator][ios-simulator]
- [Mono][mono-intro] - a cross-platform implementation of .NET that runs on mobile devices

The Xamarin installer does a pretty good job of walking you through the steps necessary to set all of this up.
After that, you should be able to follow the [Hello, iOS Quickstart app][ios-quickstart] guide to develop a sample
app in Visual Studio.  It should now be possible to build the associated [Hello, iOS source code][ios-quickstart-code].


[android-emulator]: https://developer.android.com/studio/run/emulator
[clr-intro]: https://docs.microsoft.com/en-us/dotnet/standard/clr
[dotnet-core]: https://dotnet.microsoft.com/download
[ios-quickstart]: https://docs.microsoft.com/en-us/xamarin/ios/get-started/hello-ios/hello-ios-quickstart
[ios-quickstart-code]: https://developer.xamarin.com/samples/monotouch/Hello_iOS/
[ios-simulator]: https://help.apple.com/simulator/mac/current/
[mono-intro]: https://www.mono-project.com/
[msbuild]: https://docs.microsoft.com/en-us/visualstudio/msbuild/msbuild
[xamarin-install]: https://docs.microsoft.com/en-us/xamarin/cross-platform/get-started/installation/


### Cognito Configuration

Cognito needs some information about which User Pool to connect to, and that information should be kept private.
Rather than looking for - and possibly overlooking - values in the code that need to be updated, this code simply
will not compile until you supply the necessary secrets.  In other words, **the source file containing this information
is intentionally left out of source control**.

Follow these steps, to supply your own configuration:

1. Create a C# file `Cuneiform.Private.StaticCognitoCofiguration`.
1. Implement `IConfigureCognito`.
1. Fill in the values required by the interface.


### Build

The code is built with Mono's version of MSBuild, [`xbuild`][mono-xbuild], and this is simplest to invoke from the IDE.
Running the build will generate artifacts for the selected configuration (Debug or Release) on the selected platform.
The selected solution configuration defines which configuration and platform to build for each project.

If you find yourself on the command line, basic build tasks can be run as in the following examples:

    # Remove built artifacts for the specified configuration and platform
    $ msbuild /target:Clean /property:Configuration=Debug /property:Platform=AnyCPU [.csproj file | project directory]
    
    # Build Debug|iPhoneSimulator artifacts for all projects
    $ msbuild /p:Configuration=Debug /p:Platform=iPhoneSimulator

Builds generate an assembly for each project's `bin/` directory, in the form of a `.dll` or `.exe` file (depending upon
the project's output type).  Assemblies can be inspected with [Mono tools][mono-tools] like `ikdasm`.  For example:

    $ ikdasm bin/Release/netstandard2.0/Cuneiform.dll | grep '[.]class'
    .class public auto ansi beforefieldinit Cuneiform.App
    .class interface public abstract auto ansi Cuneiform.IConfigureCognito
    ...

Additional details for building, packaging, and deploying apps to each target platform are available here:

- [Android Deployment and Testing][xamarin-android-deployment]
- [iOS Deployment and Testing][xamarin-ios-deployment]


[mono-tools]: https://www.mono-project.com/docs/tools+libraries/tools/
[mono-xbuild]: https://www.mono-project.com/docs/tools+libraries/tools/xbuild/
[xamarin-android-deployment]: https://docs.microsoft.com/en-us/xamarin/android/deploy-test/
[xamarin-ios-deployment]: https://docs.microsoft.com/en-us/xamarin/ios/deploy-test/


### Running Android on the Android Emulator

Target a device with a [sufficient version of Android][xamarin-requirements] (19 or later, as of this writing).

If the app is not starting (or is constantly logging to the console) there are a few things to check:

- `docker-engine` may need to be stopped, at least if you are running from Visual Studio for Mac.
- If you are in Rider, try running the app from Visual Studio once.  This tends to trigger a cold boot on the Android
  device, which seems to help.

The code ultimately compiles to the .NET Intermediate Language and runs on the device on Mono for Android.
The build configuration you select determines a number of factors in the
[packaging and deployment of the app][android-packaging] to the target device. 


[android-packaging]: https://docs.microsoft.com/en-us/xamarin/android/deploy-test/building-apps/build-process
[xamarin-requirements]: https://docs.microsoft.com/en-us/xamarin/xamarin-forms/get-started/installation


### Running iOS on the iOS Simulator

The sample application seems to run well on iPhone 7 (iOS 12.1), under the iOS Simulator, from either Visual Studio
or Rider.
