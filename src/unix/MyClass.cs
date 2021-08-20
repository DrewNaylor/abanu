// WeastroShell - A free/libre open source software desktop environment for Windows and Linux.
// This project is a fork of Abanu Desktop: https://github.com/abanu-desktop/abanu
// WeastroShell is not associated with Abanu Desktop or its developers beyond being a fork.
//
// Original code is, I assume based on the file "LICENSE", Copyright (C) 2015 Sebastian Loncar
// Modifications to this file are Copyright (C) 2021 Drew Naylor.
// (Note that the copyright years include the years left out by the hyphen.)
//
// This project is under the MIT License.
// See the file "LICENSE" in the project root directory for more information. Below is a copy of the license:
//
//   Permission is hereby granted, free of charge, to any person obtaining a copy
//   of this software and associated documentation files (the "Software"), to deal
//   in the Software without restriction, including without limitation the rights
//   to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
//   copies of the Software, and to permit persons to whom the Software is
//   furnished to do so, subject to the following conditions:
// 
//   The above copyright notice and this permission notice shall be included in all
//   copies or substantial portions of the Software.
// 
//   THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
//   IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
//   FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
//   AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
//   LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
//   OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
//   SOFTWARE.
//
// Drew Naylor put this license/copyright boilerplate text here for clarity because it was missing in
// the original code, though it's assumed that doing so is ok because the project itself was under
// the MIT License and as such both the license and copyrights should apply to all the files
// unless otherwise specified.
//

using System;
using System.IO;
using Gdk;
using Gtk;
using System.Runtime.InteropServices;
using libdotdesktop_standard;

using abanu.core;

namespace abanu.unix
{
	public class FactoryActivator : abanu.core.FactoryActivator
	{
		
		public override ShellManager CreateShellManager()
		{
			return new ShellManagerUnix();
		}

		public override TWindow CreateWindow(IntPtr handle)
		{
			return new TWindowUnix(handle);
		}

		public override TLauncherEntry ReadLinkFile(string file)
		{
			var entry = new TLauncherEntry();
			entry.Name = desktopEntryStuff.getInfo(file, "Name");
			var cmd = desktopEntryStuff.getInfo(file, "Exec");
			entry.CommandPath = Path.GetDirectoryName(cmd);
			entry.CommandFile = Path.GetFileName(cmd);
			entry.CommandArgs = ""; //TODO
			entry.Categories = desktopEntryStuff.getInfo(file, "Categories", file, true);
			entry.IconName = desktopEntryStuff.getInfo(file, "Icon", file, true);
			entry.Description = desktopEntryStuff.getInfo(file, "Comment", file, true);
			entry.UpdateMainCategory();
			return entry;
		}

	}

}

