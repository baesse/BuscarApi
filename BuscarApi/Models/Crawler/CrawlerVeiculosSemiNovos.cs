using BuscarApi.Models.Poco;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Web;

namespace BuscarApi.Models.Crawler
{
    public class CrawlerVeiculosSemiNovos: CrawlerVeiculos
    {


        public string _idsitebusca { get; set; }
        public string _tipoveiculo { get; set; }
        public string _0km { get; set; }
        public string _marca { get; set; }
        public string _modelo { get; set; }
        public string _cidade { get; set; }
        public string _precoinicial { get; set; }
        public string _precofinal { get; set; }
        public string _anoinicial { get; set; }
        public string _anofinal { get; set; }
        public string _particular { get; set; }
        public string _revenda { get; set; }
        public string _anode { get; set; }
        public string _anoate { get; set; }
        public string _tipoparticular { get; set; }

        public String Crawler(BuscarParametro parametros)
        {
            

           String parametrosbusca = ParseUrl(parametros);
           return SerializerHtml(parametrosbusca);
          // SerializerVeiculos( GetVeiculos(htmlveiculos));
            
        }
        public CrawlerVeiculosSemiNovos()
        {

            
        }

        public override string SerializerVeiculos(string veiculostojson)
        {
            return null;
            throw new NotImplementedException();
        }



        public override String ParseUrl(BuscarParametro parametros)
        {
            StringBuilder urlbusca = new StringBuilder();

            
            this._urlbase = "http://mobile.seminovosbh.com.br/resultado-busca-veiculo?";

            urlbusca.Append(_urlbase);

            
            if (parametros._tipoveiculo != null)
            {
                urlbusca.Append("tipo=");
                urlbusca.Append(parametros._tipoveiculo);
                urlbusca.Append("&");

            }
            if (parametros._0km.Equals("1"))
            {
                urlbusca.Append("novo=");
                urlbusca.Append(parametros._0km);
                urlbusca.Append("&");

            }

            
                urlbusca.Append("veiculozerokm=");
                urlbusca.Append(parametros.seminovo);
                urlbusca.Append("&");

            


            if (parametros._marca!=null)
            {
                urlbusca.Append("marca=");
                urlbusca.Append(parametros._marca);
                urlbusca.Append("&");

            }

           
            if (parametros._modelo != null)
            {
                urlbusca.Append("modelo");               
                urlbusca.Append(parametros._modelo);
                urlbusca.Append("&");

            }
           
            if (parametros._cidade != null)
            {


                urlbusca.Append("cidade=");
                urlbusca.Append(parametros._cidade);
                urlbusca.Append("&");

            }



            if (parametros._precoinicial != null)
            {

                urlbusca.Append("precode=");              
                urlbusca.Append(parametros._precoinicial);
                urlbusca.Append("&");

                if (parametros._precofinal != null)
                {

                    urlbusca.Append("precoate=");
                    urlbusca.Append(parametros._precofinal);
                    urlbusca.Append("&");


                }

            }

            //http://mobile.seminovosbh.com.br/resultado-busca-veiculo?tipo=1&novo=1&veiculoZeroKm=1&marca=9&modelo=68&cidade=2700&precoDe=2000&precoAte=16000&anoDe=2017&anoAte=2017&tipoParticular=2&tipoCadastro=2
        


                urlbusca.Append("anode=");
                urlbusca.Append(parametros._anoinicial);
                urlbusca.Append("&");

            


          
                urlbusca.Append("anoate=");
              
                urlbusca.Append(parametros._anofinal);
                urlbusca.Append("&");


            

            if (parametros._particular != null)
            {
                urlbusca.Append("tipoparticular=");

                urlbusca.Append(parametros._particular);
                urlbusca.Append("&");


            }

            if (parametros._tipoparticular != null)
            {
                urlbusca.Append("tipocadastro=");
               


            }






           return urlbusca.ToString();


        }

        public override string SerializerHtml(string url)
        {

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = WebRequestMethods.Http.Get;
            request.Accept = "application/json";
            WebResponse response = request.GetResponse();
            Stream dataStream = response.GetResponseStream();
            StreamReader reader = new StreamReader(dataStream);
            String responseFromServer = reader.ReadToEnd();         
            HtmlDocument Pagina = new HtmlDocument();
            Pagina.LoadHtml(responseFromServer);


            var teste1 = Pagina.GetElementbyId("areaResultado");



            String urlnova = teste1.InnerHtml.ToString();

            Pagina.LoadHtml(urlnova);



            //var teste2 = teste1.SelectSingleNode("//section/ul/li");
            List<Poco.Veiculo> Veiculos = new List<Poco.Veiculo>();


            Poco.Veiculo novoveiculo = new Poco.Veiculo();


            // Pagina.LoadHtml(teste2.InnerHtml);









            int i = 0;
            int k = 0;

            var carroname = teste1.SelectNodes("//section/ul/li/a/h2");
            List<String> Nomes = new List<string>();
            foreach (HtmlNode nonome in carroname)
            {

                Nomes.Add(nonome.InnerHtml);
              


            }



            var carroimg = teste1.SelectNodes("//section/ul/li/a/span");
            List<String> Imgurl = new List<string>();
            foreach (HtmlNode noimg in carroimg)
            {
                Imgurl.Add(StringFormat(noimg.InnerHtml));
                

            }

            var carrosnode = teste1.SelectNodes("//section/ul/li/a/p");
                foreach (HtmlNode teste in carrosnode)
                {
                    String descricao = "";
                    string negociacao = "";
                    string valor = "";
                    string nome = "";
                    string imgurl = "";
                                    
                 
                    



                    switch (i)
                    {
                        case 0:
                            descricao = StringFormat(teste.InnerHtml);
                            i += 1;
                            break;
                        case 1:
                            negociacao = StringFormat(teste.InnerHtml);
                            i += 1;
                            break;
                        case 2:
                            valor = StringFormat(teste.InnerHtml);
                        Veiculo carronovo = new Veiculo(descricao, negociacao, valor, nome, imgurl);
                        Veiculos.Add(carronovo);

                        i = 0;


                            break;



                    }
            




            }

            int j = 0;
            foreach (Veiculo carro in Veiculos)
            {

                carro._url = Imgurl[j];
                carro._nomeveiculo = Nomes[j];
                j++;

            }




            return JsonConvert.SerializeObject(Veiculos);
        }
         


        

        public override string GetVeiculos(string HtmlDone)
        {
            throw new NotImplementedException();
        }


        public String StringFormat(String valoraformatar)
        {
            
            valoraformatar = valoraformatar.Replace('"',' ');
            valoraformatar = valoraformatar.Replace("  ","");
            valoraformatar = valoraformatar.Replace(">","");
            valoraformatar = valoraformatar.Replace("\"\\", "\"");
            valoraformatar = valoraformatar.Replace("\\\"", "\"");
            valoraformatar = valoraformatar.Replace('\n', ' ');
            valoraformatar = valoraformatar.Replace("\\", "");
            valoraformatar = valoraformatar.Replace("\\\\", "");
            valoraformatar = valoraformatar.Replace("<br>", "");
            valoraformatar = valoraformatar.Replace("  ", "");
            valoraformatar = valoraformatar.Replace("<img src=", "");
            valoraformatar = valoraformatar.Replace("alt=", "");
            valoraformatar = valoraformatar.Replace("onerror=", "");
            valoraformatar = valoraformatar.Replace("imgError(this)", "");
            valoraformatar = valoraformatar.Replace("width=", "");
            valoraformatar = valoraformatar.Replace("height=", "");

           

            return valoraformatar;

        }


    

       
    }
}

//http://mobile.seminovosbh.com.br/resultado-busca-veiculo?tipo=1&novo=1&veiculoZeroKm=1&marca=9&modelo=68&cidade=2700&precoDe=&precoAte=&anoDe=&anoAte=&tipoCadastro=