using DoYou.Domain.ObjectValues.Base;
using prmToolkit.NotificationPattern;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace DoYou.Domain.ObjectValues
{

    public class Endereco : ObjectValue
    {
        public Endereco() { }
        public Endereco(string cEP, string uF, string municipio, string logradouro, string bairro, int numero, string complemento)
        {
            CEP = Regex.Replace(cEP, "[^0-9]+", "");
            UF = uF;
            Complemento = complemento;
            Numero = numero;
            Bairro = bairro;
            Logradouro = logradouro;
            Municipio = municipio;

            new AddNotifications<Endereco>(this)
                .IfNullOrInvalidLength(x => x.CEP, 8, 8);
        }

        public string CEP { get; set; }
        public string UF { get; set; }
        public string Complemento { get; set; }
        public int Numero { get; set; }
        public string Bairro { get; set; }
        public string Logradouro { get; set; }
        public string Municipio { get; set; }

        protected override IEnumerable<object> GetAtomicValues()
        {
            yield return CEP;
            yield return UF;
            yield return Numero;
            yield return Bairro;
            yield return Logradouro;
            yield return Municipio;

        }
    }
}
