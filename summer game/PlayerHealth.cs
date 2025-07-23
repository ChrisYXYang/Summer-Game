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

    public override void Update(GameTime gameTime)
    {
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D1))
        {
            MaxHealth -= 2;
        }

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D2))
        {
            MaxHealth += 2;
        }

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D3))
        {
            MaxHealth -= 4;
        }

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D4))
        {
            MaxHealth += 4;
        }

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D5))
        {
            CurrentHealth -= 1;
        }

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D6))
        {
            CurrentHealth += 1;
        }

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D7))
        {
            CurrentHealth -= 3;
        }

        if (InputManager.Keyboard.WasKeyJustPressed(Keys.D8))
        {
            CurrentHealth += 3;
        }
    }
}
