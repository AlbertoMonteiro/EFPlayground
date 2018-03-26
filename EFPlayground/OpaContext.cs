using System.Data.Entity;
using EntityFramework.Functions;

namespace CustomFunctionOnJsonField
{
    class OpaContext : DbContext
    {
        public OpaContext()
            => Database.SetInitializer(new DropCreateDatabaseIfModelChanges<OpaContext>());

        public DbSet<Pessoa> Pessoas { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.AddFunctions<OpaContext>();
            modelBuilder.AddFunctions(typeof(BuiltInFunctions));

            var pessoaCfg = modelBuilder.Entity<Pessoa>();
            pessoaCfg.Property(pessoa => pessoa.Nome).HasMaxLength(50).IsRequired();
            pessoaCfg.Property(pessoa => pessoa.SobreNome).HasMaxLength(50).IsRequired();
            pessoaCfg.Property(pessoa => pessoa.Info).HasMaxLength(int.MaxValue).IsRequired();
            pessoaCfg.Ignore(pessoa => pessoa.Endereco);
        }
    }
}