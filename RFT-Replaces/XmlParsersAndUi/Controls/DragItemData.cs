/*
 * Created by SharpDevelop.
 * User: mkabbani
 * Date: 10/10/2012
 * Time: 3:15 PM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections;

namespace XmlParsersAndUi.Controls
{
	/// <summary>
	/// Description of DragItemData.
	/// </summary>
	public class DragItemData
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
