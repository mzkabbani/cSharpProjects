using System;
using System.Collections;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace AppControl
{

	/// <summary>
	/// Application Display Control
	/// </summary>
	[
	ToolboxBitmap(typeof(ApplicationControl), "AppControl.bmp"),	
	]
	public class ApplicationControl : System.Windows.Forms.Panel
	{

		/// <summary>
		/// Track if the application has been created
		/// </summary>
		bool created = false;

		/// <summary>
		/// Handle to the application Window
		/// </summary>
		IntPtr appWin;

		/// <summary>
		/// The name of the exe to launch
		/// </summary>
		private string exeName = "putty";
        private string arguments = "";
		/// <summary>
		/// Get/Set if we draw the tick marks
		/// </summary>
		[
		Category("Data"),
		Description("Name of the executable to launch"),		
		DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)
		]
		public string ExeName
		{
			get
			{
				return exeName;
			}
			set
			{
				exeName = value;				
			}
		}

        public string Arguments {
            get {
                return arguments;
            }
            set {
                arguments = value;
            }
        }

		/// <summary>
		/// Constructor
		/// </summary>
		public ApplicationControl()
		{			
		}


		[DllImport("user32.dll", EntryPoint="GetWindowThreadProcessId",  SetLastError=true,
			 CharSet=CharSet.Unicode, ExactSpelling=true,
			 CallingConvention=CallingConvention.StdCall)]
		private static extern long GetWindowThreadProcessId(long hWnd, long lpdwProcessId); 
			
		[DllImport("user32.dll", SetLastError=true)]
		private static extern IntPtr FindWindow (string lpClassName, string lpWindowName);

		[DllImport("user32.dll", SetLastError=true)]
		private static extern long SetParent (IntPtr hWndChild, IntPtr hWndNewParent);

		[DllImport("user32.dll", EntryPoint="GetWindowLongA", SetLastError=true)]
		private static extern long GetWindowLong (IntPtr hwnd, int nIndex);

		[DllImport("user32.dll", EntryPoint="SetWindowLongA", SetLastError=true)]
		private static extern long SetWindowLong (IntPtr hwnd, int nIndex, long dwNewLong);

		[DllImport("user32.dll", SetLastError=true)]
		private static extern long SetWindowPos(IntPtr hwnd, long hWndInsertAfter, long x, long y, long cx, long cy, long wFlags);
		
		[DllImport("user32.dll", SetLastError=true)]
		private static extern bool MoveWindow(IntPtr hwnd, int x, int y, int cx, int cy, bool repaint);
		
		[DllImport("user32.dll", EntryPoint="PostMessageA", SetLastError=true)]		
		private static extern bool PostMessage(IntPtr hwnd, uint Msg, long wParam, long lParam);
		
		private const int SWP_NOOWNERZORDER = 0x200;
		private const int SWP_NOREDRAW = 0x8;
		private const int SWP_NOZORDER = 0x4;
		private const int SWP_SHOWWINDOW = 0x0040;
		private const int WS_EX_MDICHILD = 0x40;
		private const int SWP_FRAMECHANGED = 0x20;
		private const int SWP_NOACTIVATE = 0x10;
		private const int SWP_ASYNCWINDOWPOS = 0x4000;
		private const int SWP_NOMOVE = 0x2;
		private const int SWP_NOSIZE = 0x1;
		private const int GWL_STYLE = (-16);
		private const int WS_VISIBLE = 0x10000000;
		private const int WM_CLOSE = 0x10;
		private const int WS_CHILD = 0x40000000;
		
		/// <summary>
		/// Force redraw of control when size changes
		/// </summary>
		/// <param name="e">Not used</param>
		protected override void OnSizeChanged(EventArgs e)
		{
			this.Invalidate();
			base.OnSizeChanged (e);
		}


		/// <summary>
		/// Creeate control when visibility changes
		/// </summary>
		/// <param name="e">Not used</param>
		protected override void OnVisibleChanged(EventArgs e)
		{

			// If control needs to be initialized/created
			if (created == false)
			{
                
				// Mark that control is created
				created = true;

				// Initialize handle value to invalid
				appWin = IntPtr.Zero;

				// Start the remote application
				Process p = null;
				try
				{
					// Start the process                   
                    ProcessStartInfo startInfo = new ProcessStartInfo(this.exeName, this.arguments);
                    startInfo.WindowStyle = ProcessWindowStyle.Maximized;

                    p = System.Diagnostics.Process.Start(startInfo);
					// Wait for process to be created and enter idle condition
					p.WaitForInputIdle();                    
					// Get the main handle
					appWin = p.MainWindowHandle;
				}
				catch (Exception ex)
				{
					MessageBox.Show(this, ex.Message, "Error");
				}			
            
				// Put it into this form
				SetParent(appWin, this.Handle);

               // GetWindowLong(appWin, 0);
				// Remove border and whatnot
				SetWindowLong(appWin, 1200, 2000);

				// Move the window to overlay it on this window
               MoveWindow(appWin, -5, -30, 1200, 2000, true);
				
			}

			base.OnVisibleChanged (e);
		}

	
		/// <summary>
		/// 
		/// </summary>
		/// <param name="e"></param>
		protected override void OnHandleDestroyed(EventArgs e)
		{
			// Stop the application
			if (appWin != IntPtr.Zero)
			{

				// Post a colse message
				PostMessage(appWin, WM_CLOSE, 0, 0);

				// Delay for it to get the message
				System.Threading.Thread.Sleep(1000);

				// Clear internal handle
				appWin = IntPtr.Zero;

			}

			base.OnHandleDestroyed (e);
		}


		/// <summary>
		/// Update display of the executable
		/// </summary>
		/// <param name="e">Not used</param>
		protected override void OnResize(EventArgs e)
		{
			if (this.appWin != IntPtr.Zero)
			{
                MoveWindow(appWin, -5, -30, 1200, 2000, true);
			}
			base.OnResize (e);
		}


	}


}
