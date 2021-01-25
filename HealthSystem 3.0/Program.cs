// Bradley Morrison
// 2021-01-21
// NSCC - Game Development
// Health System 3.0
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem_3._0
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player = new Player();

            player.ShowHUD();

            player.TakeDamage(166);

            player.ShowHUD();

            player.Heal(266);

            player.ShowHUD();

            Console.ReadKey(true);
        }
    }
}
