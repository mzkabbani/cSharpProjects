#region using ...
using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;																				// 1.0.020
using System.Drawing.Drawing2D;
using System.Data;
using System.Windows.Forms;
using System.IO;
using System.Reflection;

using TDHControls.TDHTabCtl.TDHEditBox;																		// 1.0.001
#endregion 

namespace TDHControls.TDHTabCtl																				// 1.0.000
{
	/// <summary>
	/// Summary description for TdhTabCtl.																	// 1.0.000
	/// </summary>

	// Assign the custom [TabControlDesigner] class															// 1.0.020
	[System.ComponentModel.Designer(typeof(TDHControls.TDHTabCtl.TdhTabCtl_Designer))]						// 1.0.020 

	[System.ComponentModel.ToolboxItem(true)]																// 1.0.000
	[System.Drawing.ToolboxBitmapAttribute(typeof(TDHTabCtl.TdhTabCtl), "TdhTabCtl.bmp")]					// 1.0.000
	[Description( "TdhTabCtl -- An extension of the .NET TabControl and TabPage controls." )]				// 1.0.004

	public class TdhTabCtl : System.Windows.Forms.TabControl												// 1.0.000
	{
		#region pseudo-[Windows Component Designer generated instantiation of components]

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		#endregion 

		#region pseudo-[Component Designer generated code]
		/// <summary>
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			components = new System.ComponentModel.Container();

			this._TabPages = new TDHTabCtl.TdhTabPageCollection(this);										// 1.0.001
			//this._Controls = new TDHTabCtl.TdhTabPageControls(this);										// 1.0.002

			// The following code will set all TabPage widths to a fixed size	// TEST						// 1.0.003
			//this.SizeMode = System.Windows.Forms.TabSizeMode.Fixed;			// TEST						// 1.0.003
			//this.ItemSize = new System.Drawing.Size(100, 24);					// TEST						// 1.0.003
			// The following code doesn't seem to have any effect whether used or not.						// 1.0.003
			this.DrawMode = System.Windows.Forms.TabDrawMode.OwnerDrawFixed;
			this.ItemSize = new System.Drawing.Size(230, 24);

			this.SetStyle(System.Windows.Forms.ControlStyles.DoubleBuffer, true);	

			// Let's not hard-code [this.Font]																// 1.0.001
			//this.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));

			// Let's not hard-code [this.TabStop = false;]													// 1.0.001
			//this.TabStop = false;	

			Initialize_gblRunModeIs();		// Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]	// 1.0.000
			#region Build TDHTabCtl-ContextMenu [cmnuTabRect] and [cmnuTabRect.MenuItems]
			//if (!this.DesignMode)																			// 1.0.001
			if (!this.gblRunModeIs_DesignMode)																// 1.0.001
			{																								// 1.0.001
				this.cmnuTabRect = new System.Windows.Forms.ContextMenu();									// 1.0.001
				this.cmnuTabRect_New = new System.Windows.Forms.MenuItem();									// 1.0.001
				this.cmnuTabRect_New_TabsBase = new System.Windows.Forms.MenuItem();						// 1.0.011
				this.cmnuTabRect_Rename = new System.Windows.Forms.MenuItem();								// 1.0.001
				this.cmnuTabRect_Separator01 = new System.Windows.Forms.MenuItem();							// 1.0.001
				this.cmnuTabRect_Reorder = new System.Windows.Forms.MenuItem();								// 1.0.003
				this.cmnuTabRect_Separator09 = new System.Windows.Forms.MenuItem();							// 1.0.003
				this.cmnuTabRect_CloseThis = new System.Windows.Forms.MenuItem();							// 1.0.001
				this.cmnuTabRect_CloseSelect = new System.Windows.Forms.MenuItem();							// 1.0.001
				this.cmnuTabRect_CloseAllBut = new System.Windows.Forms.MenuItem();							// 1.0.001
				this.cmnuTabRect_CloseAll = new System.Windows.Forms.MenuItem();							// 1.0.001
				this.cmnuTabRect_Separator99 = new System.Windows.Forms.MenuItem();							// 1.0.001
				//																							// 1.0.001
				// cmnuTabRect_New																			// 1.0.001
				//																							// 1.0.001
				this.cmnuTabRect_New.Text = "Open New Tab (Enhanced TabPage)";								// 1.0.011
				this.cmnuTabRect_New.Click += new System.EventHandler(this.cmnuTabRect_New_Click);			// 1.0.001
				//																							// 1.0.011
				// cmnuTabRect_New_TabsBase																	// 1.0.011
				//																							// 1.0.011
				this.cmnuTabRect_New_TabsBase.Text = "Open New Tab (Basic TabPage)";						// 1.0.011
				this.cmnuTabRect_New_TabsBase.Click += new System.EventHandler(this.cmnuTabRect_New_Click);	// 1.0.011
				//																							// 1.0.001
				// cmnuTabRect_Rename																		// 1.0.001
				//																							// 1.0.001
				this.cmnuTabRect_Rename.Text = "Rename This Tab";											// 1.0.001
				this.cmnuTabRect_Rename.Click += new System.EventHandler(this.cmnuTabRect_Rename_Click);	// 1.0.001
				//																							// 1.0.001
				// cmnuTabRect_Separator01																	// 1.0.001
				//																							// 1.0.001
				this.cmnuTabRect_Separator01.Text = "-";													// 1.0.001
				//																							// 1.0.003
				// cmnuTabRect_Reorder																		// 1.0.003
				//																							// 1.0.003
				this.cmnuTabRect_Reorder.Text = "ReOrder TabPages";											// 1.0.003
				this.cmnuTabRect_Reorder.Click += new System.EventHandler(this.cmnuTabRect_Reorder_Click);	// 1.0.003
				//																							// 1.0.003
				// cmnuTabRect_Separator09																	// 1.0.003
				//																							// 1.0.003
				this.cmnuTabRect_Separator09.Text = "-";													// 1.0.003
				//																							// 1.0.001
				// cmnuTabRect_CloseThis																	// 1.0.001
				//																							// 1.0.001
				this.cmnuTabRect_CloseThis.Text = "Close This Tab";											// 1.0.001
				this.cmnuTabRect_CloseThis.Click += new System.EventHandler(this.cmnuTabRect_CloseThis_Click);	// 1.0.001
				//																							// 1.0.001
				// cmnuTabRect_CloseSelect																	// 1.0.001
				//																							// 1.0.001
				this.cmnuTabRect_CloseSelect.Text = "Close Tab ...";										// 1.0.001
				//																							// 1.0.001
				// cmnuTabRect_CloseAllBut																	// 1.0.001
				//																							// 1.0.001
				this.cmnuTabRect_CloseAllBut.Text = "Close All Other Tabs";									// 1.0.001
				this.cmnuTabRect_CloseAllBut.Click += new System.EventHandler(this.cmnuTabRect_CloseAllBut_Click);	// 1.0.001
				//																							// 1.0.001
				// cmnuTabRect_CloseAll																		// 1.0.001
				//																							// 1.0.001
				this.cmnuTabRect_CloseAll.Text = "Close All Tabs (Except ...)";								// 1.0.003
				this.cmnuTabRect_CloseAll.Click += new System.EventHandler(this.cmnuTabRect_CloseAll_Click);// 1.0.001
				//																							// 1.0.001
				// cmnuTabRect_Separator99																	// 1.0.001
				//																							// 1.0.001
				this.cmnuTabRect_Separator99.Text = "-";													// 1.0.001
			}																								// 1.0.001
			#endregion 
		}
		#endregion


		#region Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]
		private bool gblRunModeIs_DebugMode = false;														// 1.0.000
		private bool gblRunModeIs_DesignMode = true;														// 1.0.000

		private void Initialize_gblRunModeIs()																// 1.0.000
		{																									// 1.0.000
			#region Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]
			gblRunModeIs_DebugMode = System.Diagnostics.Debugger.IsAttached;								// 1.0.000

			//gblRunModeIs_DesignMode = false;																// 1.0.000
			//try						// the try-catch method can detect 'DesignMode' in the Constructor	// 1.0.000
			//{																								// 1.0.000
			//	//string dummy = System.Reflection.Assembly.GetEntryAssembly().Location.ToString();			// 1.0.000
			//	string dummy = System.Reflection.Assembly.GetEntryAssembly().FullName;						// 1.0.000
			//}																								// 1.0.000
			//catch (System.NullReferenceException ex)														// 1.0.000
			//{																								// 1.0.000
			//	gblRunModeIs_DesignMode = true;																// 1.0.000
			//}																								// 1.0.000

			// In the Constructor, [this.DesignMode] always returns false.									// 1.0.000
			// Also, [this.DesignMode] is applicable only to the class that actually invokes it.			// 1.0.000
			// Thus, in the code of the base class, it will return false.									// 1.0.000
			//gblRunModeIs_DesignMode = this.DesignMode;													// 1.0.000

			// Determine whether the class is in DesignMode by examining the .ProcessName of the current Process	// 1.0.000
			if (System.Diagnostics.Process.GetCurrentProcess().ProcessName.ToLower() == "devenv")			// 1.0.000
			{																								// 1.0.000
				gblRunModeIs_DesignMode = true;																// 1.0.000
			}																								// 1.0.000
			else																							// 1.0.000
			{																								// 1.0.000
				gblRunModeIs_DesignMode = false;															// 1.0.000
			}																								// 1.0.000
			#endregion
		}																									// 1.0.000
		#endregion 

		#region Define EventHandler Events

		[Category ("Action")]																				// 1.0.000
		[Description ("Occurs when the user Adds, Removes, Renames a TdhTabPage of the TdhTabCtl control.")]// 1.0.000
		public event TDHControls.TDHTabCtl.TabEventsDelegate OnTabEvents;									// 1.0.001

		[Category ("Action")]																				// 1.0.003
		[Description ("Occurs when the user Reorders the TdhTabPages of the TdhTabCtl control.")]			// 1.0.003
		public event TDHControls.TDHTabCtl.TabsReorderedEventDelegate OnTabsReordered;						// 1.0.003

		#endregion 

		#region Class Private Fields/Properties

		// If "New-TabPage" action is rejected; ensure that [this.SelectedIndex] doesn't change				// 1.0.003
		private int _thisSelectedIndex = -1;																// 1.0.003

		// TDHEditBox.TdhEditBox tdhEditBox -- Allow TdhTabPage-Rename										// 1.0.001
		//private TDHEditBox.TdhEditBox tdhEditBox = new TDHEditBox.TdhEditBox(new TDHEditBox.EditComplete(this.TabPage_Renamed));	// 1.0.001
		//private TDHEditBox.TdhEditBox tdhEditBox = new TDHEditBox.TdhEditBox();							// 1.0.001
		private TDHControls.TDHTabCtl.TDHEditBox.TdhEditBox _tdhEditBox = null;								// 1.0.001
		private bool _OnTabEvents_RenameIsAdd = false;														// 1.0.001

		private System.Drawing.RectangleF _lastTabRect = System.Drawing.RectangleF.Empty;					// 1.0.001
		private int _lastTabRectIdx = -1;																	// 1.0.001

		private System.Windows.Forms.ContextMenu cmnuTabRect = new System.Windows.Forms.ContextMenu();		// 1.0.001
		private System.Windows.Forms.ContextMenu cmnuTabRect_Work = new System.Windows.Forms.ContextMenu();	// 1.0.001
		private System.Windows.Forms.MenuItem cmnuTabRect_New;												// 1.0.001
		private System.Windows.Forms.MenuItem cmnuTabRect_New_TabsBase;										// 1.0.011
		private System.Windows.Forms.MenuItem cmnuTabRect_Rename;											// 1.0.001
		private System.Windows.Forms.MenuItem cmnuTabRect_Separator01;										// 1.0.001
		private System.Windows.Forms.MenuItem cmnuTabRect_Reorder;											// 1.0.003
		private System.Windows.Forms.MenuItem cmnuTabRect_Separator09;										// 1.0.003
		private System.Windows.Forms.MenuItem cmnuTabRect_CloseThis;										// 1.0.001
		private System.Windows.Forms.MenuItem cmnuTabRect_CloseSelect;										// 1.0.001
		private System.Windows.Forms.MenuItem cmnuTabRect_CloseAllBut;										// 1.0.001
		private System.Windows.Forms.MenuItem cmnuTabRect_CloseAll;											// 1.0.001
		private System.Windows.Forms.MenuItem cmnuTabRect_Separator99;										// 1.0.001

		#endregion 

		#region TdhTabCtl class constructor (and Dispose), etc
		// public TdhTabCtl()
		// 
		// protected override void Dispose( bool disposing )
		// 
		public TdhTabCtl()																				// 1.0.000
		{
			Initialize_gblRunModeIs();		// Set [gblRunModeIs_DebugMode] and [gblRunModeIs_DesignMode]	// 1.0.000
			// 
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
			// 
			// TODO: Add any initialization after the InitComponent call
			// 

			// Let's not hard-code [this.TabStop = false;]													// 1.0.001
			//this.TabStop = false;
		}


		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if( components != null )
				{
					components.Dispose();
				}

				if( (this._tdhEditBox != null)																// 1.0.001
				//&& !this._tdhEditBox.Disposing															// 1.0.001
				//&& !this._tdhEditBox.IsDisposed															// 1.0.001
				)																							// 1.0.001
				{																							// 1.0.001
					this._tdhEditBox.Dispose();																// 1.0.001
				}																							// 1.0.001
				this._tdhEditBox = null;																	// 1.0.001
			}
			base.Dispose( disposing );
		}
		#endregion 


		#region EventHandlers for TdhTabPage-ContextMenu [cmnuTabRect]
		// private void cmnuTabRect_New_Click(object sender, System.EventArgs e)
		// private void cmnuTabRect_Rename_Click(object sender, System.EventArgs e)
		// private void cmnuTabRect_Reorder_Click(object sender, System.EventArgs e)
		// private void cmnuTabRect_CloseAll_Click(object sender, System.EventArgs e)
		// private void cmnuTabRect_CloseAllBut_Click(object sender, System.EventArgs e)
		// private void cmnuTabRect_CloseSelect_Click(object sender, System.EventArgs e)
		// private void cmnuTabRect_CloseThis_Click(object sender, System.EventArgs e)
		// 
		private void cmnuTabRect_New_Click(object sender, System.EventArgs e)								// 1.0.001
		{																									// 1.0.001
			System.Windows.Forms.MenuItem menuItem = (System.Windows.Forms.MenuItem)sender;					// 1.0.011
			if( (this._tabsContextMenuAllowOpen																// 1.0.001
				&&(menuItem == this.cmnuTabRect_New)														// 1.0.011
				)																							// 1.0.011
			|| (this._tabsBase_ContextMenuAllowOpen															// 1.0.001
				&&(menuItem == this.cmnuTabRect_New_TabsBase)												// 1.0.011
				)																							// 1.0.011
			)																								// 1.0.001
			{																								// 1.0.001
				// If "New-TabPage" action is rejected; ensure that [this.SelectedIndex] doesn't change		// 1.0.003
				this._thisSelectedIndex = this.SelectedIndex;												// 1.0.003

				System.Windows.Forms.TabPage theTabPage;													// 1.0.011
				if (menuItem == this.cmnuTabRect_New)														// 1.0.011
				{																							// 1.0.011
					//theTabPage = new TDHTabCtl.TdhTabPage(this.components);								// 1.0.011
					theTabPage = new TDHTabCtl.TdhTabPage();												// 1.0.011
				}																							// 1.0.011
				else																						// 1.0.011
				//if (menuItem == this.cmnuTabRect_New_TabsBase)											// 1.0.011
				{																							// 1.0.011
					theTabPage = new System.Windows.Forms.TabPage();										// 1.0.011
				}																							// 1.0.011
				string tabPageName = "Page"+ (this.TabCount + 1).ToString();								// 1.0.001
				theTabPage.Name = tabPageName;																// 1.0.001
				theTabPage.Text = tabPageName;																// 1.0.001
				theTabPage.TabIndex = this.TabCount;														// 1.0.011

				//this.TabPages.Add(theTabPage);															// 1.0.001
				this.TdhTabPages.Add(theTabPage);															// 1.0.010

				this.cmnuTabRect_TabRect_Idx = this.TabCount - 1;											// 1.0.001
				this.cmnuTabRect_Built = false;																// 1.0.001
				this._OnTabEvents_RenameIsAdd = true;														// 1.0.001

				this.SelectedIndex = this.cmnuTabRect_TabRect_Idx;											// 1.0.003
				TabPage_Rename(theTabPage, this.cmnuTabRect_TabRect_Idx);									// 1.0.001
			}																								// 1.0.001
		}																									// 1.0.001

		private void cmnuTabRect_Rename_Click(object sender, System.EventArgs e)							// 1.0.001
		{																									// 1.0.001
			if (this._tabsContextMenuAllowRename															// 1.0.001
			&& (cmnuTabRect_TabRect_Idx > -1)																// 1.0.001
			&& (cmnuTabRect_TabRect_Idx < this.TabCount) 													// 1.0.001
			)																								// 1.0.001
			{																								// 1.0.001
				System.Windows.Forms.TabPage theTabPage = this.TdhTabPages[true, cmnuTabRect_TabRect_Idx];	// 1.0.010

				this._OnTabEvents_RenameIsAdd = false;														// 1.0.001
				TabPage_Rename(theTabPage, cmnuTabRect_TabRect_Idx);										// 1.0.001
				this.cmnuTabRect_Built = false;																// 1.0.001
			}																								// 1.0.001
		}																									// 1.0.001

		private void cmnuTabRect_Reorder_Click(object sender, System.EventArgs e)							// 1.0.003
		{																									// 1.0.003
			if (this._tabsContextMenuAllowReorder															// 1.0.003
			&& (this.TabCount > 1)																			// 1.0.003
			&& (cmnuTabRect_TabRect_Idx > -1)																// 1.0.003
			&& (cmnuTabRect_TabRect_Idx < this.TabCount) 													// 1.0.003
			)																								// 1.0.003
			{																								// 1.0.003
				TDHTabCtl.TdhTabReorder frmReorder = new TDHTabCtl.TdhTabReorder(							// 1.0.003
					this, cmnuTabRect_TabRect_Idx,															// 1.0.003
					this.PointToScreen(new System.Drawing.Point(0, 0)), -1, this.ClientSize.Width			// 1.0.003
					);																						// 1.0.003
				System.Windows.Forms.DialogResult diaResult = frmReorder.ShowDialog();						// 1.0.003
				if (diaResult == System.Windows.Forms.DialogResult.OK)										// 1.0.003
				{																							// 1.0.003
					#region Verify that we have some work to do here
					bool continueReorder = false;															// 1.0.003
					bool eventEachTab = false;																// 1.0.003
					int[] intTabOrder = frmReorder.TabOrder_int;											// 1.0.003
					if (intTabOrder.Length > 0)																// 1.0.003
					{																						// 1.0.003
						// Were any TabPages actually reordered?											// 1.0.003
						for (int idx = 0; idx < intTabOrder.Length; idx++)									// 1.0.003
						{																					// 1.0.003
							if (intTabOrder[idx] != idx)													// 1.0.003
							{																				// 1.0.003
								continueReorder = true;														// 1.0.003
								break;																		// 1.0.003
							}																				// 1.0.003
						}																					// 1.0.003

						if (continueReorder)																// 1.0.003
						{																					// 1.0.003
							eventEachTab = true;															// 1.0.003
							if (this.OnTabsReordered != null)												// 1.0.003
							{																				// 1.0.003
								eventEachTab = false;														// 1.0.003
							}																				// 1.0.003
							if (this.OnTabEvents == null)													// 1.0.003
							{																				// 1.0.003
								eventEachTab = false;														// 1.0.003
							}																				// 1.0.003
						}																					// 1.0.003
					}																						// 1.0.003
					#endregion 
					if (continueReorder)					// Do the work of Reordering the TabPages		// 1.0.003
					{																						// 1.0.003
						#region Put the TabPages into an ArrayList sequenced in the new order
						System.Collections.ArrayList alNewTabOrder = new System.Collections.ArrayList(intTabOrder.Length);	// 1.0.003
						for (int idxNew = 0; idxNew < intTabOrder.Length; idxNew++)							// 1.0.003
						{																					// 1.0.003
							//int idxOld = intTabOrder[idxNew];	// Array values point to current order		// 1.0.003
							alNewTabOrder.Add(this.TdhTabPages[true, intTabOrder[idxNew]]);					// 1.0.010
						}																					// 1.0.003
						#endregion 
						#region Clear/Rebuild [this.TabPages]; and Notify client of TabPage Reordering (for each TabPage)?
						this.SuspendLayout();																// 1.0.003
						//this.TabPages.Clear();															// 1.0.003
						this.TdhTabPages.Clear();															// 1.0.010
						for (int idxNew = 0; idxNew < intTabOrder.Length; idxNew++)							// 1.0.003
						{																					// 1.0.003
							System.Windows.Forms.TabPage theTabPage = (System.Windows.Forms.TabPage)alNewTabOrder[idxNew];	// 1.0.010
							theTabPage.TabIndex = idxNew;													// 1.0.003
							//this.TabPages.Add(theTabPage);	// This	method								// 1.0.003
							this.TdhTabPages.Add(theTabPage);	// This	method								// 1.0.010
							//this.Controls.Add(theTabPage);	// or this methodd							// 1.0.003

							#region Notify client of TabPage Reordering (for each TabPage)?
							int idxOld = intTabOrder[idxNew];												// 1.0.003
							// Notify client of TabPage Reordering (for each TabPage)?						// 1.0.003
							if (eventEachTab																// 1.0.003
							&& (idxNew != idxOld) 															// 1.0.003
							//&& (this.OnTabEvents != null)													// 1.0.003
							)																				// 1.0.003
							{																				// 1.0.003
								// Fire [.TabEvents.TabsReordered] event to client							// 1.0.003
								if (this.OnTabEvents != null)												// 1.0.003
								{																			// 1.0.003
									this.OnTabEvents(this, new TDHTabCtl.TabEventArgs(idxNew, idxOld, theTabPage, TDHTabCtl.TabEventArgs.TabEvents.TabsReordered));	// 1.0.003
								}																			// 1.0.003
							}																				// 1.0.003
							#endregion 
						}																					// 1.0.003
						alNewTabOrder.Clear();																// 1.0.003
						this.ResumeLayout(false);															// 1.0.003
						this.Invalidate();																	// 1.0.003
						#endregion 
					}																						// 1.0.003
					#region Notify client of TabPage Reordering?
					// Notify client of TabPage Reordering?													// 1.0.003
					if (continueReorder																		// 1.0.003
					&& !eventEachTab																		// 1.0.003
					//&& (this.OnTabsReordered != null)														// 1.0.003
					)																						// 1.0.003
					{																						// 1.0.003
						// Fire [.TabEvents.TabsReordered] event to client									// 1.0.003
						if (this.OnTabsReordered != null)													// 1.0.003
						{																					// 1.0.003
							this.OnTabsReordered(this, new TDHTabCtl.TabsReorderedEventArgs(intTabOrder));	// 1.0.003
						}																					// 1.0.003
					}																						// 1.0.003
					#endregion 
				}																							// 1.0.003
				frmReorder.Dispose();																		// 1.0.003
			}																								// 1.0.003
		}																									// 1.0.003

		private void cmnuTabRect_CloseAll_Click(object sender, System.EventArgs e)							// 1.0.001
		{																									// 1.0.001
			if( (this.TabCount > 1)																			// 1.0.001
			&& TabPage_ConfirmClose(-1)																		// 1.0.003
			)																								// 1.0.001
			{																								// 1.0.001
				TabPages_RemoveRange(false, 0, this.TabCount - 1);											// 1.0.012

				this.cmnuTabRect_TabRect_Idx = -1;															// 1.0.001
				this.cmnuTabRect_Built = false;																// 1.0.001
			}																								// 1.0.001
		}																									// 1.0.001

		private void cmnuTabRect_CloseAllBut_Click(object sender, System.EventArgs e)						// 1.0.001
		{																									// 1.0.001
			if( (this.TabCount > 1)																			// 1.0.001
			&& (this.cmnuTabRect_TabRect_Idx > -1)															// 1.0.001
			&& (this.cmnuTabRect_TabRect_Idx < this.TabCount) 												// 1.0.001
			&& TabPage_ConfirmClose(-1)																		// 1.0.003
			)																								// 1.0.001
			{																								// 1.0.001
				int idxNoClose = this.cmnuTabRect_TabRect_Idx;												// 1.0.001
				if (idxNoClose < this.TabCount - 1)															// 1.0.012
				{																							// 1.0.012
					TabPages_RemoveRange(false, idxNoClose + 1, this.TabCount - 1);							// 1.0.012
				}																							// 1.0.012
				if (idxNoClose > 0)																			// 1.0.012
				{																							// 1.0.012
					TabPages_RemoveRange(false, 0, idxNoClose - 1);											// 1.0.012
				}																							// 1.0.012

				this.cmnuTabRect_TabRect_Idx = -1;															// 1.0.001
				this.cmnuTabRect_Built = false;																// 1.0.001
			}																								// 1.0.001
		}																									// 1.0.001

		private void cmnuTabRect_CloseSelect_Click(object sender, System.EventArgs e)						// 1.0.001
		{																									// 1.0.001
			this.cmnuTabRect_TabRect_Idx = ((System.Windows.Forms.MenuItem)sender).Index;					// 1.0.001
			cmnuTabRect_CloseThis_Click(sender, e);															// 1.0.003
		}																									// 1.0.001

		private void cmnuTabRect_CloseThis_Click(object sender, System.EventArgs e)							// 1.0.001
		{																									// 1.0.001
			if( (this.TabCount > 1)																			// 1.0.001
			&& (this.cmnuTabRect_TabRect_Idx > -1)															// 1.0.001
			&& (this.cmnuTabRect_TabRect_Idx < this.TabCount) 												// 1.0.001
			&& TabPage_ConfirmClose(this.cmnuTabRect_TabRect_Idx)											// 1.0.003
			)																								// 1.0.001
			{																								// 1.0.001
				//TDHTabCtl.TdhTabPage theTabPage = this.TdhTabPages[cmnuTabRect_TabRect_Idx];				// 1.0.010
				System.Windows.Forms.TabPage theTabPage = this.TdhTabPages[true, this.cmnuTabRect_TabRect_Idx];	// 1.0.011

				// This check will have been done by [TabPage_ConfirmClose(cmnuTabRect_TabRect_Idx)]		// 1.0.011
				////if (theTabPage.TabAllowClose)															// 1.0.001
				//if( (this.TdhTabPages.IsTdhTabPage(this.cmnuTabRect_TabRect_Idx)							// 1.0.011
				//	&& ((TDHTabCtl.TdhTabPage)theTabPage).TabAllowClose)									// 1.0.011
				//|| (!this.TdhTabPages.IsTdhTabPage(this.cmnuTabRect_TabRect_Idx)							// 1.0.011
				//	&& this._tabsBase_AllowClose)															// 1.0.011
				//)																							// 1.0.011
				{																							// 1.0.001
					TabPage_Close(theTabPage, this.cmnuTabRect_TabRect_Idx);								// 1.0.001
				}																							// 1.0.001

				this.cmnuTabRect_TabRect_Idx = -1;															// 1.0.001
				this.cmnuTabRect_Built = false;																// 1.0.001
			}																								// 1.0.001
		}																									// 1.0.001
		#endregion 

		#region New and Over-ridden Fields/Properties 
// public new TDHTabCtl.TdhTabPageControls Controls
// 
		// public TDHTabCtl.TdhTabPageCollection TdhTabPages {get} {set}
		// [TabPages] Collection, either:
		//   public new TDHTabCtl.TdhTabPageCollection TabPages {get} {set}
		//   protected new TDHTabCtl.TdhTabPageCollection TabPages {get} {set}
		// public new System.Windows.Forms.TabControl.TabPageCollection TabPages {get}
		// 
		#region public new TDHTabCtl.TdhTabPageControls Controls {get}
//		private TDHTabCtl.TdhTabPageControls _Controls = null;											// 1.0.002
////[System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]	// 1.0.002
//[System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]	// 1.0.002
////[System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]		// 1.0.002
//		[System.ComponentModel.Browsable(false)]															// 1.0.002
//		public new TDHTabCtl.TdhTabPageControls Controls													// 1.0.002
//		{																									// 1.0.002
//			get { return this._Controls; }																	// 1.0.002
//		}																									// 1.0.002
		#endregion 

		private TDHTabCtl.TdhTabPageCollection _TabPages = null;											// 1.0.001
		#region public TDHTabCtl.TdhTabPageCollection TdhTabPages {get} {set}

		[System.ComponentModel.Editor(typeof(TdhTabPageCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]	// 1.0.020
		[System.ComponentModel.Category("Misc")]															// 1.0.001
//[System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]	// 1.0.001
[System.ComponentModel.DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]	// 1.0.001
		[System.ComponentModel.Description("The TdhTabPages in the TdhTabCtl.")]							// 1.0.001
		public TDHTabCtl.TdhTabPageCollection TdhTabPages													// 1.0.010
		{																									// 1.0.001
			get {return this._TabPages;}																	// 1.0.001
			set {this._TabPages = value;}																	// 1.0.002
		}																									// 1.0.001
		#endregion

		#region protected new TDHTabCtl.TdhTabPageCollection TabPages {get} {set}
//		// * To hide the [base.TabPages] Collection, define [this.TabPages] as:								// 1.0.010
//		//     [public new TDHTabCtl.TdhTabPageCollection TabPages]											// 1.0.010
//		//   . To then hide [this.TabPages] from the Visual Studio IDE, use the directive:					// 1.0.010
//		//     [System.ComponentModel.Browsable(false)]														// 1.0.010
//		// * The [base.TabPages] Collection isn't hidden when [this.TabPages] is defined as:				// 1.0.010
//		//     [protected new TDHTabCtl.TdhTabPageCollection TabPages]										// 1.0.010
//		//   However, [this.TabPages] will then not be visible to "external" classes,						// 1.0.010
//		//   meaning that the novel methods and properties aren't available.								// 1.0.010
//		//																									// 1.0.010
//		// * When the [base.TabPages] Collection isn't hidden												// 1.0.010
//		//   (and is thus visible in the Properties list in the Visual Studio IDE)							// 1.0.010
//		//   it can be used to add standard [TabPages] to the [TdhTabPageCollection]						// 1.0.010
//		// 
//		[System.ComponentModel.Category ("Misc")]															// 1.0.010
//		[System.ComponentModel.Description ("The TdhTabPages and/or TabPages in the TdhTabCtl.")]			// 1.0.010
//		[System.ComponentModel.Browsable(false)]															// 1.0.010

//		//public new TDHTabCtl.TdhTabPageCollection TabPages												// 1.0.010
//		protected new TDHTabCtl.TdhTabPageCollection TabPages												// 1.0.010
//		{																									// 1.0.010
//			get { return this._TabPages; }																	// 1.0.010
//			set { this._TabPages = value; }																	// 1.0.010
//		}																									// 1.0.010
		#endregion
		#region public new System.Windows.Forms.TabControl.TabPageCollection TabPages {get}

		// This definition of [TabPages] is tp allow us to attach the [TabPageCollectionEditor]				// 1.0.020

		[System.ComponentModel.Editor(typeof(TabPageCollectionEditor), typeof(System.Drawing.Design.UITypeEditor))]	// 1.0.020
		public new System.Windows.Forms.TabControl.TabPageCollection TabPages								// 1.0.020
		{																									// 1.0.020
			get {return base.TabPages;}																		// 1.0.020
			//set {base.TabPages = value;}																	// 1.0.020
		}																									// 1.0.020
		#endregion

		#endregion 

		#region Over-ridden Methods
		// protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
		// 
		// protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		// protected override void OnMouseLeave(System.EventArgs e)
		// protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		// 
		protected override void OnDrawItem(System.Windows.Forms.DrawItemEventArgs e)
		{
			// DON'T DO THIS IN THE [OnDrawItem()] METHOD!													// 1.0.001
			//if (this.gblRunModeIs_DesignMode)																// 1.0.001
			//{																								// 1.0.001
			//	base.OnDrawItem(e);																			// 1.0.001
			//	return;																						// 1.0.001
			//}																								// 1.0.001

			if( (e.Bounds != System.Drawing.RectangleF.Empty) 
			&& ((e.Index > -1) && (e.Index < this.TabCount))												// 1.0.001
			)
			{
				#region Create working variables 
				//System.Drawing.Point ptMouse = new System.Drawing.Point(									// 1.0.001
				//	this.PointToClient(System.Windows.Forms.Control.MousePosition).X,						// 1.0.001
				//	this.PointToClient(System.Windows.Forms.Control.MousePosition).Y						// 1.0.001
				//	);																						// 1.0.001
				System.Drawing.Point ptMouse = PointToClient(System.Windows.Forms.Control.MousePosition);	// 1.0.001
				bool asActive = false;																		// 1.0.003
				//if (e.Index == this.SelectedIndex)				// Is this the active TabPage?			// 1.0.003
				if (e.State == System.Windows.Forms.DrawItemState.Selected)	// Is this the active TabPage?	// 1.0.003
				{																							// 1.0.003
					asActive = true;																		// 1.0.003
				}																							// 1.0.003
				System.Drawing.RectangleF tabRectDraw = TabRect_ByIdx(e.Index);								// 1.0.001
				#endregion 
				e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
				TabRect_DrawTabRect(																		// 1.0.003
					this, ptMouse,																			// 1.0.003
					//this.TabPages[e.Index],																// 1.0.003
					this.TdhTabPages[true, e.Index],														// 1.0.010
					e.Index, asActive,																		// 1.0.003
					e.Graphics, tabRectDraw 																// 1.0.003
					);																						// 1.0.003
			}

			// Use [_lastTabRect/_lastTabRectIdx] to redraw the last [TabRect] the mouse was over			// 1.0.005
			this._lastTabRectIdx = -1;																		// 1.0.005
			this._lastTabRect = System.Drawing.RectangleF.Empty;											// 1.0.005

			base.OnDrawItem(e);																				// 1.0.001
		}
      

		protected override void OnMouseDown(System.Windows.Forms.MouseEventArgs e)
		{
			//if (this.DesignMode)
			if (this.gblRunModeIs_DesignMode)																// 1.0.001
			{
				//base.OnMouseDown(e);																		// 1.0.001
				return;
			}
			base.OnMouseDown(e);																			// 1.0.001

			#region Create working variables 
			System.Drawing.Point ptMouse = new System.Drawing.Point(e.X, e.Y);	// the mouse location 
			System.Drawing.RectangleF tabRectDraw = System.Drawing.RectangleF.Empty;						// 1.0.010
			int idxTabRect = this.SelectedIndex;			// RightClick doesn't set [this.SelectedIndex]	// 1.0.001

			// Determine the "ClientRectangle" of the clicked TabRect										// 1.0.001
			// -- [this.SelectedIndex] isn't set by a RightClick, so it may not have the correct value.		// 1.0.001
			if (e.Button == System.Windows.Forms.MouseButtons.Left)		// LeftClick?						// 1.0.010
			{																								// 1.0.010
				tabRectDraw = TabRect_ByIdx(this.SelectedIndex);											// 1.0.001
			}																								// 1.0.010
			// If the TabRect defined by [this.SelectedIndex] doesn't contain the mouse location,			// 1.0.001
			// try to find the TabRect which does contain the mouse location								// 1.0.001
			if( (e.Button != System.Windows.Forms.MouseButtons.Left)	// RightClick?						// 1.0.010
			|| !tabRectDraw.Contains(ptMouse) )				// Is the mouse location outside the TabRect?	// 1.0.001
			{																								// 1.0.001
				idxTabRect = -1;																			// 1.0.001
				for (int idx = 0; idx < this.TabCount; idx++)												// 1.0.001
				{																							// 1.0.001
					tabRectDraw = TabRect_ByIdx(idx);														// 1.0.001
					if (tabRectDraw.Contains(ptMouse))														// 1.0.001
					{																						// 1.0.001
						idxTabRect = idx;																	// 1.0.001
						break;																				// 1.0.001
					}																						// 1.0.001
				}																							// 1.0.001
			}																								// 1.0.001

			this.cmnuTabRect_TabRect_Idx = idxTabRect;														// 1.0.010
			#endregion 

			#region Was a LeftClick made within the "Close pseudo-Button" Rectangle?
			// Determine the Rectangle of the "Close pseudo-Button"											// 1.0.001
			System.Drawing.RectangleF tabRectClose = TabRect_CloseButton(tabRectDraw);						// 1.0.001
			if( (this.TabCount > 1) 									// Don't close last open TabPage	// 1.0.001
			&& (e.Button == System.Windows.Forms.MouseButtons.Left)		// LeftClick?						// 1.0.001
			&&( this.TdhTabPages.IsTdhTabPage(idxTabRect)													// 1.0.010
				&& this.CanDrawCloseButton(idxTabRect) )													// 1.0.001
			&& tabRectClose.Contains(ptMouse)							//   on the "Close pseudo-Button"?
			)
			{
				if (this.TdhTabPages[this.SelectedIndex].TabAllowClose 										// 1.0.010
				&& TabPage_ConfirmClose(this.SelectedIndex) )												// 1.0.003
				{																							// 1.0.001
					//this.cmnuTabRect_TabRect_Idx = idxTabRect;											// 1.0.001
					this.cmnuTabRect_TabRect_Idx = this.SelectedIndex;										// 1.0.001
					TDHTabCtl.TdhTabPage theTabPage = this.TdhTabPages[this.cmnuTabRect_TabRect_Idx];		// 1.0.010
					TabPage_Close(theTabPage, this.cmnuTabRect_TabRect_Idx);								// 1.0.001
				}																							// 1.0.001
			}
			#endregion 
			else																							// 1.0.001
			#region Perhaps we're going to .Show() the ContextMenu?
			{
				// Perhaps we're going to .Show() the ContextMenu?
				if (idxTabRect > -1)						// Did we find the clicked TabRect?				// 1.0.001
				{																							// 1.0.001
					// Determine the Rectangle of the "ContextMenu pseudo-Button"							// 1.0.001
					System.Drawing.RectangleF tabRectMenu = TabRect_MenuButton(tabRectDraw, idxTabRect);	// 1.0.001

					if (e.Button == System.Windows.Forms.MouseButtons.Right)								// 1.0.001
					{																						// 1.0.001
						#region [if .TabAllowContextMenu] Position the ContextMenu based on mouse location
						if (this._tabsAllowContextMenu														// 1.0.010
						&& (!this.TdhTabPages.IsTdhTabPage(idxTabRect)										// 1.0.010
							|| this.TdhTabPages[idxTabRect].TabAllowContextMenu								// 1.0.010
							)																				// 1.0.010
						)																					// 1.0.010
						{																					// 1.0.001
							// Reset [tabRectMenu] based on the mouse location								// 1.0.001
							// -- this determines the location to position the ContextMenu					// 1.0.001
							tabRectMenu = new System.Drawing.RectangleF(									// 1.0.001
								ptMouse.X, 4,																// 1.0.001
								tabRectDraw.Width - 3, tabRectDraw.Height - 5);								// 1.0.001
						}																					// 1.0.001
						else																				// 1.0.001
						{																					// 1.0.001
							idxTabRect = -1;				// Don't .Show() the ContextMenu				// 1.0.001
						}																					// 1.0.001
						#endregion 
					}																						// 1.0.001
					else																					// 1.0.001
					if (CanDrawMenuButton(idxTabRect))		// a LeftClick; Is MenuButton on this TabPage?	// 1.0.001
					{																						// 1.0.001
						#region Position the ContextMenu beneath the "ContextMenu pseudo-Button"
						// Is the mouse location within the "ContextMenu pseudo-Button" Rectangle			// 1.0.001
						if (!tabRectMenu.Contains(ptMouse))	// Is the mouse location within the MenuButton?	// 1.0.001
						{																					// 1.0.001
							idxTabRect = -1;				// No											// 1.0.001
						}																					// 1.0.001
						#endregion 
					}																						// 1.0.001
					else																					// 1.0.001
					{																						// 1.0.001
						idxTabRect = -1;					// Don't .Show() the ContextMenu				// 1.0.001
					}																						// 1.0.001

					#region .Show() the ContextMenu? 
					// Was a RightClick made, or a LeftClick made within the "ContextMenu pseudo-Button" Rectangle?	// 1.0.001
					if (idxTabRect > -1)					// Do we have a good location for the ContextMenu?// 1.0.001
					{																						// 1.0.001
						cmnuTabRect_Show(																	// 1.0.001
							new System.Drawing.Point((int)tabRectMenu.X, (int)(tabRectMenu.Y + tabRectMenu.Height)), // 1.0.001
							idxTabRect																		// 1.0.001
							);																				// 1.0.001
					}																						// 1.0.001
					#endregion 
				}																							// 1.0.001
			}
			#endregion 
		}																									// 1.0.001

		protected override void OnMouseLeave(System.EventArgs e)
		{
			if (this.gblRunModeIs_DesignMode)																// 1.0.001
			{																								// 1.0.001
				base.OnMouseLeave(e);																		// 1.0.001
				return;																						// 1.0.001
			}																								// 1.0.001

			#region Create working variables 
			//System.Drawing.Point ptMouse = new System.Drawing.Point(										// 1.0.001
			//	this.PointToClient(System.Windows.Forms.Control.MousePosition).X,							// 1.0.001
			//	this.PointToClient(System.Windows.Forms.Control.MousePosition).Y							// 1.0.001
			//	);																							// 1.0.001
			System.Drawing.Point ptMouse = PointToClient(System.Windows.Forms.Control.MousePosition);		// 1.0.001
			System.Drawing.Graphics gfx = this.CreateGraphics();
			gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			#endregion 

			#region Try to redraw Buttons on the TabRect indicated by [this._lastTabRect / this._lastTabRectIdx]
			if( (this._lastTabRectIdx > -1) 																// 1.0.001
			&& (this._lastTabRectIdx < this.TabCount) 														// 1.0.005
			&& (this._lastTabRect != System.Drawing.RectangleF.Empty) )										// 1.0.001
			{																								// 1.0.001
				TabRect_DrawButtons(																		// 1.0.001
					this, ptMouse,																			// 1.0.001
					gfx, 																					// 1.0.001
					this._lastTabRect, this._lastTabRectIdx													// 1.0.001
					);																						// 1.0.001
			}																								// 1.0.001
			#endregion 
			else																							// 1.0.001
			#region Redraw Buttons on all TabRects
			{																								// 1.0.001
				System.Drawing.RectangleF tabRectDraw = System.Drawing.RectangleF.Empty;
				for (int nIndex = 0; nIndex < this.TabCount; nIndex++)
				{
					tabRectDraw = (System.Drawing.RectangleF)this.GetTabRect(nIndex);
					//tabRectDraw = TabRect_ByIdx(nIndex);													// 1.0.001

					#region Draw Buttons the TabRect
					TabRect_DrawButtons(																	// 1.0.001
						this, ptMouse,																		// 1.0.001
						gfx, 																				// 1.0.001
						tabRectDraw, nIndex																	// 1.0.001
						);																					// 1.0.001
					#endregion 
				}
			}																								// 1.0.001
			#endregion 

			gfx.Dispose();
			this._lastTabRectIdx = -1;																		// 1.0.001
			this._lastTabRect = System.Drawing.RectangleF.Empty;											// 1.0.001

			base.OnMouseLeave(e);																			// 1.0.001
		}
       
		protected override void OnMouseMove(System.Windows.Forms.MouseEventArgs e)
		{
			//if (this.DesignMode)
			if (this.gblRunModeIs_DesignMode)																// 1.0.001
			{
				base.OnMouseMove(e);																		// 1.0.001
				return;
			}

			#region Create working variables 
			System.Drawing.Point ptMouse = new System.Drawing.Point(e.X, e.Y);	// the mouse location
			System.Drawing.RectangleF tabRectDraw = System.Drawing.RectangleF.Empty;

			System.Drawing.Graphics gfx = this.CreateGraphics();
			gfx.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias;
			#endregion 

			for (int nIndex = 0; nIndex < this.TabCount; nIndex++)
			{
				//System.Drawing.RectangleF tabRectDraw = TabRect_ByIdx(nIndex);							// 1.0.001
				tabRectDraw = TabRect_ByIdx(nIndex);														// 1.0.001
				if (tabRectDraw.Contains(ptMouse))			// Is mouse location within this TabRect?		// 1.0.001
				{																							// 1.0.001
					#region Redraw Buttons on the TabRect indicated by [this._lastTabRect / this._lastTabRectIdx]
					if( (this._lastTabRectIdx > -1) 														// 1.0.001
					&& (this._lastTabRectIdx < this.TabCount) 												// 1.0.005
					&& (this._lastTabRectIdx != nIndex) 													// 1.0.001
					&& (this._lastTabRect != System.Drawing.RectangleF.Empty) )								// 1.0.001
					{																						// 1.0.001
						TabRect_DrawButtons(																// 1.0.001
							this, ptMouse,																	// 1.0.001
							gfx,																			// 1.0.001
							this._lastTabRect, this._lastTabRectIdx											// 1.0.001
							);																				// 1.0.001
					}																						// 1.0.001
					#endregion 

					#region Draw Buttons on this TabRect
					TabRect_DrawButtons(																	// 1.0.001
						this, ptMouse,																		// 1.0.001
						gfx,																				// 1.0.001
						tabRectDraw, nIndex																	// 1.0.001
						);																					// 1.0.001
					#endregion 
					this._lastTabRect = tabRectDraw; 														// 1.0.001
					this._lastTabRectIdx = nIndex; 															// 1.0.001
				}																							// 1.0.001
			}
			gfx.Dispose();

			base.OnMouseMove(e);																			// 1.0.001
		}
		#endregion 

		#region Novel Public Properties
		// public bool TabsBase_AllowClose {get} {set}
		// public bool TabsBase_ConfirmOnClose {get} {set}
		// public bool TabsBase_ContextMenuAllowOpen {get} {set}
		// 
		// public bool TabsAllowClose {get} {set}
		// public bool TabsAllowContextMenu {get} {set}
		// public bool TabsConfirmOnClose {get} {set}
		// public bool TabsContextMenuAllowClose {get} {set}
		// public bool TabsContextMenuAllowOpen {get} {set}
		// public bool TabsContextMenuAllowRename {get} {set}
		// public bool TabsContextMenuAllowReorder {get} {set}
		// public bool TabsShowCloseButton {get} {set}
		// public bool TabsShowMenuButton {get} {set}
		// 
		private bool _tabsBase_AllowClose = false;															// 1.0.011
		[System.ComponentModel.Category("Behavior")]														// 1.0.011
		[System.ComponentModel.Browsable(true)]																// 1.0.011
		[System.ComponentModel.Description("Determines whether to allow closing any (standard) TabPage of the TdhTabCtl control.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "false")]											// 1.0.011
		public bool TabsBase_AllowClose																		// 1.0.011
		{																									// 1.0.011
			get {return this._tabsBase_AllowClose;}															// 1.0.011
			set {this._tabsBase_AllowClose = value;}														// 1.0.011
		}																									// 1.0.011


		private bool _tabsBase_ConfirmOnClose = true;														// 1.0.011
		[System.ComponentModel.Category("Behavior")]														// 1.0.011
		[System.ComponentModel.Browsable(true)]																// 1.0.011
		[System.ComponentModel.Description("Determines whether confirmation is required before closing a (standard) TabPage of the TdhTabCtl control.")]	// 1.0.011
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.011
		public bool TabsBase_ConfirmOnClose																	// 1.0.011
		{																									// 1.0.011
			get {return this._tabsBase_ConfirmOnClose;}														// 1.0.011
			set {this._tabsBase_ConfirmOnClose = value;}													// 1.0.011
		}																									// 1.0.011


		private bool _tabsBase_ContextMenuAllowOpen = false;													// 1.0.011
		[System.ComponentModel.Category("Behavior")]														// 1.0.011
		[System.ComponentModel.Browsable(true)]																// 1.0.011
		[System.ComponentModel.Description("Determines whether the TdhTabPage-ContextMenu will show the 'Open (standard) TabPage' MenuItem.")]	// 1.0.011
		[System.ComponentModel.DefaultValue(typeof(bool), "false")]											// 1.0.011
		public bool TabsBase_ContextMenuAllowOpen															// 1.0.011
		{																									// 1.0.011
			get {return this._tabsBase_ContextMenuAllowOpen;}												// 1.0.011
			set {this._tabsBase_ContextMenuAllowOpen = value;}												// 1.0.011
		}																									// 1.0.011


		private bool _tabsAllowClose = true;																// 1.0.001
		[System.ComponentModel.Category("Behavior")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
//[System.ComponentModel.EditorBrowsable(System.ComponentModel.EditorBrowsableState.Always)]			// 1.0.001
		[System.ComponentModel.Description("Determines whether to allow closing any TdhTabPage (or standard TabPage) of the TdhTabCtl control.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabsAllowClose																			// 1.0.001
		{																									// 1.0.001
			get {return this._tabsAllowClose;}																// 1.0.001
			set {this._tabsAllowClose = value;}																// 1.0.001
		}																									// 1.0.001


		private bool _tabsAllowContextMenu = true;															// 1.0.001
		[System.ComponentModel.Category("Behavior")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether ContextMenus may be displayed by right-clicking the Tab of a TdhTabPage (or standard TabPage) of the TdhTabCtl control.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabsAllowContextMenu																	// 1.0.001
		{																									// 1.0.001
			get	{return this._tabsAllowContextMenu;}														// 1.0.001
			set {this._tabsAllowContextMenu = value;}														// 1.0.001
		}																									// 1.0.001


		private bool _tabsConfirmOnClose = true;
		[System.ComponentModel.Category("Behavior")]														// 1.0.000
		[System.ComponentModel.Browsable(true)]																// 1.0.000
		[System.ComponentModel.Description("Determines whether confirmation is required before closing a TdhTabPage (or standard TabPage) of the TdhTabCtl control.")]	// 1.0.000
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.000
		public bool TabsConfirmOnClose
		{
			get {return this._tabsConfirmOnClose;}
			set {this._tabsConfirmOnClose = value;}
		}


		private bool _tabsContextMenuAllowClose = true;														// 1.0.001
		[System.ComponentModel.Category("Behavior")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether the TdhTabPage-ContextMenu will show the 'Close-Tabs' MenuItems.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabsContextMenuAllowClose																// 1.0.001
		{																									// 1.0.001
			get {return this._tabsContextMenuAllowClose;}													// 1.0.001
			set {this._tabsContextMenuAllowClose = value;}													// 1.0.001
		}																									// 1.0.001


		private bool _tabsContextMenuAllowOpen = true;														// 1.0.001
		[System.ComponentModel.Category("Behavior")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether the TdhTabPage-ContextMenu will show the 'Open TdhTabPage' MenuItem.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabsContextMenuAllowOpen																// 1.0.001
		{																									// 1.0.001
			get {return this._tabsContextMenuAllowOpen;}													// 1.0.001
			set {this._tabsContextMenuAllowOpen = value;}													// 1.0.001
		}																									// 1.0.001


		private bool _tabsContextMenuAllowRename = true;													// 1.0.001
		[System.ComponentModel.Category("Behavior")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether the TdhTabPage-ContextMenu will show the 'Rename-Tab' MenuItem.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabsContextMenuAllowRename																// 1.0.001
		{																									// 1.0.001
			get {return this._tabsContextMenuAllowRename;}													// 1.0.001
			set {this._tabsContextMenuAllowRename = value;}													// 1.0.001
		}																									// 1.0.001


		private bool _tabsContextMenuAllowReorder = true;													// 1.0.003
		[System.ComponentModel.Category("Behavior")]														// 1.0.003
		[System.ComponentModel.Browsable(true)]																// 1.0.003
		[System.ComponentModel.Description("Determines whether the TdhTabPage-ContextMenu will show the 'Reorder-Tabs' MenuItem.")]	// 1.0.003
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.003
		public bool TabsContextMenuAllowReorder																// 1.0.003
		{																									// 1.0.003
			get {return this._tabsContextMenuAllowReorder;}													// 1.0.003
			set {this._tabsContextMenuAllowReorder = value;}												// 1.0.003
		}																									// 1.0.003


		private bool _tabsShowCloseButton = true;															// 1.0.001
		[System.ComponentModel.Category("Appearance")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether a Close Button may be displayed on any TdhTabPage of the TdhTabCtl control.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabsShowCloseButton																		// 1.0.001
		{																									// 1.0.001
			get	{return this._tabsShowCloseButton;}															// 1.0.001
			set {this._tabsShowCloseButton = value;}														// 1.0.001
		}																									// 1.0.001


		private bool _tabsShowMenuButton = true;															// 1.0.001
		[System.ComponentModel.Category("Appearance")]														// 1.0.001
		[System.ComponentModel.Browsable(true)]																// 1.0.001
		[System.ComponentModel.Description("Determines whether a Menu Button may be displayed on any TdhTabPage of the TdhTabCtl control.")]	// 1.0.001
		[System.ComponentModel.DefaultValue(typeof(bool), "true")]											// 1.0.001
		public bool TabsShowMenuButton																		// 1.0.001
		{																									// 1.0.001
			get	{return this._tabsShowMenuButton;}															// 1.0.001
			set {this._tabsShowMenuButton = value;}															// 1.0.001
		}																									// 1.0.001
		#endregion 

		#region Novel Public Methods
		// public bool TabPages_Remove(bool overridePermission, TDHTabCtl.TdhTabPage theTabPage)
		// public bool TabPages_Remove(bool overridePermission, System.Windows.Forms.TabPage theTabPage)
		// public bool TabPages_RemoveAt(bool overridePermission, int index)
		// public bool TabPages_RemoveRange(bool overridePermission, int indexStart, int indexEnd)
		// 
		public bool TabPages_Remove(bool overridePermission, TDHTabCtl.TdhTabPage theTabPage)				// 1.0.012
		{																									// 1.0.012
			return TabPages_Remove(overridePermission, (System.Windows.Forms.TabPage)theTabPage);			// 1.0.012
		}																									// 1.0.012

		public bool TabPages_Remove(bool overridePermission, System.Windows.Forms.TabPage theTabPage)		// 1.0.012
		{																									// 1.0.012
			if( (theTabPage != null)																		// 1.0.012
			&& (base.Contains(theTabPage))																	// 1.0.012
			)																								// 1.0.012
			{																								// 1.0.012
				bool isTdhTabPage = (theTabPage.GetType() == typeof(TDHTabCtl.TdhTabPage))					// 1.0.012
					|| theTabPage.GetType().IsSubclassOf(typeof(TDHTabCtl.TdhTabPage));						// 1.0.012
				if (overridePermission																		// 1.0.012
				|| (isTdhTabPage																			// 1.0.012
					&& ((TDHTabCtl.TdhTabPage)theTabPage).TabAllowClose)									// 1.0.012
				|| (!isTdhTabPage																			// 1.0.012
					&& this._tabsBase_AllowClose)															// 1.0.012
				)																							// 1.0.012
				{																							// 1.0.002
					int index = -1;																			// 1.0.012
					for (int idx = 0; idx < this.TabCount; idx++)											// 1.0.012
					{																						// 1.0.01
						System.Windows.Forms.TabPage tempTabPage = this.TdhTabPages[true, idx];				// 1.0.012
						if (tempTabPage.Equals(theTabPage))													// 1.0.012
						{																					// 1.0.012
							index = idx;																	// 1.0.012
							break;																			// 1.0.012
						}																					// 1.0.012
					}																						// 1.0.012

					if (index > -1)																			// 1.0.012
					{																						// 1.0.012
						TabPage_Close(theTabPage, index);													// 1.0.002
						return true;																		// 1.0.012
					}																						// 1.0.012
				}																							// 1.0.002
			}																								// 1.0.012

			return false;																					// 1.0.012
		}																									// 1.0.012

		public bool TabPages_RemoveAt(bool overridePermission, int index)									// 1.0.012
		{																									// 1.0.012
			if( (index < 0)																					// 1.0.012
			|| (index >= this.TabCount) )																	// 1.0.012
			{																								// 1.0.012
				return false;																				// 1.0.012
			}																								// 1.0.012

			System.Windows.Forms.TabPage theTabPage = this.TdhTabPages[true, index];						// 1.0.011
			bool isTdhTabPage = this.TdhTabPages.IsTdhTabPage(index);										// 1.0.012
			if (overridePermission																			// 1.0.012
			|| (isTdhTabPage																				// 1.0.012
				&& ((TDHTabCtl.TdhTabPage)theTabPage).TabAllowClose)										// 1.0.011
			|| (!isTdhTabPage																				// 1.0.012
				&& this._tabsBase_AllowClose)																// 1.0.011
			)																								// 1.0.011
			{																								// 1.0.001
				TabPage_Close(theTabPage, index);															// 1.0.001
			}																								// 1.0.001

			return true;																					// 1.0.012
		}																									// 1.0.012

		public bool TabPages_RemoveRange(bool overridePermission, int indexStart, int indexEnd)				// 1.0.012
		{																									// 1.0.012
			//int idxStart = System.Math.Min(indexStart, indexEnd);											// 1.0.012
			int idxStart = System.Math.Max(System.Math.Min(indexStart, indexEnd), 0);						// 1.0.012
			//int idxEnd = System.Math.Max(indexStart, indexEnd);											// 1.0.012
			int idxEnd = System.Math.Min(System.Math.Max(indexStart, indexEnd), this.TabCount - 1);			// 1.0.012
			if (idxEnd < idxStart)																			// 1.0.012
			{																								// 1.0.012
				return false;																				// 1.0.012
			}																								// 1.0.012

			for (int idx = idxEnd; idx >= idxStart; idx--)													// 1.0.012
			{																								// 1.0.001
				System.Windows.Forms.TabPage theTabPage = this.TdhTabPages[true, idx];						// 1.0.011
				bool isTdhTabPage = this.TdhTabPages.IsTdhTabPage(idx);										// 1.0.012
				if (overridePermission																		// 1.0.012
				|| (isTdhTabPage																			// 1.0.012
					&& ((TDHTabCtl.TdhTabPage)theTabPage).TabAllowClose)									// 1.0.011
				|| (!isTdhTabPage																			// 1.0.012
					&& this._tabsBase_AllowClose)															// 1.0.011
				)																							// 1.0.011
				{																							// 1.0.001
					TabPage_Close(theTabPage, idx);															// 1.0.001
				}																							// 1.0.001
			}																								// 1.0.001

			return true;																					// 1.0.012
		}																									// 1.0.012
		#endregion 

		#region Class Private Functions/Methods
		// private void cmnuTabRect_Build()
		// private void cmnuTabRect_Show(System.Drawing.Point ptMenu, int idxTab)
		// 
		// private bool CanDrawCloseButton(int idxTab)
		// private bool CanDrawMenuButton(int idxTab)
		// 
		// private bool TabPage_ConfirmClose(int idxTab)
		// private void TabPage_Close(System.Windows.Forms.TabPage theTabPage, int idxTab)
		// 
		// private void TabPage_Rename(System.Windows.Forms.TabPage theTabPage, int idxTab)
		// private void TabPage_Renamed(object sender, TDHControls.TDHTabCtl.TDHEditBox.EditEventArgs editArgs)
		// 
		// internal System.Drawing.RectangleF TabRect_ByIdx(int idxTab)
		// internal int TabRect_FindIdx(System.Drawing.RectangleF tabRectFind)
		// internal System.Drawing.RectangleF TabRect_CloseButton(System.Drawing.RectangleF tabRect)
		// internal System.Drawing.RectangleF TabRect_MenuButton(System.Drawing.RectangleF tabRect, int idxRect)
		// 
		internal bool cmnuTabRect_Built = false;															// 1.0.001
		private int cmnuTabRect_TabRect_Idx = -1;															// 1.0.001
		private void cmnuTabRect_Build()																	// 1.0.001
		{																									// 1.0.001
			if (!this.gblRunModeIs_DesignMode)																// 1.0.001
			{																								// 1.0.001
				this.cmnuTabRect.MenuItems.Clear();															// 1.0.001
				#region Build the [cmnuTabRect_CloseSelect] ContextMenu
				cmnuTabRect_CloseSelect.MenuItems.Clear();													// 1.0.001
				if (this._tabsContextMenuAllowClose)															// 1.0.003
				{																							// 1.0.003
					for (int idx = 0; idx < this.TabCount; idx++)											// 1.0.001
					{																						// 1.0.001
						System.Windows.Forms.MenuItem cmnuItem = new System.Windows.Forms.MenuItem();		// 1.0.001
						//cmnuItem.Text = this.TabPages[idx].Text.Trim();									// 1.0.001
						cmnuItem.Text = this.TdhTabPages[true, idx].Text.Trim();							// 1.0.010
						cmnuItem.Index = idx;																// 1.0.001
						if( (this.TabCount > 1)																// 1.0.001
						&& this._tabsAllowClose																// 1.0.010
						&&( (this.TdhTabPages.IsTdhTabPage(idx)												// 1.0.010
								&& this.TdhTabPages[idx].TabAllowClose) 									// 1.0.010
							|| (!this.TdhTabPages.IsTdhTabPage(idx)											// 1.0.011
								&& this._tabsBase_AllowClose) 												// 1.0.011
							)																				// 1.0.010
						)																					// 1.0.001
						{																					// 1.0.001
							cmnuItem.Enabled = true;														// 1.0.001
							cmnuItem.Click += new System.EventHandler(this.cmnuTabRect_CloseSelect_Click);	// 1.0.001
						}																					// 1.0.001
						else																				// 1.0.001
						{																					// 1.0.001
							cmnuItem.Enabled = false;														// 1.0.001
						}																					// 1.0.001
						cmnuTabRect_CloseSelect.MenuItems.Add(cmnuItem);									// 1.0.001
					}																						// 1.0.001
				}																							// 1.0.003
				#endregion 
				this.cmnuTabRect.MenuItems.AddRange(														// 1.0.001
					new System.Windows.Forms.MenuItem[]														// 1.0.001
						{																					// 1.0.001
							this.cmnuTabRect_New, 															// 1.0.001
							this.cmnuTabRect_New_TabsBase,													// 1.0.011
							this.cmnuTabRect_Rename,														// 1.0.001
							this.cmnuTabRect_Separator01,													// 1.0.001
							this.cmnuTabRect_Reorder,														// 1.0.003
							this.cmnuTabRect_Separator09,													// 1.0.003
							this.cmnuTabRect_CloseThis,														// 1.0.001
							this.cmnuTabRect_CloseSelect,													// 1.0.001
							this.cmnuTabRect_CloseAllBut,													// 1.0.001
							this.cmnuTabRect_CloseAll,														// 1.0.001
							this.cmnuTabRect_Separator99													// 1.0.001
						}																					// 1.0.001
					);																						// 1.0.001
				this.cmnuTabRect_Built = true;																// 1.0.001
			}																								// 1.0.001
		}																									// 1.0.001

		private void cmnuTabRect_Show(System.Drawing.Point ptMenu, int idxTab)								// 1.0.001
		{																									// 1.0.001
			if (this.gblRunModeIs_DesignMode)																// 1.0.001
			{																								// 1.0.001
				return;																						// 1.0.001
			}																								// 1.0.001

			this.cmnuTabRect_TabRect_Idx = idxTab;															// 1.0.001
			#region (Conditionally) Build/Show the [cmnuTabRect_Work] ContextMenu
			if( (idxTab > -1)																				// 1.0.001
			&& (idxTab < this.TabCount)																		// 1.0.001
			&& (this._tabsAllowContextMenu																	// 1.0.011
				&& (!this.TdhTabPages.IsTdhTabPage(idxTab)													// 1.0.011
					|| this.TdhTabPages[idxTab].TabAllowContextMenu) 										// 1.0.011
				)																							// 1.0.011
			&& (ptMenu != System.Drawing.Point.Empty)														// 1.0.001
			)																								// 1.0.001
			{																								// 1.0.001
				if (!this.cmnuTabRect_Built)																// 1.0.001
				{																							// 1.0.001
					cmnuTabRect_Build();																	// 1.0.001
				}																							// 1.0.001
				#region Specify .Text of TdhTabPage-ContextMenu [cmnuTabRect.MenuItems[].Text]
				this.cmnuTabRect_Rename.Text = "Rename '"													// 1.0.003
					+ this.TabPages[idxTab].Text.Trim()														// 1.0.003
					//+ this.TdhTabPages[true, idxTab].Text.Trim() 											// 1.0.010
					+"'";																					// 1.0.003
				//this.cmnuTabRect_Reorder.Text = "ReOrder TabPages";										// 1.0.003
				this.cmnuTabRect_CloseThis.Text = "Close '"													// 1.0.003
					+ this.TabPages[idxTab].Text.Trim()														// 1.0.003
					//+ this.TdhTabPages[true, idxTab].Text.Trim() 											// 1.0.010
					+"'";																					// 1.0.003
				this.cmnuTabRect_CloseAllBut.Text = "Close All Tabs (Except '"								// 1.0.003
					+ this.TabPages[idxTab].Text.Trim()														// 1.0.003
					//+ this.TdhTabPages[true, idxTab].Text.Trim() 											// 1.0.010
					+"')";																					// 1.0.003
				//this.cmnuTabRect_CloseAll.Text = "Close All Tabs (Except ...)";							// 1.0.003
				#endregion 

//this.TabsAllowClose = false;					// TEST
//this.TabsBase_AllowClose = true;				// TEST
				#region Enable/Disable [cmnuTabRect_Reorder] and [cmnuTabRect_CloseThis] and [cmnuTabRect_CloseX]
				if( (this.TabCount > 1)																		// 1.0.003
				&& this._tabsContextMenuAllowReorder)														// 1.0.003
				{																							// 1.0.003
					this.cmnuTabRect_Reorder.Enabled = true;												// 1.0.003
				}																							// 1.0.003
				else																						// 1.0.003
				{																							// 1.0.003
					this.cmnuTabRect_Reorder.Enabled = false;												// 1.0.003
				}																							// 1.0.003

				if( (this.TabCount > 1)																		// 1.0.001
				&& this._tabsAllowClose																		// 1.0.010
				&& this._tabsContextMenuAllowClose															// 1.0.001
				&&( (this.TdhTabPages.IsTdhTabPage(idxTab) 													// 1.0.010
						&& this.TdhTabPages[idxTab].TabAllowClose) 											// 1.0.010
					|| (!this.TdhTabPages.IsTdhTabPage(idxTab)												// 1.0.011
						&& this._tabsBase_AllowClose) 														// 1.0.011
					)																						// 1.0.010
				)																							// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_CloseThis.Enabled = true;												// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_CloseThis.Enabled = false;												// 1.0.001
				}																							// 1.0.001

				if( (this.TabCount > 1)																		// 1.0.003
				&& this._tabsAllowClose																		// 1.0.010
				&& this._tabsContextMenuAllowClose															// 1.0.003
				)																							// 1.0.003
				{																							// 1.0.003
					this.cmnuTabRect_CloseSelect.Enabled = true;											// 1.0.003
					this.cmnuTabRect_CloseAllBut.Enabled = true;											// 1.0.003
					this.cmnuTabRect_CloseAll.Enabled = true;												// 1.0.003
				}																							// 1.0.003
				else																						// 1.0.003
				{																							// 1.0.003
					this.cmnuTabRect_CloseSelect.Enabled = false;											// 1.0.003
					this.cmnuTabRect_CloseAllBut.Enabled = false;											// 1.0.003
					this.cmnuTabRect_CloseAll.Enabled = false;												// 1.0.003
				}																							// 1.0.003
				#endregion 
//this.TabsContextMenuAllowOpen = false;		// TEST
//this.TabsBase_ContextMenuAllowOpen = false;	// TEST
//this.TabsContextMenuAllowRename = false;		// TEST
				#region Set visibility of TdhTabPage-ContextMenu OpenItems [cmnuTabRect.MenuItems]
				if (this._tabsContextMenuAllowOpen)															// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_New.Visible = true;													// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_New.Visible = false;													// 1.0.001
				}																							// 1.0.001

				if (this._tabsBase_ContextMenuAllowOpen)													// 1.0.011
				{																							// 1.0.011
					this.cmnuTabRect_New_TabsBase.Visible = true;											// 1.0.011
					this.cmnuTabRect_New.Text = "Open New Tab (Enhanced TabPage)";							// 1.0.011
				}																							// 1.0.011
				else																						// 1.0.011
				{																							// 1.0.011
					this.cmnuTabRect_New_TabsBase.Visible = false;											// 1.0.011
					this.cmnuTabRect_New.Text = "Open New Tab";												// 1.0.011
				}																							// 1.0.011

				if (this._tabsContextMenuAllowRename)														// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_Rename.Visible = true;													// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_Rename.Visible = false;												// 1.0.001
				}																							// 1.0.001

				if (this._tabsContextMenuAllowOpen															// 1.0.001
				|| this._tabsBase_ContextMenuAllowOpen 														// 1.0.011
				|| this._tabsContextMenuAllowRename															// 1.0.001
				)																							// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_Separator01.Visible = true;											// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_Separator01.Visible = false;											// 1.0.001
				}																							// 1.0.001
				#endregion 
//this.TabsContextMenuAllowReorder = false;		// TEST
				#region Set visibility of TdhTabPage-ContextMenu ReorderItem [cmnuTabRect.MenuItems]
				if (this._tabsContextMenuAllowReorder)														// 1.0.003
				{																							// 1.0.003
					this.cmnuTabRect_Reorder.Visible = true;												// 1.0.003
					this.cmnuTabRect_Separator09.Visible = true;											// 1.0.003
				}																							// 1.0.003
				else																						// 1.0.003
				{																							// 1.0.003
					this.cmnuTabRect_Reorder.Visible = false;												// 1.0.003
					this.cmnuTabRect_Separator09.Visible = false;											// 1.0.003
				}																							// 1.0.003
				#endregion 
//this.TabsContextMenuAllowClose = false;		// TEST
				#region Set visibility of TdhTabPage-ContextMenu CloseItems [cmnuTabRect.MenuItems]
				if (this._tabsContextMenuAllowClose)														// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_CloseThis.Visible = true;												// 1.0.001
					this.cmnuTabRect_CloseSelect.Visible = true;											// 1.0.001
					this.cmnuTabRect_CloseAllBut.Visible = true;											// 1.0.001
					this.cmnuTabRect_CloseAll.Visible = true;												// 1.0.001
					this.cmnuTabRect_Separator99.Visible = true;											// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_CloseThis.Visible = false;												// 1.0.001
					this.cmnuTabRect_CloseSelect.Visible = false;											// 1.0.001
					this.cmnuTabRect_CloseAllBut.Visible = false;											// 1.0.001
					this.cmnuTabRect_CloseAll.Visible = false;												// 1.0.001
					this.cmnuTabRect_Separator99.Visible = false;											// 1.0.001
				}																							// 1.0.001
				#endregion 

				#region Build [cmnuTabRect_Work.MenuItems]
				cmnuTabRect_Work.MenuItems.Clear();															// 1.0.001
				if (this._tabsAllowContextMenu)																// 1.0.011
				{																							// 1.0.011
					if (this._tabsContextMenuAllowOpen														// 1.0.001
						//|| this._tabsBase_ContextMenuAllowOpen	// this is subsidiary					// 1.0.011
					|| this._tabsContextMenuAllowRename 													// 1.0.011
					|| this._tabsContextMenuAllowReorder 													// 1.0.011
					|| this._tabsContextMenuAllowClose														// 1.0.001
						//|| this._tabsBase_AllowClose				// this is subsidiary					// 1.0.011
					)																						// 1.0.001
					{																						// 1.0.001
						cmnuTabRect_Work.MergeMenu(cmnuTabRect);											// 1.0.001
					}																						// 1.0.001

					//if (this.TabPages[idxTab].ContextMenu != null)										// 1.0.001
					if (this.TdhTabPages[true, idxTab].ContextMenu != null)									// 1.0.010
					{																						// 1.0.001
						//cmnuTabRect_Work.MergeMenu(this.TabPages[idxTab].ContextMenu);					// 1.0.001
						cmnuTabRect_Work.MergeMenu(this.TdhTabPages[true, idxTab].ContextMenu);				// 1.0.010
					}																						// 1.0.001
				}																							// 1.0.011
				#endregion 
				if (cmnuTabRect_Work.MenuItems.Count > 0)													// 1.0.001
				{																							// 1.0.001
					cmnuTabRect_Work.Show(this, ptMenu);													// 1.0.001
				}																							// 1.0.001
			}																								// 1.0.001
			#endregion 
		}																									// 1.0.001


		private bool CanDrawCloseButton(int idxTab)															// 1.0.001
		{																									// 1.0.001
			if (this._tabsShowCloseButton 																	// 1.0.001
			&& ((idxTab > -1) && (idxTab < this.TabCount))													// 1.0.001
			&&( this.TdhTabPages.IsTdhTabPage(idxTab)														// 1.0.010
				&& this.TdhTabPages[idxTab].TabShowCloseButton ) 											// 1.0.010
			)																								// 1.0.001
			{																								// 1.0.001
				return true;																				// 1.0.001
			}																								// 1.0.001
			return false;																					// 1.0.001
		}																									// 1.0.001

		private bool CanDrawMenuButton(int idxTab)
		{
			if (this._tabsShowMenuButton																		// 1.0.001
			&& ((idxTab > -1) && (idxTab < this.TabCount))													// 1.0.010
			&&( this.TdhTabPages.IsTdhTabPage(idxTab)														// 1.0.010
				&& this.TdhTabPages[idxTab].TabShowMenuButton ) 											// 1.0.010
			)																								// 1.0.001
			{
				return true;
			}
			return false;
		}


		private bool TabPage_ConfirmClose(int idxTab)														// 1.0.003
		{																									// 1.0.003
			#region See if we're allowed to close the TabPage/TdhTabPage
			if (!this._tabsAllowClose																		// 1.0.003
			|| (this.TabCount <= 1)																			// 1.0.011
			|| ( (idxTab > -1)																				// 1.0.003
				&& (idxTab >= this.TabCount)																// 1.0.011
				) 																							// 1.0.003
			)																								// 1.0.003
			{																								// 1.0.003
				return false;																				// 1.0.003
			}																								// 1.0.003

			bool idxTab_PointsToTabPage = false;															// 1.0.011
			bool idxTab_IsTdhTabPage = false;																// 1.0.011
			bool idxTab_AllowClose = false;																	// 1.0.011
			if( (idxTab > -1)																				// 1.0.011
			&& (idxTab < this.TabCount)																		// 1.0.011
			)																								// 1.0.011
			{																								// 1.0.011
				idxTab_PointsToTabPage = true;																// 1.0.011
				if (this.TdhTabPages.IsTdhTabPage(idxTab))													// 1.0.011
				{																							// 1.0.011
					idxTab_IsTdhTabPage = true;																// 1.0.011
					idxTab_AllowClose = this.TdhTabPages[idxTab].TabAllowClose;								// 1.0.011
				}																							// 1.0.011
				else																						// 1.0.011
				{																							// 1.0.011
					idxTab_IsTdhTabPage = false;															// 1.0.011
					idxTab_AllowClose = this._tabsBase_AllowClose;											// 1.0.011
				}																							// 1.0.011
			}																								// 1.0.011
			if (idxTab_PointsToTabPage 																		// 1.0.011
			&& !idxTab_AllowClose)																			// 1.0.011
			{																								// 1.0.011
				return false;																				// 1.0.011
			}																								// 1.0.011
			#endregion 

			#region Set [needConfirmation] switch
			bool needConfirmation = this._tabsConfirmOnClose;												// 1.0.003
			if (!needConfirmation)																			// 1.0.003
			{																								// 1.0.003
				#region Attempting to close on specific TabPage/TdhTabPage -- Need confirmation?
				//if (idxTab > -1)																			// 1.0.003
				if (idxTab_PointsToTabPage)																	// 1.0.011
				{																							// 1.0.003
					if (idxTab_IsTdhTabPage																	// 1.0.011
					&& idxTab_AllowClose)																	// 1.0.011
					{																						// 1.0.011
						needConfirmation = this.TdhTabPages[idxTab].TabConfirmOnClose;						// 1.0.011
					}																						// 1.0.011
					else																					// 1.0.011
					if (!idxTab_IsTdhTabPage																// 1.0.011
					&& idxTab_AllowClose)																	// 1.0.011
					{																						// 1.0.011
						needConfirmation = this._tabsBase_ConfirmOnClose;									// 1.0.011
					}																						// 1.0.011
					else																					// 1.0.011
					{																						// 1.0.011
						return false;																		// 1.0.011
					}																						// 1.0.011
				}																							// 1.0.003
				#endregion 
				else																						// 1.0.003
				#region Do we need confirmation to close any TabPage/TdhTabPage?
				{																							// 1.0.003
					for (int idx = 0; idx < this.TabCount; idx++)											// 1.0.003
					{																						// 1.0.003
						if (this.TdhTabPages.IsTdhTabPage(idx))												// 1.0.011
						{																					// 1.0.011
							if (this.TdhTabPages[idx].TabAllowClose											// 1.0.010
							&& this.TdhTabPages[idx].TabConfirmOnClose)										// 1.0.010
							{																				// 1.0.003
								needConfirmation = true;													// 1.0.003
								break;																		// 1.0.003
							}																				// 1.0.003
						}																					// 1.0.011
						else																				// 1.0.011
						{																					// 1.0.011
							if (this._tabsBase_AllowClose													// 1.0.011
							&& this._tabsBase_ConfirmOnClose)												// 1.0.011
							{																				// 1.0.011
								needConfirmation = true;													// 1.0.011
								break;																		// 1.0.011
							}																				// 1.0.011
						}																					// 1.0.011
					}																						// 1.0.003
				}																							// 1.0.003
				#endregion 
			}																								// 1.0.003
			#endregion 
			if (needConfirmation)																			// 1.0.003
			{																								// 1.0.003
				#region Get close confirmation
				string msg = "You are about to close ";														// 1.0.003
				if (idxTab > -1)																			// 1.0.003
				{																							// 1.0.003
					msg += "the TabPage '"																	// 1.0.003
						//+ this.TabPages[idxTab].Text.Trim()												// 1.0.003
						+ this.TdhTabPages[true, idxTab].Text.Trim()										// 1.0.010
						+"'";																				// 1.0.003
				}																							// 1.0.003
				else																						// 1.0.003
				{																							// 1.0.003
					msg += "one or more TabPages";															// 1.0.003
				}																							// 1.0.003
				msg += "\n\nAre you sure you want to continue?";											// 1.0.003

				System.Windows.Forms.DialogResult diaResult = MessageBox.Show(
					msg,																					// 1.0.003
					"Confirm Close", 
					System.Windows.Forms.MessageBoxButtons.YesNo, 
					//System.Windows.Forms.MessageBoxIcon.Question,											// 1.0.003
					System.Windows.Forms.MessageBoxIcon.Exclamation,										// 1.0.003
					System.Windows.Forms.MessageBoxDefaultButton.Button2);									// 1.0.003
				if (diaResult != System.Windows.Forms.DialogResult.Yes)										// 1.0.003
				{																							// 1.0.003
					return false;																			// 1.0.011
				}																							// 1.0.003
				#endregion  
			}																								// 1.0.003
			return true;																					// 1.0.011
		}																									// 1.0.003

		private void TabPage_Close(System.Windows.Forms.TabPage theTabPage, int idxTab)						// 1.0.011
		{																									// 1.0.001
			if( (theTabPage != null)																		// 1.0.001
			//&& this._tabsAllowClose 						// This check should be done already			// 1.0.001
			//// This complex check should have been done by [ TabPage_ConfirmClose(index) ]				// 1.0.011
			//&&( ( ((theTabPage.GetType() == typeof(TDHTabCtl.TdhTabPage))									// 1.0.010
			//		|| theTabPage.GetType().IsSubclassOf(typeof(TDHTabCtl.TdhTabPage))						// 1.0.010
			//		)																						// 1.0.010
			//		&& ((TDHTabCtl.TdhTabPage)theTabPage).TabAllowClose)									// 1.0.010
			//	|| ((theTabPage.GetType() != typeof(TDHTabCtl.TdhTabPage))									// 1.0.011
			//		&& this._tabsBase_AllowClose)															// 1.0.011
			//	)																							// 1.0.010
			)																								// 1.0.001
			{																								// 1.0.001
				this.cmnuTabRect_TabRect_Idx = -1;															// 1.0.001
				this.cmnuTabRect_Built = false;																// 1.0.001
				this._OnTabEvents_RenameIsAdd = false;														// 1.0.001

				// Use [_lastTabRect/_lastTabRectIdx] to redraw the last [TabRect] the mouse was over		// 1.0.005
				this._lastTabRectIdx = -1;																	// 1.0.005
				this._lastTabRect = System.Drawing.RectangleF.Empty;										// 1.0.005

			//	this.TabPages.Remove(theTabPage);			// either this									// 1.0.001
			//	//this.TabPages.RemoveAt(idxTab);			// or this										// 1.0.001
				this.TdhTabPages.Remove(theTabPage);		// either this									// 1.0.010
				//this.TdhTabPages.RemoveAt(idxTab);		// or this										// 1.0.010
				#region Reset [this.SelectedIndex]
				//// The removal of [theTabPage] will take care of resetting [this.SelectedIndex]			// 1.0.003
				//if (idxTab < this.TabCount)																// 1.0.003
				//{																							// 1.0.003
				//	this.SelectedIndex = idxTab;															// 1.0.003
				//}																							// 1.0.003
				//else																						// 1.0.003
				//{																							// 1.0.003
				//	this.SelectedIndex = this.TabCount -1;													// 1.0.003
				//}																							// 1.0.003
				#endregion 

				// Fire [.TabEvents.TabRemoved] event to client												// 1.0.001
				if (this.OnTabEvents != null)																// 1.0.001
				{																							// 1.0.001
					this.OnTabEvents(this, new TDHTabCtl.TabEventArgs(-1, idxTab, theTabPage, TDHTabCtl.TabEventArgs.TabEvents.TabRemoved));	// 1.0.001
				}																							// 1.0.001
			}																								// 1.0.001
		}																									// 1.0.001


		private void TabPage_Rename(System.Windows.Forms.TabPage theTabPage, int idxTab)					// 1.0.010
		{																									// 1.0.001
			if (!this.gblRunModeIs_DesignMode																// 1.0.001
			&& (theTabPage != null) )																		// 1.0.001
			{																								// 1.0.001
				System.Drawing.RectangleF tabRect = TabRect_ByIdx(idxTab);									// 1.0.001
				if (tabRect != System.Drawing.RectangleF.Empty)												// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_TabRect_Idx = idxTab;													// 1.0.001

					// Create [this._tdhEditBox] -- to allow TdhTabPage-Rename								// 1.0.001
					if (this._tdhEditBox == null)															// 1.0.001
					{																						// 1.0.001
						this._tdhEditBox = new TDHControls.TDHTabCtl.TDHEditBox.TdhEditBox(new TDHControls.TDHTabCtl.TDHEditBox.EditComplete(this.TabPage_Renamed));	// 1.0.001
					}																						// 1.0.001
					this._tdhEditBox.Show(																	// 1.0.001
					//this._tdhEditBox.ShowDialog(															// 1.0.001
						this.PointToScreen(new System.Drawing.Point((int)tabRect.X, (int)tabRect.Y)),		// 1.0.001
						(int)tabRect.Height, (int)tabRect.Width,											// 1.0.001
						theTabPage.Text.Trim()																// 1.0.001
						);																					// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				{																							// 1.0.001
					this.cmnuTabRect_TabRect_Idx = -1;														// 1.0.001
					this.cmnuTabRect_Built = false;															// 1.0.001
					this._OnTabEvents_RenameIsAdd = false;													// 1.0.001
				}																							// 1.0.001
			}																								// 1.0.001
		}																									// 1.0.001

		private void TabPage_Renamed(object sender, TDHControls.TDHTabCtl.TDHEditBox.EditEventArgs editArgs)// 1.0.001
		{																									// 1.0.001
			// This method finalizes the [.TabEvents.TabAdded] and [.TabEvents.TabRenamed] actions			// 1.0.001
			if( (this.cmnuTabRect_TabRect_Idx > -1)															// 1.0.001
			&& (this.cmnuTabRect_TabRect_Idx < this.TabCount)												// 1.0.001
			)																								// 1.0.001
			{																								// 1.0.001
				if( (this._OnTabEvents_RenameIsAdd) 		// Was the user adding a TabPage				// 1.0.001
				&& !editArgs.EditAccepted)					// and rejected the new TabPage?				// 1.0.001
				{																							// 1.0.001
					#region Fire [.TabEvents.TabAddRejected] event to client?
					// Remove the new TabPage from [this.TabPages]											// 1.0.001
					System.Windows.Forms.TabPage theTabPage = this.TdhTabPages[cmnuTabRect_TabRect_Idx];	// 1.0.010
					//this.TabPages.Remove(theTabPage);														// 1.0.001
					this.TdhTabPages.Remove(theTabPage);													// 1.0.010

					// If "New-TabPage" action is rejected; ensure that [this.SelectedIndex] doesn't change	// 1.0.003
					if( (this._thisSelectedIndex > -1)														// 1.0.003
					&& (this._thisSelectedIndex < this.TabCount)											// 1.0.003
					&& (this._thisSelectedIndex != this.SelectedIndex)										// 1.0.003
					)																						// 1.0.003
					{																						// 1.0.003
						this.SelectedIndex = this._thisSelectedIndex;										// 1.0.003
					}																						// 1.0.003

					// Fire [.TabEvents.TabAddRejected] event to client										// 1.0.001
					if (this.OnTabEvents != null)															// 1.0.001
					{																						// 1.0.001
						this.OnTabEvents(																	// 1.0.001
							this,																			// 1.0.001
							new TDHTabCtl.TabEventArgs(														// 1.0.001
								theTabPage,																	// 1.0.001
								TDHTabCtl.TabEventArgs.TabEvents.TabAddRejected								// 1.0.001
							)																				// 1.0.001
						);																					// 1.0.001
					}																						// 1.0.001
					#endregion 
				}																							// 1.0.001
				else										// The Add/Rename was accepted; Process it		// 1.0.001
				{																							// 1.0.001
					#region Rename the TabPage (set [.Name] and [.Text])
					if (editArgs.EditAccepted																// 1.0.001
					&& (editArgs.EditText.Trim().Length > 0) 												// 1.0.001
					)																						// 1.0.001
					{																						// 1.0.001
					//	//this.TabPages[cmnuTabRect_TabRect_Idx].Name = editArgs.EditText.Trim();			// 1.0.001
					//	this.TabPages[cmnuTabRect_TabRect_Idx].Text = editArgs.EditText.Trim();				// 1.0.001

						//this.TdhTabPages[true, cmnuTabRect_TabRect_Idx].Name = editArgs.EditText.Trim();	// 1.0.010
						this.TdhTabPages[true, cmnuTabRect_TabRect_Idx].Text = editArgs.EditText.Trim();	// 1.0.010
					}																						// 1.0.001
					this.cmnuTabRect_Built = false;															// 1.0.001
					#endregion 

					#region Fire [.TabEvents.TabAdded] event to client?
					if (this._OnTabEvents_RenameIsAdd)														// 1.0.001
					{																						// 1.0.001
						// Fire [.TabEvents.TabAdded] event to client										// 1.0.001
						if (this.OnTabEvents != null)														// 1.0.001
						{																					// 1.0.001
							this.OnTabEvents(																// 1.0.001
								this,																		// 1.0.001
								new TDHTabCtl.TabEventArgs(													// 1.0.001
									cmnuTabRect_TabRect_Idx,												// 1.0.001
									//this.TabPages[cmnuTabRect_TabRect_Idx],								// 1.0.001
									this.TdhTabPages[true, cmnuTabRect_TabRect_Idx],						// 1.0.010
									TDHTabCtl.TabEventArgs.TabEvents.TabAdded								// 1.0.001
								)																			// 1.0.001
							);																				// 1.0.001
						}																					// 1.0.001
					}																						// 1.0.001
					#endregion 
					else																					// 1.0.001
					#region Fire [.TabEvents.TabRenamed] event to client?
					if (editArgs.EditAccepted																// 1.0.001
					&& (editArgs.EditText.Trim().Length > 0) 												// 1.0.001
					)																						// 1.0.001
					{																						// 1.0.001
						// Fire [.TabEvents.TabRenamed] event to client										// 1.0.001
						if (this.OnTabEvents != null)														// 1.0.001
						{																					// 1.0.001
							this.OnTabEvents(																// 1.0.001
								this,																		// 1.0.001
								new TDHTabCtl.TabEventArgs(													// 1.0.001
									cmnuTabRect_TabRect_Idx,												// 1.0.001
									//this.TabPages[cmnuTabRect_TabRect_Idx],								// 1.0.001
									this.TdhTabPages[true, cmnuTabRect_TabRect_Idx],						// 1.0.010
									TDHTabCtl.TabEventArgs.TabEvents.TabRenamed								// 1.0.001
								)																			// 1.0.001
							);																				// 1.0.001
						}																					// 1.0.001
					}																						// 1.0.001
					#endregion 
				}																							// 1.0.001
			}																								// 1.0.001
			this.cmnuTabRect_Built = false;																	// 1.0.001
			this._OnTabEvents_RenameIsAdd = false;															// 1.0.001
		}																									// 1.0.001


		internal System.Drawing.RectangleF TabRect_ByIdx(int idxTab)										// 1.0.001
		{																									// 1.0.001
			System.Drawing.RectangleF tabRect = System.Drawing.RectangleF.Empty;							// 1.0.001
			if( (idxTab >= 0)																				// 1.0.001
			&& (idxTab < this.TabCount) )																	// 1.0.001
			{																								// 1.0.001
				tabRect = (System.Drawing.RectangleF)this.GetTabRect(idxTab);								// 1.0.001
			}																								// 1.0.001
			return tabRect;																					// 1.0.001
		}																									// 1.0.001

		internal int TabRect_FindIdx(System.Drawing.RectangleF tabRectFind)									// 1.0.001
		{																									// 1.0.001
			int idxTabRect = -1;																			// 1.0.001
			if (tabRectFind != System.Drawing.RectangleF.Empty)												// 1.0.001
			{																								// 1.0.001
				for (int idx = 0; idx < this.TabCount; idx++)												// 1.0.001
				{																							// 1.0.001
					System.Drawing.RectangleF tabRect = (System.Drawing.RectangleF)this.GetTabRect(idx);	// 1.0.001
					if (tabRectFind.Equals(tabRect) )														// 1.0.001
					{																						// 1.0.001
						idxTabRect = idx;																	// 1.0.001
						break;																				// 1.0.001
					}																						// 1.0.001
				}																							// 1.0.001
			}																								// 1.0.001
			return idxTabRect;																				// 1.0.001
		}																									// 1.0.001

		internal System.Drawing.RectangleF TabRect_CloseButton(System.Drawing.RectangleF tabRect)			// 1.0.001
		{																									// 1.0.001
			if (tabRect != System.Drawing.RectangleF.Empty)													// 1.0.001
			{																								// 1.0.001
				return new System.Drawing.RectangleF(														// 1.0.001
					tabRect.X + tabRect.Width - 22, 4,														// 1.0.001
					tabRect.Height - 3, tabRect.Height - 5);												// 1.0.001
			}																								// 1.0.001
			return System.Drawing.RectangleF.Empty;															// 1.0.001
		}																									// 1.0.001

		internal System.Drawing.RectangleF TabRect_MenuButton(System.Drawing.RectangleF tabRect, int idxTab)// 1.0.001
		{																									// 1.0.001
			if (tabRect != System.Drawing.RectangleF.Empty)													// 1.0.001
			{																								// 1.0.001
				if( ((idxTab > -1)																			// 1.0.001
					&& (idxTab < this.TabCount)																// 1.0.001
					&& this.CanDrawCloseButton(idxTab)														// 1.0.001
					)																						// 1.0.001
				|| ((idxTab <= -1)																			// 1.0.001
					&& this.CanDrawCloseButton(this.TabRect_FindIdx(tabRect))								// 1.0.001
					)																						// 1.0.001
				)																							// 1.0.001
				{																							// 1.0.001
					// Tne normal "Menu pseudo-Button" Rectangle location									// 1.0.001
					return new System.Drawing.RectangleF(													// 1.0.001
						tabRect.X + tabRect.Width - 43, 4,													// 1.0.001
						tabRect.Height - 3, tabRect.Height - 5);											// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				{																							// 1.0.001
					// Draw the "Menu pseudo-Button" Rectangle at the "Close pseudo-Button" location		// 1.0.001
					return this.TabRect_CloseButton(tabRect);												// 1.0.001
				}																							// 1.0.001
			}																								// 1.0.001
			return System.Drawing.RectangleF.Empty;															// 1.0.001
		}																									// 1.0.001
		#endregion 

		#region Class Static Functions/Methods -- Draw TabRect
		// internal static void TabRect_DrawTabRect(
		//     TDHTabCtl.TdhTabCtl theTabCtl, 
		//     System.Drawing.Point ptMouse, 
		//     System.Windows.Forms.TabPage theTabPage, int idxTabPage, bool asActive,
		//     System.Drawing.Graphics gfx, System.Drawing.RectangleF tabRectDraw
		// )
		// internal static void TabRect_DrawButtons(
		//     TDHTabCtl.TdhTabCtl theTabCtl, 
		//     System.Drawing.Point ptMouse, 
		//     System.Drawing.Graphics gfx, 
		//     System.Drawing.RectangleF tabRectDraw, int tabRectIdx 
		// )
		// internal static void TabRect_DrawButtons(
		//     TDHTabCtl.TdhTabCtl theTabCtl, 
		//     System.Drawing.Point ptMouse, 
		//     System.Drawing.Graphics gfx, 
		//     System.Drawing.RectangleF tabRectDraw, int tabRectIdx, 
		//     bool asActiveExplicit, bool asInactiveExplicit
		// )
		// 
		// internal static void TabRect_DrawButton(
		//     System.Drawing.Graphics gfx, 
		//     bool ButtonIsMenu, 
		//     System.Drawing.RectangleF tabRectButton, 
		//     System.Drawing.Color[] colors 
		// )
		// 
		private static System.Object mutex_TabRect_DrawTabRect = new System.Object[0];						// 1.0.003
		internal static void TabRect_DrawTabRect(															// 1.0.003
			TDHTabCtl.TdhTabCtl theTabCtl, 																	// 1.0.003
			System.Drawing.Point ptMouse, 																	// 1.0.003
			System.Windows.Forms.TabPage theTabPage, int idxTabPage, bool asActive, 						// 1.0.010
			System.Drawing.Graphics gfx, System.Drawing.RectangleF tabRectDraw 								// 1.0.003
		)																									// 1.0.003
		{																									// 1.0.003
			lock (mutex_TabRect_DrawTabRect)								// Just-in-case					// 1.0.003
			{																								// 1.0.003
				#region Draw the TabRect Background and Buttons
				System.Drawing.Drawing2D.GraphicsPath _Path = new System.Drawing.Drawing2D.GraphicsPath();
				_Path.AddRectangle(tabRectDraw);
				using (
					System.Drawing.Drawing2D.LinearGradientBrush _Brush = 
						new System.Drawing.Drawing2D.LinearGradientBrush(
						tabRectDraw, 
						System.Drawing.SystemColors.Control, 
						System.Drawing.SystemColors.ControlLight, 
						System.Drawing.Drawing2D.LinearGradientMode.Vertical) 
						)
				{
					if (asActive)							// Is this the active TabPage?					// 1.0.003
					{																						// 1.0.003						
						#region Draw the TabRect background (active TabPage)
						System.Drawing.Drawing2D.ColorBlend _ColorBlend = new System.Drawing.Drawing2D.ColorBlend(3);
						_ColorBlend.Colors = new System.Drawing.Color[]
							{
								//System.Drawing.SystemColors.ControlLightLight, 
								//System.Drawing.Color.FromArgb(255, System.Drawing.SystemColors.Control), 
								//System.Drawing.SystemColors.ControlLight, 
								//System.Drawing.SystemColors.Control

//								System.Drawing.SystemColors.ControlLightLight,								// 1.0.001
//								//System.Drawing.Color.FromArgb(255, System.Drawing.SystemColors.ControlLight),// 1.0.001
//								System.Drawing.SystemColors.ControlLight,									// 1.0.001
//								System.Drawing.SystemColors.ControlDark,									// 1.0.001
//								System.Drawing.SystemColors.ControlLightLight								// 1.0.001

								System.Drawing.Color.FromArgb(255, 170, 213, 243),							// 1.0.001
								System.Drawing.Color.FromArgb(255, 170, 213, 243),							// 1.0.001
								System.Drawing.Color.FromArgb(255, 170, 213, 243),							// 1.0.001
								//System.Drawing.Color.FromArgb(255, 44, 137, 191),							// 1.0.001
								System.Drawing.Color.FromArgb(255, 44, 137, 191)							// 1.0.001
							};
						_ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
						_Brush.InterpolationColors = _ColorBlend;
						gfx.FillPath(_Brush, _Path);														// 1.0.003
						using (Pen pen = new Pen(SystemColors.ActiveBorder))
						{
							gfx.DrawPath(pen, _Path);														// 1.0.003
						}
						#endregion 
					}																						// 1.0.003
					else																					// 1.0.003
					{																						// 1.0.003
						#region Draw the TabRect background (inactive TabPage)
						ColorBlend _ColorBlend = new ColorBlend(3);
						_ColorBlend.Colors = new System.Drawing.Color[]
							{
								//System.Drawing.SystemColors.ControlLightLight, 
								//System.Drawing.Color.FromArgb(255, System.Drawing.SystemColors.ControlLight), 
								//System.Drawing.SystemColors.ControlDark, 
								//System.Drawing.SystemColors.ControlLightLight 

//								System.Drawing.SystemColors.ControlDarkDark,								// 1.0.001
//								System.Drawing.SystemColors.ControlLightLight,								// 1.0.001
//								System.Drawing.SystemColors.ControlLightLight,								// 1.0.001
//								System.Drawing.SystemColors.ControlLight									// 1.0.001

								System.Drawing.SystemColors.ControlLightLight,								// 1.0.001
								System.Drawing.Color.FromArgb(255, System.Drawing.SystemColors.ControlLight), // 1.0.001
								//System.Drawing.SystemColors.ControlLightLight,							 // 1.0.001
								System.Drawing.SystemColors.ControlLight,									// 1.0.001
								System.Drawing.SystemColors.ControlDark										// 1.0.001
							};
						_ColorBlend.Positions = new float[] { 0f, .4f, 0.5f, 1f };
						_Brush.InterpolationColors = _ColorBlend;
						gfx.FillPath(_Brush, _Path);														// 1.0.003
						using (System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.SystemColors.ActiveBorder))
						{
							gfx.DrawPath(pen, _Path);														// 1.0.003
						}
						#endregion 
					}																						// 1.0.003

					#region Draw Buttons this TabRect
					if( (theTabPage.GetType() == typeof(TDHTabCtl.TdhTabPage))								// 1.0.010
						|| theTabPage.GetType().IsSubclassOf(typeof(TDHTabCtl.TdhTabPage))					// 1.0.010
					)																						// 1.0.010
					{																						// 1.0.010
						TabRect_DrawButtons(																// 1.0.001
							theTabCtl, ptMouse,																// 1.0.003
							gfx, 																			// 1.0.003
							tabRectDraw, idxTabPage, asActive, !asActive									// 1.0.003
							);																				// 1.0.001
					}																						// 1.0.010
					#endregion 
				}
				_Path.Dispose();
				#endregion 

				#region Draw [theTabPage.Text] on the TabRect
				int textOffset = 0;																			// 1.0.001
				if (theTabCtl.Font.Size <= 8.25f)		// Size: 8											// 1.0.003
				{																							// 1.0.001
					textOffset = 5;																			// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				if (theTabCtl.Font.Size <= 9f)			// Size: 9											// 1.0.003
				{																							// 1.0.001
					textOffset = 4;																			// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				if (theTabCtl.Font.Size <= 9.75f)		// Size: 10											// 1.0.003
				{																							// 1.0.001
					textOffset = 3;																			// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				if (theTabCtl.Font.Size < 11.25f)		// Size: 11											// 1.0.003
				{																							// 1.0.001
					textOffset = 2;																			// 1.0.001
				}																							// 1.0.001
				else																						// 1.0.001
				if (theTabCtl.Font.Size < 12f)			// Size: 12											// 1.0.003
				{																							// 1.0.001
					textOffset = 1;																			// 1.0.001
				}																							// 1.0.001
				System.Drawing.RectangleF textRect = new System.Drawing.RectangleF(							// 1.0.001
					tabRectDraw.X,																			// 1.0.001
					tabRectDraw.Y + textOffset,																// 1.0.001
					tabRectDraw.Width,																		// 1.0.001
					tabRectDraw.Height - textOffset);														// 1.0.001

				string str = " "+ theTabPage.Text.Trim();													// 1.0.010
				System.Drawing.StringFormat stringFormat = new System.Drawing.StringFormat();
				stringFormat.Alignment = System.Drawing.StringAlignment.Near;								// 1.0.001
				gfx.DrawString(																				// 1.0.003
					str, 
					theTabCtl.Font,																			// 1.0.003
					new System.Drawing.SolidBrush(theTabPage.ForeColor),									// 1.0.010
					textRect,																				// 1.0.001
					stringFormat);
				#endregion 
			}																								// 1.0.003
		}																									// 1.0.003


		private static System.Object mutex_TabRect_DrawButtons = new System.Object[0];						// 1.0.001
		internal static void TabRect_DrawButtons(															// 1.0.001
			TDHTabCtl.TdhTabCtl theTabCtl, 																	// 1.0.001
			System.Drawing.Point ptMouse, 																	// 1.0.001
			System.Drawing.Graphics gfx, 																	// 1.0.001
			System.Drawing.RectangleF tabRectDraw, int tabRectIdx 											// 1.0.001
		)																									// 1.0.001
		{																									// 1.0.001
			TabRect_DrawButtons(																			// 1.0.003
				theTabCtl,																					// 1.0.003
				ptMouse, 																					// 1.0.003
				gfx, 																						// 1.0.003
				tabRectDraw, tabRectIdx,																	// 1.0.003
				false, false																				// 1.0.003
				);																							// 1.0.003
		}																									// 1.0.001

		internal static void TabRect_DrawButtons(															// 1.0.001
			TDHTabCtl.TdhTabCtl theTabCtl,																	// 1.0.001
			System.Drawing.Point ptMouse, 																	// 1.0.001
			System.Drawing.Graphics gfx, 																	// 1.0.001
			System.Drawing.RectangleF tabRectDraw, int tabRectIdx,											// 1.0.001
			bool asActiveExplicit, bool asInactiveExplicit 													// 1.0.003
		)																									// 1.0.001
		{																									// 1.0.001
			lock (mutex_TabRect_DrawButtons)								// Just-in-case					// 1.0.001
			{																								// 1.0.001
				#region Draw the "Close pseudo-Button" Rectangle?
				if (theTabCtl.CanDrawCloseButton(tabRectIdx) )												// 1.0.001
				{																							// 1.0.001
					System.Drawing.RectangleF tabRectClose = theTabCtl.TabRect_CloseButton(tabRectDraw);	// 1.0.001
					#region Draw the "Close pseudo-Button" Rectangle as "active?"
					if( (asActiveExplicit 					// Explicitly draw as "active?"					// 1.0.003
						|| (!asInactiveExplicit																// 1.0.003
							&& tabRectClose.Contains(ptMouse) ) // Is mouse location within the "Close pseudo-Button" Rectangle?	// 1.0.001
						)																					// 1.0.001
					&& (theTabCtl.TabCount > 1)																// 1.0.003
					&& theTabCtl.TabsAllowClose																// 1.0.005
					&& theTabCtl.TdhTabPages[tabRectIdx].TabAllowClose										// 1.0.010
					)																						// 1.0.001
					{																						// 1.0.001
						TabRect_DrawButton(																	// 1.0.001
							gfx,																			// 1.0.001
							false,																			// 1.0.001
							tabRectClose,																	// 1.0.001
							new System.Drawing.Color[]														// 1.0.001
								{																			// 1.0.001
									System.Drawing.Color.FromArgb(255, 252, 193, 183),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 252, 193, 183),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 210, 35, 2),							// 1.0.001
									System.Drawing.Color.FromArgb(255, 210, 35, 2)							// 1.0.001
								}																			// 1.0.001
							);																				// 1.0.001
					}																						// 1.0.001
					#endregion 
					else																					// 1.0.001
					#region No; Draw the "Close pseudo-Button" Rectangle as "disabled?"
					if( !asInactiveExplicit																	// 1.0.003
					&& (asActiveExplicit 					// Explicitly draw as "active?"					// 1.0.003
						|| tabRectClose.Contains(ptMouse)	// Is mouse location within the "Close pseudo-Button" Rectangle?	// 1.0.001
						|| (tabRectIdx == theTabCtl.SelectedIndex) )		// or within the TabRect?		// 1.0.001
					&&( (theTabCtl.TabCount <= 1)							// Cannot close this TabPage	// 1.0.003
						|| !theTabCtl.TabsAllowClose														// 1.0.005
						|| !theTabCtl.TdhTabPages[tabRectIdx].TabAllowClose									// 1.0.010
						)																					// 1.0.003
					)																						// 1.0.001
					{																						// 1.0.001
						TabRect_DrawButton(																	// 1.0.001
							gfx, 																			// 1.0.001
							false,																			// 1.0.001
							tabRectClose,																	// 1.0.001
							new System.Drawing.Color[]														// 1.0.001
								{																			// 1.0.001
									System.Drawing.Color.FromArgb(255, 197, 98, 79),						// 1.0.001
									System.Drawing.SystemColors.ActiveBorder,								// 1.0.001
									System.Drawing.SystemColors.ControlDarkDark,							// 1.0.001
									System.Drawing.SystemColors.ControlDark 								// 1.0.001
								}																			// 1.0.001
							);																				// 1.0.001
					}																						// 1.0.001
					#endregion 
					else																					// 1.0.001
					#region No; Draw the "Close pseudo-Button" Rectangle as "semi-active?"
					if( (!asInactiveExplicit																// 1.0.003
						&& (tabRectIdx == theTabCtl.SelectedIndex) )										// 1.0.001
					&& theTabCtl.TdhTabPages[tabRectIdx].TabAllowClose										// 1.0.010
					)																						// 1.0.001
					{																						// 1.0.001
						TabRect_DrawButton(																	// 1.0.001
							gfx,																			// 1.0.001
							false,																			// 1.0.001
							tabRectClose,																	// 1.0.001
							new System.Drawing.Color[]														// 1.0.001
								{																			// 1.0.001
									System.Drawing.Color.FromArgb(255, 231, 164, 152),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 231, 164, 152),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 197, 98, 79),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 197, 98, 79)							// 1.0.001
								}																			// 1.0.001
							);																				// 1.0.001
					}																						// 1.0.001
					#endregion 
					else																					// 1.0.001
					#region No; Draw the "Close pseudo-Button" Rectangle as "inactive?"
					{																						// 1.0.001
						TabRect_DrawButton(																	// 1.0.001
							gfx, 																			// 1.0.001
							false,																			// 1.0.001
							tabRectClose,																	// 1.0.001
							new System.Drawing.Color[]														// 1.0.001
								{																			// 1.0.001
									System.Drawing.SystemColors.ActiveBorder,								// 1.0.001
									System.Drawing.SystemColors.ActiveBorder,								// 1.0.001
									System.Drawing.SystemColors.ActiveBorder,								// 1.0.001
									System.Drawing.SystemColors.ActiveBorder								// 1.0.001
								}																			// 1.0.001
							);																				// 1.0.001
					}																						// 1.0.001
					#endregion 
				}																							// 1.0.001
				#endregion 

				#region Draw the "Menu pseudo-Button" Rectangle?
				if (theTabCtl.CanDrawMenuButton(tabRectIdx) )												// 1.0.001
				{																							// 1.0.001
					System.Drawing.RectangleF tabRectMenu = theTabCtl.TabRect_MenuButton(tabRectDraw, tabRectIdx);	// 1.0.001
					#region Draw the "Menu pseudo-Button" Rectangle as "active?"
					if (asActiveExplicit 					// Explicitly draw as "active?"					// 1.0.003
					|| (!asInactiveExplicit																	// 1.0.003
						&& tabRectMenu.Contains(ptMouse) )	// Is mouse location within the "Close pseudo-Button" Rectangle?	// 1.0.001
					)																						// 1.0.001
					{																						// 1.0.001
						TabRect_DrawButton(																	// 1.0.001
							gfx, 																			// 1.0.001
							true,																			// 1.0.001
							tabRectMenu,																	// 1.0.001
							new System.Drawing.Color[]														// 1.0.001
								{																			// 1.0.001
									System.Drawing.Color.FromArgb(255, 170, 213, 255),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 170, 213, 255),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 44, 157, 250),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 44, 157, 250)						// 1.0.001
								}																			// 1.0.001
							);																				// 1.0.001
					}																						// 1.0.001
						#endregion 
					else																					// 1.0.001
					#region No; Draw the "Menu pseudo-Button" Rectangle as "semi-active?"
					if (!asInactiveExplicit																	// 1.0.003
					&& (tabRectIdx == theTabCtl.SelectedIndex) )											// 1.0.001
					{																						// 1.0.001
						TabRect_DrawButton(																	// 1.0.001
							gfx, 																			// 1.0.001
							true,																			// 1.0.001
							tabRectMenu, 																	// 1.0.001
							new System.Drawing.Color[]														// 1.0.001
								{																			// 1.0.001
									System.Drawing.Color.FromArgb(255, 170, 213, 243),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 170, 213, 243),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 44, 137, 191),						// 1.0.001
									System.Drawing.Color.FromArgb(255, 44, 137, 191)						// 1.0.001
								}																			// 1.0.001
							);																				// 1.0.001
					}																						// 1.0.001
					#endregion 
					else																					// 1.0.001
					#region No; Draw the "Menu pseudo-Button" Rectangle as "inactive?"
					{																						// 1.0.001
						TabRect_DrawButton(																	// 1.0.001
							gfx, 																			// 1.0.001
							true,																			// 1.0.001
							tabRectMenu,																	// 1.0.001
							new System.Drawing.Color[]														// 1.0.001
								{																			// 1.0.001
									System.Drawing.SystemColors.ActiveBorder,								// 1.0.001
									System.Drawing.SystemColors.ActiveBorder,								// 1.0.001
									System.Drawing.SystemColors.ActiveBorder,								// 1.0.001
									System.Drawing.SystemColors.ActiveBorder								// 1.0.001
								}																			// 1.0.001
							);																				// 1.0.001
					}																						// 1.0.001
					#endregion 
				}																							// 1.0.001
				#endregion 
			}																								// 1.0.001
		}																									// 1.0.001


		private static System.Object mutex_TabRect_DrawButton = new System.Object[0];						// 1.0.001
		internal static void TabRect_DrawButton(															// 1.0.001
			System.Drawing.Graphics gfx, 																	// 1.0.001
			bool ButtonIsMenu,																				// 1.0.001
			System.Drawing.RectangleF tabRectButton,														// 1.0.001
			System.Drawing.Color[] colors 																	// 1.0.001
		)																									// 1.0.001
		{																									// 1.0.001
			lock (mutex_TabRect_DrawButton)									// Just-in-case					// 1.0.001
			{																								// 1.0.001
				using (
					System.Drawing.Drawing2D.LinearGradientBrush _Brush =  
						new System.Drawing.Drawing2D.LinearGradientBrush(
						tabRectButton, 
						System.Drawing.SystemColors.Control, 
						SystemColors.ControlLight, 
						System.Drawing.Drawing2D.LinearGradientMode.Vertical) 
						)
				{
					#region Build/apply the [.Drawing2D.ColorBlend]
					System.Drawing.Drawing2D.ColorBlend _ColorBlend = new System.Drawing.Drawing2D.ColorBlend(3);
					_ColorBlend.Colors = colors;															// 1.0.001
					_ColorBlend.Positions = new float[] {0f, .4f, 0.5f, 1f};
					_Brush.InterpolationColors = _ColorBlend;
					#endregion 

					#region Draw the "background"
					gfx.FillRectangle(_Brush, tabRectButton);
					gfx.DrawRectangle(
						System.Drawing.Pens.White, 
						tabRectButton.X + 2, 6, 
						tabRectButton.Height - 2, tabRectButton.Height - 4);
					#endregion 
					#region Draw the "foreground"
					using (System.Drawing.Pen pen = new System.Drawing.Pen(System.Drawing.Color.White, 2))
					{
						if (ButtonIsMenu)																	// 1.0.001
						{																					// 1.0.001
							gfx.DrawLine(pen, 
								tabRectButton.X + 7, 11, 
								tabRectButton.X + 10, 16);
							gfx.DrawLine(pen, 
								tabRectButton.X + 10, 16, 
								tabRectButton.X + 13, 11);
						}																					// 1.0.001
						else																				// 1.0.001
						{																					// 1.0.001
							gfx.DrawLine(pen, 
								tabRectButton.X + 6, 9, 
								tabRectButton.X + 15, 17);
							gfx.DrawLine(pen, 
								tabRectButton.X + 6, 17, 
								tabRectButton.X + 15, 9);
						}																					// 1.0.001
					}
					#endregion 
				}
			}																								// 1.0.001
		}																									// 1.0.001
		#endregion 

	}
}
