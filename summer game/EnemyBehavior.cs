using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Graphics;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;
using static System.Net.Mime.MediaTypeNames;

namespace summer_game;

public class EnemyBehavior : BehaviorComponent
{
    public float ProjectileSpeed { get; set; }
    public bool DoubleDamage { get; set; }
    // attack rate
    private float _attackRate;
    public float AttackRate
    {
        get => _attackRate;
        set => _attackRate = value * (1 + (float)Core.Random.NextDouble() * 0.1f);
    }
    public float HandRange { get; set; }
    public bool Knockbacked { get; set; } = false;

    // movement speed
    private float _moveSpeed;
    public float MoveSpeed
    {
        get =>_moveSpeed;
        set => _moveSpeed = value * (1 + (float)Core.Random.NextDouble() * 0.1f);
    }
    
    // x distance from player until stopping movement
    private float _range;
    public float Range
    {
        get => _range;
        set => _range = value * (1 + (float)Core.Random.NextDouble() * 0.25f);
    }

    private Transform _player;
    private SpriteRenderer _sr;
    private Health _health;
    private readonly Animation _run;
    private readonly Func<PrefabInstance> _projectile;
    //private GameObject _indicator;
    private float _timeToNextThrow = 0;

    public EnemyBehavior(float projectileSpeed, bool doubleDmg, float attackRate, float handRange, 
        float moveSpeed, float range, Func<PrefabInstance> projectile, Animation run)
    {
        ProjectileSpeed = projectileSpeed;
        DoubleDamage = doubleDmg;
        AttackRate = attackRate;
        HandRange = handRange;
        MoveSpeed = moveSpeed;
        Range = range;
        _projectile = projectile;
        _run = run;
    }

    public override void Start()
    {
        _player = SceneTools.GetGameObject("player").Transform;
        _sr = GetComponent<SpriteRenderer>();
        _health = GetComponent<Health>();
        //_indicator = Parent.GetChild(0);
    }

    public override void Update(GameTime gameTime)
    {
        if (!Knockbacked)
        {
            // shoot
            float time = (float)gameTime.TotalGameTime.TotalSeconds;
            Vector2 playerDist = Vector2.Normalize(_player.position - Transform.position);

            //_indicator.Transform.position = playerDist * HandRange;

            if (time >= _timeToNextThrow)
            {
                GameObject projectile = SceneTools.Instantiate(_projectile.Invoke(), Transform.position + (playerDist * HandRange), 0f);
                projectile.GetComponent<EnemyProjectile>().Damage = DoubleDamage ? 2 : 1;
                projectile.Rigidbody.XVelocity = playerDist.X * ProjectileSpeed;
                projectile.Rigidbody.YVelocity = playerDist.Y * ProjectileSpeed;
                _timeToNextThrow = time + AttackRate;
            }


            // move
            bool outRange = MathF.Abs(_player.Transform.position.X - Transform.position.X) > Range;

            if (_player.position.X > Transform.position.X)
            {
                if (outRange)
                {
                    Parent.Rigidbody.XVelocity = MoveSpeed;
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
                    Parent.Rigidbody.XVelocity = -MoveSpeed;
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
