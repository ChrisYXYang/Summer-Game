using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class EnemyBehavior : BehaviorComponent
{
    public float ProjectileSpeed { get; set; }
    public bool DoubleDamage { get; set; }
    public float AttackRate { get; set; }
    public float HandRange { get; set; }
    public bool CanMove { get; set; } = true;

    // movement speed
    private float _speed;
    public float Speed
    {
        get
        {
            return _speed;
        }
        set
        {
            _speed = value * (1 + (float)Core.Random.NextDouble() * 0.1f);
        }
    }
    
    // x distance from player until stopping movement
    private float _range;
    public float Range
    {
        get
        {
            return _range;
        }
        set
        {
            _range = value * (1 + (float)Core.Random.NextDouble() * 0.25f);
        }
    }

    private Transform _player;
    private SpriteRenderer _sr;
    private Health _health;
    private readonly Animation _run;

    public EnemyBehavior(float speed, float range, Animation run)
    {
        Speed = speed;
        Range = range;
        _run = run;
    }

    public override void Start()
    {
        _player = SceneTools.GetGameObject("player").Transform;
        _sr = GetComponent<SpriteRenderer>();
        _health = GetComponent<Health>();
    }

    public override void Update(GameTime gameTime)
    {
        if (CanMove)
        {
            bool outRange = MathF.Abs(_player.Transform.position.X - Transform.position.X) > Range;

            if (_player.position.X > Transform.position.X)
            {
                if (outRange)
                {
                    Parent.Rigidbody.XVelocity = Speed;
                    Parent.Animator.Animation = _run;
                }
                else
                {
                    Parent.Rigidbody.XVelocity = 0;
                    Parent.Animator.Animation = null;
                }
                _sr.FlipX = false;
            }
            else
            {
                if (outRange)
                {
                    Parent.Rigidbody.XVelocity = -Speed;
                    Parent.Animator.Animation = _run;
                }
                else
                {
                    Parent.Rigidbody.XVelocity = 0;
                    Parent.Animator.Animation = null;
                }

                _sr.FlipX = true;

            }
        }
        else
        {
            Parent.Animator.Animation = null;
        }
    }
}
