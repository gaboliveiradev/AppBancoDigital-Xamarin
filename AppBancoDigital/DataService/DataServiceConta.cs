using AppBancoDigital.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace AppBancoDigital.DataService
{
    public class DataServiceConta : DataService
    {

        public static async Task<Conta> GetDataOfConta(Conta c, string uri)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);
            string json = await DataService.PostDataToService(json_a_enviar, uri);

            if (json == "false")
                return null;

            Conta conta = JsonConvert.DeserializeObject<Conta>(json);

            return conta;
        }
    }
}
