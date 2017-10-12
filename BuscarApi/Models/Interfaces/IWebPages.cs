using BuscarApi.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BuscarApi.Models.Interfaces
{
    interface IWebPages
    {
        String ParseUrl(BuscarParametro JsonFiltro);
        String CrawlerVeiculos(String JsonFiltro);
        String SerializerHtml(String JsonFiltro);
        String GetVeiculos(String HtmlDone);
        String BuildCache(String JsonFiltro);
        String SerializerVeiculos(String JsonFiltro);



    }
}
