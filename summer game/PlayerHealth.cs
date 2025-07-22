using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace summer_game;

public class PlayerHealth : Health
{
    public override int MaxHealth 
    { 
        get => base.MaxHealth;
        set
        {
            base.MaxHealth = value;
            HealthUI.Instance.SetHealth(CurrentHealth, value);
        } 
    }
    public override int CurrentHealth 
    { 
        get => base.CurrentHealth;
        set
        {
            base.CurrentHealth = value;
            HealthUI.Instance.SetHealth(value, MaxHealth);

        }
    }

    public PlayerHealth(int health) : base(health)
    {
    }

    public PlayerHealth(int maxHealth, int currentHealth) : base(maxHealth, currentHealth)
    {
    }

    public override void Start()
    {
        HealthUI.Instance.SetHealth(CurrentHealth, MaxHealth);
    }

    public override void Heal(int heal)
    {
        base.Heal(heal);
        HealthUI.Instance.AddHealth(heal, MaxHealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        HealthUI.Instance.RemoveHealth(damage, MaxHealth);
    }
}
