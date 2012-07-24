using System;
using System.Collections.Generic;

namespace OldEventAutomaticConverter {
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
