using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace XmlParsersAndUi.Classes {
    public class EnvComparisonFilter {
        public int filterId, localFilterType;        
        public string localName, localDescription, localFilterPattern;
        public int localUserId;

        public override string ToString() {
            return localName ;
        }

        public EnvComparisonFilter(int id, string name, string description, string pattern, int filterType, int userId) {
            filterId = id;
            localName = name;
            localDescription = description;
            localFilterPattern = pattern;
            localFilterType = filterType;
            localUserId = userId;
        }

        public enum ComparisonFilterType {
            Regular=0,
            PreFilter=1,        
        }
    
    }
}
