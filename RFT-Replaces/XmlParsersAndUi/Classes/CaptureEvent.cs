using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using XmlParsersAndUi.Classes;

namespace XmlParsersAndUi {

    public enum CapturePointListType {
        SimpleList = 1,
        ListWithMutlipleDesc = 2,
    }

    public class CaptureEvent {
        public string CaptureEventName, CaptureEventDescription, CaptureEventEventText;
        public ReplacementEvent Replacement;
        public List<CustomTreeNode> CaptureEventCapturePointsList;
        public CapturePointListType capturePointListType;
        public int captureEventCategory;
        public int captureEventuserId;
        public int captureEventUsageCount, CaptureEventId;
        public CaptureEvent(string Name, string Description, string EventText,List<CustomTreeNode> CapturePointsList) {
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            CaptureEventCapturePointsList = CapturePointsList;   
        }

        public CaptureEvent(int id, string Name, string Description, string EventText, List<CustomTreeNode> CapturePointsList) {
            CaptureEventId = id;
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            CaptureEventCapturePointsList = CapturePointsList;
        }

        public CaptureEvent(string Name, string Description, string EventText,int categoryId, int usageCount, List<CustomTreeNode> CapturePointsList) {
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            captureEventCategory = categoryId;
            CaptureEventCapturePointsList = CapturePointsList;
            captureEventUsageCount = usageCount;
        }

        public CaptureEvent(int id, string Name, string Description, string EventText, int categoryId, int usageCount, List<CustomTreeNode> CapturePointsList) {
            CaptureEventId = id;
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            captureEventCategory = categoryId;
            CaptureEventCapturePointsList = CapturePointsList;
            captureEventUsageCount = usageCount;
        }

        public CaptureEvent(int id, string Name, string Description, string EventText, int categoryId, int usageCount, List<CustomTreeNode> CapturePointsList, int userId) {
            CaptureEventId = id;
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            captureEventCategory = categoryId;
            CaptureEventCapturePointsList = CapturePointsList;
            captureEventUsageCount = usageCount;
            captureEventuserId = userId;
        }
        public CaptureEvent() { 
        
        }
        public override string ToString() {
            return CaptureEventName;
        }
    
    }
}
