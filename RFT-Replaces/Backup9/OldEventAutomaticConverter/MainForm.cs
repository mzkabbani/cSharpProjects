using System;
using System.IO;
using System.Xml;
using System.Text.RegularExpressions;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace OldEventAutomaticConverter {
    public partial class MainForm : Form {

        #region Global Variables

        string rulesDirectory = string.Empty;
        Dictionary<int, string> filterMappings = new Dictionary<int, string>();
        Dictionary<int, string> actionToolbarMappings = new Dictionary<int, string>();
        string GlobalSearchText = string.Empty;
        int TotalNumberOfFiles = 0;
        int currentNumberOfFiles = 0;
        List<string> eventFiles;
        bool Finished = false;


        #endregion

        #region Constructor

        public MainForm() {
            InitializeComponent();
        }

        #endregion

        #region Methods

        #region OverviewTab

        private void DispatchAllWorkers(int numberOfWorkers, int remainder, int filesperWorker) {
            List<Rules> allRules = new List<Rules>();
            allRules = BuildRulesList(allRules);
            for (int i = 0; i < numberOfWorkers; i++) {
                if (filesperWorker * (i) < eventFiles.Count) {
                    WorkerObject workerObject = new WorkerObject();
                    BackgroundWorker bGW = new BackgroundWorker();
                    bGW.WorkerReportsProgress = true;
                    bGW.DoWork += bgWorker_DoWork;
                    bGW.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
                    workerObject.AllRules = allRules;
                    string[] eventFilesPortion = new string[filesperWorker];

                    eventFiles.CopyTo(filesperWorker * i, eventFilesPortion, 0, filesperWorker);
                    workerObject.EventFiles = new List<string>(eventFilesPortion);
                    bGW.RunWorkerAsync(workerObject);
                    if (i + 1 == numberOfWorkers && remainder != 0) {
                        workerObject = new WorkerObject();
                        bGW = new BackgroundWorker();
                        bGW.WorkerReportsProgress = true;
                        bGW.DoWork += bgWorker_DoWork;
                        bGW.RunWorkerCompleted += bgWorker_RunWorkerCompleted;
                        workerObject.AllRules = allRules;
                        eventFilesPortion = new string[remainder];

                        eventFiles.CopyTo(filesperWorker * (i + 1), eventFilesPortion, 0, remainder);
                        workerObject.EventFiles = new List<string>(eventFilesPortion);
                        bGW.RunWorkerAsync(workerObject);
                    }
                }



            }
        }

        private int ValidateWorkersAndShowCalculations(out int numberOfWorkers, out int remainder, out int filesperWorker) {
            TotalNumberOfFiles = eventFiles.Count;

            numberOfWorkers = (int)nudNumberOfWorkers.Value;
            InsertLog("Found " + TotalNumberOfFiles + " file(s) to parse\r\n");
            //MessageBox.Show("Found " + TotalNumberOfFiles + " file(s) to parse\r\n");
            //int filesperWorker = (int)Math.Ceiling(TotalNumberOfFiles / nudNumberOfWorkers.Value);
            if ((int)nudNumberOfWorkers.Value > TotalNumberOfFiles) {
                nudNumberOfWorkers.Value = TotalNumberOfFiles;
            }
            remainder = 0;
            filesperWorker = Math.DivRem((int)TotalNumberOfFiles, (int)nudNumberOfWorkers.Value, out remainder);

            //if (remainder > ((int)nudNumberOfWorkers.Value / 2)) {
            //    ShowCustomError("Your choice of number of workers is not efficient, \nplease choose an adequate number of workers considering:"
            //        + "\n- Total files: " + TotalNumberOfFiles + "\n- Files to allocated to each worker\n\n Note: Golden choice is allocating 20 files to each worker on average", false);
            //    return -1;
            //}
            return 0;
        }


        private bool IsValidToParse(string fromDir, ListBox.ObjectCollection objectCollection) {
            if (String.IsNullOrEmpty(fromDir)) {
                ShowCustomError("Please choose a from directory", false);
                return false;
            }
            if (!Directory.Exists(fromDir)) {
                ShowCustomError("The chosen directory to parse from does not exist", false);
            }
            if (objectCollection.Count == 0) {
                ShowCustomError("Please define conversion rules before you proceed", false);
                return false;
            }
            return true;
        }

        private int ParseFile(string file, List<Rules> allRules) {
            try {
                Dictionary<Rules, double> ruleTimes = new Dictionary<Rules, double>();
                int fileReplacementsCount = 0;
                List<string> regexMatchesForTokens = new List<string>();
                StreamReader reader = new StreamReader(file);
                string fileRead = string.Empty;
                try {
                    fileRead = reader.ReadToEnd();
                } catch (Exception ex) {
                    ShowCustomError(ex.Message, false);
                } finally {
                    reader.Close();
                }
                for (int i = 0; i < allRules.Count; i++) {
                    DateTime now = DateTime.Now;
                    if (!allRules[i].regexMode) {
                        if (fileRead.Contains(allRules[i].oldEvent)) {
                            fileRead = fileRead.Replace(allRules[i].oldEvent, allRules[i].newEvent);
                            fileReplacementsCount++;
                        }
                    } else if (allRules[i].regexMode) {
                        //regex mode                    
                        GroupCollection groupCollection = Regex.Match(fileRead, allRules[i].oldEvent, RegexOptions.Compiled).Groups;
                        MatchCollection eventMatches = Regex.Matches(fileRead, allRules[i].oldEvent, RegexOptions.Compiled);
                        int counter = 0;
                        if (groupCollection.Count > 1) {
                            foreach (Match eventMatch in eventMatches) {
                                //1-extract the value
                                //2-replace with new event
                                MatchCollection matches = Regex.Matches(allRules[i].newEvent, @"{[\S]*}", RegexOptions.Compiled);
                                int groupNumber = 0;
                                string replacementEvent = string.Empty;
                                for (int p = 0; p < matches.Count; p++) {
                                    groupNumber = Convert.ToInt32(matches[p].ToString().Replace("{", "").Replace("}", ""));
                                    if (eventMatch.Groups[groupNumber].Value.Contains("\"")) {
                                        string extractedGroupActualValue = eventMatch.Groups[groupNumber].Value.Split('"')[1];
                                        // this is for the filter special cases
                                        if (allRules[i].filterEvent) {
                                            string lastCharacter = extractedGroupActualValue.Substring(extractedGroupActualValue.Length - 1);//get last character
                                            int filterIndex;
                                            string lastCharacterReplacement = string.Empty;
                                            if (Int32.TryParse(lastCharacter, out filterIndex)) {
                                                lastCharacterReplacement = filterMappings[filterIndex];
                                            }
                                            extractedGroupActualValue = lastCharacterReplacement + "::1";
                                        } else if (allRules[i].ActionToolBar) {//action TB specific
                                            string lastCharacter = extractedGroupActualValue.Substring(extractedGroupActualValue.Length - 1);//get  last character
                                            int actionTBIndex;
                                            string lastCharacterReplacement = string.Empty;
                                            if (Int32.TryParse(lastCharacter, out actionTBIndex)) {
                                                lastCharacterReplacement = actionToolbarMappings[actionTBIndex];
                                            }
                                            extractedGroupActualValue = lastCharacterReplacement + "::1";
                                        }
                                        if (!string.IsNullOrEmpty(replacementEvent)) {
                                            replacementEvent = replacementEvent.Replace(matches[p].Value.ToString(), extractedGroupActualValue);

                                        } else {
                                            replacementEvent = allRules[i].newEvent.Replace(matches[p].Value.ToString(), extractedGroupActualValue);

                                        }
                                    } else {
                                        string extractedGroupActualValue = eventMatch.Groups[groupNumber].Value;
                                        // this is for the filter special cases
                                        if (allRules[i].filterEvent) {
                                            string lastCharacter = extractedGroupActualValue.Substring(extractedGroupActualValue.Length - 1);//get last character
                                            int filterIndex;
                                            string lastCharacterReplacement = string.Empty;
                                            if (Int32.TryParse(lastCharacter, out filterIndex)) {
                                                lastCharacterReplacement = filterMappings[filterIndex];
                                            }
                                            extractedGroupActualValue = lastCharacterReplacement + "::1";
                                        } else if (allRules[i].ActionToolBar) {//action TB specific
                                            string lastCharacter = extractedGroupActualValue.Substring(extractedGroupActualValue.Length - 1);//get  last character
                                            int actionTBIndex;
                                            string lastCharacterReplacement = string.Empty;
                                            if (Int32.TryParse(lastCharacter, out actionTBIndex)) {
                                                lastCharacterReplacement = actionToolbarMappings[actionTBIndex];
                                            }
                                            extractedGroupActualValue = lastCharacterReplacement + "::1";
                                        }
                                        if (!string.IsNullOrEmpty(replacementEvent)) {
                                            replacementEvent = replacementEvent.Replace(matches[p].Value.ToString(), extractedGroupActualValue);

                                        } else {
                                            replacementEvent = allRules[i].newEvent.Replace(matches[p].Value.ToString(), extractedGroupActualValue);

                                        }
                                    }
                                }
                                //3-replace value at selected point
                                if (counter == 0) {
                                    fileReplacementsCount = fileReplacementsCount + Regex.Matches(fileRead, allRules[i].oldEvent, RegexOptions.Compiled).Count;
                                    counter++;
                                }
                                fileRead = fileRead.Replace(eventMatch.Value, replacementEvent);
                                //fileRead = Regex.Replace(fileRead, allRules[i].oldEvent, replacementEvent);
                            }
                        } else {
                            fileReplacementsCount = fileReplacementsCount + Regex.Matches(fileRead, allRules[i].oldEvent).Count;
                            fileRead = ReplaceWithRegex(fileRead, allRules[i].oldEvent, allRules[i].newEvent);
                        }
                    }
                }
                //Write the finished file to output directory

                WriteNewFile(txtFromDirectory.Text, file, fileRead);

                return fileReplacementsCount;

            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
            return -1;
        }

        private string ReplaceWithRegex(string inputFile, string oldEventWithRegex, string newEvent) {
            Regex regex = new Regex(oldEventWithRegex, RegexOptions.IgnoreCase | RegexOptions.Multiline | RegexOptions.Compiled);
            return Regex.Replace(inputFile, oldEventWithRegex, newEvent, RegexOptions.Compiled);
        }

        private void WriteNewFile(string outputDirectory, string originalFileName, string updatedFileContent) {
            FileInfo fileInfo = new FileInfo(originalFileName);
            StreamWriter writer = new StreamWriter(originalFileName);
            try {
                writer.Write(updatedFileContent);
            } finally {
                //InsertLog("Parsed File: " + fileInfo.Name + "\r\n");
                if (writer != null) {
                    writer.Close();
                }
            }
        }

        #endregion

        #region Common

        public String arrayToString(String[] stringarray) {
            String str = " ";
            for (int i = 0; i < stringarray.Length; i++) {
                str = str + "\r\nParsed: " + stringarray[i];
            }
            return str;
        }

        private void LoadSavedRules(string rulesDirectory, bool insertLog) {
            lbSavedRules.Items.Clear();
            string[] savedRulesPaths = Directory.GetFiles(rulesDirectory);
            if (insertLog) {
                InsertLog("\r\n\r\n\r\n\r\n------------ Tool Loading ------------\r\nLoading rules from: " + rulesDirectory + ".\r\n");
                InsertLog("Found: " + savedRulesPaths.Length + " saved rules.\r\n");
            }
            foreach (string savedRule in savedRulesPaths) {
                if (insertLog) {
                    InsertLogWithUI("Rule name: " + Path.GetFileNameWithoutExtension(savedRule) + " Fetched !\r\n");
                }
                FetchSavedRule(savedRule);
            }
        }

        private void InsertLogWithUI(string logText) {
            logText = DateTime.Now + " - " + logText;
            txtLog.Text = txtLog.Text + logText;
            string logsDirectory = Directory.GetCurrentDirectory() + @"\Logs";
            if (!Directory.Exists(logsDirectory)) {
                Directory.CreateDirectory(logsDirectory);
            }
            StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\Logs\application.log", true);
            try {
                writer.Write(logText);
            } finally {
                if (writer != null) {
                    writer.Close();
                }
            }
        }

        private void InsertLog(string logText) {
            //logText = DateTime.Now + " - " + logText;
            // txtLog.Text = txtLog.Text + logText;
            string logsDirectory = Directory.GetCurrentDirectory() + @"\Logs";
            if (!Directory.Exists(logsDirectory)) {
                Directory.CreateDirectory(logsDirectory);
            }
            StreamWriter writer = new StreamWriter(Directory.GetCurrentDirectory() + @"\Logs\application.log", true);
            try {
                writer.Write(logText);
            } finally {
                if (writer != null) {
                    writer.Close();
                }
            }
        }

        private void FetchSavedRule(string savedRule) {
            StreamReader reader = new StreamReader(savedRule);
            try {
                string ruleFileSaved = reader.ReadToEnd();
                string[] delimiter = new string[] { "\n#End#\n" };
                string[] ruleDetailes = ruleFileSaved.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                Rules rules = new Rules();
                bool isRegexMode = false;
                bool isFilterEvent = false;
                bool isActionToolbar = false;
                if (ruleDetailes.Length > 2) {
                    if (string.Equals(ruleDetailes[2], "True", StringComparison.InvariantCulture)) {
                        isRegexMode = true;
                    }
                    if (ruleDetailes.Length > 3) {
                        if (string.Equals(ruleDetailes[3], "True", StringComparison.InvariantCulture)) {
                            isFilterEvent = true;
                        }
                        if (ruleDetailes.Length > 4) {
                            if (string.Equals(ruleDetailes[4], "True", StringComparison.InvariantCulture)) {
                                isActionToolbar = true;
                            }
                        }
                    }
                }
                rules.ruleName = Path.GetFileNameWithoutExtension(savedRule);
                rules.oldEvent = ruleDetailes[0];
                rules.newEvent = ruleDetailes[1];
                rules.regexMode = isRegexMode;
                rules.filterEvent = isFilterEvent;
                rules.ActionToolBar = isActionToolbar;
                lbSavedRules.Items.Add(rules);
            } finally {
                if (reader != null)
                    reader.Close();
            }
        }

        public DialogResult ShowCustomError(string errorText, bool useYesNo) {
            if (!useYesNo) {
                InsertLog("ERROR: " + errorText + "\r\n");
                return MessageBox.Show(errorText, "Error!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            } else {
                InsertLog("ERROR: " + errorText + "\r\n");
                return MessageBox.Show(errorText, "Error!", MessageBoxButtons.YesNo, MessageBoxIcon.Error);
            }
        }

        #endregion

        #region Add Rules Tab

        private string GetRulesDirectory() {
            RulesDirectoryForm rulesDirForm = new RulesDirectoryForm();
            DialogResult dialog = rulesDirForm.ShowDialog();
            string SvnRulePath = string.Empty;
            string defaultRulesPath = "D:\\svn\\PFR0000081\\pfr\\QAA-Activities\\GIM\\Rules";
            if (dialog == DialogResult.OK) {
                SvnRulePath = rulesDirForm.Controls["txtSvnLocation"].Text;
                if (string.IsNullOrEmpty(SvnRulePath)) {
                    DialogResult dialogResult = MessageBox.Show("The rules directory cannot be left empty!", "Rules Directory Empty", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    GetRulesDirectory();
                } else if (string.Equals(SvnRulePath, defaultRulesPath)) {
                    DialogResult dialogResult = MessageBox.Show("You are using the default rules directory, Do you want to proceed?", "Defaul Rules Directory", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.No) {
                        GetRulesDirectory();
                    }
                }
            } else {
                DialogResult dialogFromClose = MessageBox.Show("Are you sure you want to exit ?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogFromClose == DialogResult.Yes) {
                    this.Close();
                } else {
                    GetRulesDirectory();
                }
            }
            return SvnRulePath;
        }

        private void DisableRuleModification() {
            btnSaveRule.Enabled = false;
            btnAddRule.Enabled = false;
            btnReset.Enabled = false;
            chkActionTB.Enabled = false;
            chkFilter.Enabled = false;
            chkRegexMode.Enabled = false;
            txtOldEvent.ReadOnly = true;
            txtNewEvent.ReadOnly = true;
            txtRuleName.ReadOnly = true;
        }

        private void ResetRulesAddingTab() {
            btnSaveRule.Enabled = false;
            btnAddRule.Enabled = true;
            txtRuleName.ReadOnly = false;
            chkRegexMode.Checked = false;
            chkFilter.Checked = false;
            chkActionTB.Checked = false;
            txtRuleName.Clear();
            txtOldEvent.Clear();
            txtNewEvent.Clear();
        }

        //0 1 2 3 4 5 6 7 8 9
        //C E G I K M O Q S U
        private void BuildFilterMappings() {
            filterMappings.Add(0, "C");
            filterMappings.Add(1, "E");
            filterMappings.Add(2, "G");
            filterMappings.Add(3, "I");
            filterMappings.Add(4, "K");
            filterMappings.Add(5, "M");
            filterMappings.Add(6, "O");
            filterMappings.Add(7, "Q");
            filterMappings.Add(8, "S");
            filterMappings.Add(9, "U");
        }

        //0 1 2 3 4 5 6 7 8 9 10 11 12 13 14 15 16 17 18 19 20 21 22 23 24 25
        //A B C D E F G H I J  K  L  M  N  O  P  Q  R  S  T  U  V  W  X  Y  Z
        private void BuildActionToolbarMappings() {
            actionToolbarMappings.Add(0, "A");
            actionToolbarMappings.Add(1, "B");
            actionToolbarMappings.Add(2, "C");
            actionToolbarMappings.Add(3, "D");
            actionToolbarMappings.Add(4, "E");
            actionToolbarMappings.Add(5, "F");
            actionToolbarMappings.Add(6, "G");
            actionToolbarMappings.Add(7, "H");
            actionToolbarMappings.Add(8, "I");
            actionToolbarMappings.Add(9, "J");
            actionToolbarMappings.Add(10, "K");
            actionToolbarMappings.Add(11, "L");
            actionToolbarMappings.Add(12, "M");
            actionToolbarMappings.Add(13, "N");
            actionToolbarMappings.Add(14, "O");
            actionToolbarMappings.Add(15, "P");
            actionToolbarMappings.Add(16, "Q");
            actionToolbarMappings.Add(17, "R");
            actionToolbarMappings.Add(18, "S");
            actionToolbarMappings.Add(19, "T");
            actionToolbarMappings.Add(20, "U");
            actionToolbarMappings.Add(21, "V");
            actionToolbarMappings.Add(22, "W");
            actionToolbarMappings.Add(23, "X");
            actionToolbarMappings.Add(24, "Y");
            actionToolbarMappings.Add(25, "Z");
        }

        private bool IsValidToAddRule(string oldEvent, string newEvent, string ruleName) {
            if (String.IsNullOrEmpty(oldEvent)) {
                ShowCustomError("Please insert an old event to parse", false);
                return false;
            }
            if (String.IsNullOrEmpty(newEvent)) {
                ShowCustomError("Please insert new event to replace the old one", false);
                return false;
            }
            if (String.IsNullOrEmpty(ruleName)) {
                ShowCustomError("Rule name cannot be empty", false);
                return false;
            }
            if ((chkActionTB.Checked || chkFilter.Checked) && !chkRegexMode.Checked) {
                ShowCustomError("Please toggle regex mode to enable parsing of Action TB and Filter Events", false);
                return false;
            }
            if (chkActionTB.Checked && chkFilter.Checked) {
                ShowCustomError("Event should either correspond to an Action TB or Filter not both", false);
                return false;
            }
            for (int i = 0; i < lbSavedRules.Items.Count; i++) {
                if (string.Equals(lbSavedRules.Items[i].ToString(), ruleName) && btnSaveRule.Enabled == false) {
                    ShowCustomError("The selected rule name already exists, please modify it", false);
                    return false;
                }
            }

            //if (!TryParseXml(txtOldEvent.Text)) {
            //    ShowCustomError("The old event is not of valid XML format", false);
            //    return false;

            //}
            if (!TryParseXml(txtNewEvent.Text)) {
                if (ShowCustomError("The new event is not of valid XML format, Override ?", true) != DialogResult.Yes) {
                    return false;
                }
            }
            return true;
        }

        private bool TryParseXml(string xml) {
            using (XmlReader xr = XmlReader.Create(
                    new StringReader(xml))) {
                try {
                    while (xr.Read()) { }
                } catch (Exception) {
                    return false;
                }
            }
            return true;
        }

        private void AddRuleToAppDirectory(Rules rules) {
            string workingDirectory = Directory.GetCurrentDirectory();
            if (!Directory.Exists(rulesDirectory)) {
                Directory.CreateDirectory(rulesDirectory);
            }
            StreamWriter writer = new StreamWriter(rulesDirectory + @"\" + rules.ruleName + ".txt");
            try {
                writer.Write(rules.oldEvent + "\n#End#\n" + rules.newEvent + "\n#End#\n" + rules.regexMode.ToString() + "\n#End#\n" + rules.filterEvent.ToString() + "\n#End#\n" + rules.ActionToolBar.ToString());
            } finally {
                if (writer != null) {
                    writer.Close();
                }
            }
        }

        #endregion

        #region Incidents

        private bool IsValidToAddIncident(string incidentName, string incident, string solution, bool isNewIncident) {
            if (string.IsNullOrEmpty(incidentName) || string.IsNullOrEmpty(incident) || string.IsNullOrEmpty(solution)) {
                ShowCustomError("Please fill in the following mandatory fields:\n-Name\n-Incident\n-Solution", false);
                return false;
            }
            if (isNewIncident) {
                if (IncidentNameIsUsed(incidentName)) {
                    ShowCustomError("The selected incident name is already in use !", false);
                    return false;
                }
            }
            if (incidentName.IndexOfAny(System.IO.Path.GetInvalidFileNameChars()) != -1) {
                ShowCustomError("Incident name cannot contain " + "[ \\/:*?\"<>| ] characters", false);
                return false;
            }
            return true;
        }

        private bool IncidentNameIsUsed(string incidentName) {
            for (int i = 0; i < dgvIncidents.Rows.Count; i++) {
                if (string.Equals(dgvIncidents.Rows[i].Cells["dgvcName"].Value, incidentName)) {
                    return true;
                }
            }
            return false;
        }

        private void CreateIncidentFile(Incident incident) {
            if (!Directory.Exists(rulesDirectory + @"\Incidents\")) {
                DialogResult dialog = ShowCustomError("Incidents directory not found, do you want to create one ?", true);
                if (dialog == DialogResult.Yes) {
                    Directory.CreateDirectory(rulesDirectory + @"\Incidents\");
                }
            }
            StreamWriter writer = new StreamWriter(rulesDirectory + @"\Incidents\" + incident.Name + ".inc");
            try {
                writer.Write(incident.Name + "\n#END#\n");
                writer.Write(incident.IncidentText + "\n#END#\n");
                writer.Write(incident.Solution + "\n#END#\n");
                writer.Write(incident.Notes);
            } finally {
                if (writer != null) {
                    writer.Close();
                }
            }
        }

        private Incident AddIncidentToDataGrid(string incidentName, string incidentText, string incidentSolution, string incidentNotes) {
            Incident incidentObj = new Incident();
            incidentObj.Name = incidentName;
            incidentObj.IncidentText = incidentText;
            incidentObj.Solution = incidentSolution;
            incidentObj.Notes = incidentNotes;

            dgvIncidents.Rows.Add();
            dgvIncidents.Rows[dgvIncidents.Rows.Count - 1].Cells["dgvcName"].Value = incidentObj.Name;
            dgvIncidents.Rows[dgvIncidents.Rows.Count - 1].Cells["dgvcIncident"].Value = incidentObj.IncidentText;
            dgvIncidents.Rows[dgvIncidents.Rows.Count - 1].Cells["dgvcSolution"].Value = incidentObj.Solution;
            dgvIncidents.Rows[dgvIncidents.Rows.Count - 1].Cells["dgvcNotes"].Value = incidentObj.Notes;


            return incidentObj;
        }

        private Incident ReadIncidentFiles(string fileName) {
            Incident incidentObj = new Incident();
            StreamReader reader = new StreamReader(fileName);
            try {
                string fileText = reader.ReadToEnd();
                string[] delimiter = new string[] { "\n#END#\n" };
                string[] incidentAttributes = fileText.Split(delimiter, StringSplitOptions.RemoveEmptyEntries);
                if (incidentAttributes.Length < 4) {
                    return null;
                }
                incidentObj.Name = incidentAttributes[0];
                incidentObj.IncidentText = incidentAttributes[1];
                incidentObj.Solution = incidentAttributes[2];
                incidentObj.Notes = incidentAttributes[3];
                return incidentObj;
            } finally {
                if (reader != null) {
                    reader.Close();
                }
            }
        }

        private void LoadSavedIncidents(string incidentDirectory) {
            dgvIncidents.Rows.Clear();
            string[] incidentFiles = Directory.GetFiles(incidentDirectory);
            for (int i = 0; i < incidentFiles.Length; i++) {
                Incident parsedIncident = ReadIncidentFiles(incidentFiles[i]);
                AddIncidentToDataGrid(parsedIncident.Name, parsedIncident.IncidentText, parsedIncident.Solution, parsedIncident.Notes);
            }

        }

        private void SearchForIncidents(string searchText) {
            int startIndex = 0;
            bool found = false;
            if (dgvIncidents.SelectedRows.Count > 0) {
                //if (dgvIncidents.SelectedRows[0].Index != 0) {                           
                //    startIndex = dgvIncidents.SelectedRows[0].Index;
                //} else {
                //    if(string.Equals(GlobalSearchText,searchText)){
                //        if (dgvIncidents.Rows.Count-1 > startIndex) {
                //            startIndex = startIndex+1;
                //        }                    
                //    }else{
                //    GlobalSearchText = searchText;
                //    }            
                //}
                DataGridViewSelectedRowCollection selectedRows = dgvIncidents.SelectedRows;
                for (int i = 0; i < selectedRows.Count; i++) {
                    selectedRows[i].Selected = false;
                    selectedRows[i].DefaultCellStyle.BackColor = Color.White;
                }
            }
            if (!string.Equals(GlobalSearchText, searchText)) {
                startIndex = 0;
                DataGridViewSelectedRowCollection selectedRows = dgvIncidents.SelectedRows;
                for (int i = 0; i < dgvIncidents.Rows.Count; i++) {
                    dgvIncidents.Rows[i].Selected = false;
                    dgvIncidents.Rows[i].DefaultCellStyle.BackColor = Color.White;

                }
                GlobalSearchText = searchText;
            }
            // case sensitive mode !!!!

            if (!chkCaseSensitive.Checked) {
                for (int i = startIndex; i < dgvIncidents.Rows.Count; i++) {
                    if (Regex.IsMatch(dgvIncidents.Rows[i].Cells["dgvcName"].Value.ToString(), searchText, RegexOptions.IgnoreCase) ||
                        Regex.IsMatch(dgvIncidents.Rows[i].Cells["dgvcIncident"].Value.ToString(), searchText, RegexOptions.IgnoreCase) ||
                        Regex.IsMatch(dgvIncidents.Rows[i].Cells["dgvcSolution"].Value.ToString(), searchText, RegexOptions.IgnoreCase)) {
                        found = true;
                        //dgvr.DefaultCellStyle.ForeColor
                        dgvIncidents.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                    }
                    if (!Regex.IsMatch(dgvIncidents.Rows[0].Cells["dgvcName"].Value.ToString(), searchText, RegexOptions.IgnoreCase) &&
                        !Regex.IsMatch(dgvIncidents.Rows[0].Cells["dgvcIncident"].Value.ToString(), searchText, RegexOptions.IgnoreCase) &&
                        !Regex.IsMatch(dgvIncidents.Rows[0].Cells["dgvcSolution"].Value.ToString(), searchText, RegexOptions.IgnoreCase)) {
                        dgvIncidents.Rows[0].Selected = false;
                    }
                }
            } else {
                for (int i = startIndex; i < dgvIncidents.Rows.Count; i++) {
                    if (dgvIncidents.Rows[i].Cells["dgvcName"].Value.ToString().Contains(searchText) || dgvIncidents.Rows[i].Cells["dgvcIncident"].Value.ToString().Contains(searchText) || dgvIncidents.Rows[i].Cells["dgvcSolution"].Value.ToString().Contains(searchText)) {
                        found = true;
                        //dgvr.DefaultCellStyle.ForeColor
                        dgvIncidents.Rows[i].DefaultCellStyle.BackColor = Color.YellowGreen;
                    }
                }
                if (!dgvIncidents.Rows[0].Cells["dgvcName"].Value.ToString().Contains(searchText) && !dgvIncidents.Rows[0].Cells["dgvcIncident"].Value.ToString().Contains(searchText) && !dgvIncidents.Rows[0].Cells["dgvcSolution"].Value.ToString().Contains(searchText)) {
                    dgvIncidents.Rows[0].Selected = false;
                }
            }

            if (!found) {
                startIndex = 0;
                DataGridViewSelectedRowCollection selectedRows = dgvIncidents.SelectedRows;
                for (int i = 0; i < dgvIncidents.Rows.Count; i++) {
                    dgvIncidents.Rows[i].Selected = false;
                    dgvIncidents.Rows[i].DefaultCellStyle.BackColor = Color.White;
                }
                ShowCustomError("You search query did not return any results!", false);
            }
        }

        #endregion

        #endregion

        #region Events

        #region OverviewTab


        private void bWGetFiles_DoWork(object sender, DoWorkEventArgs e) {
            try {
                List<string> eventFiles = new List<string>();
                eventFiles = GetEventFiles();
                //List<string> eventFilesintact = new List<string>();
                //  for (int i = 0; i < eventFiles.Count; i++) {
                //       FileInfo fileInfo = new FileInfo(eventFiles[i]);
                //       DateTime date = new DateTime(2011, 5, 31);
                //       if (fileInfo.LastWriteTime < date) {
                //          eventFilesintact.Add(eventFiles[i]);
                //      }
                //    }
                //  e.Result = eventFilesintact;
                e.Result = eventFiles;
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void bWGetFiles_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            try {
                eventFiles = e.Result as List<string>;
                InsertLog("Worker completed loading " + eventFiles.Count + " file(s)");
                lblGlobalStatus.Text = "Loaded " + eventFiles.Count + " file(s)...";
                if (eventFiles.Count > 10) {
                    nudNumberOfWorkers.Value = eventFiles.Count / 10;
                } else {
                    nudNumberOfWorkers.Value = 1;
                }
                //nudNumberOfWorkers.Value = eventFiles.Count / 10;
                int numberOfWorkers;
                int remainder;
                int filesperWorker;
                if (ValidateWorkersAndShowCalculations(out numberOfWorkers, out remainder, out filesperWorker) == -1) {
                    // we have an illogical number of workers
                    btnParse.Enabled = true;
                    return;
                }
                DispatchAllWorkers(numberOfWorkers, remainder, filesperWorker);

            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void toolStripStatusLabel1_TextChanged(object sender, EventArgs e) {
            try {
                if (string.Equals(toolStripStatusLabel1.Text, "Status: 100% done!") && Finished) {
                    btnParse.Enabled = true;
                    MessageBox.Show("Done parsing all files", "Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTotalReplacements.Text = "0";
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }


        private void btnBrowseFrom_Click(object sender, EventArgs e) {
            try {
                FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
                DialogResult dialogResult = folderBrowserDialog.ShowDialog();
                if (dialogResult == DialogResult.OK) {
                    txtFromDirectory.Text = folderBrowserDialog.SelectedPath;
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnClearFrom_Click(object sender, EventArgs e) {
            try {
                txtFromDirectory.Clear();
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        public static int gcd(int x, int y) {
            if (y == 0) return x;
            else return gcd(y, x % y);
        }

        private void btnParse_Click(object sender, EventArgs e) {
            try {
                if (IsValidToParse(txtFromDirectory.Text, lbSavedRules.Items)) {
                    TotalNumberOfFiles = 0;
                    currentNumberOfFiles = 0;
                    //DateTime start = DateTime.Now;


                    lblGlobalStatus.Text = "Innitiating...";
                    toolStripStatusLabel1.Text = "Status: Loading";
                    bWGetFiles.RunWorkerAsync();// this worker is the parent, it will get files then start dispatching other workers
                    lblGlobalStatus.Text = "Loading Event Files...";
                    btnParse.Enabled = false;
                    //WorkerObject workerObject = new WorkerObject();
                    //workerObject.AllRules = allRules;
                    //workerObject.EventFiles = eventFiles;





                    //DateTime end = DateTime.Now;
                    //TimeSpan elapsed = end - start;
                    //MessageBox.Show("Converted " + numberOfFiles + " event files in " + elapsed.TotalSeconds + " second(s).", "Conversion Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    //btnShowResult.Enabled = true;
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private List<string> GetEventFiles() {

            List<string> eventFiles = new List<string>(Directory.GetFiles(txtFromDirectory.Text, "step*.xml", SearchOption.AllDirectories));
            List<string> newEventFiles = new List<string>();
            for (int i = 0; i < eventFiles.Count; i++) {
                if (!eventFiles[i].Contains("customs") && !eventFiles[i].Contains("gui") && !eventFiles[i].Contains("_events")) {
                    newEventFiles.Add(eventFiles[i]);
                }
            }

            return newEventFiles;
        }

        private List<Rules> BuildRulesList(List<Rules> allRules) {
            foreach (object item in lbSavedRules.Items) {
                allRules.Add((Rules)item);
            }
            return allRules;
        }


        private void btnShowResult_Click(object sender, EventArgs e) {
            try {
                string myPath = txtFromDirectory.Text;
                System.Diagnostics.Process prc = new System.Diagnostics.Process();
                prc.StartInfo.FileName = myPath;
                prc.Start();
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void txtLog_TextChanged(object sender, EventArgs e) {
            txtLog.SelectionStart = txtLog.Text.Length;
            txtLog.ScrollToCaret();
        }

        #endregion

        #region Add Rule Tab

        private void chkFilter_CheckedChanged(object sender, EventArgs e) {
            try {
                if (chkFilter.Checked) {
                    chkRegexMode.Checked = true;
                    chkActionTB.Checked = false;
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void chkActionTB_CheckedChanged(object sender, EventArgs e) {
            try {
                if (chkActionTB.Checked) {
                    chkRegexMode.Checked = true;
                    chkFilter.Checked = false;
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnAddRule_Click(object sender, EventArgs e) {
            try {
                if (IsValidToAddRule(txtOldEvent.Text, txtNewEvent.Text, txtRuleName.Text)) {
                    Rules rules = new Rules();
                    rules.ruleName = txtRuleName.Text;
                    rules.oldEvent = txtOldEvent.Text;
                    rules.newEvent = txtNewEvent.Text;
                    rules.regexMode = chkRegexMode.Checked;
                    rules.filterEvent = chkFilter.Checked;
                    rules.ActionToolBar = chkActionTB.Checked;
                    lbSavedRules.Items.Add(rules);
                    AddRuleToAppDirectory(rules);
                    InsertLog("Added rule :" + rules.ruleName + "\r\n");
                    txtRuleName.ReadOnly = true;
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void lbSavedRules_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (lbSavedRules.SelectedItem == null) {
                    return;
                }
                Rules rule = (Rules)lbSavedRules.SelectedItem;
                txtNewEvent.Text = rule.newEvent;
                txtOldEvent.Text = rule.oldEvent;
                txtRuleName.Text = rule.ruleName;
                chkRegexMode.Checked = rule.regexMode;
                chkFilter.Checked = rule.filterEvent;
                chkActionTB.Checked = rule.ActionToolBar;
                txtRuleName.ReadOnly = true;
                btnAddRule.Enabled = false;
                btnSaveRule.Enabled = true;
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnReset_Click(object sender, EventArgs e) {
            try {
                ResetRulesAddingTab();
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnSaveRule_Click(object sender, EventArgs e) {
            try {
                if (IsValidToAddRule(txtOldEvent.Text, txtNewEvent.Text, txtRuleName.Text)) {
                    Rules rule = (Rules)lbSavedRules.SelectedItem;
                    rule.oldEvent = txtOldEvent.Text;
                    rule.newEvent = txtNewEvent.Text;
                    rule.regexMode = chkRegexMode.Checked;
                    rule.filterEvent = chkFilter.Checked;
                    rule.ActionToolBar = chkActionTB.Checked;
                    AddRuleToAppDirectory(rule);
                    InsertLog("Saved rule: " + rule.ruleName + "\r\n");
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnDeleteRule_Click(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(txtRuleName.Text) && !string.IsNullOrEmpty(txtOldEvent.Text) && !string.IsNullOrEmpty(txtNewEvent.Text)) {
                    DialogResult dialogResult = MessageBox.Show("Are you sure you want to delete rule?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Information);
                    if (dialogResult == DialogResult.Yes) {
                        int indexToDelete = lbSavedRules.SelectedIndex;
                        //  lbSavedRules.Items.Remove((object)txtRuleName.Text);
                        lbSavedRules.Items.RemoveAt(indexToDelete);
                        File.Delete(rulesDirectory + @"\" + txtRuleName.Text + ".txt");
                        InsertLog("Deleted rule : " + txtRuleName.Text + "\r\n");
                        ResetRulesAddingTab();
                    }
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void chkRegexMode_CheckedChanged(object sender, EventArgs e) {
            try {
                if (!chkRegexMode.Checked) {
                    chkFilter.Checked = false;
                    chkActionTB.Checked = false;
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        #endregion

        #region New Rule Request Tab

        private void btnSendRequest_Click(object sender, EventArgs e) {
            try {
                if (IsValidToSendMail(txtRequestRuleName.Text, txtRequestOldEvent.Text, txtRequestNewEvent.Text)) {
                    System.Security.Principal.WindowsIdentity user =
                    System.Security.Principal.WindowsIdentity.GetCurrent();
                    EmailRequest emailRequest = new EmailRequest();
                    string ruleMode = string.Empty;
                    ruleMode = "\n\n~~~~~Modes~~~~~\nAction TB mode= " + chkRequestActionTB.Checked.ToString() +
                    "\nFilter Event mode=" + chkRequestFilterEv.Checked.ToString() +
                    "\nRegex mode=" + chkRequestRegexM.Checked.ToString() + "\n~~~~~~~~~~~~~~~";
                    emailRequest.SendEmail("SemiAutomaticConverter@SAC.Com", user.Name.Replace("LB-MUREX-COM\\", "") + "@murex.com", "Your request for a new rule has been sent", txtRequestRuleName.Text + ruleMode + "\n\nOld Event Text:\n" + txtRequestOldEvent.Text + "\n\nNew Event Text:\n" + txtRequestNewEvent.Text);
                    emailRequest.SendEmailToMultiUsers("SemiAutomaticConverter@SAC.Com", "mkabbani@murex.com;jeldib@murex.com", "New rule Request from " + user.Name.Replace("LB-MUREX-COM\\", ""), "Rule Name: " + txtRequestRuleName.Text + ruleMode + "\n\nOld Event Text:\n" + txtRequestOldEvent.Text + "\n\nNew Event Text:\n" + txtRequestNewEvent.Text);
                    MessageBox.Show("A new rule request has been sent, \nyou will be notified with the addition shortly.", "Request Sent", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private bool IsValidToSendMail(string ruleName, string oldEvent, string newEvent) {
            if (string.IsNullOrEmpty(ruleName) || string.IsNullOrEmpty(oldEvent) || string.IsNullOrEmpty(newEvent)) {
                ShowCustomError("Please fill the following mandatory info:\n-Rule Name\n-Old Event\n-New Event", false);
                return false;
            }
            return true;
        }

        private void btnRequestReset_Click(object sender, EventArgs e) {
            txtRequestNewEvent.Clear();
            txtRequestOldEvent.Clear();
            txtRequestRuleName.Clear();
            chkRequestRegexM.Checked = false;
            chkRequestFilterEv.Checked = false;
            chkRequestActionTB.Checked = false;
        }

        #endregion

        #region Incidents

        private void btnAddIncident_Click_1(object sender, EventArgs e) {
            try {
                if (IsValidToAddIncident(txtIncidentName.Text, txtIncident.Text, txtIncidentSolution.Text, true)) {
                    Incident incident = AddIncidentToDataGrid(txtIncidentName.Text, txtIncident.Text, txtIncidentSolution.Text, txtIncidentNotes.Text);
                    CreateIncidentFile(incident);
                    System.Security.Principal.WindowsIdentity user =
                    System.Security.Principal.WindowsIdentity.GetCurrent();
                    EmailRequest emailRequest = new EmailRequest();
                    emailRequest.SendEmailToMultiUsers("SemiAutomaticConverter@SAC.Com", "mkabbani@murex.com;jeldib@murex.com", "Incident has been added by " + user.Name.Replace("LB-MUREX-COM\\", ""), "\nIncident name: " + txtIncidentName.Text + "\n\nIncident text: " + txtIncident.Text + "\n\nIncident Solution:\n " + txtIncidentSolution.Text + "\n\nIncident Notes:\n " + txtIncidentNotes.Text);
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void txtIncidentSearchText_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyValue == 13) {
                try {
                    if (!string.IsNullOrEmpty(txtIncidentSearchText.Text)) {
                        SearchForIncidents(txtIncidentSearchText.Text);
                    } else {
                        ShowCustomError("Search text cannot be empty!", false);
                    }
                } catch (Exception ex) {
                    ShowCustomError(ex.Message, false);
                }
            }
        }

        private void btnSearchIncidents_Click(object sender, EventArgs e) {
            try {
                if (!string.IsNullOrEmpty(txtIncidentSearchText.Text)) {
                    SearchForIncidents(txtIncidentSearchText.Text);
                } else {
                    ShowCustomError("Search text cannot be empty!", false);
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void PopulateUiFromDg(int rowIndex) {
            txtIncidentName.Text = dgvIncidents.Rows[rowIndex].Cells["dgvcName"].Value.ToString();
            txtIncident.Text = dgvIncidents.Rows[rowIndex].Cells["dgvcIncident"].Value.ToString();
            txtIncidentSolution.Text = dgvIncidents.Rows[rowIndex].Cells["dgvcSolution"].Value.ToString();
            txtIncidentNotes.Text = dgvIncidents.Rows[rowIndex].Cells["dgvcNotes"].Value.ToString();
        }

        private void dgvIncidents_CellClick(object sender, DataGridViewCellEventArgs e) {
            try {
                PopulateUiFromDg(e.RowIndex);
                txtIncidentName.ReadOnly = true;
                btnAddIncident.Enabled = false;
                btnSaveIncident.Enabled = true;
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnSaveIncident_Click(object sender, EventArgs e) {
            try {

                SaveIncident(txtIncidentName.Text, txtIncident.Text, txtIncidentSolution.Text, txtIncidentNotes.Text);
                LoadSavedIncidents(rulesDirectory + @"\Incidents");
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void SaveIncident(string incidentName, string incidentText, string incidentSolution, string incidentNotes) {
            try {
                if (IsValidToAddIncident(txtIncidentName.Text, txtIncident.Text, txtIncidentSolution.Text, false)) {
                    Incident incident = new Incident();
                    incident.Name = txtIncidentName.Text;
                    incident.IncidentText = txtIncident.Text;
                    incident.Solution = txtIncidentSolution.Text;
                    incident.Notes = txtIncidentNotes.Text;
                    CreateIncidentFile(incident);
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnResetIncident_Click(object sender, EventArgs e) {
            try {
                txtIncidentName.ReadOnly = false;
                txtIncidentName.Text = string.Empty;
                txtIncident.Text = string.Empty;
                txtIncidentSolution.Text = string.Empty;
                txtIncidentNotes.Text = string.Empty;
                txtIncidentSearchText.Text = string.Empty;
                btnSaveIncident.Enabled = false;
                btnAddIncident.Enabled = true;
                GlobalSearchText = string.Empty;
                for (int i = 0; i < dgvIncidents.Rows.Count; i++) {
                    dgvIncidents.Rows[i].Selected = false;
                    dgvIncidents.Rows[i].DefaultCellStyle.BackColor = Color.White;

                }

            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnRefreshIncidents_Click(object sender, EventArgs e) {
            try {
                LoadSavedIncidents(rulesDirectory + @"\Incidents");
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        #endregion

        #region Common

        private void AutomaticConverter_Load(object sender, EventArgs e) {
            try {
                rulesDirectory = GetRulesDirectory();
                System.Security.Principal.WindowsIdentity user =
                System.Security.Principal.WindowsIdentity.GetCurrent();
                if (!user.Name.Contains("mkabbani") && !user.Name.Contains("jeldib")) {
                    DisableRuleModification();
                }
                LoadSavedRules(rulesDirectory, true);
                BuildFilterMappings();
                BuildActionToolbarMappings();
                //helpAbouttext = "<Command EventID=\"3\" Code=\"COMMAND_1949\">\n<Focus FocusCode=\"NO_FOCUS\" PanelFather=\"NO_FOCUS\" Area=\"\" Line=\"-1\" Col=\"-1\" Ref=\"-1\" CursorMoveLine=\"-1\" CaretPosition=\"0\"/>\n</Command>\n<Command EventID=\"4\" Code=\"COMMAND_1998\">\n<Focus FocusCode=\"_MX_ABOUT___BTN_EXIT___0\" PanelFather=\"OBJECT_20\" Area=\"\" Line=\"0\" Col=\"0\" Ref=\"0\" CursorMoveLine=\"-1\" CaretPosition=\"0\"/>\n</Command>\n</Events>\n</MXClientScript>";
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnClose_Click(object sender, EventArgs e) {
            try {
                DialogResult dialogResult = MessageBox.Show("Are you sure you want to exit?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dialogResult == DialogResult.Yes) {
                    this.Close();
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void tabControl1_SelectedIndexChanged(object sender, EventArgs e) {
            try {
                if (tabControl1.SelectedIndex == 1) {
                    LoadSavedRules(rulesDirectory, false);
                }
                if (tabControl1.SelectedIndex == 3) {
                    LoadSavedIncidents(rulesDirectory + @"\Incidents");
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void btnRefreshRules_Click(object sender, EventArgs e) {
            try {
                LoadSavedRules(rulesDirectory, false);
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        #endregion

        #region BackgroundWorker

        private void bgWorker_DoWork(object sender, DoWorkEventArgs e) {
            try {
                WorkerObject workerObject = e.Argument as WorkerObject;
                int result = 100 / workerObject.EventFiles.Count;
                int replacementCount = 0;
                workerReporting workerReport = new workerReporting();
                workerReport.FilesParsed = workerObject.EventFiles;
                for (int i = 0; i < workerObject.EventFiles.Count; i++) {
                    replacementCount = replacementCount + ParseFile(workerObject.EventFiles[i], workerObject.AllRules);
                    workerReport.FileName = workerObject.EventFiles[i];
                    // workerReport.ReplacementCount = replacementCount;
                    workerReport.CurrentFileNumber = i + 1;
                    bgWorker.ReportProgress(i * result, workerReport);
                }
                workerReport.ReplacementCount = replacementCount;
                e.Result = workerReport;
                bgWorker.ReportProgress(100);
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void bgWorker_ProgressChanged(object sender, ProgressChangedEventArgs e) {
            try {
                int done = e.ProgressPercentage;
                //this.txtLog.Text = this.txtLog.Text + done;

                // tspbProgress.Value = e.ProgressPercentage;
                //toolStripStatusLabel1.Text = "Status: " + e.ProgressPercentage + "%";
                //if (tspbProgress.Value == 100) {
                //    btnShowResult.Enabled = true;
                //    toolStripStatusLabel1.Text = "Status: 100%";

                //    MessageBox.Show("Conversion has been completed!");
                //}
                if (e.UserState != null) {
                    workerReporting workerReport = e.UserState as workerReporting;
                    //lblStats.Text = workerReport.CurrentFileNumber + "/" + TotalNumberOfFiles + "Files parsed !";
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        private void bgWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e) {
            try {
                if (e.Result != null) {
                    workerReporting report = e.Result as workerReporting;

                    txtLog.Text = txtLog.Text + "\r\n" + arrayToString(report.FilesParsed.ToArray()) + "\r\n==>" + report.ReplacementCount + " replacement(s) in " + report.FilesParsed.Count + " file(s).";
                    InsertLog("\r\n" + arrayToString(report.FilesParsed.ToArray()) + "\r\n==>" + report.ReplacementCount + " replacement(s) in " + report.FilesParsed.Count + " file(s).");
                    txtTotalReplacements.Text = (Int32.Parse(txtTotalReplacements.Text) + report.ReplacementCount).ToString();
                    currentNumberOfFiles = currentNumberOfFiles + report.FilesParsed.Count;
                    double currentRatio = ((double)currentNumberOfFiles / TotalNumberOfFiles) * 100;
                    tspbProgress.Value = (int)Math.Ceiling(currentRatio);
                    lblGlobalStatus.Text = currentNumberOfFiles + "/" + TotalNumberOfFiles + " files parsed !";
                    if ((int)Math.Ceiling(currentRatio) == 100) {
                        Finished = true;
                    }
                    toolStripStatusLabel1.Text = "Status: " + (int)Math.Ceiling(currentRatio) + "% done!";
                }
            } catch (Exception ex) {
                ShowCustomError(ex.Message, false);
            }
        }

        #endregion

        #endregion
    }
}
