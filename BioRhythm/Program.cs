using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.ComponentModel;
using System.Reflection;
using System.Windows.Forms;
using Ssepan.Application;
using Ssepan.Application.WinConsole;
using Ssepan.Utility;
using BioRhythmLibrary;

namespace BioRhythm
{
    /// <summary>
    /// Program will also serve as the Controller.
    /// </summary>
    static class Program
    {
        #region Declarations
        public const String APP_NAME = "BioRhythm Viewer";
        #endregion Declarations

        #region INotifyPropertyChanged
        public static event PropertyChangedEventHandler PropertyChanged;
        public static void OnPropertyChanged(String propertyName)
        {
            try
            {
                if (PropertyChanged != null)
                {
                    PropertyChanged(null, new PropertyChangedEventArgs(propertyName));
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                throw;
            }
        }
        #endregion INotifyPropertyChanged

        #region PropertyChangedEventHandlerDelegate
        /// <summary>
        /// Note: property changes update UI manually.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public static void ModelPropertyChangedEventHandlerDelegate
        (
            Object sender,
            PropertyChangedEventArgs e
        )
        {
            try
            {
                if (e.PropertyName == "Filename")
                {
                    ConsoleApplication.defaultOutputDelegate(String.Format("{0}", Filename));
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion PropertyChangedEventHandlerDelegate

        #region Properties
        private static String _Filename = default(String);
        public static String Filename
        {
            get { return _Filename; }
            set
            {
                _Filename = value;
                OnPropertyChanged("Filename");
            }
        }
        #endregion Properties

        /// <summary>
        /// The main entry point for the application. 
        /// </summary>
        [STAThread]
        static Int32 Main(String[] args)
        {
            //default to fail code
            Int32 returnValue = -1;

            try
            {
                //define default output delegate
                ConsoleApplication.defaultOutputDelegate = ConsoleApplication.messageBoxWrapperOutputDelegate;

                //subscribe to notifications
                PropertyChanged += ModelPropertyChangedEventHandlerDelegate;

                //load, parse, run switches
                DoSwitches(args);

                InitModelAndSettings();

                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                Application.Run(new BioRhythmViewer(args));

                returnValue = 0;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
            return returnValue;
        }

        #region FormAppBase
        /// <summary>
        /// Note: switches are processed before Model or Settings are accessed.
        /// </summary>
        /// <param name="args"></param>
        static void DoSwitches(String[] args)
        {
            //define supported switches
            // -t -f:"filename" -h
            ConsoleApplication.DoCommandLineSwitches
            (
                args,
                new CommandLineSwitch[]  
                { 
                    new CommandLineSwitch("f", "f filename; overrides app.config", true, f),
                    //new CommandLineSwitch("H", "H invokes the Help command.", false, ConsoleApplication.Help)//may already be loaded
                }
            );
        }

        static void InitModelAndSettings()
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
        #endregion FormAppBase

        #region CommandLineSwitch Action Delegates
        /// <summary>
        /// Set Test Data Mode flag
        /// command line Action Delegate
        /// Do not change; this delegate is triggered by a commnd line switch.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="outputDelegate"></param>
        private static void Test(String value, Action<String> outputDelegate)
        {
            BioRhythmModel.TestDataMode = true;
        }

        /// <summary>
        /// Validate and set selected settings.
        /// Instance of an action conforming to delegate Action<T>, where T is String.
        /// </summary>
        /// <param name="value"></param>
        /// <param name="outputDelegate"></param>
        private static void f(String value, Action<String> outputDelegate)
        {
            try
            {
#if debug
                outputDelegate(String.Format("s{0}\t{1}", ConsoleApplication.CommandLineSwitchValueSeparator, value));
#endif

                //validate settings file path
                if (!System.IO.File.Exists(value))
                {
                    throw new ArgumentException(String.Format("Invalid settings file path: '{0}'", value));
                }
                Filename = value;
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
        #endregion CommandLineSwitch Action Delegates
    }
}