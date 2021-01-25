using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HealthSystem_3._0
{
    class Enemy : GameCharacter
    {
        public Enemy()
        {
            name = "Bowser";

            health = maxHealth;
            shield = maxShield;

            maxHealth = 100;
            maxShield = 100;
            lives = 3;
        }

    }
}
