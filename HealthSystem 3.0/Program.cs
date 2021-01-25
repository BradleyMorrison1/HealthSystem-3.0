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
            string enterCombat;
            string enterMode;
            string restart;

            int userInput; // Used to enter custom values for damage and healing

            Random random = new Random();

            Player player = new Player("Hero");

            Enemy enemy = new Enemy("Big Bad Enemy");

            Console.WriteLine("Would you like to enter Game mode?" + yesOrNo);
            enterMode = Console.ReadLine();
            if (enterMode == "y" || enterMode == "Y")
            {
                do
                {

                    player.ShowHUD();

                    Console.WriteLine(player.name + " Has Encountered, " + enemy.name);

                    Console.WriteLine("Does " + player.name + " want to enter Combat?" + yesOrNo);
                    enterCombat = Console.ReadLine();
                    if(enterCombat == "y" || enterCombat == "Y")
                    {
                        do
                        {
                            int playerDamage = random.Next(15, 100); // Damage player does to enemy range 15 - 100
                            int enemyDamage = random.Next(15, 100); // Damage enemy does to player range 15 - 100

                            enemy.TakeDamage(playerDamage);
                            enemy.ShowHUD();

                            Console.WriteLine(enemy.name + " will now attack" + player.name);

                            player.TakeDamage(enemyDamage);
                            player.ShowHUD();


                        }
                        while (!player.alive || !enemy.alive);
                    }




                    Console.WriteLine("Would you like to restart?" + yesOrNo);
                    restart = Console.ReadLine();
                }
                while (restart == "y" || restart == "Y");
            }

            Console.WriteLine("Would you like to enter Custom Value Debug mode?" + yesOrNo);
            enterMode = Console.ReadLine();
            if (enterMode == "y" || enterMode == "Y")
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

                    Console.WriteLine("Would you like to restart?" + yesOrNo);
                    restart = Console.ReadLine();
                }
                while (restart == "y" || restart == "Y");
            }
        }
    }
}
