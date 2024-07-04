using EvaluacionP3JC.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionP3JC.Repositories
{
    public class CountryRepo
    {
        public string _dbPath;
        private SQLiteConnection conn;

        private void Init()
        {
            if (conn != null)
                return;

            conn = new SQLiteConnection(_dbPath);
            conn.CreateTable<Country>();
        }

        //Constructor
        public CountryRepo(string dbPath)
        {
            _dbPath = dbPath;
        }

        public List<Country> RetonaListadoCountry()
        {
            return conn.Table<Country>().ToList();
        }

        // Método para guardar la cita en la base de datos SQLite
        public void GuardarCountry(Country country)
        {
            conn.Insert(country);
        }

        public void EliminarCountry(Country country)
        {
            conn.Delete(country);
        }

        public async Task<List<Country>> RetornarCountries()
        {
            HttpClient client = new HttpClient();
            string url = "https://restcountries.com/v3.1/all";
            var response = client.GetAsync(url);
            string response_json = await response.Result.Content.ReadAsStringAsync();

            List<Country> countries = JsonConvert.DeserializeObject<List<Country>>(response_json);

            return countries;
        }
    }
}
