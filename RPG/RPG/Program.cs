using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPG.Champions;
using RPG.Interfaces;
using RPG.Services;
using RPG.Services.Fight;
using System;
using System.IO;
using System.Threading.Tasks;

namespace RPG
{
    public class Program
    {
        private readonly Game _game;
        public Program(Game game)
        {
            _game = game;
        }
        static void Main(string[] args)
        {
            var host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }
        public void Run()
        {
            _game.AddChampion(new Archer("Bonobo"))
                   .AddChampion(new Mage("Dudu"))
                   .AddChampion(new Archer("Koko"))
                   .AddChampion(new Warrior("Himen"))
                   .AddChampion(new Mage("Pomyleniec"));

            _game.Tournament();
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped<Program>();
                    services.AddSingleton<IMessageFactory, MessageFactory>();
                    services.AddScoped<IMessageService, MessageService>();
                    services.AddScoped<IMessageService, PrintToFileService>(); 
                    services.AddScoped<ILadderService, LadderService>();
                    services.AddScoped<Game>();
                    services.AddScoped(x => new DamageService(x.GetRequiredService<IMessageFactory>()));
                    services.AddScoped(x => new FightService(x.GetRequiredService<IMessageFactory>(),
                                       x.GetRequiredService<ILadderService>(),
                                       x.GetRequiredService<DamageService>()));
                });
        }


    }
}
