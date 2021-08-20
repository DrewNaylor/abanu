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

