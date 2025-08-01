﻿using System;
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
using MyMonoGameLibrary.Tools;
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

    public int Level { get; set; }

    private Transform _player;
    private SpriteRenderer _sr;
    private Health _health;
    private readonly Animation _run;
    private readonly Func<PrefabInstance> _projectile;
    //private GameObject _indicator;
    private float _attackTimer = 0;
    private bool _attackMode;
    private float _stateTimer = 0;
    private bool _roam = true;

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
        _attackTimer -= SceneTools.DeltaTime;
        _stateTimer -= SceneTools.DeltaTime;

        if (_player.position.Y <= -6.5)
        {
            if (Level == 3)
            {
                _attackMode = true;
            }
            else
            {
                _attackMode = false;
            }
        }
        else if (_player.position.Y > 3.5)
        {
            if (Level == 1)
            {
                _attackMode = true;
            }
            else
            {
                _attackMode = false;
            }
        }
        else
        {
            if (Level == 2)
            {
                _attackMode = true;
            }
            else
            {
                _attackMode = false;
            }
        }

        if (!Knockbacked)
        {
            if (_attackMode)
            {
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

                // shoot
                Vector2 playerDist = Vector2.Normalize(_player.position - Transform.position);

                //_indicator.Transform.position = playerDist * HandRange;
                if (_attackTimer <= 0)
                {
                    Shoot(playerDist, 0);

                    _attackTimer = AttackRate;
                }
                _sr.Color = Color.White;

            }
            else
            {
                if (_stateTimer <= 0)
                {
                    _stateTimer = 1.5f + ((float)Core.Random.NextDouble() * 2.5f);

                    if (!_roam)
                    {
                        _roam = true;
                    }
                    else
                    {
                        _roam = Tools.HalfChance();
                    }

                    if (_roam)
                    {
                        Parent.Animator.Animation = _run;
                        
                        bool left = Tools.HalfChance();
                        if (left)
                        {
                            Parent.Rigidbody.XVelocity = -MoveSpeed;
                        }
                        else
                        {
                            Parent.Rigidbody.XVelocity = MoveSpeed;
                        }
                    }
                    else
                    {
                        Parent.Rigidbody.XVelocity = 0;
                    }
                }

                if (Parent.Rigidbody.TouchingLeft)
                {
                    Parent.Rigidbody.XVelocity = MoveSpeed;
                }

                if (Parent.Rigidbody.TouchingRight)
                {
                    Parent.Rigidbody.XVelocity = -MoveSpeed;
                }

                if (Parent.Rigidbody.XVelocity < 0)
                {
                    Parent.Animator.Animation = _run;
                    _sr.FlipX = true;
                }
                else if (Parent.Rigidbody.XVelocity > 0)
                {
                    Parent.Animator.Animation = _run;
                    _sr.FlipX = false;
                }
                else
                {
                    Parent.Animator.Animation = null;
                }

                _sr.Color = Color.Blue;
            }
        }
        else
        {
            Parent.Animator.Animation = null;
        }
    }

    private void Shoot(Vector2 playerDist, float skew)
    {
        float rotation = MathF.Atan2(playerDist.Y, playerDist.X) + MathHelper.ToRadians(skew);
        GameObject projectile = SceneTools.Instantiate(_projectile.Invoke(), Transform.position + (playerDist * HandRange), 0f);
        projectile.GetComponent<EnemyProjectile>().Damage = DoubleDamage ? 2 : 1;
        Vector2 direction = new ((float)MathF.Cos(rotation), (float)MathF.Sin(rotation));
        projectile.Rigidbody.XVelocity = direction.X * ProjectileSpeed;
        projectile.Rigidbody.YVelocity = direction.Y * ProjectileSpeed;
        projectile.Transform.Rotation = MathHelper.ToDegrees(rotation);
    }

    //public override void OnCollisionEnter(ICollider other)
    //{
    //    if (other is ColliderComponent col)
    //    {
    //        PlayerHealth playerHealth = col.GetComponent<PlayerHealth>();
    //        if (playerHealth != null)
    //        {
    //            int damage = DoubleDamage ? 2 : 1;
    //            playerHealth.TakeDamage(damage);
    //        }
    //    }
    //}
}
