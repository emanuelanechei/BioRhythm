//#define USE_CONFIG_FILEPATH

using System;
using System.Drawing;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Reflection;
using System.Windows.Forms;
using Ssepan.Application;
using Ssepan.Application.MVC;
using Ssepan.Io;
using Ssepan.Patterns;
using Ssepan.Utility;
using BioRhythmLibrary;
using BioRhythmLibrary.Properties;

namespace BioRhythm
{
    /// <summary>
    /// This is the View.
    /// </summary>
    public partial class BioRhythmViewer :
        Form,
        INotifyPropertyChanged
    {
        #region Declarations
        protected Boolean disposed;

        private Boolean _ValueChangedProgrammatically;

        //cancellation hook
        Action cancelDelegate = null;
        protected BioRhythmViewModel ViewModel = default(BioRhythmViewModel);
        #endregion Declarations

        #region Constructors
        public BioRhythmViewer(String[] args) 
        {
            try
            {
                InitializeComponent();

                ////(re)define default output delegate
                //ConsoleApplication.defaultOutputDelegate = ConsoleApplication.messageBoxWrapperOutputDelegate;

                //subscribe to notifications
                this.PropertyChanged += PropertyChangedEventHandlerDelegate;

                InitViewModel();

                BindSizeAndLocation();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion Constructors

        #region INotifyPropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(String propertyName)
        {
            try
            {
                if (this.PropertyChanged != null)
                {
                    this.PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
                }
            }
            catch (Exception ex)
            {
                ViewModel.ErrorMessage = ex.Message;
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                throw;
            }
        }
        #endregion INotifyPropertyChanged

        #region PropertyChangedEventHandlerDelegate
        /// <summary>
        /// Note: model property changes update UI manually.
        /// Note: handle settings property changes manually.
        /// Note: because settings properties are a subset of the model 
        ///  (every settings property should be in the model, 
        ///  but not every model property is persisted to settings)
        ///  it is decided that for now the settigns handler will 
        ///  invoke the model handler as well.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void PropertyChangedEventHandlerDelegate
        (
            Object sender,
            PropertyChangedEventArgs e
        )
        {
            try
            {
                #region Model
                if (e.PropertyName == "IsChanged")
                {
                    //ConsoleApplication.defaultOutputDelegate(String.Format("{0}", e.PropertyName));
                    ApplySettings();
                }
                //Status Bar
                else if (e.PropertyName == "ActionIconIsVisible")
                {
                    StatusBarActionIcon.Visible = (ViewModel.ActionIconIsVisible);
                }
                else if (e.PropertyName == "ActionIconImage")
                {
                    StatusBarActionIcon.Image = (ViewModel != null ? ViewModel.ActionIconImage : (Image)null);
                }
                else if (e.PropertyName == "StatusMessage")
                {
                    //replace default action by setting control property
                    StatusBarStatusMessage.Text = (ViewModel != null ? ViewModel.StatusMessage : (String)null);
                    //e = new PropertyChangedEventArgs(e.PropertyName + ".handled");

                    //ConsoleApplication.defaultOutputDelegate(String.Format("{0}", StatusMessage));
                }
                else if (e.PropertyName == "ErrorMessage")
                {
                    //replace default action by setting control property
                    StatusBarErrorMessage.Text = (ViewModel != null ? ViewModel.ErrorMessage : (String)null);
                    //e = new PropertyChangedEventArgs(e.PropertyName + ".handled");

                    //ConsoleApplication.defaultOutputDelegate(String.Format("{0}", ErrorMessage));
                }
                else if (e.PropertyName == "ErrorMessageToolTipText")
                {
                    StatusBarErrorMessage.ToolTipText = ViewModel.ErrorMessageToolTipText;
                }
                else if (e.PropertyName == "ProgressBarValue")
                {
                    StatusBarProgressBar.Value = ViewModel.ProgressBarValue;
                }
                else if (e.PropertyName == "ProgressBarMaximum")
                {
                    StatusBarProgressBar.Maximum = ViewModel.ProgressBarMaximum;
                }
                else if (e.PropertyName == "ProgressBarMinimum")
                {
                    StatusBarProgressBar.Minimum = ViewModel.ProgressBarMinimum;
                }
                else if (e.PropertyName == "ProgressBarStep")
                {
                    StatusBarProgressBar.Step = ViewModel.ProgressBarStep;
                }
                else if (e.PropertyName == "ProgressBarIsMarquee")
                {
                    StatusBarProgressBar.Style = (ViewModel.ProgressBarIsMarquee ? ProgressBarStyle.Marquee : ProgressBarStyle.Blocks);
                }
                else if (e.PropertyName == "ProgressBarIsVisible")
                {
                    StatusBarProgressBar.Visible = (ViewModel.ProgressBarIsVisible);
                }
                else if (e.PropertyName == "DirtyIconIsVisible")
                {
                    StatusBarDirtyMessage.Visible = (ViewModel.DirtyIconIsVisible);
                }
                else if (e.PropertyName == "DirtyIconImage")
                {
                    StatusBarDirtyMessage.Image = ViewModel.DirtyIconImage;
                }
                //Chart
                else if (e.PropertyName == "Title")
                {
                    this.chart1.Titles[0].Text = ModelController<BioRhythmModel>.Model.Title;
                }
                else if (e.PropertyName == "SubTitle")
                {
                    this.chart1.Titles[1].Text = ModelController<BioRhythmModel>.Model.SubTitle;
                }
                else if (e.PropertyName == "LegendTitle")
                {
                    this.chart1.Legends[0].Title = ModelController<BioRhythmModel>.Model.LegendTitle;
                }
                else if (e.PropertyName.StartsWith("Emotion"))
                {
                    this.chart1.Series["Emotion"].Points.Clear();
                    foreach (DataPointModel dataPoint in ModelController<BioRhythmModel>.Model.Emotion)
                    {
                        // Add X and Y values for a point.
                        this.chart1.Series["Emotion"].Points.AddXY
                            (
                                dataPoint.Date,
                                dataPoint.Value
                            );
                    }
                }
                else if (e.PropertyName.StartsWith("Intellect"))
                {
                    this.chart1.Series["Intellect"].Points.Clear();
                    foreach (DataPointModel dataPoint in ModelController<BioRhythmModel>.Model.Intellect)
                    {
                        // Add X and Y values for a point.
                        this.chart1.Series["Intellect"].Points.AddXY
                            (
                                dataPoint.Date,
                                dataPoint.Value
                            );
                    }
                }
                else if (e.PropertyName.StartsWith("Physique"))
                {
                    this.chart1.Series["Physique"].Points.Clear();
                    foreach (DataPointModel dataPoint in ModelController<BioRhythmModel>.Model.Physique)
                    {
                        // Add X and Y values for a point.
                        this.chart1.Series["Physique"].Points.AddXY
                            (
                                dataPoint.Date,
                                dataPoint.Value
                            );
                    }
                }
                else if (e.PropertyName.StartsWith("Average"))
                {
                    this.chart1.Series["Average"].Points.Clear();
                    foreach (DataPointModel dataPoint in ModelController<BioRhythmModel>.Model.Average)
                    {
                        // Add X and Y values for a point.
                        this.chart1.Series["Average"].Points.AddXY
                            (
                                dataPoint.Date,
                                dataPoint.Value
                            );
                    }
                }
                else if (e.PropertyName.StartsWith("XAxisLabels"))
                {
                    //TODO:this.chart1.Xxx = ModelController<BioRhythmModel>.Model.XAxisLabels;
                }
                else if (e.PropertyName == "SelectedDate")
                {
                    ModelController<BioRhythmModel>.Model.Refresh();
                }
                #endregion Model

                #region Settings
                if (e.PropertyName == "Dirty")
                {
                    //apply settings that don't have databindings
                    ViewModel.DirtyIconIsVisible = (SettingsController<Settings>.Settings.Dirty);
                }
                #endregion Settings
            }
            catch (Exception ex)
            {
                //ErrorMessage = ex.Message;
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion PropertyChangedEventHandler

        #region Properties
        private String _Filename = default(String);
        public String Filename
        {
            get { return _Filename; }
            set
            {
                _Filename = value;
                OnPropertyChanged("Filename");
            }
        }

        private String _ViewName = Program.APP_NAME;
        public String ViewName
        {
            get { return _ViewName; }
            set { _ViewName = value; }
        }
        #endregion Properties

        #region Events
        #region Form Events
        /// <summary>
        /// Process Form key presses.
        /// </summary>
        /// <param name="msg"></param>
        /// <param name="keyData"></param>
        /// <returns></returns>
        protected override Boolean ProcessCmdKey(ref Message msg, Keys keyData)
        {
            Boolean returnValue = default(Boolean);
            try
            {
                // Implement the Escape / Cancel keystroke
                if (keyData == Keys.Cancel || keyData == Keys.Escape)
                {
                    //if a long-running cancellable-action has registered 
                    //an escapable-event, trigger it
                    InvokeActionCancel();

                    // This keystroke was handled, 
                    //don't pass to the control with the focus
                    returnValue = true;
                }
                else
                {
                    returnValue = base.ProcessCmdKey(ref msg, keyData);
                }

            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        private void BioRhythmViewer_Load(Object sender, EventArgs e)
        {
            try
            {
                ViewModel.StatusMessage = String.Format("{0} starting...", ViewName);

                ViewModel.StatusMessage = String.Format("{0} started.", ViewName);

                _Run();
            }
            catch (Exception ex)
            {
                ViewModel.ErrorMessage = ex.Message;
                ViewModel.StatusMessage = String.Empty;

                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        private void BioRhythmViewer_FormClosing(Object sender, FormClosingEventArgs e)
        {
            try
            {
                ViewModel.StatusMessage = String.Format("{0} completing...", ViewName);

                DisposeSettings();

                ViewModel.StatusMessage = String.Format("{0} completed.", ViewName);
            }
            catch (Exception ex)
            {
                ViewModel.ErrorMessage = ex.Message.ToString();
                ViewModel.StatusMessage = "";

                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            finally
            {
                ViewModel = null;
            }
        }
        #endregion Form Events

        #region Menu Events
        private void menuFileNew_Click(Object sender, EventArgs e)
        {
            ViewModel.FileNew();
        }

        private void menuFileOpen_Click(Object sender, EventArgs e)
        {
            ViewModel.FileOpen();
        }

        private void menuFileSave_Click(Object sender, EventArgs e)
        {
            ViewModel.FileSave();
        }

        private void menuFileSaveAs_Click(Object sender, EventArgs e)
        {
            ViewModel.FileSaveAs();
        }

        private void menuFilePrint_Click(Object sender, EventArgs e)
        {
            ViewModel.FilePrint();
        }

        private void menuFileExit_Click(Object sender, EventArgs e)
        {
            ViewModel.FileExit();
        }

        private void menuEditProperties_Click(Object sender, EventArgs e)
        {
            ViewModel.EditProperties();
        }

        private void menuEditCopyToClipboard_Click(Object sender, EventArgs e)
        {
            ViewModel.EditCopy();
        }

        private void menuViewPreviousMonth_Click(Object sender, EventArgs e)
        {
            ViewModel.PreviousMonth();
        }

        private void menuViewPreviousWeek_Click(Object sender, EventArgs e)
        {
            ViewModel.PreviousWeek();
        }

        private void menuViewNextWeek_Click(Object sender, EventArgs e)
        {
            ViewModel.NextWeek();
        }

        private void menuViewNextMonth_Click(Object sender, EventArgs e)
        {
            ViewModel.NextMonth();
        }

        private void menuHelpAbout_Click(Object sender, EventArgs e)
        {
            ViewModel.HelpAbout<AssemblyInfo>();
        }
        #endregion Menu Events

        #region Control Events
        #endregion Control Events
        #endregion Events

        #region FormAppBase

        protected void InitViewModel()
        {
            try
            {
                //tell controller how model should notify view about non-persisted properties AND including model properties that may be part of settings
                ModelController<BioRhythmModel>.DefaultHandler = PropertyChangedEventHandlerDelegate;

                //tell controller how settings should notify view about persisted properties
                SettingsController<Settings>.DefaultHandler = PropertyChangedEventHandlerDelegate;

                InitModelAndSettings();

                FileDialogInfo settingsFileDialogInfo =
                    new FileDialogInfo
                    (
                        SettingsController<Settings>.FILE_NEW,
                        null,
                        null,
                        Settings.FileTypeExtension,
                        Settings.FileTypeDescription,
                        Settings.FileTypeName,
                        new String[] 
                    { 
                        "XML files (*.xml)|*.xml", 
                        "All files (*.*)|*.*" 
                    },
                        false,
                        default(Environment.SpecialFolder),
                        Environment.GetFolderPath(Environment.SpecialFolder.Personal).WithTrailingSeparator()
                    );

                //set dialog caption
                settingsFileDialogInfo.Title = this.Text;

                //class to handle standard behaviors
                ViewModelController<Bitmap, BioRhythmViewModel>.New
                (
                    ViewName,
                    new BioRhythmViewModel
                    (
                        this.PropertyChangedEventHandlerDelegate,
                        new Dictionary<String, Bitmap>() 
                    { 
                        { "Above", Resources.Above }, 
                        { "Below", Resources.Below }, 
                        { "Bottom", Resources.Bottom }, 
                        { "Copy", Resources.Copy },
                        { "Delete", Resources.Delete }, 
                        { "FastForward", Resources.FastForward }, 
                        { "FastRewind", Resources.FastRewind }, 
                        { "Forward", Resources.Forward }, 
                        { "New", Resources.New }, 
                        { "Open", Resources.Open },
                        { "Print", Resources.Print },
                        { "Properties", Resources.Properties },
                        { "Rewind", Resources.Rewind }, 
                        { "Save", Resources.Save },
                        { "Top", Resources.Top } 
                    },
                        settingsFileDialogInfo
                    )
                );
                ViewModel = ViewModelController<Bitmap, BioRhythmViewModel>.ViewModel[ViewName];

                BindFormUi();

                //Init config parameters
                if (!LoadParameters())
                {
                    throw new Exception(String.Format("Unable to load config file parameter(s)."));
                }

                //DEBUG:filename coming in is being converted/passed as DOS 8.3 format equivalent
                //Load
                if ((SettingsController<Settings>.FilePath == null) || (SettingsController<Settings>.Filename == SettingsController<Settings>.FILE_NEW))
                {
                    //NEW
                    ViewModel.FileNew();
                }
                else
                {
                    //OPEN
                    ViewModel.FileOpen(false);
                }

#if debug
            //debug view
            menuEditProperties_Click(sender, e);
#endif

                //Display dirty state
                ModelController<BioRhythmModel>.Model.Refresh();

            }
            catch (Exception ex)
            {
                if (ViewModel != null)
                {
                    ViewModel.ErrorMessage = ex.Message;
                }
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        protected void InitModelAndSettings()
        {
            //create Settings before first use by Model
            if (SettingsController<Settings>.Settings == null)
            {
                SettingsController<Settings>.New();
            }
            //Model properties rely on Settings, so don't call Refresh before this is run.
            if (ModelController<BioRhythmModel>.Model == null)
            {
                ModelController<BioRhythmModel>.New();
            }
        }

        protected void DisposeSettings()
        {
            //save user and application settings 
            Properties.Settings.Default.Save();

            if (SettingsController<Settings>.Settings.Dirty)
            {
                //prompt before saving
                DialogResult dialogResult = MessageBox.Show("Save changes?", this.Text, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                switch (dialogResult)
                {
                    case DialogResult.Yes:
                        {
                            //SAVE
                            ViewModel.FileSave();

                            break;
                        }
                    case DialogResult.No:
                        {
                            break;
                        }
                    default:
                        {
                            throw new InvalidEnumArgumentException();
                        }
                }
            }

            //unsubscribe from model notifications
            ModelController<BioRhythmModel>.Model.PropertyChanged -= PropertyChangedEventHandlerDelegate;
        }

        protected void _Run()
        {
        }
        #endregion FormAppBase

        #region Utility
        /// <summary>
        /// Bind static list controls to lookup values, etc.
        /// </summary>
        private void BindFormUi()
        {
            try
            {
                //Form

                //Controls
                BindField<DateTimePicker, BioRhythmModel>(CurrentDate, ModelController<BioRhythmModel>.Model, "SelectedDate");
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Bind Settings controls to SettingsController
        /// </summary>
        private void BindModelUi(Settings settings)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }


        private void BindField<TControl, TModel>
        (
            TControl fieldControl,
            TModel model,
            String modelPropertyName,
            String controlPropertyName = "Text",
            Boolean formattingEnabled = false,
            DataSourceUpdateMode dataSourceUpdateMode = DataSourceUpdateMode.OnPropertyChanged,
            Boolean reBind = true
        )
            where TControl : Control
        {
            try
            {
                fieldControl.DataBindings.Clear();
                if (reBind)
                {
                    fieldControl.DataBindings.Add(controlPropertyName, model, modelPropertyName, formattingEnabled, dataSourceUpdateMode);
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Apply settings to viewer.
        /// </summary>
        private void ApplySettings()
        {
            try
            {
                _ValueChangedProgrammatically = true;

                //apply settings that have databindings
                BindModelUi(SettingsController<Settings>.Settings);

                //apply settings that shouldn't use databindings
                //this.Size = SettingsController<Settings>.Settings.Size;
                //this.Location = SettingsController<Settings>.Settings.Location;

                //apply settings that can't use databindings
                Text = Path.GetFileName(SettingsController<Settings>.Filename) + " - " + ViewName;//TODO: use String.Format(); also make a property?

                //apply settings that don't have databindings
                ViewModel.DirtyIconIsVisible = (SettingsController<Settings>.Settings.Dirty);

                _ValueChangedProgrammatically = false;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Set function button and menu to enable value, and cancel button to opposite.
        /// For now, do only disabling here and leave enabling based on biz logic 
        ///  to be triggered by refresh?
        /// </summary>
        /// <param name="functionButton"></param>
        /// <param name="functionMenu"></param>
        /// <param name="cancelButton"></param>
        /// <param name="enable"></param>
        private void SetFunctionControlsEnable
        (
            Button functionButton,
            ToolStripButton functionToolbarButton,
            ToolStripMenuItem functionMenu,
            Button cancelButton,
            Boolean enable
        )
        {
            try
            {
                //stand-alone button
                if (functionButton != null)
                {
                    functionButton.Enabled = enable;
                }

                //toolbar button
                if (functionToolbarButton != null)
                {
                    functionToolbarButton.Enabled = enable;
                }

                //menu item
                if (functionMenu != null)
                {
                    functionMenu.Enabled = enable;
                }

                //stand-alone cancel button
                if (cancelButton != null)
                {
                    cancelButton.Enabled = !enable;
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Invoke any delegate that has been registered 
        ///  to cancel a long-running background process.
        /// </summary>
        private void InvokeActionCancel()
        {
            try
            {
                //execute cancellation hook
                if (cancelDelegate != null)
                {
                    cancelDelegate();
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }

        /// <summary>
        /// Load from app config; override with command line if present
        /// </summary>
        /// <returns></returns>
        private Boolean LoadParameters()
        {
            Boolean returnValue = default(Boolean);
#if USE_CONFIG_FILEPATH
            String _settingsFilename = default(String);
#endif

            try
            {
                if ((Filename != null) && (Filename != SettingsController<Settings>.FILE_NEW))
                {
                    //got filename from command line
                    //DEBUG:filename coming in is being converted/passed as DOS 8.3 format equivalent
                    if (!RegistryAccess.ValidateFileAssociation(Application.ExecutablePath, "." + /*SettingsController<Settings>.*/Settings.FileTypeExtension))
                    {
                        throw new ApplicationException(String.Format("Settings filename not associated: '{0}'.\nCheck filename on command line.", Filename));
                    }
                    //it passed; use value from command line
                }
                else
                {
#if USE_CONFIG_FILEPATH
                    //get filename from app.config
                    if (!Configuration.ReadString("SettingsFilename", out _settingsFilename))
                    {
                        throw new ApplicationException(String.Format("Unable to load SettingsFilename: {0}", "SettingsFilename"));
                    }
                    if ((_settingsFilename == null) || (_settingsFilename == SettingsController<MVCSettings>.FILE_NEW))
                    {
                        throw new ApplicationException(String.Format("Settings filename not set: '{0}'.\nCheck SettingsFilename in app config file.", _settingsFilename));
                    }
                    //use with the supplied path
                    SettingsController<MVCSettings>.Filename = _settingsFilename;

                    if (Path.GetDirectoryName(_settingsFilename) == String.Empty)
                    {
                        //supply default path if missing
                        SettingsController<MVCSettings>.Pathname = Environment.GetFolderPath(Environment.SpecialFolder.Personal).WithTrailingSeparator();
                    }
#endif
                }

                returnValue = true;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                //throw;
            }
            return returnValue;
        }

        private void BindSizeAndLocation()
        {
            //Note:Size must be done after InitializeComponent(); do Location this way as well.--SJS
            this.DataBindings.Add(new System.Windows.Forms.Binding("Location", global::BioRhythm.Properties.Settings.Default, "Location", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.DataBindings.Add(new System.Windows.Forms.Binding("ClientSize", global::BioRhythm.Properties.Settings.Default, "Size", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.ClientSize = global::BioRhythm.Properties.Settings.Default.Size;
            this.Location = global::BioRhythm.Properties.Settings.Default.Location;
        }
        #endregion Utility

    }
}