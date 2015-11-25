using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Reflection;
using System.IO;
using System.Globalization;
using System.Threading;

namespace AlterCollation
{
    public class MainForm : Form, IScriptExecuteCallback
    {


		#region Windows Form Designer generated code


		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		private System.Windows.Forms.CheckBox dropAllE;
		private System.Windows.Forms.Button cancelB;
		private System.Windows.Forms.ComboBox languageE;
		private System.Windows.Forms.Label languageL;
		private System.Windows.Forms.Label labelNote2;
		private System.Windows.Forms.Label labelNote1;
		private System.Windows.Forms.ComboBox cmbCollationToMigrate;
		private System.Windows.Forms.ProgressBar progressBar;
		private System.Windows.Forms.Button scriptB;
		private System.Windows.Forms.RichTextBox feedbackL;
		private System.Windows.Forms.Button executeB;
		private System.Windows.Forms.Label collationL;
		private System.Windows.Forms.Label databaseL;
		private System.Windows.Forms.Label passwordL;
		private System.Windows.Forms.Label userIdL;
		private System.Windows.Forms.Label serverL;
		private System.Windows.Forms.TextBox txtPassword;
		private System.Windows.Forms.TextBox txtUserID;
		private System.Windows.Forms.CheckBox integratedE;
		private System.Windows.Forms.TextBox txtDataBaseName;
		private System.Windows.Forms.TextBox txtServerInstance;
		private System.Windows.Forms.CheckBox singleUserE;
        private Button btnConnectServerTest;
        private Label label1;
        private Label lblErrorConnect;
        private TextBox txtActualCollations;
		private System.Windows.Forms.Timer cancelTimer;

		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.cancelB = new System.Windows.Forms.Button();
            this.languageE = new System.Windows.Forms.ComboBox();
            this.languageL = new System.Windows.Forms.Label();
            this.dropAllE = new System.Windows.Forms.CheckBox();
            this.labelNote2 = new System.Windows.Forms.Label();
            this.labelNote1 = new System.Windows.Forms.Label();
            this.cmbCollationToMigrate = new System.Windows.Forms.ComboBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.scriptB = new System.Windows.Forms.Button();
            this.feedbackL = new System.Windows.Forms.RichTextBox();
            this.executeB = new System.Windows.Forms.Button();
            this.collationL = new System.Windows.Forms.Label();
            this.databaseL = new System.Windows.Forms.Label();
            this.passwordL = new System.Windows.Forms.Label();
            this.userIdL = new System.Windows.Forms.Label();
            this.serverL = new System.Windows.Forms.Label();
            this.txtPassword = new System.Windows.Forms.TextBox();
            this.txtUserID = new System.Windows.Forms.TextBox();
            this.integratedE = new System.Windows.Forms.CheckBox();
            this.txtDataBaseName = new System.Windows.Forms.TextBox();
            this.txtServerInstance = new System.Windows.Forms.TextBox();
            this.cancelTimer = new System.Windows.Forms.Timer(this.components);
            this.singleUserE = new System.Windows.Forms.CheckBox();
            this.btnConnectServerTest = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.lblErrorConnect = new System.Windows.Forms.Label();
            this.txtActualCollations = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // cancelB
            // 
            this.cancelB.Location = new System.Drawing.Point(536, 526);
            this.cancelB.Name = "cancelB";
            this.cancelB.Size = new System.Drawing.Size(88, 24);
            this.cancelB.TabIndex = 41;
            this.cancelB.Text = "Cancelar";
            this.cancelB.Click += new System.EventHandler(this.cancelB_Click);
            // 
            // languageE
            // 
            this.languageE.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.languageE.Enabled = false;
            this.languageE.Location = new System.Drawing.Point(131, 284);
            this.languageE.Name = "languageE";
            this.languageE.Size = new System.Drawing.Size(461, 21);
            this.languageE.TabIndex = 40;
            this.languageE.DropDown += new System.EventHandler(this.languageE_DropDown);
            // 
            // languageL
            // 
            this.languageL.Location = new System.Drawing.Point(5, 287);
            this.languageL.Name = "languageL";
            this.languageL.Size = new System.Drawing.Size(120, 16);
            this.languageL.TabIndex = 39;
            this.languageL.Text = "Full Text Language:";
            // 
            // dropAllE
            // 
            this.dropAllE.ImageAlign = System.Drawing.ContentAlignment.TopLeft;
            this.dropAllE.Location = new System.Drawing.Point(339, 162);
            this.dropAllE.Name = "dropAllE";
            this.dropAllE.Size = new System.Drawing.Size(256, 32);
            this.dropAllE.TabIndex = 38;
            this.dropAllE.Text = "Drop All Keys and Constraints.  (By Default only the required items are dropped)";
            this.dropAllE.TextAlign = System.Drawing.ContentAlignment.TopLeft;
            // 
            // labelNote2
            // 
            this.labelNote2.Location = new System.Drawing.Point(336, 88);
            this.labelNote2.Name = "labelNote2";
            this.labelNote2.Size = new System.Drawing.Size(256, 56);
            this.labelNote2.TabIndex = 35;
            this.labelNote2.Text = "NOTE: Once the script has been executed you will see any error messages shown in " +
    "red in the window below directly after the SQL code that failed";
            // 
            // labelNote1
            // 
            this.labelNote1.Location = new System.Drawing.Point(336, 8);
            this.labelNote1.Name = "labelNote1";
            this.labelNote1.Size = new System.Drawing.Size(256, 80);
            this.labelNote1.TabIndex = 34;
            this.labelNote1.Text = resources.GetString("labelNote1.Text");
            // 
            // cmbCollationToMigrate
            // 
            this.cmbCollationToMigrate.Enabled = false;
            this.cmbCollationToMigrate.Location = new System.Drawing.Point(131, 257);
            this.cmbCollationToMigrate.Name = "cmbCollationToMigrate";
            this.cmbCollationToMigrate.Size = new System.Drawing.Size(461, 21);
            this.cmbCollationToMigrate.TabIndex = 31;
            this.cmbCollationToMigrate.DropDown += new System.EventHandler(this.collationE_DropDown);
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.progressBar.Location = new System.Drawing.Point(8, 319);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(616, 23);
            this.progressBar.TabIndex = 36;
            // 
            // scriptB
            // 
            this.scriptB.Enabled = false;
            this.scriptB.Location = new System.Drawing.Point(308, 526);
            this.scriptB.Name = "scriptB";
            this.scriptB.Size = new System.Drawing.Size(104, 24);
            this.scriptB.TabIndex = 33;
            this.scriptB.Text = "Script";
            this.scriptB.Click += new System.EventHandler(this.scriptB_Click);
            // 
            // feedbackL
            // 
            this.feedbackL.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.feedbackL.DetectUrls = false;
            this.feedbackL.Location = new System.Drawing.Point(8, 353);
            this.feedbackL.Name = "feedbackL";
            this.feedbackL.ReadOnly = true;
            this.feedbackL.Size = new System.Drawing.Size(616, 167);
            this.feedbackL.TabIndex = 37;
            this.feedbackL.Text = "";
            // 
            // executeB
            // 
            this.executeB.Enabled = false;
            this.executeB.Location = new System.Drawing.Point(418, 526);
            this.executeB.Name = "executeB";
            this.executeB.Size = new System.Drawing.Size(112, 24);
            this.executeB.TabIndex = 32;
            this.executeB.Text = "Impactar script";
            this.executeB.Click += new System.EventHandler(this.executeB_Click);
            // 
            // collationL
            // 
            this.collationL.Location = new System.Drawing.Point(8, 260);
            this.collationL.Name = "collationL";
            this.collationL.Size = new System.Drawing.Size(120, 16);
            this.collationL.TabIndex = 30;
            this.collationL.Text = "Collation final:";
            // 
            // databaseL
            // 
            this.databaseL.Location = new System.Drawing.Point(8, 110);
            this.databaseL.Name = "databaseL";
            this.databaseL.Size = new System.Drawing.Size(120, 16);
            this.databaseL.TabIndex = 28;
            this.databaseL.Text = "Catalogo:";
            // 
            // passwordL
            // 
            this.passwordL.Enabled = false;
            this.passwordL.Location = new System.Drawing.Point(8, 84);
            this.passwordL.Name = "passwordL";
            this.passwordL.Size = new System.Drawing.Size(120, 16);
            this.passwordL.TabIndex = 26;
            this.passwordL.Text = "Password:";
            // 
            // userIdL
            // 
            this.userIdL.Enabled = false;
            this.userIdL.Location = new System.Drawing.Point(8, 59);
            this.userIdL.Name = "userIdL";
            this.userIdL.Size = new System.Drawing.Size(120, 16);
            this.userIdL.TabIndex = 24;
            this.userIdL.Text = "User ID:";
            // 
            // serverL
            // 
            this.serverL.Location = new System.Drawing.Point(8, 11);
            this.serverL.Name = "serverL";
            this.serverL.Size = new System.Drawing.Size(117, 20);
            this.serverL.TabIndex = 21;
            this.serverL.Text = "Instancia SQL Server:";
            // 
            // txtPassword
            // 
            this.txtPassword.Enabled = false;
            this.txtPassword.Location = new System.Drawing.Point(131, 81);
            this.txtPassword.Name = "txtPassword";
            this.txtPassword.Size = new System.Drawing.Size(197, 20);
            this.txtPassword.TabIndex = 27;
            // 
            // txtUserID
            // 
            this.txtUserID.Enabled = false;
            this.txtUserID.Location = new System.Drawing.Point(131, 55);
            this.txtUserID.Name = "txtUserID";
            this.txtUserID.Size = new System.Drawing.Size(197, 20);
            this.txtUserID.TabIndex = 25;
            // 
            // integratedE
            // 
            this.integratedE.Checked = true;
            this.integratedE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.integratedE.Location = new System.Drawing.Point(131, 32);
            this.integratedE.Name = "integratedE";
            this.integratedE.Size = new System.Drawing.Size(184, 24);
            this.integratedE.TabIndex = 23;
            this.integratedE.Text = "Seguridad integrada";
            this.integratedE.CheckedChanged += new System.EventHandler(this.integratedE_CheckedChanged);
            // 
            // txtDataBaseName
            // 
            this.txtDataBaseName.Location = new System.Drawing.Point(131, 107);
            this.txtDataBaseName.Name = "txtDataBaseName";
            this.txtDataBaseName.Size = new System.Drawing.Size(197, 20);
            this.txtDataBaseName.TabIndex = 29;
            this.txtDataBaseName.Text = "master";
            // 
            // txtServerInstance
            // 
            this.txtServerInstance.Location = new System.Drawing.Point(131, 11);
            this.txtServerInstance.Name = "txtServerInstance";
            this.txtServerInstance.Size = new System.Drawing.Size(197, 20);
            this.txtServerInstance.TabIndex = 22;
            this.txtServerInstance.Text = ".\\sqlexpress2012";
            this.txtServerInstance.TextChanged += new System.EventHandler(this.serverE_TextChanged);
            this.txtServerInstance.Leave += new System.EventHandler(this.serverE_Leave);
            // 
            // cancelTimer
            // 
            this.cancelTimer.Interval = 5000;
            this.cancelTimer.Tick += new System.EventHandler(this.cancelTimer_Tick);
            // 
            // singleUserE
            // 
            this.singleUserE.Checked = true;
            this.singleUserE.CheckState = System.Windows.Forms.CheckState.Checked;
            this.singleUserE.Location = new System.Drawing.Point(339, 202);
            this.singleUserE.Name = "singleUserE";
            this.singleUserE.Size = new System.Drawing.Size(256, 48);
            this.singleUserE.TabIndex = 42;
            this.singleUserE.Text = "Switch database to single user mode while running script.  This is the safest opt" +
    "ion but does not work with database mirroring.";
            // 
            // btnConnectServerTest
            // 
            this.btnConnectServerTest.Location = new System.Drawing.Point(131, 133);
            this.btnConnectServerTest.Name = "btnConnectServerTest";
            this.btnConnectServerTest.Size = new System.Drawing.Size(197, 24);
            this.btnConnectServerTest.TabIndex = 43;
            this.btnConnectServerTest.Text = "Conectar base de datos";
            this.btnConnectServerTest.Click += new System.EventHandler(this.btnConnectServerTest_Click);
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(8, 163);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(120, 16);
            this.label1.TabIndex = 44;
            this.label1.Text = "Collations actuales:";
            // 
            // lblErrorConnect
            // 
            this.lblErrorConnect.AutoSize = true;
            this.lblErrorConnect.ForeColor = System.Drawing.Color.Maroon;
            this.lblErrorConnect.Location = new System.Drawing.Point(8, 133);
            this.lblErrorConnect.Name = "lblErrorConnect";
            this.lblErrorConnect.Size = new System.Drawing.Size(0, 13);
            this.lblErrorConnect.TabIndex = 46;
            // 
            // txtActualCollations
            // 
            this.txtActualCollations.Location = new System.Drawing.Point(131, 163);
            this.txtActualCollations.Multiline = true;
            this.txtActualCollations.Name = "txtActualCollations";
            this.txtActualCollations.ReadOnly = true;
            this.txtActualCollations.Size = new System.Drawing.Size(199, 88);
            this.txtActualCollations.TabIndex = 47;
            // 
            // MainForm
            // 
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(632, 560);
            this.Controls.Add(this.txtActualCollations);
            this.Controls.Add(this.lblErrorConnect);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnConnectServerTest);
            this.Controls.Add(this.singleUserE);
            this.Controls.Add(this.cancelB);
            this.Controls.Add(this.languageE);
            this.Controls.Add(this.languageL);
            this.Controls.Add(this.dropAllE);
            this.Controls.Add(this.labelNote2);
            this.Controls.Add(this.labelNote1);
            this.Controls.Add(this.cmbCollationToMigrate);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.scriptB);
            this.Controls.Add(this.feedbackL);
            this.Controls.Add(this.executeB);
            this.Controls.Add(this.collationL);
            this.Controls.Add(this.databaseL);
            this.Controls.Add(this.passwordL);
            this.Controls.Add(this.userIdL);
            this.Controls.Add(this.serverL);
            this.Controls.Add(this.txtPassword);
            this.Controls.Add(this.txtUserID);
            this.Controls.Add(this.integratedE);
            this.Controls.Add(this.txtDataBaseName);
            this.Controls.Add(this.txtServerInstance);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MainForm";
            this.Text = "Manager de collation ";
            this.ResumeLayout(false);
            this.PerformLayout();

		}

		#endregion

		


        private bool textLanguagePopulated;

        
        private bool collationPopulated;
        private ViewMode viewMode;
        private bool executeScriptOnly;
        private bool canceled;

        //private delegate ScriptStepCollection GenerateScript(IScriptExecuteCallback callback, string server, string userId, string password, string database, bool dropAllConstraints, string collation, FullTextLanguage language);
        

        private delegate void UpdateUICallback(int step);
        private delegate bool ScriptErrorCallback(ScriptStep step, Exception ex);
        private delegate void ScriptCompleteCallback(ScriptStepCollection script);
        private delegate void ScriptCompleteErrorCallback(Exception ex);
        private delegate void ExecuteCompleteCallback();
        
        private ScriptStepCollection executingScript;
        private int lastReportedStep;

        private Thread workerThread;
		private WorkerThreadArguments workerThreadArguments;

        private class WorkerThreadArguments
        {
            private bool scriptOnly;
            private IScriptExecuteCallback callback;
            private string server;
            private string userId;
            private string password;
            private string database;
            private bool dropAllConstraints;
            private string collation;
            private FullTextLanguage language;
			private bool setSingleUser;

            public WorkerThreadArguments(bool scriptOnly, IScriptExecuteCallback callback, string server, string userId, string password, string database, bool dropAllConstraints, string collation, FullTextLanguage language, bool setSingleUser)
            {
                this.scriptOnly = scriptOnly;
                this.callback = callback;
                this.server = server;
                this.userId = userId;
                this.password = password;
                this.database = database;
                this.dropAllConstraints = dropAllConstraints;
                this.collation = collation;
                this.language = language;
				this.setSingleUser =setSingleUser;
            }
            public bool ScriptOnly
            {
                get { return scriptOnly; }
            }
            public IScriptExecuteCallback Callback
            {
                get { return callback; }
            }
            public string Server
            {
                get { return server; }
            }
            public string UserId
            {
                get { return userId; }
            }
            public string Password
            {
                get { return password; }
            }
            public string Database
            {
                get { return database; }
            }
            public bool DropAllConstraints
            {
                get { return dropAllConstraints; }
            }
            public string Collation
            {
                get { return collation; }
            }
            public FullTextLanguage Language
            {
                get { return language; }
            }
			public bool SetSingleUser
			{
				get {return setSingleUser;}
			}

        }

        private enum ViewMode
        {
            Normal,
            Running,
            Aborting
        }

        public MainForm()
        {
            InitializeComponent();
        }


        private void Script()
        {
            if ((viewMode == ViewMode.Running))
            {
                MessageBox.Show("Already Running Something");
            }
            else
            {
                ViewModeSet(ViewMode.Running);
                feedbackL.Clear();

                if (workerThread!=null)
                    throw new InvalidOperationException("Oops worker thread still running");

				//workerThread = new Thread(
				workerThreadArguments  =new WorkerThreadArguments(true,this, txtServerInstance.Text, txtUserID.Text, txtPassword.Text, txtDataBaseName.Text, dropAllE.Checked, cmbCollationToMigrate.Text, languageE.SelectedItem as FullTextLanguage, singleUserE.Checked);
                workerThread = new Thread(new ThreadStart(ScriptThreadProc));
                workerThread.Start();


            }
        }

        private void ScriptThreadProc()
        {
            //WorkerThreadArguments arguments = (WorkerThreadArguments)threadArguments;
            CollationChanger collationChanger = new CollationChanger();
            ScriptStepCollection script = null;
            SqlConnection connection = null;
            try
            {
                script = collationChanger.GenerateScript(workerThreadArguments.Callback, workerThreadArguments.Server, workerThreadArguments.UserId, workerThreadArguments.Password, workerThreadArguments.Database, workerThreadArguments.DropAllConstraints, workerThreadArguments.Collation, workerThreadArguments.Language, workerThreadArguments.SetSingleUser);
				if (script!=null)
				{
					if (workerThreadArguments.ScriptOnly)
					{
						BeginInvoke(new ScriptCompleteCallback(ScriptComplete), new object[] {script});
					}
					else
					{
						connection = new SqlConnection(Utils.ConnectionString(workerThreadArguments.Server, workerThreadArguments.UserId, workerThreadArguments.Password));
						connection.Open();
						script.Execute(connection, workerThreadArguments.Callback);
						BeginInvoke(new ExecuteCompleteCallback(ExecuteComplete));
					}
				}
				else
				{
					BeginInvoke(new ScriptCompleteCallback(ScriptComplete), new object[] { null});
				}


            }
            catch (ThreadAbortException) { throw; }
            catch (Exception ex)
            {
				BeginInvoke(new ScriptCompleteErrorCallback(ScriptComplete), new object[] { ex});
            }
            finally
            {
                if (connection != null)
                    connection.Dispose();
            }

            lock (this)
            {
                workerThread = null;
            }
            
        }

        private void ExecuteComplete()
        {
            if (!canceled)
                MessageBox.Show("Ejecución terminada.", this.Text);
            progressBar.Value = progressBar.Maximum;
            ViewModeSet(ViewMode.Normal);
        }
        
        /// <summary>
        /// callback from worker thread when something goes wrong
        /// </summary>
        /// <param name="ex"></param>
        private void ScriptComplete(Exception ex)
        {
            MessageBox.Show(ex.Message, this.Text);
            progressBar.Value = progressBar.Maximum;
            ViewModeSet(ViewMode.Normal);
        }
        
        /// <summary>
        /// callback from worker thread when it went OK
        /// </summary>
        /// <param name="script"></param>
        private void ScriptComplete(ScriptStepCollection script)
        {
            if (script!=null)
                WriteScriptToWindow(script);
            progressBar.Value = progressBar.Maximum;
            ViewModeSet(ViewMode.Normal);
        }


        private void WriteScriptToWindow(ScriptStepCollection script)
        {
            feedbackL.Clear();
            foreach (ScriptStep step in script)
            {
                feedbackL.AppendText(step.CommandText);
                feedbackL.AppendText("\n\nGO\n\n");

            }
        }

        private void ViewModeSet(ViewMode viewMode)
        {
            this.viewMode = viewMode;
            txtServerInstance.Enabled = viewMode == ViewMode.Normal;
            integratedE.Enabled = viewMode == ViewMode.Normal;
            txtUserID.Enabled = viewMode == ViewMode.Normal && !integratedE.Checked;
            txtPassword.Enabled = viewMode == ViewMode.Normal && !integratedE.Checked;
            txtDataBaseName.Enabled = viewMode == ViewMode.Normal;
            cmbCollationToMigrate.Enabled = viewMode == ViewMode.Normal;
            languageE.Enabled = viewMode == ViewMode.Normal;
            scriptB.Enabled = viewMode == ViewMode.Normal;
            executeB.Enabled = viewMode == ViewMode.Normal;
            dropAllE.Enabled = viewMode == ViewMode.Normal;
            cancelB.Enabled = viewMode == ViewMode.Running;
			singleUserE.Enabled = viewMode == ViewMode.Normal;
            cancelTimer.Enabled = viewMode == ViewMode.Aborting;

            switch (viewMode)
            {
                case ViewMode.Running:
                    canceled = false;
                    break;
                case ViewMode.Aborting:
                    canceled = true;
                    break;
                case ViewMode.Normal:
                    break;
            }
        }



        

        //private void ExecuteDo()
        //{
        //    canceled = false;
        //    ScriptRunner scriptRunner = new ScriptRunner();

        //    scriptRunner.Execute(serverE.Text, userIdE.Text, passwordE.Text,databaseE.Text, dropAllE.Checked, collationE.Text, (FullTextLanguage)languageE.SelectedItem);
        //    ExecuteComplete();

        //}


        protected override void OnLoad(System.EventArgs e)
        {
            base.OnLoad(e);
            ViewModeSet(ViewMode.Normal);

        }

        private void executeB_Click(object sender, EventArgs e)
        {

            if ((viewMode == ViewMode.Running))
            {
                MessageBox.Show("Already Running Something");
            }
            else
            {
                if (MessageBox.Show("This program will now execute a script to alter the collation of your database.  This may take a long time and may result in data loss.  Please ensure that all your data is backed up.\n\nExclusive database access is required to complete the process so before running use the sp_who command to verify that there are no users connected to your database.", "Confirm", MessageBoxButtons.OKCancel, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button2) == DialogResult.OK)
                {
                    ViewModeSet(ViewMode.Running);
                    feedbackL.Clear();

                    if (workerThread != null)
                        throw new InvalidOperationException("Oops worker thread still running");

					workerThreadArguments =  new WorkerThreadArguments(false, this, txtServerInstance.Text, txtUserID.Text, txtPassword.Text, txtDataBaseName.Text, dropAllE.Checked, cmbCollationToMigrate.Text, languageE.SelectedItem as FullTextLanguage, singleUserE.Checked);
                    workerThread = new Thread(new ThreadStart(ScriptThreadProc));
                    workerThread.Start();
                }


            }

        }

        private void integratedE_CheckedChanged(object sender, EventArgs e)
        {
            if (integratedE.Checked)
            {
                txtUserID.Text = string.Empty;
                txtPassword.Text = string.Empty;
            }

            txtUserID.Enabled = !integratedE.Checked;
            userIdL.Enabled = !integratedE.Checked;
            txtPassword.Enabled = !integratedE.Checked;
            passwordL.Enabled = !integratedE.Checked;

        }

        private void scriptB_Click(object sender, EventArgs e)
        {
            Script();
        }

        private void languageE_DropDown(object sender, EventArgs e)
        {
            if (!textLanguagePopulated && !string.IsNullOrEmpty( this.txtServerInstance.Text.ToString()) )
            {
                textLanguagePopulated = true;
                SqlConnection con = new SqlConnection();

                try
                {

                    SqlCommand cmd;
                    int ixName;
                    int ixLcid;
                    SqlDataReader dr;
                    Version serverVersion;
                    con.ConnectionString = Utils.ConnectionString(txtServerInstance.Text, txtUserID.Text, txtPassword.Text);
                    con.Open();
                    serverVersion = new Version(con.ServerVersion);

                    cmd = con.CreateCommand();


                    if (serverVersion.Major>=9)
                    {
                        cmd.CommandType = CommandType.Text;
                        cmd.CommandText = "select * from sys.fulltext_languages";
                    }
                    else
                    {
                        cmd.CommandType = CommandType.StoredProcedure;
                        cmd.CommandText = "master..xp_MSFullText";
                    }

                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    
                    
                    if (serverVersion.Major>=9)
                    {
                        ixName = dr.GetOrdinal("name");
                    }
                    else
                    {
                        ixName = dr.GetOrdinal("Language");
                    }

                    ixLcid = dr.GetOrdinal("LCID");

                    languageE.Items.Clear();
                    languageE.Items.Add(new FullTextLanguage("<Unchanged>", int.MinValue));
                    while (dr.Read())
                    {
                        languageE.Items.Add(new FullTextLanguage(dr.GetString(ixName), dr.GetInt32(ixLcid)));
                    }
                }

                catch (SqlException)
                {
                    textLanguagePopulated = false;
                }
                catch (Exception)
                {
                    textLanguagePopulated = false;
                    throw;
                }
                finally
                {
                    con.Dispose();
                }
            }
        }

        private void cancelB_Click(object sender, EventArgs e)
        {
            ViewModeSet(ViewMode.Aborting);
        }

        private void serverE_TextChanged(object sender, EventArgs e)
        {
            collationPopulated = false;
            textLanguagePopulated = false;
            cmbCollationToMigrate.Items.Clear();

            languageE.Items.Clear();
            languageE.Items.Add(new FullTextLanguage("<Unchanged>", int.MinValue));
        }

        private void collationE_DropDown(object sender, EventArgs e)
        {
            //populate the list

            if (!collationPopulated && !string.IsNullOrEmpty(this.txtServerInstance.Text.ToString()))
            {
                collationPopulated = true;
                SqlConnection con = new SqlConnection();

                try
                {

                    SqlCommand cmd;
                    int ixName;
                    SqlDataReader dr;

                    con.ConnectionString = Utils.ConnectionString(txtServerInstance.Text, txtUserID.Text, txtPassword.Text);
                    
                    con.Open();
                    cmd = con.CreateCommand();
                    cmd.CommandType = CommandType.Text;
                    cmd.CommandText = "select name from ::fn_helpCollations() where name like '%SQL_Latin%'";
                    dr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                    ixName = dr.GetOrdinal("name");
                    cmbCollationToMigrate.Items.Clear();
                    while (dr.Read())
                    {
                        cmbCollationToMigrate.Items.Add(dr.GetString(ixName));
                    }
                }
                catch (SqlException)
                {
                    collationPopulated = false;
                }
                catch (Exception)
                {
                    collationPopulated = false;
                    throw;
                }
                finally
                {
                    con.Dispose();
                }
            }
        }


        private void UpdateUI(int step)
        {
			lock(this)
			{
				if (lastReportedStep == -1)
				{
					feedbackL.Clear();
					lastReportedStep =0;
				}
				ScriptStep scriptItem;
				for (int index = lastReportedStep; index < step; index++)
				{
					scriptItem = executingScript[index];
					feedbackL.AppendText(scriptItem.CommandText);
					feedbackL.AppendText("\n\nGO\n\n");

				}
				progressBar.Maximum = executingScript.Count;
				progressBar.Value = step;
				lastReportedStep = step;
			}
        }


        private bool ScriptError(ScriptStep step, Exception exception)
        {
            SqlException ex = exception as SqlException;
            if (ex == null)
            {
                MessageBox.Show("Unexpeced error");
                return false;
            }

            for (int stepIndex = 0; stepIndex < executingScript.Count; stepIndex++)
            {
                if (object.ReferenceEquals(executingScript[stepIndex], step))
                {
                    UpdateUI(stepIndex+1);
                    break;
                }
            }


            foreach (SqlError e in ex.Errors)
            {
                if (e.Class >= 11)
                {
                    feedbackL.SelectionColor = Color.Red;
                }
                else
                {
                    feedbackL.SelectionColor = Color.Black;
                }
                feedbackL.AppendText(string.Format("{0} - {1}", e.Number, e.Message));
                feedbackL.AppendText("\n");
            }

            if (ex.Class >= 11)
            {
                string commandText = step.CommandText;
                if (commandText.Length > 1000)
                    commandText = commandText.Substring(0, 1000) + "......";

                string message = string.Format("An error occured while executing the SQL Statement\n\n '{0}'\n\n{1}\n\nDo you which to continue running the script anyway?", commandText, ex.Message);
                if (!(MessageBox.Show(this,message, "Error", MessageBoxButtons.YesNo, MessageBoxIcon.Stop) == DialogResult.Yes))
                {
                    canceled = true;
                    feedbackL.SelectionColor = Color.Red;
                    feedbackL.AppendText("Canceled");
                    feedbackL.AppendText("\n");
                }
            }


            return !canceled;
        }

        #region IScriptExecuteCallback Members

        bool IScriptExecuteCallback.Error(ScriptStep step, Exception exception)
        {
			return (bool) this.Invoke(new ScriptErrorCallback(ScriptError), new object [] {step, exception});
        }

        bool IScriptExecuteCallback.Progress(ScriptStep script, int step, int stepMax)
        {
            if (!canceled)
				this.BeginInvoke(new UpdateUICallback(UpdateUI), new object[] {step});
            return !canceled;
        }

        void IScriptExecuteCallback.ExecutionStarting(ScriptStepCollection script)
        {
			lock(this)
			{
				executingScript = script;
				lastReportedStep = -1;
			}
        }
        #endregion

        private void cancelTimer_Tick(object sender, EventArgs e)
        {
            lock(this)
            {
                if (workerThread != null)
                    workerThread.Abort();
                workerThread = null;
            }
            progressBar.Value = progressBar.Maximum;
            ViewModeSet(ViewMode.Normal);
            
        }

        private void serverE_Leave(object sender, EventArgs e)
        {

        }

        private void btnConnectServerTest_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand cmd;
            Version serverVersion;
            bool conectoOk = false;
            this.txtActualCollations.Text = "";
            this.lblErrorConnect.Text = "";
            try
            {
                con.ConnectionString = Utils.ConnectionString(txtServerInstance.Text, txtUserID.Text, txtPassword.Text, 1, this.txtDataBaseName.Text);
                con.Open();
                conectoOk = true;
            }
            catch (Exception){
                this.lblErrorConnect.Text = "Error de conexión";
            }
            System.Windows.Forms.ToolTip ToolTip = new System.Windows.Forms.ToolTip();
            ToolTip.ToolTipIcon = ToolTipIcon.Info;
            ToolTip.IsBalloon = true;
            ToolTip.ShowAlways = true;
            
            if (conectoOk)
            { 
                serverVersion = new Version(con.ServerVersion);

                cmd = con.CreateCommand();
                cmd.CommandType = CommandType.Text;
                cmd.CommandText = @"select distinct collation from (
SELECT 
    tab.name as Tabla, 
    sch.name as Esquema,
    c.name as Columna,
    t.Name as TipoDato,
    c.max_length as Longitud,
    c.precision as Enteros,
    c.scale as Decimales,
    c.is_nullable as SoportaNull,
    ISNULL(ClavesPrimarias.is_primary_key, 0) as EsPk,	
	PropiedadExtendida = ISNULL( p.Name, '' ),
    Ubicacion = ISNULL( p.Value, '' ),
	c.is_identity as EsIdentity,
	c.collation_Name as Collation,
	replace( replace( object_definition(c.default_object_id), '(', '' ), ')', '' ) AS ValorPorDefecto
FROM   
	sys.tables as tab
INNER JOIN
	sys.schemas as sch on tab.schema_id = sch.schema_id
LEFT JOIN  
    sys.columns AS c on tab.[Object_id] = c.[Object_id]
INNER JOIN 
    sys.types t ON c.system_type_id = t.system_type_id
LEFT OUTER JOIN 

(
SELECT  ic.object_id, ic.column_id, i.is_primary_key
FROM
    sys.index_columns ic 
INNER JOIN 
    sys.indexes i ON ic.object_id = i.object_id AND 
	ic.index_id = i.index_id AND 
	i.is_primary_key = 1) as ClavesPrimarias
		
	ON ClavesPrimarias.object_id = c.object_id AND ClavesPrimarias.column_id = c.column_id
LEFT OUTER JOIN  
    sys.extended_properties p on p.major_id = tab.[Object_id] and p.class = 1
) resultado";
                using (SqlDataReader dr = cmd.ExecuteReader())
                {
                    while (dr.Read())
                    {
                        string database = dr["Collation"].ToString() ;
                        if (!string.IsNullOrEmpty(database))
                        {
                            this.txtActualCollations.Text = this.txtActualCollations.Text + database + "\r\n";
                        }

                    }
                }  
            }
            ToolTip.SetToolTip(this.txtActualCollations, this.txtActualCollations.Text);
        }
    }
}



