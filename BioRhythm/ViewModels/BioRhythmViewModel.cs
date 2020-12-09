using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using Ssepan.Utility;
using Ssepan.Application;
using Ssepan.Io;
using BioRhythmLibrary;

namespace BioRhythm
{
    /// <summary>
    /// Note: it is not necessary to make this subclass take type parameters.
    /// </summary>
    public class BioRhythmViewModel :
        FormsViewModel<Bitmap, Settings, BioRhythmModel, BioRhythmViewer>
    {
        #region Declarations

        #region Commands
        //public ICommand FileNewCommand { get; private set; }
        //public ICommand FileOpenCommand { get; private set; }
        //public ICommand FileSaveCommand { get; private set; }
        //public ICommand FileSaveAsCommand { get; private set; }
        //public ICommand FilePrintCommand { get; private set; }
        //public ICommand FileExitCommand { get; private set; }
        //public ICommand EditCopyToClipboardCommand { get; private set; }
        //public ICommand EditPropertiesCommand { get; private set; }
        //public ICommand ViewPreviousMonthCommand { get; private set; }
        //public ICommand ViewPreviousWeekCommand { get; private set; }
        //public ICommand ViewNextWeekCommand { get; private set; }
        //public ICommand ViewNextMonthCommand { get; private set; }
        //public ICommand HelpAboutCommand { get; private set; }
        #endregion Commands
        #endregion Declarations

        #region Constructors
        public BioRhythmViewModel() { }//Note: not called, but need to be present to compile--SJS

        public BioRhythmViewModel
        (
            PropertyChangedEventHandler propertyChangedEventHandlerDelegate,
            Dictionary<String, Bitmap> actionIconImages,
            FileDialogInfo settingsFileDialogInfo
        ) :
            base(propertyChangedEventHandlerDelegate, actionIconImages, settingsFileDialogInfo)
        {
            try
            {
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
            }
        }
        #endregion Constructors

        #region Properties
        #endregion Properties

        #region Methods
        /// <summary>
        /// model specific, not generioc
        /// </summary>
        public void PreviousMonth()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                StartProgressBar
                (
                    "Previous Month...",
                    null,
                    _actionIconImages["FastRewind"],
                    true,
                    33
                );

                ModelController<BioRhythmModel>.Model.SelectedDate = ModelController<BioRhythmModel>.Model.SelectedDate.AddMonths(-1);

                ModelController<BioRhythmModel>.Model.Refresh();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
            finally
            {
                StopProgressBar("Previous Month.");
            }
        }

        /// <summary>
        /// model specific, not generioc
        /// </summary>
        public void PreviousWeek()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                StartProgressBar
                (
                    "Previous Week...",
                    null,
                    _actionIconImages["Rewind"],
                    true,
                    33
                );

                ModelController<BioRhythmModel>.Model.SelectedDate = ModelController<BioRhythmModel>.Model.SelectedDate.AddDays(-7);

                ModelController<BioRhythmModel>.Model.Refresh();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
            finally
            {
                StopProgressBar("Previous Week.");
            }
        }

        /// <summary>
        /// model specific, not generioc
        /// </summary>
        public void NextWeek()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                StartProgressBar
                (
                    "Next Week...",
                    null,
                    _actionIconImages["Forward"],
                    true,
                    33
                );

                ModelController<BioRhythmModel>.Model.SelectedDate = ModelController<BioRhythmModel>.Model.SelectedDate.AddDays(7);

                ModelController<BioRhythmModel>.Model.Refresh();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
            finally
            {
                StopProgressBar("Next Week.");
            }
        }

        /// <summary>
        /// model specific, not generioc
        /// </summary>
        public void NextMonth()
        {
            StatusMessage = String.Empty;
            ErrorMessage = String.Empty;

            try
            {
                StartProgressBar
                (
                    "Next Month...",
                    null,
                    _actionIconImages["FastForward"],
                    true,
                    33
                );

                ModelController<BioRhythmModel>.Model.SelectedDate = ModelController<BioRhythmModel>.Model.SelectedDate.AddMonths(1);

                ModelController<BioRhythmModel>.Model.Refresh();
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                StopProgressBar(null, String.Format("{0}", ex.Message));
            }
            finally
            {
                StopProgressBar("Next Month.");
            }
        }
        #endregion Methods

    }
}
