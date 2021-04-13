using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using RPG.Champions;
using RPG.Services;
using RPG.Services.Fight;
using System;

namespace RPG
{
    class Program
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
                .AddChampion(new Warrior("Ciamajda"))
                .AddChampion(new Archer("NoName"))
                .AddChampion(new Mage("Kapucyn"));
            _game.Tournament();
        }
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddTransient<Program>();
                    services.AddTransient<IMessageService, MessageService>();
                    services.AddTransient<Game>();
                    services.AddTransient<FightService>();
                    services.AddTransient<Champion>();

                });
        }

    }
}
