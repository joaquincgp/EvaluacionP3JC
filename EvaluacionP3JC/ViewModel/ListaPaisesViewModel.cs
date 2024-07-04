using EvaluacionP3JC.Models;
using EvaluacionP3JC.Repositories;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace EvaluacionP3JC.ViewModel
{
    public class ListaPaisesViewModel : INotifyPropertyChanged
    {
        private Country _model;
        public Country Model
        {
            get => _model;
            set
            {
                if (_model != value)
                {
                    _model = value;
                    OnPropertyChanged(nameof(Model));
                }
            }
        }


        public ICommand ComandoMostrarPais { get; }


        public event PropertyChangedEventHandler? PropertyChanged;

        private ListaPaisesViewModel() {
            Model = new Country();

            ComandoMostrarPais = new Command(async () => await CargarPais());

        }

        protected virtual void OnPropertyChanged(string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private async Task CargarPais()
        {
            CountryRepo repo = new CountryRepo("COUNTRY.DB");

            List<Country> countries = await repo.RetornarCountries();
            Country country = countries.FirstOrDefault();
            if (country != null)
            {
                Model.Name.Oficial = country.Name.Oficial;
                Model.Region = country.Region;
                Model.Region = country.Region;

            }

            OnPropertyChanged(nameof(Model));
        }
    }
}
