using System;
using System.Windows;
using System.Windows.Input;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BioRhythm
{
    public class FileNewCommand :
        //RoutedCommand
        ICommand
    {
        private BioRhythmViewModel _BioRhythmViewModel = default(BioRhythmViewModel);

        public FileNewCommand(BioRhythmViewModel bioRhythmViewModel)
        {
            _BioRhythmViewModel = bioRhythmViewModel;
        }

        public Boolean CanExecute(object parameter)
        {
            return (true);
        }

        public event EventHandler CanExecuteChanged;
        //public event EventHandler CanExecuteChanged
        //{
        //    add { CommandManager.RequerySuggested += value; }
        //    remove { CommandManager.RequerySuggested -= value; }
        //}


        public void Execute(object parameter)
        {
            //call viewmodel here
            if (CanExecute(null))
            {
                _BioRhythmViewModel.FileNew();
            }
        }
    }
}
