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
            const string yesOrNo = "\n(Y)es or (N)o"; // To save writing it out every time
            string playerChoice;
            int enterMode;
            string restart;

            int userInput; // Used to enter custom values for damage and healing

            Random random = new Random();

            Player player = new Player("Hero");

            Enemy enemy = new Enemy("Big Bad Enemy");

            Console.WriteLine("Which mode would you like to enter?\n1: Game Mode\n2: Preset Value Debug\n3.Custom Value Debug");
            enterMode = Convert.ToInt32(Console.ReadLine());
            switch(enterMode)
            {
                case 1:
                    do {
                        do
                        {
                            int playerDamage = random.Next(15, 100); // Damage player does to enemy range 15 - 100
                            int enemyDamage = random.Next(15, 100); // Damage enemy does to player range 15 - 100
                            int enemyHealChance = random.Next(1, 3); // Random number used to decide if enemy heals unless their health is too low

                            enemy.TakeDamage(playerDamage);
                            enemy.ShowHUD();

                            Console.WriteLine(enemy.name + " attacks " + player.name);

                            player.TakeDamage(enemyDamage);
                            player.ShowHUD();

                            Console.WriteLine("Would you like to Heal?" + yesOrNo);
                            playerChoice = Console.ReadLine();
                            if (playerChoice == "y" || playerChoice == "Y" && player.alive)
                            {
                                Console.WriteLine(player.name + " uses a health pack");
                                player.Heal(25);

                                if (player.health == 100 && player.shield < 100)
                                {
                                    player.RegenerateShield(25);
                                }
                                player.ShowHUD();
                            }

                            if (enemyHealChance == 2 || enemy.health < 15 && enemy.alive)
                            {
                                Console.WriteLine(enemy.name + " uses a health pack");
                                enemy.Heal(25);

                                if (enemy.health == 100 && enemy.shield < 100)
                                {
                                    enemy.RegenerateShield(25);
                                }
                                enemy.ShowHUD();
                            }
                            Console.WriteLine("");
                        }
                        while (player.alive || enemy.alive) ;
                        Console.WriteLine("Would you like to restart?" + yesOrNo);

                        restart = Console.ReadLine();
                    }
                    while (restart == "y" || restart == "Y");

                    break;

                case 2:

                    break;

                case 3:
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

                    Console.WriteLine("Would you like to restart?" + yesOrNo);
                    restart = Console.ReadLine();
                }
                while (restart == "y" || restart == "Y");
                    break;

                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Sorry Input Unexpected. Please Restart and try again");
                    Console.ResetColor();
                    break;
            }

        }
    }
}
