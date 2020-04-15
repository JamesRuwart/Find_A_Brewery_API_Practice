using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using API_Practice_Brewery.Models;
using Microsoft.AspNetCore.Mvc;

namespace API_Practice_Brewery.Controllers
{
    public class BreweryController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        //public async Task<IActionResult> DisplayBreweriesByState()
        //{
        //    var client = new HttpClient();
        //    client.BaseAddress = new Uri("https://brianiswu-open-brewery-db-v1.p.rapidapi.com");
        //    client.DefaultRequestHeaders.Add("x-rapidapi-host", "brianiswu-open-brewery-db-v1.p.rapidapi.com");
        //    client.DefaultRequestHeaders.Add("x-rapidapi-key", "0495956901msh0faebcb59561518p1e45ebjsnbd272e41ebb3");

        //    var response = await client.GetAsync("/breweries?by_state=Michigan");
        //    var breweries = await response.Content.ReadAsAsync<List<Brewery>>();
        //    return View(breweries);
        //}

        public async Task<IActionResult> DisplayBreweriesByState(string state)
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://brianiswu-open-brewery-db-v1.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "brianiswu-open-brewery-db-v1.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", "0495956901msh0faebcb59561518p1e45ebjsnbd272e41ebb3");

            var response = await client.GetAsync($"/breweries?by_state={state}");
            var breweries = await response.Content.ReadAsAsync<List<Brewery>>();
            return View(breweries);
        }

        public async Task<IActionResult> RandomBrewery()
        {
            var client = new HttpClient();
            client.BaseAddress = new Uri("https://brianiswu-open-brewery-db-v1.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-host", "brianiswu-open-brewery-db-v1.p.rapidapi.com");
            client.DefaultRequestHeaders.Add("x-rapidapi-key", "0495956901msh0faebcb59561518p1e45ebjsnbd272e41ebb3");

            //generate a random 4 digit id number
            Random num = new Random();
            int id = num.Next(0, 6000);
            

            //plug that id number into api call
            var response = await client.GetAsync($"/breweries/{id}");
            var brewery = await response.Content.ReadAsAsync<Brewery>();
            
            return View(brewery);
        }
    }
}