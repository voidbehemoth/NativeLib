# NativeLib
NativeLib is a [SalemModLoader](https://github.com/Curtbot9000/SalemModLoader) library for [Town of Salem 2](https://store.steampowered.com/app/2140510/Town_of_Salem_2/) by DigitalBanditos.

NativeLib is developed by VoidBehemoth and is unaffiliated with with DigitalBanditos.

## Development
Are you a modder that wants to use this library? Here's how it works:

Everything that one should need can be accessed by importing 'CommandLib.API'.

Load files via the below method:
```
NativeLoader.LoadNativeLibrary(string libName, Assembly assembly);
```
The first argument is the name of your file, including the extension. It is recommended to use Assembly.GetExecutingAssembly() for the second argument.

Native files are bundled with your mod as EmbeddedResources.

To check if your files have been loaded call NativeLoader.HasLoaded(string assemblyName).

Happy modding!

## Building
Want to build the latest (potentially unreleased) version of the mod yourself? Follow these steps:

1. Make sure you have the latest version of the repo on your client.
2. Create a file in the same directory as AutoGG.csproj called SteamLibrary.targets and copy the following into it:
```
<Project xmlns="http://schemas.microsoft.com/developer/msbuild/2003">
    <PropertyGroup>
        <SteamLibraryPath>REPLACE</SteamLibraryPath>
    </PropertyGroup>
</Project>
```
3. Replace the text 'REPLACE' with the location of your 'SteamLibrary' folder (or 'ApplicationSupport/Steam' on OSX).
4. Build the mod using either the [dotnet cli](https://dotnet.microsoft.com/en-us/download), [Visual Studio](https://visualstudio.microsoft.com/), or some other means.

NOTE: This repository is licensed under the GNU General Public License v3.0. Learn more about what this means [here](https://www.tldrlegal.com/license/gnu-general-public-license-v3-gpl-3).
