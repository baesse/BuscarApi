using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BuscarApi.Models.Interfaces;
using BuscarApi.Models.Poco;

namespace BuscarApi.Models.Crawler
{
    public class CrawlerVeiculos : IWebPages

    {
        public String _urlbase { get; set; }
        public string BuildCache(string JsonFiltro)
        {
            throw new NotImplementedException();
        }

        public virtual string GetVeiculos(string HtmlDone)
        {
            throw new NotImplementedException();
        }

        public virtual String ParseUrl(BuscarParametro parametros)
        {
            throw new NotImplementedException();
        }

        public virtual string SerializerHtml(string JsonFiltro)
        {
            throw new NotImplementedException();
        }

        public virtual string SerializerVeiculos(string JsonFiltro)
        {
            throw new NotImplementedException();
        }

        string IWebPages.CrawlerVeiculos(string JsonFiltro)
        {
            throw new NotImplementedException();
        }
    }
}