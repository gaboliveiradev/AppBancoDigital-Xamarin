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
        public static async Task<Correntista> Cadastrar(Correntista c)
        {
            var json_a_enviar = JsonConvert.SerializeObject(c);
            string json = await DataService.PostDataToService(json_a_enviar, "/correntista/cadastrar");

            //if (json == "false")
              //return null;

            Correntista correntista = JsonConvert.DeserializeObject<Correntista>(json);

            return correntista;
        }
    }
}
