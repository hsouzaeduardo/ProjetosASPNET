using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Demo05.Models
{
    public class Carros
    {
        public string Nome { get; set; }
        public string Marca { get; set; }

        public List<Carros> ListarCarros()
        {
            var resultado = new List<Carros>();

            resultado.Add(new Carros() { Marca = "KIA", Nome = "CERATO" });
            resultado.Add(new Carros() { Marca = "Nissan", Nome = "Kicks" });
            resultado.Add(new Carros() { Marca = "Jeep", Nome = "Compass" });

            return resultado;
        }
    }
}
