using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class EnemyHealth : Health
{
    private SpriteRenderer _sr;
    private EnemyBehavior _behavior;

    private float _damageColorTime = 0.1f;
    private float _knockbackReducer = 20f;
    private bool _damaged = false;
    private bool _knockRight = false;
    private float _whenWhite;
    
    public EnemyHealth(int health) : base(health)
    {
    }

    public EnemyHealth(int maxHealth, int currentHealth) : base(maxHealth, currentHealth)
    {
    }

    public void TakeDamage(int damage, float knockback, bool knockRight)
    {
        base.TakeDamage(damage);

        _damaged = true;
        _sr.Color = Color.Pink;
        _behavior.Knockbacked = true;
        _knockRight = knockRight;
        Parent.Rigidbody.XVelocity = knockRight ? knockback : -knockback;

        if (Dead)
        {
            Die();
        }

    }

    public void Die()
    {
        SceneTools.Destroy(Parent);
    }

    public override void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _behavior = GetComponent<EnemyBehavior>();
    }

    public override void Update(GameTime gameTime)
    {
        // handle if damaged.
        float time = (float)gameTime.TotalGameTime.TotalSeconds;
        if (_damaged)
        {
            _whenWhite = time + _damageColorTime;
            _damaged = false;
        }

        // handle when to turn color back to normal
        if (_whenWhite <= time)
        {
            _sr.Color = Color.White;
        }

        // handle knockback
        if (_behavior.Knockbacked)
        {
            if (_knockRight)
            {
                Parent.Rigidbody.XVelocity = MathF.Max(0, Parent.Rigidbody.XVelocity - (_knockbackReducer * (float)gameTime.ElapsedGameTime.TotalSeconds));

                if (Parent.Rigidbody.XVelocity <= 0)
                {
                    _behavior.Knockbacked = false;
                }
            }
            else 
            {
                Parent.Rigidbody.XVelocity = MathF.Min(0, Parent.Rigidbody.XVelocity + (_knockbackReducer * (float)gameTime.ElapsedGameTime.TotalSeconds));

                if (Parent.Rigidbody.XVelocity >= 0)
                {
                    _behavior.Knockbacked = false;
                }
            }
        }
    }
}
