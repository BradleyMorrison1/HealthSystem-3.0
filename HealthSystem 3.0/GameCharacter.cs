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

            Console.Write("\n\n" + name + " has taken ");
            Console.ForegroundColor = ConsoleColor.DarkRed;
            Console.Write(damage);
            Console.ResetColor();
            Console.Write(" points of Damage!");

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
                health = maxHealth;
                shield = maxShield;
            }

            if (lives <= 0)
            {
                lives = 0;
                alive = false;
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("\n" + name + " HAS DIED\n");
                Console.ResetColor();
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

            Console.Write("\n\n" + name + " has healed ");
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write(healingPoints);
            Console.ResetColor();
            Console.Write(" points to Health");

            if (health < maxHealth) health += healingPoints;
            if (health > maxHealth) health = maxHealth;
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

            Console.Write("\n\n" + name + " has regenerated ");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write(regenPoints);
            Console.ResetColor();
            Console.Write(" points to their Shield");

            if (shield < maxShield) shield += regenPoints;
            if (shield > maxShield) shield = maxShield;
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
