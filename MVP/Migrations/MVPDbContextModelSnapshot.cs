// <auto-generated />
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace MVP.Migrations
{
    [DbContext(typeof(MVPDbContext))]
    partial class MVPDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "5.0.17");

            modelBuilder.Entity("MVP.Entidades.SituacaoUsuario", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("CPF")
                        .HasColumnType("TEXT");

                    b.Property<bool>("TemProcesso")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.ToTable("SituacaoUsuario");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            CPF = "123456",
                            TemProcesso = true
                        },
                        new
                        {
                            Id = 2,
                            CPF = "654321",
                            TemProcesso = false
                        },
                        new
                        {
                            Id = 3,
                            CPF = "111",
                            TemProcesso = true
                        });
                });
#pragma warning restore 612, 618
        }
    }
}
