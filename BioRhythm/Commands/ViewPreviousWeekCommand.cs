﻿using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioRhythm
{
    public class ViewPreviousWeekCommand :
        ICommand
    {
        private BioRhythmViewModel _BioRhythmViewModel = default(BioRhythmViewModel);

        public ViewPreviousWeekCommand(BioRhythmViewModel bioRhythmViewModel)
        {
            _BioRhythmViewModel = bioRhythmViewModel;
        }

        public Boolean CanExecute(object parameter)
        {
            return (true);
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter)
        {
            //call viewmodel here
            if (CanExecute(null))
            {
                _BioRhythmViewModel.PreviousWeek();
            }
        }
    }
}