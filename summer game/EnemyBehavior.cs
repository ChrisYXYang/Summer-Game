using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class EnemyBehavior : BehaviorComponent
{
    public string Name { get; private set; }
    
    private Transform _player;
    private SpriteRenderer _sr;
    private Health _health;

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

    private float _range;
    public float Range
    {
        get
        {
            return _range;
        }
        set
        {
            _range = value * (1 + (float)Core.Random.NextDouble() * 0.2f);
        }
    }

    public EnemyBehavior(string name, float speed, float range)
    {
        Name = name;
        Speed = speed;
        Range = range;
    }

    public override void Start()
    {
        _player = SceneTools.GetGameObject("player").Transform;
        _sr = GetComponent<SpriteRenderer>();
        _health = GetComponent<Health>();
    }

    public override void Update(GameTime gameTime)
    {
        bool outRange = MathF.Abs(_player.Transform.position.X - Transform.position.X) > Range;
        
        if (_player.position.X > Transform.position.X)
        {
            if (outRange)
            {
                Parent.Rigidbody.XVelocity = Speed;
            }
            else
            {
                Parent.Rigidbody.XVelocity = 0;
            }
                _sr.FlipX = false;
        }
        else
        {
            if (outRange)
            {
                Parent.Rigidbody.XVelocity = -Speed;
            }
            else
            {
                Parent.Rigidbody.XVelocity = 0;
            }

            _sr.FlipX = true;

        }
    }
}
