using System;
using System.Linq;

namespace CustomFunctionOnJsonField
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var ctx = new OpaContext())
            {
                ctx.Database.CreateIfNotExists();

                if (!ctx.Pessoas.Any()) Seed(ctx);

                ctx.Database.Log = Console.WriteLine;

                foreach (var pessoa in ctx.Pessoas.Where(p => p.Info.JsonValue("$.Cidade") == "Fortaleza"))
                {
                    Console.WriteLine(pessoa.Nome);
                    Console.WriteLine(pessoa.Endereco);
                }
            }
        }

        private static void Seed(OpaContext ctx)
        {
            ctx.Pessoas.Add(new Pessoa
            {
                Nome = "Alberto",
                SobreNome = "Monteiro",
                Endereco = new Endereco
                {
                    Bairo = "Aqui",
                    Cidade = "Fortaleza",
                    Estado = "CE",
                    Logradouro = "Rua A",
                    Numero = "1"
                }
            });

            ctx.Pessoas.Add(new Pessoa
            {
                Nome = "Fulano",
                SobreNome = "Beltrano",
                Endereco = new Endereco
                {
                    Bairo = "Acula",
                    Cidade = "São Paulo",
                    Estado = "SP",
                    Logradouro = "Rua B",
                    Numero = "2"
                }
            });

            ctx.SaveChanges();
        }
    }
}
