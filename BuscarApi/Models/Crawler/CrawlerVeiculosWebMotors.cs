using BuscarApi.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuscarApi.Models.Crawler
{
    public class CrawlerVeiculosWebMotors: CrawlerVeiculos
    {

        public override String ParseUrl(BuscarParametro parametros)
        {

            return null;


        }

        public override string SerializerHtml(string Jsonfiltro)
        {

            return null;



        }
    }
}