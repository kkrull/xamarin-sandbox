# Xamarin Super Fun Time: iOS

Going through the [tutorial][xamarin-ios-tutorial] to build and run tests for a mobile app, targetting iOS with Xamarin.

Setup involves:

1. Install Visual Studio Community Edition for MacOS, with Xamarin Tools and iOS Tools.  This also installs `mono`.
1. Install xcode.
1. Start xcode once so that it can ask for remaining permissions and install some straggling items.


[xamarin-ios-tutorial]: https://docs.microsoft.com/en-us/xamarin/ios/deploy-test/touch.unit


## Tests

There are different flavors of tests, in this project:

- `Phoneword_iOS.UITest` uses [NUnitLite][nunitlite-runner] to run UI tests on the phone, via iOS Simulator.
  There appears to be a way to run this through the NUnit3 ConsoleRunner, but that has not worked out quite yet.
  Run them for now in Visual Studio by right clicking on the project -> `Run Item`.
- `Phoneword_iOS.UnitTest` uses regular [NUnit][nunit-console-runner] to run plain unit tests on the command line.
  Use `bin/unit-test` to run it via Mono.


[nunit-console-runner]: https://github.com/nunit/docs/wiki/Console-Runner

