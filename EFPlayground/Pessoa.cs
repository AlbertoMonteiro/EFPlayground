using Newtonsoft.Json;

namespace CustomFunctionOnJsonField
{
    internal class Pessoa
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public string SobreNome { get; set; }
        internal string Info { get; private set; }

        public Endereco Endereco
        {
            get => JsonConvert.DeserializeObject<Endereco>(Info);
            set => Info = JsonConvert.SerializeObject(value);
        }
    }
}