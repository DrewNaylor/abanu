>Note: It'll take time to change things over to being named "WeastroShell". See also issue #1.

*WeastroShell is a Desktop Environment for Windows and Linux. It's extremly fast.*

This project is a fork of [Abanu Desktop](https://github.com/abanu-desktop/abanu). WeastroShell is not associated with Abanu Desktop or any of its developers beyond being a fork and using Abanu Desktop's code.

## WeastroShell contains the following applications:
* WeastroShell Panels (Application Menu; Window List; Clock; configurable size, position, and even amount of panels so you can add a sidebar, for example) [implemented]
* WeastroShell Explorer [not implemented yet]
* WeastroShell Background Window (Desktop Icons) [not implemented yet]

## Description
* Alternative for the Windows Shell ("explorer.exe") and runs side by side. On Linux, an existing Window Manager is requied.
* Flexible Panels (for example "Taskbar")
* Ultrafast application start menu
* Inspired by XFCE (for Linux)
* Each panel can have its own configurable set of plugins, though this API is undocumented as far as I (Drew Naylor) know. This is something I'll work on to get to be even better so people can easily write their own plugins that can be compiled into their own library. Currently the menu, window list, and clock plugins are compiled with the rest of the panel I think, which makes adding new plugins after compilation difficult.

## Screenshots
These screenshots were taken by Drew Naylor when the binaries still called themselves "abanu", but after it was moved to .NET Framework 4.7.2 and set to use GTK# libraries from NuGet and MSYS2.<br>
Panel:<br>
![](/docs/images/weastroshell-panel.png?raw=true)<br>
Menu:<br>
![](/docs/images/weastroshell-menu.png?raw=true)

## How to install / build / run:
* Download and Install GTK# 2.99/3.0: **[Download](https://github.com/mono/gtk-sharp/releases/download/2.99.3/gtk-sharp-2.99.3.msi)**. For Linux, install the gtk-sharp3 package with your package manager.
  * Note by Drew Naylor: The instructions to download and install GTK# 2.99/3.0 are out of date and will be rewritten once I verify which package needs to be installed on Linux. You'll need to follow the GtkSharp instructions for installing GTK# on Windows here: https://github.com/GtkSharp/GtkSharp/wiki/Installing-Gtk-on-Windows You may also need to add the "lib" directory to your PATH in addition to the "bin" directory. At the moment, things only start by changing the solution platform to x64 for the panel project, though I'm going to try to figure out how to get this to work under AnyCPU. Update: it works under AnyCPU now, though it's only been tested on 64-bit Windows.
* Download and extract Source (Zip-Archive): **[Download](https://github.com/abanu-desktop/abanu/archive/master.zip)**
* Enter `abanu` directory and call `make.cmd` (Windows) call `make` (Linux)
* Call `run.cmd` or `bin/abanu.panel.exe`
  * Note by Drew Naylor: I'm trying to make it easy to build and debug without running scripts (aside from passing the binaries to dotnet/mono on Linux, which is to be expected) and instead by clicking the "Debug" button in Visual Studio, and currently that seems to work, so I'd advise against using the scripts as they'll be removed eventually when this project is moved to .NET Core/.NET 5.

## Current development state
Right now, only the WeastroShell Panel is working, but everything is still in development.

## Your help is welcome!
We need:
* Documentation
* Testing
* Developers
* Feedback & Suggestions

## Contact
- **Original Abanu Desktop developer:** sebastian.loncar [at] gmail.com<br>
- **WeastroShell fork developer:** drewnaylor_apps AT outlook DOT com
