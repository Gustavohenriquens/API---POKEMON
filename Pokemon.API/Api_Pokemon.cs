using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Pokemon.API
{
    class Api_Pokemon
    {
        static void Main(string[] args)
        {

            var url = "https://pokeapi.co/api/v2/pokemon?limit=100000&offset=0";

            HttpClient client = new HttpClient();
            var response = client.GetAsync(url).Result;

            if (response.IsSuccessStatusCode)
            {
                var results = response.Content.ReadAsStringAsync().Result;

                var listPokemon = JsonConvert.DeserializeObject<Pokemon>(results);

                foreach (var poke in listPokemon.Results)
                {
                    Console.WriteLine(poke.Name);
                }
            }
        }
    }
}
