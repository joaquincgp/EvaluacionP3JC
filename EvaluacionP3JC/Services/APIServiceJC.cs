﻿using EvaluacionP3JC.Models;
using Newtonsoft.Json;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvaluacionP3JC.Repositories
{
    public class APIServiceJC
    {
        private readonly HttpClient _httpClient;

        public APIServiceJC()
        {
            _httpClient = new HttpClient();
        }

        public async Task<List<Country>> GetCountriesAsync()
        {
            var response = await _httpClient.GetStringAsync("https://restcountries.com/v3.1/all");
            var countries = JsonConvert.DeserializeObject<List<dynamic>>(response);

            var result = countries.Select(c => new Country
            {
                Name = c["name"]["official"].ToString(),
                Region = c["region"].ToString(),
                Subregion = c["subregion"]?.ToString(),
                Status = "Unknown",
                Code = GenerateCode()
            }).ToList();

            return result;
        }

        private string GenerateCode()
        {
            Random rnd = new Random();
            int number = rnd.Next(1000, 2000);
            return $"JC{number}";
        }
    }
}
