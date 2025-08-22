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
    public bool Invincible { get; set; } = false;
    public bool Damageable { get; set; } = true;
    public float RecoverTime { get; set; }

    private SpriteRenderer _sr;
    private float _recoverTimer;
    private float _blinkTimer;
    private float _blinkTime = 0.15f;
    
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


    public PlayerHealth(int health, float recoverTime) : base(health)
    {
        RecoverTime = recoverTime;
    }

    public PlayerHealth(int maxHealth, int currentHealth, float recoverTime) : base(maxHealth, currentHealth)
    {
        RecoverTime = recoverTime;
    }

    public override void Start()
    {
        _sr= GetComponent<SpriteRenderer>();
        HealthUI.Instance.Update(CurrentHealth, MaxHealth);
    }

    public override void Update(GameTime gameTime)
    {
        if (!Damageable)
        {
            _recoverTimer -= SceneTools.DeltaTime;
            _blinkTimer -= SceneTools.DeltaTime;

            if (_recoverTimer <= 0)
            {
                Damageable = true;
            }

            if (_blinkTimer <= 0)
            {
                _sr.IsVisible = !_sr.IsVisible;
                _blinkTimer = _blinkTime;
            }
        }
        else
        {
            _sr.IsVisible = true;
        }
    }

    public override void Heal(int heal)
    {
        base.Heal(heal);
        HealthUI.Instance.Update(CurrentHealth, MaxHealth);
    }

    public override void TakeDamage(int damage)
    {
        if (!Invincible)
        {
            if (Damageable)
            {
                base.TakeDamage(damage);
                Damageable = false;
                _recoverTimer = RecoverTime;
                HealthUI.Instance.Update(CurrentHealth, MaxHealth);
            }
        }
    }

    public override void Die()
    {
        Parent.Enabled = false;
        MenuUI.Instance.GameOver();
    }
}
