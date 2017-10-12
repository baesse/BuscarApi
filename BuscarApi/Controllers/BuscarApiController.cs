using BuscarApi.Models.Crawler;
using BuscarApi.Models.Poco;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BuscarApi.Controllers
{
    public class BuscarApiController : ApiController
    {

        [HttpPost]
        public String teste([FromBody]BuscarParametro parametrobusca)
        {

            switch (parametrobusca._idsitebusca) {

                case "1":

                    CrawlerVeiculosSemiNovos Seminovosveiculos = new CrawlerVeiculosSemiNovos(parametrobusca);

                    break;





                case "2":

                    break;




                case "3":

                    break;




                case "4":

                    break;




                 case "5":

                    break;





            }

            


            

            return null;

        }
    }
}
