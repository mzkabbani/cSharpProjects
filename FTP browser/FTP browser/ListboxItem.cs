using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FTP_browser {
    public class ListboxItem {
        public string fileName;
        public string filePath;

        public override string ToString() {
            return fileName;
        }
    }
}
