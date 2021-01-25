using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem_3._0
{
    class Player
    {
        // Variables
        string name;

        int health;
        int shield;
        int lives;


        public Player()
        {
            name = "Hero";

            health = 100;
            shield = 100;
            lives = 3;
        }
        // Methods
        public void TakeDamage(int damage)
        {
            Console.WriteLine("\n" + name + " has taken " + damage + " points of Damage!");

            int healthDamage = damage - shield;

            shield -= damage;
            if (shield <= 0)
            {
                shield = 0;
                health -= healthDamage;
            }

            if (health <= 0)
            {
                health = 0;
                lives--;
                health = 100;
                shield = 100;
            }

            if (lives <= 0)
            {
                lives = 0;
                Console.WriteLine("YOU HAVE DIED");
            }
        }

        public void Heal(int healingPoints)
        {
            Console.WriteLine("\n" + name + "has healed " + healingPoints + " point of Health");

            if (health < 100) health += healingPoints;
            if (health > 100) health = 100;
        }

        public void RegenerateShield()
        {

        }

        public void ShowHUD()
        {
            Console.WriteLine();
            Console.WriteLine("|Shield: "+ shield);
            Console.WriteLine("|Health: "+ health);
            Console.WriteLine("|Lives: "+ lives);
            Console.WriteLine();
        }
    }
}
