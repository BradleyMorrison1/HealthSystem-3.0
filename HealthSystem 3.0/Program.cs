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
            // Game Variables
            string enterDebug;
            string restart;
            int userInput; // Used to enter custom values for damage and healing

            Player player = new Player();

            Enemy enemy = new Enemy();

            Console.WriteLine("Would you like to enter Debug mode?\n(Y)es or (N)o");
            enterDebug = Console.ReadLine();
            if (enterDebug == "y" || enterDebug == "Y")
            {
                do
                {
                    player.ShowHUD();

                    Console.WriteLine("How much Damage would you like to take?");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    player.TakeDamage(userInput);

                    player.ShowHUD();

                    Console.WriteLine("How much would you like to Heal?");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    player.Heal(userInput);

                    player.ShowHUD();

                    Console.WriteLine("How much would you like to Regenerate Shield?");
                    userInput = Convert.ToInt32(Console.ReadLine());
                    player.RegenerateShield(userInput);

                    player.ShowHUD();

                    Console.WriteLine("Would you like to restart?\n(Y)es or (N)o");
                    restart = Console.ReadLine();
                }
                while (restart == "y" || restart == "Y");
            }


        }
    }
}
