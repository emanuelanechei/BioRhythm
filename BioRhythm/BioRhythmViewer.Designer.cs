namespace BioRhythm
{
    partial class BioRhythmViewer
    {
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BioRhythmViewer));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Title title1 = new System.Windows.Forms.DataVisualization.Charting.Title();
            System.Windows.Forms.DataVisualization.Charting.Title title2 = new System.Windows.Forms.DataVisualization.Charting.Title();
            this.CurrentDateLabel = new System.Windows.Forms.Label();
            this.CurrentDate = new System.Windows.Forms.DateTimePicker();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.menuFile = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileNew = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSave = new System.Windows.Forms.ToolStripMenuItem();
            this.menuFileSaveAs = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFilePrint = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.menuFileExit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEdit = new System.Windows.Forms.ToolStripMenuItem();
            this.menuEditCopyToClipboard = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuEditChartProperties = new System.Windows.Forms.ToolStripMenuItem();
            this.menuView = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewPreviousMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewPreviousWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewNextWeek = new System.Windows.Forms.ToolStripMenuItem();
            this.menuViewNextMonth = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.menuHelpAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.tsbFileNew = new System.Windows.Forms.ToolStripButton();
            this.tsbFileOpen = new System.Windows.Forms.ToolStripButton();
            this.tsbFileSave = new System.Windows.Forms.ToolStripButton();
            this.tsbFilePrint = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator = new System.Windows.Forms.ToolStripSeparator();
            this.tsbCopyToClipboard = new System.Windows.Forms.ToolStripButton();
            this.tsbEditProperties = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.tsbViewPreviousMonth = new System.Windows.Forms.ToolStripButton();
            this.tsbViewPreviousWeek = new System.Windows.Forms.ToolStripButton();
            this.tsbViewNextWeek = new System.Windows.Forms.ToolStripButton();
            this.tsbViewNextMonth = new System.Windows.Forms.ToolStripButton();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.StatusBarStatusMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarErrorMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarProgressBar = new System.Windows.Forms.ToolStripProgressBar();
            this.StatusBarActionIcon = new System.Windows.Forms.ToolStripStatusLabel();
            this.StatusBarDirtyMessage = new System.Windows.Forms.ToolStripStatusLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // CurrentDateLabel
            // 
            resources.ApplyResources(this.CurrentDateLabel, "CurrentDateLabel");
            this.CurrentDateLabel.Name = "CurrentDateLabel";
            // 
            // CurrentDate
            // 
            resources.ApplyResources(this.CurrentDate, "CurrentDate");
            this.CurrentDate.Name = "CurrentDate";
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFile,
            this.menuEdit,
            this.menuView,
            this.menuHelp});
            resources.ApplyResources(this.menuStrip1, "menuStrip1");
            this.menuStrip1.Name = "menuStrip1";
            // 
            // menuFile
            // 
            this.menuFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuFileNew,
            this.menuFileOpen,
            this.menuFileSave,
            this.menuFileSaveAs,
            this.toolStripSeparator1,
            this.menuFilePrint,
            this.toolStripSeparator3,
            this.menuFileExit});
            this.menuFile.Name = "menuFile";
            resources.ApplyResources(this.menuFile, "menuFile");
            // 
            // menuFileNew
            // 
            resources.ApplyResources(this.menuFileNew, "menuFileNew");
            this.menuFileNew.Name = "menuFileNew";
            this.menuFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // menuFileOpen
            // 
            resources.ApplyResources(this.menuFileOpen, "menuFileOpen");
            this.menuFileOpen.Name = "menuFileOpen";
            this.menuFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // menuFileSave
            // 
            resources.ApplyResources(this.menuFileSave, "menuFileSave");
            this.menuFileSave.Name = "menuFileSave";
            this.menuFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // menuFileSaveAs
            // 
            this.menuFileSaveAs.Name = "menuFileSaveAs";
            resources.ApplyResources(this.menuFileSaveAs, "menuFileSaveAs");
            this.menuFileSaveAs.Click += new System.EventHandler(this.menuFileSaveAs_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            resources.ApplyResources(this.toolStripSeparator1, "toolStripSeparator1");
            // 
            // menuFilePrint
            // 
            resources.ApplyResources(this.menuFilePrint, "menuFilePrint");
            this.menuFilePrint.Name = "menuFilePrint";
            this.menuFilePrint.Click += new System.EventHandler(this.menuFilePrint_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            resources.ApplyResources(this.toolStripSeparator3, "toolStripSeparator3");
            // 
            // menuFileExit
            // 
            this.menuFileExit.Name = "menuFileExit";
            resources.ApplyResources(this.menuFileExit, "menuFileExit");
            this.menuFileExit.Click += new System.EventHandler(this.menuFileExit_Click);
            // 
            // menuEdit
            // 
            this.menuEdit.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuEditCopyToClipboard,
            this.toolStripSeparator4,
            this.menuEditChartProperties});
            this.menuEdit.Name = "menuEdit";
            resources.ApplyResources(this.menuEdit, "menuEdit");
            // 
            // menuEditCopyToClipboard
            // 
            resources.ApplyResources(this.menuEditCopyToClipboard, "menuEditCopyToClipboard");
            this.menuEditCopyToClipboard.Name = "menuEditCopyToClipboard";
            this.menuEditCopyToClipboard.Click += new System.EventHandler(this.menuEditCopyToClipboard_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            resources.ApplyResources(this.toolStripSeparator4, "toolStripSeparator4");
            // 
            // menuEditChartProperties
            // 
            resources.ApplyResources(this.menuEditChartProperties, "menuEditChartProperties");
            this.menuEditChartProperties.Name = "menuEditChartProperties";
            this.menuEditChartProperties.Click += new System.EventHandler(this.menuEditProperties_Click);
            // 
            // menuView
            // 
            this.menuView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuViewPreviousMonth,
            this.menuViewPreviousWeek,
            this.menuViewNextWeek,
            this.menuViewNextMonth});
            this.menuView.Name = "menuView";
            resources.ApplyResources(this.menuView, "menuView");
            // 
            // menuViewPreviousMonth
            // 
            resources.ApplyResources(this.menuViewPreviousMonth, "menuViewPreviousMonth");
            this.menuViewPreviousMonth.Name = "menuViewPreviousMonth";
            this.menuViewPreviousMonth.Click += new System.EventHandler(this.menuViewPreviousMonth_Click);
            // 
            // menuViewPreviousWeek
            // 
            resources.ApplyResources(this.menuViewPreviousWeek, "menuViewPreviousWeek");
            this.menuViewPreviousWeek.Name = "menuViewPreviousWeek";
            this.menuViewPreviousWeek.Click += new System.EventHandler(this.menuViewPreviousWeek_Click);
            // 
            // menuViewNextWeek
            // 
            resources.ApplyResources(this.menuViewNextWeek, "menuViewNextWeek");
            this.menuViewNextWeek.Name = "menuViewNextWeek";
            this.menuViewNextWeek.Click += new System.EventHandler(this.menuViewNextWeek_Click);
            // 
            // menuViewNextMonth
            // 
            resources.ApplyResources(this.menuViewNextMonth, "menuViewNextMonth");
            this.menuViewNextMonth.Name = "menuViewNextMonth";
            this.menuViewNextMonth.Click += new System.EventHandler(this.menuViewNextMonth_Click);
            // 
            // menuHelp
            // 
            this.menuHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.menuHelpAbout});
            this.menuHelp.Name = "menuHelp";
            resources.ApplyResources(this.menuHelp, "menuHelp");
            // 
            // menuHelpAbout
            // 
            this.menuHelpAbout.Name = "menuHelpAbout";
            resources.ApplyResources(this.menuHelpAbout, "menuHelpAbout");
            this.menuHelpAbout.Click += new System.EventHandler(this.menuHelpAbout_Click);
            // 
            // toolStrip1
            // 
            this.toolStrip1.GripStyle = System.Windows.Forms.ToolStripGripStyle.Hidden;
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.tsbFileNew,
            this.tsbFileOpen,
            this.tsbFileSave,
            this.tsbFilePrint,
            this.toolStripSeparator,
            this.tsbCopyToClipboard,
            this.tsbEditProperties,
            this.toolStripSeparator2,
            this.tsbViewPreviousMonth,
            this.tsbViewPreviousWeek,
            this.tsbViewNextWeek,
            this.tsbViewNextMonth});
            resources.ApplyResources(this.toolStrip1, "toolStrip1");
            this.toolStrip1.Name = "toolStrip1";
            // 
            // tsbFileNew
            // 
            this.tsbFileNew.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbFileNew, "tsbFileNew");
            this.tsbFileNew.Name = "tsbFileNew";
            this.tsbFileNew.Click += new System.EventHandler(this.menuFileNew_Click);
            // 
            // tsbFileOpen
            // 
            this.tsbFileOpen.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbFileOpen, "tsbFileOpen");
            this.tsbFileOpen.Name = "tsbFileOpen";
            this.tsbFileOpen.Click += new System.EventHandler(this.menuFileOpen_Click);
            // 
            // tsbFileSave
            // 
            this.tsbFileSave.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbFileSave, "tsbFileSave");
            this.tsbFileSave.Name = "tsbFileSave";
            this.tsbFileSave.Click += new System.EventHandler(this.menuFileSave_Click);
            // 
            // tsbFilePrint
            // 
            this.tsbFilePrint.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbFilePrint, "tsbFilePrint");
            this.tsbFilePrint.Name = "tsbFilePrint";
            this.tsbFilePrint.Click += new System.EventHandler(this.menuFilePrint_Click);
            // 
            // toolStripSeparator
            // 
            this.toolStripSeparator.Name = "toolStripSeparator";
            resources.ApplyResources(this.toolStripSeparator, "toolStripSeparator");
            // 
            // tsbCopyToClipboard
            // 
            this.tsbCopyToClipboard.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbCopyToClipboard, "tsbCopyToClipboard");
            this.tsbCopyToClipboard.Name = "tsbCopyToClipboard";
            this.tsbCopyToClipboard.Click += new System.EventHandler(this.menuEditCopyToClipboard_Click);
            // 
            // tsbEditProperties
            // 
            this.tsbEditProperties.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbEditProperties, "tsbEditProperties");
            this.tsbEditProperties.Name = "tsbEditProperties";
            this.tsbEditProperties.Click += new System.EventHandler(this.menuEditProperties_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            resources.ApplyResources(this.toolStripSeparator2, "toolStripSeparator2");
            // 
            // tsbViewPreviousMonth
            // 
            this.tsbViewPreviousMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbViewPreviousMonth, "tsbViewPreviousMonth");
            this.tsbViewPreviousMonth.Name = "tsbViewPreviousMonth";
            this.tsbViewPreviousMonth.Click += new System.EventHandler(this.menuViewPreviousMonth_Click);
            // 
            // tsbViewPreviousWeek
            // 
            this.tsbViewPreviousWeek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbViewPreviousWeek, "tsbViewPreviousWeek");
            this.tsbViewPreviousWeek.Name = "tsbViewPreviousWeek";
            this.tsbViewPreviousWeek.Click += new System.EventHandler(this.menuViewPreviousWeek_Click);
            // 
            // tsbViewNextWeek
            // 
            this.tsbViewNextWeek.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbViewNextWeek, "tsbViewNextWeek");
            this.tsbViewNextWeek.Name = "tsbViewNextWeek";
            this.tsbViewNextWeek.Click += new System.EventHandler(this.menuViewNextWeek_Click);
            // 
            // tsbViewNextMonth
            // 
            this.tsbViewNextMonth.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.tsbViewNextMonth, "tsbViewNextMonth");
            this.tsbViewNextMonth.Name = "tsbViewNextMonth";
            this.tsbViewNextMonth.Click += new System.EventHandler(this.menuViewNextMonth_Click);
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.StatusBarStatusMessage,
            this.StatusBarErrorMessage,
            this.StatusBarProgressBar,
            this.StatusBarActionIcon,
            this.StatusBarDirtyMessage});
            resources.ApplyResources(this.statusStrip1, "statusStrip1");
            this.statusStrip1.Name = "statusStrip1";
            // 
            // StatusBarStatusMessage
            // 
            this.StatusBarStatusMessage.ForeColor = System.Drawing.Color.Green;
            this.StatusBarStatusMessage.Name = "StatusBarStatusMessage";
            resources.ApplyResources(this.StatusBarStatusMessage, "StatusBarStatusMessage");
            // 
            // StatusBarErrorMessage
            // 
            this.StatusBarErrorMessage.AutoToolTip = true;
            this.StatusBarErrorMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.StatusBarErrorMessage.ForeColor = System.Drawing.Color.Red;
            this.StatusBarErrorMessage.Name = "StatusBarErrorMessage";
            resources.ApplyResources(this.StatusBarErrorMessage, "StatusBarErrorMessage");
            this.StatusBarErrorMessage.Spring = true;
            // 
            // StatusBarProgressBar
            // 
            this.StatusBarProgressBar.Alignment = System.Windows.Forms.ToolStripItemAlignment.Right;
            this.StatusBarProgressBar.Name = "StatusBarProgressBar";
            resources.ApplyResources(this.StatusBarProgressBar, "StatusBarProgressBar");
            this.StatusBarProgressBar.Value = 10;
            // 
            // StatusBarActionIcon
            // 
            this.StatusBarActionIcon.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.StatusBarActionIcon, "StatusBarActionIcon");
            this.StatusBarActionIcon.Name = "StatusBarActionIcon";
            // 
            // StatusBarDirtyMessage
            // 
            this.StatusBarDirtyMessage.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            resources.ApplyResources(this.StatusBarDirtyMessage, "StatusBarDirtyMessage");
            this.StatusBarDirtyMessage.Name = "StatusBarDirtyMessage";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // chart1
            // 
            resources.ApplyResources(this.chart1, "chart1");
            chartArea1.AxisX.IsLabelAutoFit = false;
            chartArea1.AxisX.LabelStyle.Angle = -45;
            chartArea1.AxisX.LabelStyle.Interval = 0D;
            chartArea1.AxisX.MinorGrid.Enabled = true;
            chartArea1.AxisX.MinorGrid.LineColor = System.Drawing.Color.Gray;
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            legend1.Title = "Legend";
            this.chart1.Legends.Add(legend1);
            this.chart1.Name = "chart1";
            series1.BorderWidth = 2;
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Color = System.Drawing.Color.Green;
            series1.Legend = "Legend1";
            series1.Name = "Emotion";
            series2.BorderWidth = 2;
            series2.ChartArea = "ChartArea1";
            series2.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series2.Color = System.Drawing.Color.Blue;
            series2.Legend = "Legend1";
            series2.Name = "Intellect";
            series3.BorderWidth = 2;
            series3.ChartArea = "ChartArea1";
            series3.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series3.Color = System.Drawing.Color.Red;
            series3.Legend = "Legend1";
            series3.Name = "Physique";
            series4.BorderWidth = 2;
            series4.ChartArea = "ChartArea1";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Color = System.Drawing.Color.Magenta;
            series4.Legend = "Legend1";
            series4.Name = "Average";
            this.chart1.Series.Add(series1);
            this.chart1.Series.Add(series2);
            this.chart1.Series.Add(series3);
            this.chart1.Series.Add(series4);
            title1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold);
            title1.Name = "Title1";
            title1.Text = "Title";
            title2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F);
            title2.Name = "Title2";
            title2.Text = "SubTitle";
            this.chart1.Titles.Add(title1);
            this.chart1.Titles.Add(title2);
            // 
            // BioRhythmViewer
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.Controls.Add(this.CurrentDate);
            this.Controls.Add(this.CurrentDateLabel);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "BioRhythmViewer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.BioRhythmViewer_FormClosing);
            this.Load += new System.EventHandler(this.BioRhythmViewer_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label CurrentDateLabel;
        private System.Windows.Forms.DateTimePicker CurrentDate;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem menuFile;
        private System.Windows.Forms.ToolStripMenuItem menuFileNew;
        private System.Windows.Forms.ToolStripMenuItem menuFileOpen;
        private System.Windows.Forms.ToolStripMenuItem menuFileSave;
        private System.Windows.Forms.ToolStripMenuItem menuFileSaveAs;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem menuFileExit;
        private System.Windows.Forms.ToolStripMenuItem menuEdit;
        private System.Windows.Forms.ToolStripMenuItem menuHelp;
        private System.Windows.Forms.ToolStripMenuItem menuHelpAbout;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton tsbFileNew;
        private System.Windows.Forms.ToolStripButton tsbFileOpen;
        private System.Windows.Forms.ToolStripButton tsbFileSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarStatusMessage;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarErrorMessage;
        private System.Windows.Forms.ToolStripProgressBar StatusBarProgressBar;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarActionIcon;
        private System.Windows.Forms.ToolStripStatusLabel StatusBarDirtyMessage;
        private System.Windows.Forms.ToolStripMenuItem menuView;
        private System.Windows.Forms.ToolStripButton tsbEditProperties;
        private System.Windows.Forms.ToolStripMenuItem menuViewPreviousMonth;
        private System.Windows.Forms.ToolStripMenuItem menuViewPreviousWeek;
        private System.Windows.Forms.ToolStripMenuItem menuViewNextWeek;
        private System.Windows.Forms.ToolStripMenuItem menuViewNextMonth;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton tsbViewPreviousMonth;
        private System.Windows.Forms.ToolStripButton tsbViewPreviousWeek;
        private System.Windows.Forms.ToolStripButton tsbViewNextWeek;
        private System.Windows.Forms.ToolStripButton tsbViewNextMonth;
        private System.Windows.Forms.ToolStripMenuItem menuFilePrint;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton tsbFilePrint;
        private System.Windows.Forms.ToolStripButton tsbCopyToClipboard;
        private System.Windows.Forms.ToolStripMenuItem menuEditCopyToClipboard;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.ToolStripMenuItem menuEditChartProperties;
        internal System.Windows.Forms.DataVisualization.Charting.Chart chart1;

    }
}

