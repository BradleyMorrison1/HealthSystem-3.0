using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem_3._0
{
    class GameCharacter
    {

        // Variables
        public string name; // Characters name
        public ConsoleColor hudColor; // Color HUD prints in

        public int health;
        public int shield;
        public int maxHealth;
        public int maxShield;
        public int lives;
        public bool alive;


        // Methods
        public void TakeDamage(int damage)
        {
            if (damage < 0)
            {
                damage = 0;
                ErrorMessage("damageNegative");
            }

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
            }

            if(shield <= 0 && health <= 0)
            {
                Console.WriteLine("\n" + name + " has lost a life");
                lives--;
                health = 100;
                shield = 100;
            }

            if (lives <= 0)
            {
                lives = 0;
                alive = false;
                Console.WriteLine(name + " HAS DIED");
            }
        }

        public void Heal(int healingPoints)
        {
            if (healingPoints > 100)
            {
                healingPoints = 100;
                ErrorMessage("healExceed");
            }

            if (healingPoints < 0)
            {
                healingPoints = 0;
                ErrorMessage("healNegative");
            }

            Console.WriteLine("\n" + name + " has healed " + healingPoints + " points to Health");

            if (health < 100) health += healingPoints;
            if (health > 100) health = 100;
        }

        public void RegenerateShield(int regenPoints)
        {
            if (regenPoints > 100)
            {
                regenPoints = 100;
                ErrorMessage("shieldHealExceed");
            }

            if (regenPoints < 0)
            {
                regenPoints = 0;
                ErrorMessage("shieldHealNegative");
            }

            Console.WriteLine("\n" + name + " has regenerated " + regenPoints + " points to their Shield");

            if (shield < 100) shield += regenPoints;
            if (shield > 100) shield = 100;
        }

        public void ShowHUD()
        {
            Console.ForegroundColor = hudColor;

            Console.WriteLine();
            Console.WriteLine("|" + name);
            Console.WriteLine("|Shield: " + shield);
            Console.WriteLine("|Health: " + health);
            Console.WriteLine("|Lives: " + lives);
            Console.WriteLine();

            Console.ResetColor();
        }

        private void ErrorMessage(string errorType)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            switch (errorType)
            {
                case "healExceed":
                    Console.WriteLine("\nERROR Healing Points Exceed 100\nReseting to 100");
                    break;

                case "shieldHealExceed":
                    Console.WriteLine("\nERROR Shield Regeneration Points Exceed 100\nResetting to 100");
                    break;
                case "healNegative":
                    Console.WriteLine("\nERROR Healing Value Negative, Healing Value must be Positive\nResetting to 0");
                    break;
                case "shieldHealNegative":
                    Console.WriteLine("\nERROR Shield Regeneration Value Negative, Shield Regeneration Value must be Positive\nResetting to 0");
                    break;
                case "damageNegative":
                    Console.WriteLine("\nERROR Damage Value Negative, Damage Value must be Positive \nResetting to 0");
                    break;
            }


            Console.ResetColor();
        }
    }
}
