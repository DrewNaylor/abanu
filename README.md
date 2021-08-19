>Note: It'll take time to change things over to being named "WeastroShell". See also issue #1.

*Abanu Desktop is a Desktop Environment for Windows and Linux. It's extremly fast.*

[![Gitter](https://badges.gitter.im/Join%20Chat.svg)](https://gitter.im/abanu-desktop/abanu?utm_source=badge&utm_medium=badge&utm_campaign=pr-badge&utm_content=badge)

## Abanu Desktop contains the following applications:
* Abanu Panels (Application Menu, Window List, Clock, configurable size & position) [implemented]
* Abanu Explorer [not implemented yet]
* Abanu Background Window (Desktop Icons) [not implemented yet]

## Description
* Alternative for the Windows Shell ("explorer.exe") and runs side by side. On Linux, an existing Window Manager is requied.
* Flexible Panels (for example "Taskbar")
* Ultrafast application start menu
* inspired by XFCE (from for Linux)

## How to install / build / run:
* Download and Install GTK# 2.99/3.0: **[Download](https://github.com/mono/gtk-sharp/releases/download/2.99.3/gtk-sharp-2.99.3.msi)**. For Linux, install the gtk-sharp3 package with your packetmanager.
* Note by Drew Naylor: You'll need to follow the GtkSharp instructions for installing GTK# on Windows here: https://github.com/GtkSharp/GtkSharp/wiki/Installing-Gtk-on-Windows You may also need to add the "lib" directory to your PATH in addition to the "bin" directory. At the moment, things only start by changing the solution platform to x64 for the panel project, though I'm going to try to figure out how to get this to work under AnyCPU.
* Download and extract Source (Zip-Archive): **[Download](https://github.com/abanu-desktop/abanu/archive/master.zip)**
* Enter `abanu` directory and call `make.cmd` (Windows) call `make` (Linux)
* Call `run.cmd` or `bin/abanu.panel.exe`

## Current development state
In the moment, only the Abanu Panel is working, but still in development.

## Your help is welcome!
* We need documentation
* Testing
* Developers
* Feedback & Suggestions

Contact:
sebastian.loncar [at] gmail.com


[![Issues][github-issues]][github-issues-link]
