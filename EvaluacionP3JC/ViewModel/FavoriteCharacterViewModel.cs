using EvaluacionP3JC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;


namespace EvaluacionP3JC.ViewModel
{
    public class FavoriteCharacterViewModel : INotifyPropertyChanged
    {
        private FavoriteCharacter _favoriteCharacter;
        private string _newDescription;

        public FavoriteCharacter FavoriteCharacter
        {
            get => _favoriteCharacter;
            set
            {
                if (_favoriteCharacter != value)
                {
                    _favoriteCharacter = value;
                    OnPropertyChanged();
                }
            }
        }

        public string NewDescription
        {
            get => _newDescription;
            set
            {
                if (_newDescription != value)
                {
                    _newDescription = value;
                    OnPropertyChanged();
                }
            }
        }

        public ICommand SaveDescriptionCommand { get; private set; }

        public FavoriteCharacterViewModel()
        {
            FavoriteCharacter = new FavoriteCharacter
            {
                ImageUrl = "https://dt7v1i9vyp3mf.cloudfront.net/styles/news_large/s3/imagelibrary/F/Fred_Again_01-ek5spoxRapFfVohY5SG8oGzj9HFiZGYH.jpg",
                Description = ""
            };

            SaveDescriptionCommand = new Command(SaveDescription);
        }

        private void SaveDescription()
        {
            // Aquí puedes guardar la nueva descripción en algún lugar (base de datos, almacenamiento en la nube, etc.)
            FavoriteCharacter.Description = NewDescription;
            OnPropertyChanged(nameof(FavoriteCharacter)); // Notificar cambios en FavoriteCharacter
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
