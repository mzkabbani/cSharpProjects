using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi.Classes {
    class ApplicationConfigObject {
        public string key;
        public string value;
        public int id;
        public ApplicationConfigObject() { }
        public ApplicationConfigObject(int newId,string newKey, string newValue) {
            key = newKey;
            value = newValue;
            id = newId;
        }
    }
}