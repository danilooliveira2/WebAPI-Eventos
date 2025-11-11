using Microsoft.AspNetCore.Mvc;
using System;
using WebAPI_Aprendizado.Models;

namespace WebAPI_Aprendizado.Controllers
{
    [ApiController]
    //[Route("[controller]")] // isso usa o nome da classe ("WeatherForecastController") para as rotas, ficando ForecastController apenas.
    [Route("api/previsao")]

    public class PrevisaoTempoController : ControllerBase
    {

        //OBJETIOS: ESTA CLASSE VAI RETORNAR 'PREVISÕES DO TEMPO'
        // VAMOS CRIAR DOIS ENDPOINTS:
        // 1 - RETORNAR TODAS AS PREVISÕES
        // 2 - RETORNAR A PREVISÃO DO DIA DE HOJE
        // VAMOS USAR A CLASSE PrevisaoTempo.cs PARA ISSO
        // VAMOS GERAR DADOS ALEATÓRIOS PARA AS PREVISÕES - SEM USO DE BANCO DE DADOS



        private static readonly string[] Sumarios = new[]
        {
            "Congelante", "Revigorante", "Frio", "Fresco", "Amável", "Quente", "Agradável", "Caloroso", "Abafado", "Escaldante"
        };




        [HttpGet("5dias")]
        public IEnumerable<PrevisaoTempo> Get()
        {
            return Enumerable.Range(1, 5).Select(index => new PrevisaoTempo
            {
                Data = DateTime.Now.AddDays(index),
                TemperaturaCelsius = Random.Shared.Next(-20, 55),
                SumarioExplicativo = Sumarios[Random.Shared.Next(Sumarios.Length)]
            })
            .ToArray();
        }




        [HttpGet("hoje")]
        public PrevisaoTempo GetHoje()
        {
            return new PrevisaoTempo
            {
                Data = DateTime.Now,
                TemperaturaCelsius = Random.Shared.Next(-20, 55),
                SumarioExplicativo = Sumarios[Random.Shared.Next(Sumarios.Length)]
            };
        }



        [HttpPost("hoje")]
        public PrevisaoTempo PostHoje()
        {
            return new PrevisaoTempo
            {
                Data = DateTime.Now,
                TemperaturaCelsius = Random.Shared.Next(-20, 55),
                SumarioExplicativo = Sumarios[Random.Shared.Next(Sumarios.Length)]
            };
        }

        //* * * * * * * CAPTURANDO PARAMETROS NA REQUISIÇÃO * * * * * * * * *

        /*
                MOSTRAR DADOS RECEBENDO VALOR ESPECÍFICO NA CHAMADA

                1. Usando query string ([FromQuery]):
                   - Se o parâmetro não estiver na rota, você usa [FromQuery].
                   - Exemplo:
                       [HttpGet("por-data")]
                       public PrevisaoTempo GetPorData([FromQuery] DateTime data)
                   - Chamada:
                       GET https://localhost:7103/PrevisaoTempo/por-data?data=2025-10-27
                   - Indicado para filtros, buscas ou parâmetros opcionais.



                2. Usando rota (path parameter):
                   - Parâmetros essenciais ou que identificam um recurso específico devem ir na rota.
                   - Exemplo:
                       [HttpGet("por-data/{data}")]
                       public PrevisaoTempo GetPorData(DateTime data)
                   - Chamada:
                       GET https://localhost:7103/PrevisaoTempo/por-data/2025-10-27
                 
                - Vantagens:
                       * URL semântica e mais amigável
                       * Segue boas práticas REST

              
    */



        [HttpGet("por-data/{data}")]  //Colocar os atributos
        public PrevisaoTempo GetPorData(
          [FromQuery]  DateTime data

            )
        {

            return new PrevisaoTempo
            {
                Data = data,
                TemperaturaCelsius = Random.Shared.Next(-20, 55),
                SumarioExplicativo = Sumarios[Random.Shared.Next(Sumarios.Length)]
            };
        }

        //https://localhost:7103/api/previsao/por-data?data=2025-10-27


        //private readonly ILogger<WeatherForecastController> _logger;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}


        //[HttpGet(Name = "GetWeatherForecast")]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = Random.Shared.Next(-20, 55),
        //        Summary = Summaries[Random.Shared.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}


    }
}