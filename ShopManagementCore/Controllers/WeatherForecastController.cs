using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using DLL.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace ShopManagementCore.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly ICategoryRepository _categoryRepository;

        public WeatherForecastController(ILogger<WeatherForecastController> logger,ICategoryRepository categoryRepository)
        {
            _logger = logger;
            _categoryRepository = categoryRepository;
        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        [HttpGet]
        [Route("{category}")]
        public ActionResult GetCategory()
        {
           // var categoryList = _categoryRepository.ExecuteReader("Select * from Category", System.Data.CommandType.Text, null);
            string jSon = "{ ";
            //foreach (DataRow item in categoryList.Rows)
            //{
            //    jSon += "{";
            //    foreach (DataColumn dc in categoryList.Columns)
            //    {
            //        jSon += item[dc].ToString()+",";
            //    }
            //    jSon += item[0].ToString();
            //    jSon += "}, ";

            //}
            //jSon += "}";
            return Ok(jSon);
        }
    }
}
