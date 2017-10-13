using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BuscarApi.Models.Poco
{
    public class Veiculo
    {
        public String _linkimg { get; set; }
        public String _url { get; set; }
        public String _nomeveiculo { get; set; }
        public String _descricao { get; set; }
        public String _atributtos { get; set; }
        public String _negociacao { get; set; }
        public String _valor { get; set; }

        public Veiculo(string descricao, string negociacao, string _valor,string nome,string _urlimg)
        {
            this._descricao = descricao;
            this._negociacao = negociacao;
            this._valor = _valor;
            this._nomeveiculo = nome;
            this._url = _urlimg;

        }
        public Veiculo()
        {
           

        }

    }
}