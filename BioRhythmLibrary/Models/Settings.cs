using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Reflection;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using Ssepan.Application;
using Ssepan.Utility;

namespace BioRhythmLibrary
{
	/// <summary>
	/// Settings which are persisted. This is a sub-component of the Model.
	/// </summary>
    [TypeConverter(typeof(ExpandableObjectConverter))]
    [DefaultPropertyAttribute("UserName")]
    [Serializable]
    public class Settings :
        SettingsBase
    {
        #region Declarations
        private const String FILE_TYPE_EXTENSION = "biorhythm";
        private const String FILE_TYPE_NAME = "biorhythmfile";
        private const String FILE_TYPE_DESCRIPTION = "BioRhythm Settings File";
        #endregion Declarations

        #region Constructors
        public Settings() 
        {
            FileTypeExtension = FILE_TYPE_EXTENSION;
            FileTypeName = FILE_TYPE_NAME;
            FileTypeDescription = FILE_TYPE_DESCRIPTION;
            SerializeAs = SerializationFormat.Xml;//default
        }
        #endregion Constructors

        #region IEquatable<ISettings> 
        /// <summary>
        /// Compare property values of two specified Settings objects.
        /// </summary>
        /// <param name="anotherSettings"></param>
        /// <returns></returns>
        public override Boolean Equals(ISettingsComponent other)
        {
            Boolean returnValue = default(Boolean);
            Settings otherSettings = default(Settings);

            try
            {
                otherSettings = other as Settings;
                
                if (this == otherSettings)
                {
                    returnValue = true;
                }
                else
                {
                    if (!base.Equals(other))
                    {
                        returnValue = false;
                    }
                    else if (this.StartHow != otherSettings.StartHow)
                    {
                        returnValue = false;
                    }
                    else if (this.StartWhen != otherSettings.StartWhen)
                    {
                        returnValue = false;
                    }
                    else if (this.OriginDate != otherSettings.OriginDate)
                    {
                        returnValue = false;
                    }
                    else if (this.BirthDate != otherSettings.BirthDate)
                    {
                        returnValue = false;
                    }
                    else if (this.UserName != otherSettings.UserName)
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
        #endregion IEquatable<ISettings> 

        #region Properties
        [XmlIgnore]
        public override Boolean Dirty
        {
            get
            {
                Boolean returnValue = default(Boolean);

                try
                {
                    if (base.Dirty)
                    {
                        returnValue = true;
                    }
                    else if (_StartHow != __StartHow)
                    {
                        returnValue = true;
                    }
                    else if (_StartWhen != __StartWhen)
                    {
                        returnValue = true;
                    }
                    else if (_OriginDate != __OriginDate)
                    {
                        returnValue = true;
                    }
                    else if (_BirthDate != __BirthDate)
                    {
                        returnValue = true;
                    }
                    else if (_UserName != __UserName)
                    {
                        returnValue = true;
                    }
                    //else if (!_Xxx.Equals(__Xxx))
                    //{
                    //    returnValue = true;
                    //}
                    else
                    {
                        returnValue = false;
                    }
                }
                catch (Exception ex)
                {
                    Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);

                    throw;
                }

                return returnValue;
            }
        }

        #region Persisted Properties
        //Appearance

        //Behavior

        /// <summary>
        /// Determines whether graph starts in positive, neutral, or negative mode.
        /// </summary>
        private BioRhythmModel.StartHowTypes __StartHow = BioRhythmModel.StartHowTypes.Neutral;
        private BioRhythmModel.StartHowTypes _StartHow = BioRhythmModel.StartHowTypes.Neutral;
        [DescriptionAttribute("Determines whether graph starts in positive, neutral, or negative mode."),
        CategoryAttribute("Behavior"),
        DefaultValueAttribute(BioRhythmModel.StartHowTypes.Neutral),
        ReadOnlyAttribute(true)]
        public BioRhythmModel.StartHowTypes StartHow
		{
            get 
            {
                return _StartHow;
            }
            set 
            {
                _StartHow = value;
                OnPropertyChanged("StartHow");
            }
		}

        /// <summary>
        /// Determines whether graph starts on date of birth, approximate date of conception (9 months before birth), or an explicit date different from birth.
        /// </summary>
        private BioRhythmModel.StartWhenTypes __StartWhen = BioRhythmModel.StartWhenTypes.Birth;
        private BioRhythmModel.StartWhenTypes _StartWhen = BioRhythmModel.StartWhenTypes.Birth;
        [DescriptionAttribute("Determines whether graph starts on date of birth, approximate date of conception (9 months before birth), or an explicit date different from birth."),
        CategoryAttribute("Behavior"),
        DefaultValueAttribute(BioRhythmModel.StartWhenTypes.Birth)]
        public BioRhythmModel.StartWhenTypes StartWhen
		{
            get 
            {
                return _StartWhen;
            }
            set 
            {
                _StartWhen = value;
                OnPropertyChanged("StartWhen");
            }
		}

        //Misc

        /// <summary>
        /// Identifies date on which graph starts. Its behavior is affected by StartWhen.
        /// </summary>
        private DateTime __OriginDate = System.DateTime.Now.Date;
        private DateTime _OriginDate = System.DateTime.Now.Date;
        [DescriptionAttribute("Identifies date on which graph starts. Its behavior is affected by StartWhen."),
        CategoryAttribute("Misc")]
        public DateTime OriginDate
		{
            get 
            {
                return _OriginDate;
            }
            set 
            {
                _OriginDate = value;
                OnPropertyChanged("OriginDate");
            }
        }

        /// <summary>
        /// Identifies date on which user was born. It works in conjunction with StartWhen.
        /// </summary>
        private DateTime __BirthDate = DateTime.Now.Date;
        private DateTime _BirthDate = DateTime.Now.Date;
        [DescriptionAttribute("Identifies date on which user was born. It works in conjunction with StartWhen."),
        CategoryAttribute("Misc")]
        public DateTime BirthDate
		{
            get 
            {
                return _BirthDate;
            }
            set 
            {
                _BirthDate = value;
                OnPropertyChanged("BirthDate");
            }
		}

        /// <summary>
        /// Identifier used to store and retrieve the settings.
        /// </summary>
        private String __UserName = SettingsController<Settings>.FILE_NEW;
        private String _UserName = SettingsController<Settings>.FILE_NEW;
        [DescriptionAttribute("Identifier used to store and retrieve the settings."), 
        CategoryAttribute("Misc"),
        DefaultValueAttribute("(new)")]
        public String UserName
		{
            get 
            {
                return _UserName;
            }
            set 
            {
                _UserName = value;
                OnPropertyChanged("UserName");
            }
		}
        #endregion Persisted Properties
        #endregion Properties

        #region Methods
        /// <summary>
        /// Copies property values from source working fields to detination working fields, then optionally syncs destination.
        /// </summary>
        /// <param name="destination"></param>
        /// <param name="sync"></param>
        public override void CopyTo(ISettingsComponent destination, Boolean sync)
        {
            Settings destinationSettings = default(Settings);

            try
            {
                destinationSettings = destination as Settings; 

                destinationSettings.StartHow = this.StartHow;
                destinationSettings.StartWhen = this.StartWhen;
                destinationSettings.BirthDate = this.BirthDate;
                destinationSettings.OriginDate = this.OriginDate;
                destinationSettings.UserName = this.UserName;

                base.CopyTo(destination, sync);//also checks and optionally performs sync
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }

        /// <summary>
        /// Syncs property values from working fields to reference fields.
        /// </summary>
        public override void Sync()
        {
            try
            {
                __StartHow = _StartHow;
                __StartWhen = _StartWhen;
                __OriginDate = _OriginDate;
                __BirthDate = _BirthDate;
                __UserName = _UserName;

                base.Sync();

                if (Dirty)
                {
                    throw new ApplicationException("Sync failed.");
                }
            }
            catch (Exception ex)
            {
                Log.Write(ex, MethodBase.GetCurrentMethod(), EventLogEntryType.Error);
                throw;
            }
        }
        #endregion Methods
    }
}
