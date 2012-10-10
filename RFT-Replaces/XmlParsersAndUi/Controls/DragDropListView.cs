/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/10/2012
 * Time: 3:13 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System.Windows.Forms;
using System.Drawing;
using System;
using System.ComponentModel;
using System.Collections;

namespace XmlParsersAndUi
{
	/// <summary>
	/// Description of DragDropListView.
	/// </summary>
			  public  class DragAndDropListView : ListView
    {
        // Fields
        private bool m_allowReorder = true;
        private Color m_lineColor = Color.Red;
        private System.Windows.Forms.ListViewItem m_previousItem;

        // Methods
        private DragItemData GetDataForDragDrop()
        {
            DragItemData data = new DragItemData(this);
            foreach (System.Windows.Forms.ListViewItem item in base.SelectedItems)
            {
                data.DragItems.Add(item.Clone());
            }
            return data;
        }

        protected override void OnDragDrop(DragEventArgs drgevent)
        {
            if (!this.m_allowReorder)
            {
                base.OnDragDrop(drgevent);
            }
            else
            {
                Point point = base.PointToClient(new Point(drgevent.X, drgevent.Y));
                System.Windows.Forms.ListViewItem itemAt = base.GetItemAt(point.X, point.Y);
                if ((drgevent.Data.GetDataPresent(typeof(DragItemData).ToString()) && (((DragItemData)drgevent.Data.GetData(typeof(DragItemData).ToString())).ListView != null)) && (((DragItemData)drgevent.Data.GetData(typeof(DragItemData).ToString())).DragItems.Count != 0))
                {
                    DragItemData data = (DragItemData)drgevent.Data.GetData(typeof(DragItemData).ToString());
                    if (itemAt == null)
                    {
                        for (int i = 0; i < data.DragItems.Count; i++)
                        {
                            
                           var a =  data.DragItems;
                            System.Windows.Forms.ListViewItem item2 = (System.Windows.Forms.ListViewItem)data.DragItems[i];
                            base.Items.Add(item2);
                        }
                    }
                    else
                    {
                        int index = itemAt.Index;
                        if ((this == data.ListView) && (index > base.SelectedItems[0].Index))
                        {
                            index++;
                        }
                        for (int j = data.DragItems.Count - 1; j >= 0; j--)
                        {
                            System.Windows.Forms.ListViewItem item = (System.Windows.Forms.ListViewItem)data.DragItems[j];
                            base.Items.Insert(index, item);
                        }
                    }
                    if (data.ListView != null)
                    {
                        foreach (System.Windows.Forms.ListViewItem item4 in data.ListView.SelectedItems)
                        {
                            data.ListView.Items.Remove(item4);
                        }
                    }
                    if (this.m_previousItem != null)
                    {
                        this.m_previousItem = null;
                    }
                    base.Invalidate();
                    base.OnDragDrop(drgevent);
                }
            }
        }

        protected override void OnDragEnter(DragEventArgs drgevent)
        {
            if (!this.m_allowReorder)
            {
                base.OnDragEnter(drgevent);
            }
            else if (!drgevent.Data.GetDataPresent(typeof(DragItemData).ToString()))
            {
                drgevent.Effect = DragDropEffects.None;
            }
            else
            {
                drgevent.Effect = DragDropEffects.Move;
                base.OnDragEnter(drgevent);
            }
        }

        protected override void OnDragLeave(EventArgs e)
        {
            this.ResetOutOfRange();
            base.Invalidate();
            base.OnDragLeave(e);
        }

        protected override void OnDragOver(DragEventArgs drgevent)
        {
            if (!this.m_allowReorder)
            {
                base.OnDragOver(drgevent);
            }
            else if (!drgevent.Data.GetDataPresent(typeof(DragItemData).ToString()))
            {
                drgevent.Effect = DragDropEffects.None;
            }
            else
            {
                if (base.Items.Count > 0)
                {
                    Point[] pointArray;
                    Point point = base.PointToClient(new Point(drgevent.X, drgevent.Y));
                    System.Windows.Forms.ListViewItem itemAt = base.GetItemAt(point.X, point.Y);
                    Graphics graphics = base.CreateGraphics();
                    if (itemAt == null)
                    {
                        drgevent.Effect = DragDropEffects.Move;
                        if (this.m_previousItem != null)
                        {
                            this.m_previousItem = null;
                            base.Invalidate();
                        }
                        itemAt = base.Items[base.Items.Count - 1];
                        if ((base.View == View.Details) || (base.View == View.List))
                        {
                            graphics.DrawLine(new Pen(this.m_lineColor, 2f), new Point(itemAt.Bounds.X, itemAt.Bounds.Y + itemAt.Bounds.Height), new Point(itemAt.Bounds.X + base.Bounds.Width, itemAt.Bounds.Y + itemAt.Bounds.Height));
                            pointArray = new Point[] { new Point(itemAt.Bounds.X, (itemAt.Bounds.Y + itemAt.Bounds.Height) - 5), new Point(itemAt.Bounds.X + 5, itemAt.Bounds.Y + itemAt.Bounds.Height), new Point(itemAt.Bounds.X, (itemAt.Bounds.Y + itemAt.Bounds.Height) + 5) };
                            graphics.FillPolygon(new SolidBrush(this.m_lineColor), pointArray);
                            pointArray = new Point[] { new Point(base.Bounds.Width - 4, (itemAt.Bounds.Y + itemAt.Bounds.Height) - 5), new Point(base.Bounds.Width - 9, itemAt.Bounds.Y + itemAt.Bounds.Height), new Point(base.Bounds.Width - 4, (itemAt.Bounds.Y + itemAt.Bounds.Height) + 5) };
                            graphics.FillPolygon(new SolidBrush(this.m_lineColor), pointArray);
                        }
                        else
                        {
                            graphics.DrawLine(new Pen(this.m_lineColor, 2f), new Point(itemAt.Bounds.X + itemAt.Bounds.Width, itemAt.Bounds.Y), new Point(itemAt.Bounds.X + itemAt.Bounds.Width, itemAt.Bounds.Y + itemAt.Bounds.Height));
                            pointArray = new Point[] { new Point((itemAt.Bounds.X + itemAt.Bounds.Width) - 5, itemAt.Bounds.Y), new Point((itemAt.Bounds.X + itemAt.Bounds.Width) + 5, itemAt.Bounds.Y), new Point(itemAt.Bounds.X + itemAt.Bounds.Width, itemAt.Bounds.Y + 5) };
                            graphics.FillPolygon(new SolidBrush(this.m_lineColor), pointArray);
                            pointArray = new Point[] { new Point((itemAt.Bounds.X + itemAt.Bounds.Width) - 5, itemAt.Bounds.Y + itemAt.Bounds.Height), new Point((itemAt.Bounds.X + itemAt.Bounds.Width) + 5, itemAt.Bounds.Y + itemAt.Bounds.Height), new Point(itemAt.Bounds.X + itemAt.Bounds.Width, (itemAt.Bounds.Y + itemAt.Bounds.Height) - 5) };
                            graphics.FillPolygon(new SolidBrush(this.m_lineColor), pointArray);
                        }
                        base.OnDragOver(drgevent);
                        return;
                    }
                    if (((this.m_previousItem != null) && (this.m_previousItem != itemAt)) || (this.m_previousItem == null))
                    {
                        base.Invalidate();
                    }
                    this.m_previousItem = itemAt;
                    if ((base.View == View.Details) || (base.View == View.List))
                    {
                        graphics.DrawLine(new Pen(this.m_lineColor, 2f), new Point(itemAt.Bounds.X, itemAt.Bounds.Y), new Point(itemAt.Bounds.X + base.Bounds.Width, itemAt.Bounds.Y));
                        pointArray = new Point[] { new Point(itemAt.Bounds.X, itemAt.Bounds.Y - 5), new Point(itemAt.Bounds.X + 5, itemAt.Bounds.Y), new Point(itemAt.Bounds.X, itemAt.Bounds.Y + 5) };
                        graphics.FillPolygon(new SolidBrush(this.m_lineColor), pointArray);
                        pointArray = new Point[] { new Point(base.Bounds.Width - 4, itemAt.Bounds.Y - 5), new Point(base.Bounds.Width - 9, itemAt.Bounds.Y), new Point(base.Bounds.Width - 4, itemAt.Bounds.Y + 5) };
                        graphics.FillPolygon(new SolidBrush(this.m_lineColor), pointArray);
                    }
                    else
                    {
                        graphics.DrawLine(new Pen(this.m_lineColor, 2f), new Point(itemAt.Bounds.X, itemAt.Bounds.Y), new Point(itemAt.Bounds.X, itemAt.Bounds.Y + itemAt.Bounds.Height));
                        pointArray = new Point[] { new Point(itemAt.Bounds.X - 5, itemAt.Bounds.Y), new Point(itemAt.Bounds.X + 5, itemAt.Bounds.Y), new Point(itemAt.Bounds.X, itemAt.Bounds.Y + 5) };
                        graphics.FillPolygon(new SolidBrush(this.m_lineColor), pointArray);
                        pointArray = new Point[] { new Point(itemAt.Bounds.X - 5, itemAt.Bounds.Y + itemAt.Bounds.Height), new Point(itemAt.Bounds.X + 5, itemAt.Bounds.Y + itemAt.Bounds.Height), new Point(itemAt.Bounds.X, (itemAt.Bounds.Y + itemAt.Bounds.Height) - 5) };
                        graphics.FillPolygon(new SolidBrush(this.m_lineColor), pointArray);
                    }
                    foreach (System.Windows.Forms.ListViewItem item2 in base.SelectedItems)
                    {
                        if (item2.Index == itemAt.Index)
                        {
                            drgevent.Effect = DragDropEffects.None;
                            itemAt.EnsureVisible();
                            return;
                        }
                    }
                    itemAt.EnsureVisible();
                }
                drgevent.Effect = DragDropEffects.Move;
                base.OnDragOver(drgevent);
            }
        }

        protected override void OnItemDrag(ItemDragEventArgs e)
        {
            if (!this.m_allowReorder)
            {
                base.OnItemDrag(e);
            }
            else
            {
                base.DoDragDrop(this.GetDataForDragDrop(), DragDropEffects.Move);
                base.OnItemDrag(e);
            }
        }

        protected override void OnLostFocus(EventArgs e)
        {
            this.ResetOutOfRange();
            base.Invalidate();
            base.OnLostFocus(e);
        }

        private void ResetOutOfRange()
        {
            if (this.m_previousItem != null)
            {
                this.m_previousItem = null;
            }
        }

        // Properties
        [Category("Behavior")]
        public bool AllowReorder
        {
            get
            {
                return this.m_allowReorder;
            }
            set
            {
                this.m_allowReorder = value;
            }
        }

        [Category("Appearance")]
        public Color LineColor
        {
            get
            {
                return this.m_lineColor;
            }
            set
            {
                this.m_lineColor = value;
            }
        }

        // Nested Types
        private class DragItemData
        {
            // Fields
            private ArrayList m_dragItems;
            private DragAndDropListView m_listView;

            // Methods
            public DragItemData(DragAndDropListView listView)
            {
                this.m_listView = listView;
                this.m_dragItems = new ArrayList();
            }

            // Properties
            public ArrayList DragItems
            {
                get
                {
                    return this.m_dragItems;
                }
            }

            public DragAndDropListView ListView
            {
                get
                {
                    return this.m_listView;
                }
            }
        }
    }

	
}
