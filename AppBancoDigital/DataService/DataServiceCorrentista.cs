using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDigital.DataService
{
    public class DataServiceCorrentista : DataService
    {

        public static async Task<Correntista> Autenticar(Correntista c, string uri)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);
            string json = await DataService.PostDataToService(json_a_enviar, uri);

            if (json == "false")
                return null;

            Correntista correntista = JsonConvert.DeserializeObject<Correntista>(json);

            return correntista;
        }

        public static async Task<Correntista> Cadastrar(Correntista c, string uri)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);
            string json = await DataService.PostDataToService(json_a_enviar, uri);

            if (json == "false")
              return null;

            Correntista correntista = JsonConvert.DeserializeObject<Correntista>(json);

            return correntista;
        }
    }
}
