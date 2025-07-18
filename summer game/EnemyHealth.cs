using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class EnemyHealth : Health
{
    public EnemyHealth(int health) : base(health)
    {
    }

    public EnemyHealth(int maxHealth, int currentHealth) : base(maxHealth, currentHealth)
    {
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        
        if (Dead)
        {
            Die();
        }
    }

    public void Die()
    {
        SceneTools.Destroy(Parent);
    }
}
