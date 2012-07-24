using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SemiAutomaticConverter {
    public class Rules {
        public string ruleName;
        public string oldEvent;
        public string newEvent;
        public bool regexMode;
        public bool filterEvent;
        public bool ActionToolBar;
        public override string ToString() {
            return ruleName;
        }
    }
}
