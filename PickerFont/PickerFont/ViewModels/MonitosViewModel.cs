using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

using Xamarin.Forms;
using Xamarin.Essentials;

using PickerFont.Models;
using System.Threading.Tasks;

namespace PickerFont.ViewModels
{
    public class MonitosViewModel : BaseViewModel
    {
        private ObservableCollection<Monitos> _monitos;
        public ObservableCollection<Monitos> Monitos
        {
            get => _monitos;
            set
            {
                _monitos = value;
                OnPropertyChanged();
            }
        }

        public MonitosViewModel()
        {
            Monitos = new ObservableCollection<Monitos>()
            {
                new Monitos() { Nombre = "Baboon" },
                new Monitos() { Nombre = "Capuchin MonkeyCapuchin MonkeyCapuchin MonkeyCapuchin MonkeyCapuchin MonkeyCapuchin MonkeyCapuchin MonkeyCapuchin MonkeyCapuchin Monkey" },
                new Monitos() { Nombre = "Blue Monkey" },
                new Monitos() { Nombre = "Squirrel Monkey" },
                new Monitos() { Nombre = "Golden Lion Tamarin" },
                new Monitos() { Nombre = "Howler Monkey" },
                new Monitos() { Nombre = "Japanese Macaque" },
            };
        }

    }
}
