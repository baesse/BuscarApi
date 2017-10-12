using BuscarApi.Models.Poco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;

namespace BuscarApi.Models.Crawler
{
    public class CrawlerVeiculosSemiNovos: CrawlerVeiculos
    {


        public string _idsitebusca { get; set; }
        public string _tipoveiculo { get; set; }
        public Boolean _0km { get; set; }
        public string _marca { get; set; }
        public string _modelo { get; set; }
        public string _cidade { get; set; }
        public string _precoinicial { get; set; }
        public string _precofinal { get; set; }
        public string _anoinicial { get; set; }
        public string _anofinal { get; set; }
        public string _particular { get; set; }
        public string _revenda { get; set; }

        public CrawlerVeiculosSemiNovos(BuscarParametro parametros)
        {
            

           String parametrosbusca = ParseUrl(parametros);
           String htmlveiculos = SerializerHtml(parametrosbusca);
            SerializerVeiculos( GetVeiculos(htmlveiculos));
            
        }

        public override string SerializerVeiculos(string veiculostojson)
        {
            return null;
            throw new NotImplementedException();
        }



        public override String ParseUrl(BuscarParametro parametros)
        {
            StringBuilder urlbusca = new StringBuilder(); 
            this._urlbase = "https://www.seminovosbh.com.br/resultadobusca/index/veiculo/";

            urlbusca.Append(_urlbase);

            //https://www.seminovosbh.com.br/resultadobusca/index/veiculo/carro/estado-conservacao/0km/marca/Citroen/modelo/77/valor1/2000/valor2/16000/cidade/2700/usuario/revenda

            if (parametros._tipoveiculo != null)
            {
                
                urlbusca.Append(parametros._tipoveiculo);
                urlbusca.Append("/");

            }
            if (parametros._0km.Equals("0km"))
            {
                urlbusca.Append("estado - conservacao");
                urlbusca.Append("/");
                urlbusca.Append(parametros._0km);
                urlbusca.Append("/");

            }
            if (parametros._marca!=null)
            {
                urlbusca.Append("marca");
                urlbusca.Append("/");
                urlbusca.Append(parametros._marca);
                urlbusca.Append("/");

            }

           
            if (parametros._modelo != null)
            {
                urlbusca.Append("modelo");
                urlbusca.Append("/");
                urlbusca.Append(parametros._modelo);
                urlbusca.Append("/");

            }



            if (parametros._precoinicial != null)
            {

                urlbusca.Append("valor1");
                urlbusca.Append("/");
                urlbusca.Append(parametros._precoinicial);
                urlbusca.Append("/");

                if (parametros._precofinal != null)
                {

                    urlbusca.Append("valor2");
                    urlbusca.Append("/");
                    urlbusca.Append(parametros._precofinal);
                    urlbusca.Append("/");


                }

            }
            if (parametros._cidade != null) {


                urlbusca.Append("cidade");
                urlbusca.Append("/");
                urlbusca.Append(parametros._cidade);
                urlbusca.Append("/");

            }


            if (parametros._particular != null)
            {
                urlbusca.Append("usuario");
                urlbusca.Append("/");
                urlbusca.Append(parametros._particular);
               

            }

            




            return urlbusca.ToString();


        }

        public override string SerializerHtml(string Jsonfiltro)
        {

            return null;



        }

        public override string GetVeiculos(string HtmlDone)
        {
            throw new NotImplementedException();
        }


    

       
    }
}