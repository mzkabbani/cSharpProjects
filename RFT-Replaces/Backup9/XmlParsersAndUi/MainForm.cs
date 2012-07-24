using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;

using System.Text;
using System.Windows.Forms;
using System.Configuration;
using System.IO;
using System.Xml;
using Utilities.WinForms;
using XmlParsersAndUi.Forms;


namespace XmlParsersAndUi {
    public partial class MainForm : Form {

        #region Constructor

        public MainForm() {
            InitializeComponent();
        }

        #endregion

        #region Variables

        private int childFormNumber = 0;
        string loggedInUser = string.Empty;
        int idleCounter = 0;
        public static bool appProcessing = false;
        bool TIMER_ENABLED = true;
        int CONFIGURED_IDLE_TIME = 15;

        #endregion

        #region Properties

        public List<string> priveligedUsers {
            get;
            set;
        }

        #endregion

        #region Methods

        private void SetBackEndConnectionParameter(XmlNodeList configFileNodes) {
            for (int i = 0; i < configFileNodes.Count; i++) {
                if (configFileNodes[i].NodeType == XmlNodeType.Element && configFileNodes[i].Attributes["key"] != null) {
                    if (string.Equals(configFileNodes[i].Attributes["key"].Value, "ConnectionParameter")) {
                        BackEndUtils.ConnectionParamter = configFileNodes[i].Attributes["value"].Value;
                        // tsConnectedTo.Text = "Connected to " + Directory.GetParent(BackEndUtils.ConnectionParamter);
                    }
                }
            }
            if (string.IsNullOrEmpty(BackEndUtils.ConnectionParamter)) {
                BackEndUtils.ConnectionParamter = @"X:\beast\Test_Automation\Database.sdf";
            }
        }

        private void UpdateUIForPriviligedUsers(List<string> priviligedUsersList, string loggedInUser) {
            if (priviligedUsersList.Contains(loggedInUser)) {
                setupRecommendationsToolStripMenuItem.Visible = true;

            }
            if (string.Equals(loggedInUser, "mkabbani")) {
                testingToolStripMenuItem.Visible = true;
                preferencesToolStripMenuItem.Visible = true;
            }
        }

        private XmlNodeList LoadConfigFileNodes() {
            string configFile = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + @"\app.conf";
            XmlDocument xmldoc = new XmlDocument();
            try {
                xmldoc.Load(configFile);
                priveligedUsers = new List<string>();
                return xmldoc.DocumentElement.ChildNodes[0].ChildNodes;
            } catch (Exception ex) {
                FrontendUtils.ShowError("Configuration file not found, default configuration will be loaded", ex);
            }
            return null;
        }

        public List<string> GetPriviligedUsersFromConfigFile(XmlNodeList nodeList) {
            List<string> priveligedUsers = new List<string>();
            for (int i = 0; i < nodeList.Count; i++) {
                if (nodeList[i].NodeType == XmlNodeType.Element && nodeList[i].Attributes["key"] != null) {
                    priveligedUsers.Add(nodeList[i].Attributes["key"].Value);
                }
            }
            return priveligedUsers;
        }

        private void CheckIdleTime() {
            int cpuPct = (int)(ApplicationIdleTimer.CPUUsageThreshold * 100.0);
            ApplicationIdleTimer.ApplicationIdle += new ApplicationIdleTimer.ApplicationIdleEventHandler(this.App_Idle);
            Application.Idle += new System.EventHandler(this.Idle_Count);
            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Tick += new EventHandler(this.timer1_Tick);
            // Start the timer
            timer1.Start();
            timer1.Interval = 250;
        }

        #endregion

        #region Events

        private void ShowNewForm(object sender, EventArgs e) {
            Form childForm = new Form();
            childForm.MdiParent = this;
            childForm.Text = "Window " + childFormNumber++;
            childForm.Show();
        }

        private void OpenFile(object sender, EventArgs e) {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            openFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (openFileDialog.ShowDialog(this) == DialogResult.OK) {
                string FileName = openFileDialog.FileName;
            }
        }

        private void SaveAsToolStripMenuItem_Click(object sender, EventArgs e) {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            saveFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";
            if (saveFileDialog.ShowDialog(this) == DialogResult.OK) {
                string FileName = saveFileDialog.FileName;
            }
        }

        private void ExitToolsStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void CutToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void CopyToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void PasteToolStripMenuItem_Click(object sender, EventArgs e) {
        }

        private void CascadeToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.Cascade);
        }

        private void TileVerticalToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.TileVertical);
        }

        private void TileHorizontalToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.TileHorizontal);
        }

        private void ArrangeIconsToolStripMenuItem_Click(object sender, EventArgs e) {
            LayoutMdi(MdiLayout.ArrangeIcons);
        }

        private void CloseAllToolStripMenuItem_Click(object sender, EventArgs e) {
            foreach (Form childForm in MdiChildren) {
                childForm.Close();
            }
        }

        private void simpleOperationToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                //  SimpleOperationParser simpleOperationParser = new SimpleOperationParser();
                //   simpleOperationParser.MdiParent = this;
                //   simpleOperationParser.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void form1ToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                Form1 form1 = new Form1();
                form1.MdiParent = this;
                form1.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void form2ToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void setupRecommendationsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Recommendation Config started by " + loggedInUser);
                SetupSimpleRecForm setupRecForm = new SetupSimpleRecForm();
                setupRecForm.MdiParent = this;
                setupRecForm.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void configBuilderToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ConfigBuilder configBuilder = new ConfigBuilder();
                configBuilder.MdiParent = this;
                configBuilder.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void cleanupToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                CleanupForm cleanupForm = new CleanupForm();
                cleanupForm.MdiParent = this;
                cleanupForm.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void timer1_Tick(object sender, EventArgs e) {
            if (!ApplicationIdleTimer.IsIdle && this.tsLabelStatus.Text != "Busy") {
                this.tsLabelStatus.BackColor = Color.LightCoral;
                this.tsLabelStatus.Text = "Busy";
            }
            this.tsAppStatus.Text = idleCounter.ToString("#,##0");
        }

        private void App_Idle(ApplicationIdleTimer.ApplicationIdleEventArgs e) {
            tsLabelStatus.Text = string.Format("Idle: {0}s", e.IdleDuration.TotalSeconds.ToString("0"));
            tsLabelStatus.BackColor = Color.LightCyan;
            if (e.IdleDuration.Minutes > CONFIGURED_IDLE_TIME && !appProcessing) {
                //FrontendUtils.SendUsageNotification(loggedInUser + " was forced to exit by timer!");
                Application.Exit();
            }
        }

        private void Idle_Count(object sender, System.EventArgs e) {
            idleCounter++;
        }

        private void MainForm_Load(object sender, EventArgs e) {
            try {
                loggedInUser = FrontendUtils.GetCurrentUser();
                FrontendUtils.CreateLogsDirectory();
                this.Text = this.Text + " - Welcome " + loggedInUser + "!";
                XmlNodeList configFileNodes = LoadConfigFileNodes();
                SetBackEndConnectionParameter(configFileNodes);
                bool TIMER_ENABLED = Convert.ToBoolean(BackEndUtils.GetAppConfigValueByKey(BackEndUtils.ApplicationConfigKeys.EnableTimerKey));
                if (TIMER_ENABLED) {
                    CONFIGURED_IDLE_TIME = Convert.ToInt32(BackEndUtils.GetAppConfigValueByKey(BackEndUtils.ApplicationConfigKeys.TimerDurationKey));
                    CheckIdleTime();
                }
                int userId = BackEndUtils.GetUserIdByUsername(loggedInUser);
                if (userId == 0) {
                    userId = BackEndUtils.InsertNewUser(loggedInUser);
                    BackEndUtils.UpdateUserStatusById(userId, true);
                }
                List<string> priviligedUsersList = BackEndUtils.GetPriviligedUsersAsList();
                UpdateUIForPriviligedUsers(priviligedUsersList, loggedInUser);
                //FrontendUtils.SendUsageNotification("User Logged In " + loggedInUser);
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void macroSplitToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Macro split started by " + loggedInUser);
                BulkMacroSplitterForm form = new BulkMacroSplitterForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void firstLevelCleanupToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("First Level Cleanup started by " + loggedInUser);
                CleanupForm form = new CleanupForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void advancedOperationToolStripMenuItem_Click(object sender, EventArgs e) {

        }

        private void bulkCustomsToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                FrontendUtils.SendUsageNotification("Bulk Customs started by " + loggedInUser);
                BulkCustomsForm form = new BulkCustomsForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void advancedRecToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                SetupAdvancedRecForm form = new SetupAdvancedRecForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                DatabaseViewer form = new DatabaseViewer();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void form1ToolStripMenuItem_Click_1(object sender, EventArgs e) {
            Form1 form = new Form1();
            form.MdiParent = this;
            form.Show();
        }

        private void rFTUpdaterToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                RftReplacementForm form = new RftReplacementForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e) {
            try {
                int userId = BackEndUtils.GetUserIdByUsername(loggedInUser);
                BackEndUtils.UpdateUserStatusById(userId, false);
                FrontendUtils.SendUsageNotification(loggedInUser + " has exited the application!");
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void testExceptionToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                StreamReader reader = new StreamReader("D:\test.xml");
                reader.ReadToEnd();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
                FrontendUtils.ShowError("wow", null);
                ExceptionForm form = new ExceptionForm("Sample exception!!", ex);
                form.Show();
            }
        }

        private void userStatusToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                UsersStatus form = new UsersStatus();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void nicknameSpecificToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                OracleUpdaterForm form = new OracleUpdaterForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void form2ToolStripMenuItem1_Click(object sender, EventArgs e) {
            try {
                Form2 form2 = new Form2();
                form2.MdiParent = this;
                form2.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void preferencesToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                ApplicationPreferencesForm form = new ApplicationPreferencesForm();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        private void remoteServerToolStripMenuItem_Click(object sender, EventArgs e) {
            try {
                RemoteServer form = new RemoteServer();
                form.MdiParent = this;
                form.Show();
            } catch (Exception ex) {
                FrontendUtils.ShowError(ex.Message, ex);
            }
        }

        #endregion

        
    }
}