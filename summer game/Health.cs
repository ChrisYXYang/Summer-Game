using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public abstract class Health : BehaviorComponent
{

    private int _maxHealth;
    public virtual int MaxHealth
    {
        get => _maxHealth;
        set
        {
            _maxHealth = (int)MathF.Max(0, value);

            if (_maxHealth < CurrentHealth)
            {
                CurrentHealth = _maxHealth;
            }
        }
    }

    private int _currHealth;
    public virtual int CurrentHealth
    {
        get => _currHealth;
        set
        {
            _currHealth = (int)MathF.Max(0, value);

            if (_currHealth > MaxHealth)
            {
                _currHealth = MaxHealth;
            }
        }
    }
    public virtual bool Dead => CurrentHealth <= 0;
    public virtual bool Full => CurrentHealth == MaxHealth;

    private bool _died = false;

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

        if (Dead && !_died)
        {
            Die();
            _died = true;
        }
    }

    public virtual void Die() { }

    public virtual void Heal(int heal)
    {
        CurrentHealth += heal;
    }
}
