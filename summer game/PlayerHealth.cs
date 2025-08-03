using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class PlayerHealth : Health
{
    private HealthUI _ui;
    
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
            _ui?.Update(CurrentHealth, MaxHealth);
        } 
    }
    public override int CurrentHealth 
    { 
        get => base.CurrentHealth;
        set
        {
            base.CurrentHealth = value;
            _ui?.Update(CurrentHealth, MaxHealth);

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
        _ui = SceneTools.GetGameObject("ui manager").GetComponent<HealthUI>();
        _ui.Update(CurrentHealth, MaxHealth);
    }

    public override void Heal(int heal)
    {
        base.Heal(heal);
        _ui.Update(CurrentHealth, MaxHealth);
    }

    public override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        _ui.Update(CurrentHealth, MaxHealth);
    }
}
