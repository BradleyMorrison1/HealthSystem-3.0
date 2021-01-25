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

            Console.WriteLine("Which mode would you like to enter?\n1: Game Mode\n2: Preset Value Debug\n3: Custom Value Debug");
            enterMode = Convert.ToInt32(Console.ReadLine());
            switch(enterMode)
            {
                case 1:
                    do {
                        do
                        {
                            Console.WriteLine(player.name + " has encountered " + enemy.name + " prepare for combat!");
                            int playerDamage = random.Next(15, 100); // Damage player does to enemy range 15 - 100
                            int enemyDamage = random.Next(15, 100); // Damage enemy does to player range 15 - 100
                            int enemyHealChance = random.Next(1, 3); // Random number used to decide if enemy heals unless their health is too low

                            Console.WriteLine(player.name + " Attacks " + enemy.name);
                            enemy.TakeDamage(playerDamage);
                            enemy.ShowHUD();

                            Console.WriteLine(enemy.name + " attacks " + player.name);
                            player.TakeDamage(enemyDamage);
                            player.ShowHUD();

                            Console.WriteLine("Would you like to Heal?" + yesOrNo);
                            playerChoice = Console.ReadLine();
                            if (playerChoice == "y" || playerChoice == "Y" && player.alive)
                            {
                                player.Heal(25);

                                if (player.health == 100 && player.shield < 100)
                                {
                                    player.RegenerateShield(25);
                                }
                                player.ShowHUD();
                                Console.WriteLine("-----Press any button to continue-----");
                                Console.ReadKey(true);
                            }

                            if (enemyHealChance == 2 || enemy.health < 15 && enemy.alive)
                            {
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
                        
                        if(!enemy.alive)
                        {
                            Console.WriteLine("\n" + player.name + " has won the fight!");
                        }

                        Console.WriteLine("Would you like to restart?" + yesOrNo);

                        restart = Console.ReadLine();
                    }
                    while (restart == "y" || restart == "Y");

                    break;

                case 2:
                    do
                    {
                        // Take a large amount of damage
                        player.ShowHUD();
                        player.TakeDamage(250);

                        // Take a smaller amount of damage
                        player.ShowHUD();
                        player.TakeDamage(155);

                        // Heal and regen shield
                        player.ShowHUD();
                        player.Heal(55);
                        player.RegenerateShield(100);

                        // Error Checking
                        player.ShowHUD();
                        player.TakeDamage(-46);
                        player.Heal(-65);
                        player.RegenerateShield(-99);
                        // Kill Player
                        player.ShowHUD();
                        player.TakeDamage(200);
                        player.TakeDamage(200);
                        player.TakeDamage(200);

                        Console.WriteLine("Would you like to restart?" + yesOrNo);
                        restart = Console.ReadLine();
                    }
                    while (restart == "y" || restart == "Y");
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
