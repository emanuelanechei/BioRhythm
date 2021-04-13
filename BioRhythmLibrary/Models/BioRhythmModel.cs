using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Reflection;
//using System.Windows.Media;
using System.Xml.Serialization;
using Ssepan.Application;
using Ssepan.Application.MVC;
using Ssepan.Utility;

namespace BioRhythmLibrary
{
    /// <summary>
    /// This is the MVC Model
    /// This is the model used for the graph calculation.
    /// It knows how the calculation happens, but is not concerned with what is displayed.
    /// </summary>
    [DefaultPropertyAttribute("UserName")]
    [TypeConverter(typeof(ExpandableObjectConverter))]
    public class BioRhythmModel :
        ModelBase
    {
        #region Declarations
        private const String BIO_GRAPH_TITLE_TOP = "BioRhythm for {0} on {1},";
        private const String BIO_GRAPH_TITLE_BOTTOM = "starting on {0}.";

        public const Int32 POINTS_TO_CALCULATE = 31;

        #region Enums
        public enum LinePlotTypes
        {
            Emotion, 
            Intellect, 
            Physique, 
            Average
        }
        public enum PeriodLength
        {
            Physical  = 23, 
            Emotional = 28, 
            Intellectual = 33, 
        }

        public enum StartHowTypes
        {

            [XmlEnum(Name = "Low")]
            Low,
            [XmlEnum(Name = "Neutral")]
            Neutral,
            [XmlEnum(Name = "High")]
            High
        }

        public enum StartWhenTypes
        {
            [XmlEnum(Name = "Birth")]
            Birth,
            [XmlEnum(Name = "Conception")]
            Conception,
            [XmlEnum(Name = "Explicit")]
            Explicit
        }

        public enum ColorSchemeTypes
        {
            [XmlEnum(Name = "Mono")]
            Mono,
            [XmlEnum(Name = "Color")]
            Color
        }

        public enum ImageFormatTypes
        {
            [XmlEnum(Name = "Metafile")]
            Metafile,
            [XmlEnum(Name = "Bitmap")]
            Bitmap
        }
        #endregion Enums
        #endregion Declarations

        #region Constructors
        public BioRhythmModel() 
        {
            if (SettingsController<Settings>.Settings == null)
            {
                SettingsController<Settings>.New();
            }
            Debug.Assert(SettingsController<Settings>.Settings != null, "SettingsController<Settings>.Settings != null");
        }
        #endregion Constructors

        #region IEquatable<IModel>
        /// <summary>
        /// Compare property values of two specified Model objects.
        /// </summary>
        /// <param name="anotherSettings"></param>
        /// <returns></returns>
        public override Boolean Equals(IModelComponent other)
        {
            Boolean returnValue = default(Boolean);
            BioRhythmModel otherModel = default(BioRhythmModel);

            try
            {
                otherModel = other as BioRhythmModel;

                if (this == otherModel)
                {
                    returnValue = true;
                }
                else
                {
                    if (!base.Equals(other))
                    {
                        returnValue = false;
                    }
                    else if (this.StartHow != otherModel.StartHow)
                    {
                        returnValue = false;
                    }
                    else if (this.StartWhen != otherModel.StartWhen)
                    {
                        returnValue = false;
                    }
                    else if (this.OriginDate != otherModel.OriginDate)
                    {
                        returnValue = false;
                    }
                    else if (this.BirthDate != otherModel.BirthDate)
                    {
                        returnValue = false;
                    }
                    else if (this.UserName != otherModel.UserName)
                    {
                        returnValue = false;
                    }
                    else
                    {
                        returnValue = true;
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }

            return returnValue;
        }
        #endregion IEquatable<IModel>
        
        #region ListChanged handlers
        void Emotion_ListChanged(Object sender, ListChangedEventArgs e)
        {
            try
            {
                OnPropertyChanged(String.Format("Emotion[{0}].{1}", e.NewIndex, (e.PropertyDescriptor == null ? String.Empty : e.PropertyDescriptor.Name)));
            }
            catch (Exception ex)
            {
                Log.Write(
                    ex,
                    System.Reflection.MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        void Intellect_ListChanged(Object sender, ListChangedEventArgs e)
        {
            try
            {
                OnPropertyChanged(String.Format("Intellect[{0}].{1}", e.NewIndex, (e.PropertyDescriptor == null ? String.Empty : e.PropertyDescriptor.Name)));
            }
            catch (Exception ex)
            {
                Log.Write(
                    ex,
                    System.Reflection.MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        void Physique_ListChanged(Object sender, ListChangedEventArgs e)
        {
            try
            {
                OnPropertyChanged(String.Format("Physique[{0}].{1}", e.NewIndex, (e.PropertyDescriptor == null ? String.Empty : e.PropertyDescriptor.Name)));
            }
            catch (Exception ex)
            {
                Log.Write(
                    ex,
                    System.Reflection.MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        void Average_ListChanged(Object sender, ListChangedEventArgs e)
        {
            try
            {
                OnPropertyChanged(String.Format("Average[{0}].{1}", e.NewIndex, (e.PropertyDescriptor == null ? String.Empty : e.PropertyDescriptor.Name)));
            }
            catch (Exception ex)
            {
                Log.Write(
                    ex,
                    System.Reflection.MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }

        void XAxisLabels_ListChanged(Object sender, ListChangedEventArgs e)
        {
            try
            {
                OnPropertyChanged(String.Format("XAxisLabels[{0}].{1}", e.NewIndex, (e.PropertyDescriptor == null ? String.Empty : e.PropertyDescriptor.Name)));
            }
            catch (Exception ex)
            {
                Log.Write(
                    ex,
                    System.Reflection.MethodBase.GetCurrentMethod(),
                    System.Diagnostics.EventLogEntryType.Error);
                throw;
            }
        }
        #endregion ListChanged handlers

        #region Properties
        public static Boolean TestDataMode = default(Boolean);

        private String _LegendTitle = default(String);
        [DescriptionAttribute("Legend Title"),
        CategoryAttribute("Misc")]
        public String LegendTitle
        {
            get { return _LegendTitle; }
            set
            {
                _LegendTitle = value;
                OnPropertyChanged("LegendTitle");
            }
        }

        private DateTime _SelectedDate = DateTime.Now.Date;
        [DescriptionAttribute("Identifies date of interest, around which graph is centered."),
        CategoryAttribute("Misc")]
        public DateTime SelectedDate
        {
            get { return _SelectedDate; }
            set 
            {
                //Since the UI elements that rely on the notifications for the start/end date range 
                // are sensitive to range validation rules, the notifications must be triggered 
                // in an order that does not violate the rules. 
                //This is reflected in the notifications below. 
                DateTime oldSelectedDate = _SelectedDate;

                _SelectedDate = value;
                OnPropertyChanged("SelectedDate");

                //Update the end that is in the direction of the change (leading) first; 
                // then follow with the trailing end.
                if (_SelectedDate > oldSelectedDate)
                {
                    OnPropertyChanged("GraphEndDate");
                    OnPropertyChanged("GraphStartDate");
                }
                else //(_SelectedDate < oldSelectedDate)
                {
                    OnPropertyChanged("GraphStartDate");
                    OnPropertyChanged("GraphEndDate");
                }
            }
        }

        #region Persisted Properties
        /// <summary>
        /// Determines whether graph starts in positive, neutral, or negative mode.
        /// </summary>
        [DescriptionAttribute("Determines whether graph starts in positive, neutral, or negative mode."),
        CategoryAttribute("Behavior"),
        DefaultValueAttribute(BioRhythmModel.StartHowTypes.Neutral),
        ReadOnlyAttribute(true)]
        public StartHowTypes StartHow
        {
           get { return SettingsController<Settings>.Settings.StartHow; }
           set
           {
               SettingsController<Settings>.Settings.StartHow = value;
               OnPropertyChanged("StartHow");
           }
        }

        /// <summary>
        /// Determines whether graph starts on date of birth, on the approximate date of conception (9 months before birth), or on an explicit date different from birth.
        /// </summary>
        [DescriptionAttribute("Determines whether graph starts on date of birth, on the approximate date of conception (9 months before birth), or on an explicit date different from birth."),
        CategoryAttribute("Behavior"),
        DefaultValueAttribute(BioRhythmModel.StartWhenTypes.Birth)]
        public StartWhenTypes StartWhen
        {
            get { return SettingsController<Settings>.Settings.StartWhen; }
            set
            {
                SettingsController<Settings>.Settings.StartWhen = value;
                OnPropertyChanged("StartWhen");

                switch (value)
                {
                    case StartWhenTypes.Birth:
                        {
                            OriginDate = BirthDate;
                            break;
                        }
                    case StartWhenTypes.Conception:
                        {
                            // Start 9 months earlier if StartWhen=StartWhenTypes.Conception.
                            OriginDate = BirthDate.AddMonths(-9).Date;
                            break;
                        }
                    case StartWhenTypes.Explicit:
                        {
                            //leave StartDate alone
                            break;
                        }
                    default:
                        {
                            throw new InvalidEnumArgumentException();
                        }
                }
            }
        }

       /// <summary>
       /// Identifies date origin from which graph *calculation* starts. Its behavior is affected by StartWhen.
       /// </summary>
       [DescriptionAttribute("Identifies date on which graph starts. Its behavior is affected by StartWhen."),
       CategoryAttribute("Misc")]
       public DateTime OriginDate
       {
           get { return SettingsController<Settings>.Settings.OriginDate; }
           set
           {
               SettingsController<Settings>.Settings.OriginDate = value;
               OnPropertyChanged("OriginDate");
           }
        }

       /// <summary>
       /// Identifies date on which user was born. It works in conjunction with StartWhen.
       /// </summary>
       [DescriptionAttribute("Identifies date on which user was born. It works in conjunction with StartWhen."),
       CategoryAttribute("Misc")]
       public DateTime BirthDate
       {
           get { return SettingsController<Settings>.Settings.BirthDate; }
           set
           {
               SettingsController<Settings>.Settings.BirthDate = value;
               OnPropertyChanged("BirthDate");

               switch (StartWhen)
               {
                   case StartWhenTypes.Birth:
                       {
                           OriginDate = BirthDate;
                           break;
                       }
                   case StartWhenTypes.Conception:
                       {
                           // Start 9 months earlier if StartWhen=StartWhenTypes.Conception.
                           OriginDate = BirthDate.AddMonths(-9).Date;
                           break;
                       }
                   case StartWhenTypes.Explicit:
                       {
                           //leave StartDate alone
                           break;
                       }
                   default:
                       {
                           throw new InvalidEnumArgumentException();
                       }
               }
           }
       }

       /// <summary>
       /// Identifier used to store and retrieve the settings.
       /// </summary>
       [DescriptionAttribute("Identifier used to store and retrieve the settings."),
       CategoryAttribute("Misc"),
       DefaultValueAttribute("(new)")]
       public String UserName
       {
           get { return SettingsController<Settings>.Settings.UserName; }
           set
           {
                SettingsController<Settings>.Settings.UserName = value;
                OnPropertyChanged("UserName");
           }
       }
        #endregion Persisted Properties

       /// <summary>
       /// Start of graph 'window'.
       /// Affects CalculateGraph(), but does not call it.
       /// </summary>
       public DateTime GraphStartDate
       {
           get { return SelectedDate.AddDays(GraphStartOffset).Date; }
       }

       /// <summary>
       /// End of graph 'window'.
       /// Affects CalculateGraph(), but does not call it.
       /// </summary>
       public DateTime GraphEndDate
       {
           get { return SelectedDate.AddDays(Math.Abs(GraphStartOffset)).Date; }
       }


       /// <summary>
       /// Calculate graph start point as a negative offset
       /// from a center point (which always represents the Selected Date).
       /// Affects CalculateGraph(), but does not call it.
       /// </summary>
       public Int32 GraphStartOffset
       {
           get { return -(Int32)(POINTS_TO_CALCULATE / 2); }
       }
       
        private static String _Title = String.Empty;
       /// <summary>
       /// Set by CalculateGaph()
       /// </summary>
       public String Title
       {
           get { return _Title; }
           set
           {
               _Title = value;
               OnPropertyChanged("Title");
           }
       }

       private static String _SubTitle = String.Empty;
       /// <summary>
       /// Set by CalculateGaph()
       /// </summary>
       public String SubTitle
       {
           get { return _SubTitle; }
           set
           {
               _SubTitle = value;
               OnPropertyChanged("SubTitle");
           }
       }

       private static BindingList<DataPointModel> _Emotion = new BindingList<DataPointModel>();
       /// <summary>
       /// Set by CalculateGaph()
       /// </summary>
       public BindingList<DataPointModel> Emotion
       {
           get { return _Emotion; }
           set
           {
               if (_Emotion != null)
               {
                   _Emotion.ListChanged -= Emotion_ListChanged;
               }
               _Emotion = value;
               if (_Emotion != null)
               {
                   _Emotion.ListChanged += Emotion_ListChanged;
               }
               OnPropertyChanged("Emotion");
           }
       }

       private static BindingList<DataPointModel> _Intellect = new BindingList<DataPointModel>();
       /// <summary>
       /// Set by CalculateGaph()
       /// </summary>
       public BindingList<DataPointModel> Intellect
       {
           get { return _Intellect; }
           set
           {
               if (_Intellect != null)
               {
                   _Intellect.ListChanged -= Intellect_ListChanged;
               }
               _Intellect = value;
               if (_Intellect != null)
               {
                   _Intellect.ListChanged += Intellect_ListChanged;
               }
               OnPropertyChanged("Intellect");
           }
       }

       private static BindingList<DataPointModel> _Physique = new BindingList<DataPointModel>();
       /// <summary>
       /// Set by CalculateGaph()
       /// </summary>
       public BindingList<DataPointModel> Physique
       {
           get { return _Physique; }
           set
           {
               if (_Physique != null)
               {
                   _Physique.ListChanged -= Physique_ListChanged;
               }
               _Physique = value;
               if (_Physique != null)
               {
                   _Physique.ListChanged += Physique_ListChanged;
               }
               OnPropertyChanged("Physique");
           }
       }

       private static BindingList<DataPointModel> _Average = new BindingList<DataPointModel>();
       /// <summary>
       /// Set by CalculateGaph()
       /// </summary>
       public BindingList<DataPointModel> Average
       {
           get { return _Average; }
           set
           {
               if (_Average != null)
               {
                   _Average.ListChanged -= Average_ListChanged;
               }
               _Average = value;
               if (_Average != null)
               {
                   _Average.ListChanged += Average_ListChanged;
               }
               OnPropertyChanged("Average");
           }
       }

       private static BindingList<String> _XAxisLabels = new BindingList<String>();
       /// <summary>
       /// Set by CalculateGaph()
       /// </summary>
       public BindingList<String> XAxisLabels
       {
           get { return _XAxisLabels; }
           private set
           {
               if (_XAxisLabels != null)
               {
                   _XAxisLabels.ListChanged -= XAxisLabels_ListChanged;
               }
               _XAxisLabels = value;
               if (_XAxisLabels != null)
               {
                   _XAxisLabels.ListChanged += XAxisLabels_ListChanged;
               }
               OnPropertyChanged("XAxisLabels");
           }
       }
        #endregion Properties

        #region Methods
       /// <summary>
       /// Support clients that do not handle databinding, but which can subscribe to PropertyChanged.
       /// Additionally, while clients can handle PropertyChanged on individual properties, 
       ///  this is a general notification that the client may desire to do a Refresh.
       /// </summary>
       public override void Refresh()
       {
           CalculateGraph();
           base.Refresh(); 
       }

        /// <summary>
       /// Sets data arrays, labels, legends, etc.
       /// </summary>
       public void CalculateGraph()
       {

           DateTime dataPointDate;
           Int32 relativeDaysFromOrigin;
           DataPointModel feelingAssessment;
           DataPointModel physicalAssessment;
           DataPointModel emotionalAssessment;
           DataPointModel intellectualAssessment;
           Int32 indexIntoDataPoints;
           String labelText;

           try
           {
               Title = String.Format(BIO_GRAPH_TITLE_TOP, UserName, SelectedDate.ToLongDateString());
               SubTitle = String.Format(BIO_GRAPH_TITLE_BOTTOM, OriginDate.ToLongDateString());

               //clear all  lists
               Emotion.Clear();
               Intellect.Clear();
               Physique.Clear();
               Average.Clear();
               XAxisLabels.Clear();

               //load all array lists
               for (indexIntoDataPoints = 0; indexIntoDataPoints < POINTS_TO_CALCULATE; indexIntoDataPoints++)
               {
                   // Iterate through days before and after SelectedDate
                   dataPointDate = SelectedDate.AddDays(GraphStartOffset + indexIntoDataPoints);

                   // Determine offset of datapoint date from origin.
                   relativeDaysFromOrigin = dataPointDate.Date.Subtract(OriginDate.Date).Days;

                   // This point depicts a date on or after the start;
                   // set the point and label text appropriately.
                   physicalAssessment = new DataPointModel(dataPointDate, CalculatePoint(relativeDaysFromOrigin, PeriodLength.Physical, StartHow));
                   emotionalAssessment = new DataPointModel(dataPointDate, CalculatePoint(relativeDaysFromOrigin, PeriodLength.Emotional, StartHow));
                   intellectualAssessment = new DataPointModel(dataPointDate, CalculatePoint(relativeDaysFromOrigin, PeriodLength.Intellectual, StartHow));

                   // Calculate value as average, not total,
                   // so that graph scale is consistent throughout.
                   feelingAssessment = new DataPointModel(dataPointDate, (physicalAssessment.Value + emotionalAssessment.Value + intellectualAssessment.Value) / 3);

                   //Build the series
                   Physique.Add(physicalAssessment);
                   Emotion.Add(emotionalAssessment);
                   Intellect.Add(intellectualAssessment);
                   Average.Add(feelingAssessment);

                   // Label points by 1st two chars of Day of Week.
                   labelText = dataPointDate.DayOfWeek.ToString().Substring(0, 2) + " " + dataPointDate.Month.ToString() + "/" + dataPointDate.Day.ToString();
                   if ((indexIntoDataPoints + GraphStartOffset) == 0)
                   {
                       //wrap brackets around current date
                       labelText = "[" + labelText + "]";
                   }

                   XAxisLabels.Add(labelText);
               }
               
               //trigger list bindings
               Emotion = Emotion;
               Intellect = Intellect;
               Physique = Physique;
               Average = Average;
               XAxisLabels = XAxisLabels;
           }
           catch (Exception ex)
           {
               Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

               throw;
           }
       }

       /// <summary>
       /// Calculate individual point for a given line.
       /// </summary>
       /// <param name="relativeGraphDays"></param>
       /// <param name="periodLength"></param>
       /// <param name="startHow"></param>
       /// <returns></returns>
       private Double CalculatePoint
       (
           Int32 relativeGraphDays,
           PeriodLength periodLength,
           StartHowTypes startHow
       )
       {
           Double returnValue = default(Double);
           Int32 daysIntoCycle;

           try
           {
               if (relativeGraphDays < 0)
               {
                   // This point depicts a date before the start;2
                   // zero the point and clear the label text.
                   returnValue = CalculateZeroPoint();
               }
               else
               {
                   daysIntoCycle = relativeGraphDays % (Int32)periodLength;

                   switch (StartHow)
                   {
                       case StartHowTypes.High:
                           {
                               returnValue = 10 * Math.Cos((daysIntoCycle / (Int32)periodLength) * (2 * Math.PI));
                               break;
                           }
                       case StartHowTypes.Neutral:
                           {
                               returnValue = 10 * Math.Sin((daysIntoCycle / (Double)periodLength) * (2 * Math.PI));
                               break;
                           }
                       case StartHowTypes.Low:
                           {
                               returnValue = (-10) * Math.Cos((daysIntoCycle / (Int32)periodLength) * (2 * Math.PI));
                               break;
                           }
                       default:
                           {
                               throw new InvalidEnumArgumentException();
                           }
                   }
               }
           }
           catch (Exception ex)
           {
               Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

               throw;
           }

           return returnValue;
       }

        /// <summary>
        /// Calculate 'zero' point for data points that fall before the graph start date.
        /// </summary>
        /// <returns></returns>
        private Int32 CalculateZeroPoint
        (
        )
        {
           Int32 zeroPoint;
           switch (StartHow)
           {
               case StartHowTypes.High:
                   {
                       zeroPoint = 10;
                       break;
                   }
               case StartHowTypes.Neutral:
                   {
                       zeroPoint = 0;
                       break;
                   }
               case StartHowTypes.Low:
                   {
                       zeroPoint = -10;
                       break;
                   }
               default:
                   {
                       throw new InvalidEnumArgumentException();
                   }

           }
           return zeroPoint;
        }
        #endregion Methods


    }
}
