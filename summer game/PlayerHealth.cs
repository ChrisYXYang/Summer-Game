using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyMonoGameLibrary.Input;

namespace summer_game;

public class PlayerHealth : Health
{
    public override int MaxHealth 
    { 
        get => base.MaxHealth;
        set
        {
            if (value % 2 == 1)
            {
                throw new Exception("max health must be even");
            }
            
            base.MaxHealth = value;
            HealthUI.Instance?.Update(CurrentHealth, MaxHealth);
        } 
    }
    public override int CurrentHealth 
    { 
        get => base.CurrentHealth;
        set
        {
            base.CurrentHealth = value;
            HealthUI.Instance?.Update(CurrentHealth, MaxHealth);

        }
    }

    //private int _extraHealth;
    //public int ExtraHealth
    //{
    //    get => _extraHealth;
    //    set
    //    {
    //        _extraHealth = (int)MathF.Min(0, value);

    //    }
    //}



    public PlayerHealth(int health) : base(health)
    {
    }

    public PlayerHealth(int maxHealth, int currentHealth) : base(maxHealth, currentHealth)
    {
    }

    public override void Start()
    {
        HealthUI.Instance.Update(CurrentHealth, MaxHealth);
    }

    public override void Heal(int heal)
    {
        base.Heal(heal);
        HealthUI.Instance.Update(CurrentHealth, MaxHealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        HealthUI.Instance.Update(CurrentHealth, MaxHealth);
    }
}
