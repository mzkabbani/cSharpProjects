using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi {

    public enum CapturePointListType {
        SimpleList = 1,
        ListWithMutlipleDesc = 2,
    }

    public class CaptureEvent {
        public string CaptureEventName, CaptureEventDescription, CaptureEventEventText;
        public List<CustomTreeNode> CaptureEventCapturePointsList;
        public CapturePointListType capturePointListType; 
        public CaptureEvent(string Name, string Description, string EventText,List<CustomTreeNode> CapturePointsList) {
            CaptureEventName = Name;
            CaptureEventDescription = Description;
            CaptureEventEventText = EventText;
            CaptureEventCapturePointsList = CapturePointsList;   
        }

        public override string ToString() {
            return CaptureEventName;
        }
    
    }
}
