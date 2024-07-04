using EvaluacionP3JC.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionP3JC.ViewModel
{
    public class FavoriteCharacterViewModel : INotifyPropertyChanged
    {
        private FavoriteCharacter _favoriteCharacter;

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

        public FavoriteCharacterViewModel()
        {
            FavoriteCharacter = new FavoriteCharacter
            {
                ImageUrl = "https://dt7v1i9vyp3mf.cloudfront.net/styles/news_large/s3/imagelibrary/F/Fred_Again_01-ek5spoxRapFfVohY5SG8oGzj9HFiZGYH.jpg",
                Description = ""
            };
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
