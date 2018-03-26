namespace CustomFunctionOnJsonField
{
    class Endereco
    {
        public override string ToString()
            => $"{nameof(Logradouro)}: {Logradouro}, {nameof(Bairo)}: {Bairo}, {nameof(Cidade)}: {Cidade}, {nameof(Estado)}: {Estado}, {nameof(Numero)}: {Numero}";

        public string Logradouro { get; set; }
        public string Bairo { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string Numero { get; set; }
    }
}