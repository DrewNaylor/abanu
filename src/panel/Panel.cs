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
// unless otherwise specified. This boilerplate will be removed or modified if requested, with
// the exception of the statement that modifications to the file are copyright to Drew Naylor, because
// you're supposed to say when a file is modified, and your modifications are owned by you.
//




using System;
using Gtk;
using Gdk;
using System.Collections.Generic;

namespace abanu.panel
{
	
	public class PanelWindow : Gtk.Window
	{
		
		public PanelWindow()
			: base(Gtk.WindowType.Toplevel)
		{
			// Uncomment the next line to remove window decorations
			// from the panel window. This is recommended as it'll properly
			// look like a panel.
			Decorated = false;
			KeepAbove = true;
			//this.Resizable = false;
			//this.SetDefaultSize(300, 300);
			//this.SetGeometryHints(this, new Geometry(){ MaxWidth = 300 }, WindowHints.MaxSize);
		}

	}

	public class TPanel
	{

		private PanelWindow win;
		private Box box;
		private Menu menu;

		public PanelConfig cfg;

		public TPanel(PanelConfig cfg)
		{
			this.cfg = cfg;
			win = new PanelWindow();
		}

		public void Configure()
		{
			SetOrientation(cfg.Orientation);
			SetPos(cfg.Monitor, new Point(cfg.X, cfg.Y), cfg.RowHeight, cfg.Rows, cfg.Size, cfg.Dock);

			foreach (var plugCfg in cfg.Plugins) {
				var p = TPlugin.CreateIntance(this, plugCfg);
				AddPlugin(p);
			}
		}

		public void SetOrientation(Orientation ori)
		{
			box.Orientation = ori;
		}

		public int panelSize;

		public int monitorIdx;
		public int rowHeight;
		public int rows;


		public void SetPos(int monitorIdx, Point pos, int rowHeight, int rows, string size, EDock dock)
		{
			var mon = Screen.Default.GetMonitorGeometry(monitorIdx);

			if (size.EndsWith("%")) {
				var widthPercent = double.Parse(size.Substring(0, size.Length - 1), System.Globalization.CultureInfo.InvariantCulture);
				width = (int)(((double)mon.Width / 100) * widthPercent);
			} else {
				width = int.Parse(size);	
			}

			this.rows = rows;
			this.rowHeight = rowHeight;
			panelSize = rowHeight * rows;
			height = panelSize;

			if (dock.HasFlag(EDock.Top))
				pos.Y = 0;
			if (dock.HasFlag(EDock.Bottom))
				pos.Y = mon.Height - panelSize;

			win.Move(pos.X, pos.Y);
			win.SetDefaultSize(width, height);
			win.SetSizeRequest(width, height);
		}

		public int width;
		public int height;

		public void Setup()
		{
			menu = new Menu();
			var quitItem = new MenuItem("Quit");
			menu.Add(quitItem);
			quitItem.ButtonPressEvent += (s, e) => {
				Application.Quit();
			};

			//win.Add(box2);

			//box2.SetSizeRequest(300, 300);


			box = new Box(Orientation.Vertical, 1);
			win.Add(box);

			Configure();

			win.Events = EventMask.AllEventsMask;
			//box.Events = EventMask.AllEventsMask;

			win.ButtonPressEvent += (s, e) => {
				if (e.Event.Button == 3) {
					menu.Popup();
				}
			};
			menu.ShowAll();
		}

		public void Show()
		{
			win.ShowAll();
		}

		public void AddPlugin(TPlugin plug)
		{
			var w = plug.CreateWidget();

			plugins.Add(plug);
			box.PackStart(w, plug.expand, plug.expand, 0);
		}

		public TPluginList plugins = new TPluginList();

	}

	public class TPluginList  : List<TPlugin>
	{

	}

	public enum EDock
	{
		Top,
		Bottom,
		Left,
		Right
	}
}

