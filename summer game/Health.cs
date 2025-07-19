using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class Health : BehaviorComponent
{
    public int MaxHealth { get; set; }
    public int CurrentHealth { get; set; }
    public bool Dead => CurrentHealth <= 0;

    public Health(int health)
    {
        MaxHealth = health;
        CurrentHealth = health;
    }

    public Health(int maxHealth, int currentHealth)
    {
        MaxHealth = maxHealth;
        CurrentHealth = currentHealth;
    }

    public virtual void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
    }

    public virtual void Heal(int heal)
    {
        CurrentHealth += heal;
    }
}
