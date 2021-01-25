using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem_3._0
{
    class Player : GameCharacter
    {
        public Player()
        {
            name = "Hero";

            maxHealth = 100;
            maxShield = 100;
            lives = 3;

            health = maxHealth;
            shield = maxShield;
        }
    }
}
