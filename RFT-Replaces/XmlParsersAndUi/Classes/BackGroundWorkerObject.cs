using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi.Classes {
    public class BackGroundWorkerObject {

        public List<CaptureEvent> selectedCaptureEvents = new List<CaptureEvent>();
        public List<FileToParseObject> targetedFiles = new List<FileToParseObject>();
        public object returnObject;
        public List<ComplexCaptureMatchObject> returnedComplexCaptureMatchObject = new List<ComplexCaptureMatchObject>();

        public override string ToString() {
            return "Replacement";
        }
    }
    public class FileToParseObject {
        public string fileName;
        public bool parsed;

        public FileToParseObject(string newFileName, bool isParsed) {
            fileName = newFileName;
            parsed = isParsed;
        }
    }
    
}
