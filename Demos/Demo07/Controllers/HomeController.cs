using Demo07.conrtexto;
using Demo07.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace Demo07.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger = null;
        private readonly IConfiguration _config = null;
        private readonly Demo07Contexto _contexto = null;
        public HomeController(ILogger<HomeController> logger,
            IConfiguration config, Demo07Contexto contexto)
        {
            _logger = logger;
            _config = config;
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            string cCon = _config.GetConnectionString("BancoLab07");
            //SqlConnection conexao = new SqlConnection(cCon);
            List<Pessoa> pessoas = new List<Pessoa>();
            using (SqlConnection conexao = new SqlConnection(cCon))
            {
                conexao.Open();

                string cSql = "SELECT * FROM Pessoa";

                using (SqlCommand command = new SqlCommand(cSql, conexao))
                {
                    SqlDataReader sqlDataReader = command.ExecuteReader();

                    while (sqlDataReader.Read())
                    {
                        pessoas.Add(new Pessoa()
                        {
                            Cpf = sqlDataReader["Cpf"].ToString(),
                            Nome = sqlDataReader["Nome"].ToString()
                        });
                    }
                }
            }
            stopwatch.Stop();
            ViewBag.Tempo = stopwatch.ElapsedMilliseconds;
            return View();
        }

        public IActionResult Privacy()
        {
            System.Diagnostics.Stopwatch stopwatch = new Stopwatch();
            stopwatch.Start();
            _contexto.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;

            //Update 
            //var enderecos = new List<Endereco>();
            //enderecos.Add(new Endereco() { EnderecoDesc = "Casa" } );
            //enderecos.Add(new Endereco() { EnderecoDesc = "Empresa" });
            //enderecos.Add(new Endereco() { EnderecoDesc = "Praia" });

            //var pessoa = _contexto.Pessoa.FirstOrDefault();
            //pessoa.Enderecos = enderecos;

            //_contexto.Pessoa.Update(pessoa);
            //_contexto.SaveChanges();

            //var pessoas = _contexto.Pessoa.FirstOrDefault();
            //_contexto.Entry(pessoas).Collection(x => x.Enderecos).Load();

            var pessoas = _contexto.Pessoa.Include(x => x.Enderecos).FirstOrDefault();

            stopwatch.Stop();
            ViewBag.Tempo = stopwatch.ElapsedMilliseconds;
            return View(pessoas);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }

}
