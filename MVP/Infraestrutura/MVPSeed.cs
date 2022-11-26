using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MVP.Entidades;

namespace MVP.Infraestrutura
{
    public class MVPSeed
    {
          public static async Task SeedAsync(MVPDbContext context, ILoggerFactory loggerFactory)
        {
               var existingEnt = context.SituacaoUsuario.Local.SingleOrDefault();
                if (existingEnt != null){
                context.Entry(existingEnt).State = EntityState.Detached;
                }else{
                    context.Attach(existingEnt);
                }
                
            try
            {
                //o que acontece aqui é:
                //esse método SeedAsync serve para inserir os dados automaticamente ao iniciar a app, a partir da classe Program.cs
                //No caso, eu passo o contexto nos parâmetros pra conseguir acessar o BD, e o logger pra gerar um log em caso de erro.
                //abaixo, eu checo se há algum valor dentro do DbSet SituacaoUsuario, se não houver, eu vou ler o arquivo situacaousuario.json
                //e deserializar, e adicionar o que está no arquivo ao banco de dados =)
                
                if(!context.SituacaoUsuario.Any())
                {
                    //tem que ser esse caminho porque o pro]eto inicial é API, que é onde vai ser lido o nosso Startup.cs/Program.cs
                    var seedData = File.ReadAllText("../MVP/Seed/situacaousuario.json");
                    var situacaoUsuarios = JsonSerializer.Deserialize<List<SituacaoUsuario>>(seedData);
                    foreach(var item in situacaoUsuarios)
                    {
                        context.SituacaoUsuario.Add(item);
                    }
                    await context.SaveChangesAsync();
                }
            }catch(Exception ex){
                loggerFactory.CreateLogger<SituacaoUsuario>().LogError(ex.Message, "Deu erro no Seed");
            }
        }


    }
}