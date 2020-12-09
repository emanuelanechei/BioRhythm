using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioRhythm
{
    public class EditChartPropertiesCommand :
        ICommand
    {
        private BioRhythmViewModel _BioRhythmViewModel = default(BioRhythmViewModel);

        public EditChartPropertiesCommand(BioRhythmViewModel bioRhythmViewModel)
        {
            _BioRhythmViewModel = bioRhythmViewModel;
        }

        public Boolean CanExecute(object parameter)
        {
            return (false);//(true);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //call viewmodel here
            if (CanExecute(null))
            {
                //_BioRhythmViewModel.EditChartProperties();
            }
        }
    }
}
