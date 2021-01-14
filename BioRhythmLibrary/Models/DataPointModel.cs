using System;
using System.ComponentModel;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Ssepan.Application;
using Ssepan.Utility;

namespace BioRhythmLibrary
{
    //[TypeConverter(typeof(ExpandableObjectConverter))]
    public class DataPointModel :
        ModelComponentBase
    {
        public DataPointModel()
        { 
        }

        public DataPointModel
        (
            DateTime date,
            Double value
        )
        {
            Date = date;
            Value = value;
        }

        private DateTime _Date = default(DateTime);
        public DateTime Date
        {
            get { return _Date; }
            set 
            {
                if (value != _Date)
                {
                    _Date = value;
                    OnPropertyChanged("Date");
                }
            }
        }

        private Double _Value = default(Double);
        public Double Value
        {
            get { return _Value; }
            set 
            {
                if (value != _Value)
                {
                    _Value = value;
                    OnPropertyChanged("Value");
                }
            }
        }
    }
}
