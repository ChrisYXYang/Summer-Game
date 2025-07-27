using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.Tools;

namespace summer_game;

public class PlayerState : BehaviorComponent
{
    private Dictionary<Buffs, (bool, float)> _buffTimes = [];
    private List<Buffs> _activeBuffs = [];
    private Queue<string> _buffStatements = [];

    private float _statementRate = 0.3f;
    private float _nextStatementTime = 0;

    private PlayerShoot _shoot;
    private PlayerMovement _movement;

    public void QueueStatement(string statement)
    {
        _buffStatements.Enqueue(statement);
    }

    public void AddBuff(Buffs buff, string statement, float time)
    {
        bool activate = true;
        
        if (!_buffTimes.ContainsKey(buff))
        {
            _buffTimes.Add(buff, (true, time));
        }
        else
        {
            activate = !_buffTimes[buff].Item1;
            _buffTimes[buff] = (true, time);
        }

        if (activate)
        {
            switch (buff)
            {
                case (Buffs.TripleShot):
                    _shoot.TripleShot = true;
                    break;
                case (Buffs.EnhancedThrowing):
                    _shoot.ThrowRate /= 2f;
                    _shoot.ProjectileSpeed *= 1.5f;
                    _shoot.Knockback *= 2f;
                    break;
                case (Buffs.DoubleDamage):
                    _shoot.DoubleDamage = true;
                    break;
                case (Buffs.SpeedUp):
                    _movement.JumpPower *= 1.5f;
                    _movement.DashVelocity *= 1.5f;
                    _movement.MoveSpeed *= 2f;
                    break;
                default:
                    break;
            }

            _activeBuffs.Add(buff);
            Debug.WriteLine(buff + " activated");
        }

        QueueStatement(statement);
    }

    private void RemoveBuff(Buffs buff)
    {
        switch (buff)
        {
            case (Buffs.TripleShot):
                _shoot.TripleShot = false;
                break;
            case (Buffs.EnhancedThrowing):
                _shoot.ThrowRate *= 2f;
                _shoot.ProjectileSpeed /= 1.5f;
                _shoot.Knockback /= 2f;
                break;
            case (Buffs.DoubleDamage):
                _shoot.DoubleDamage = false;
                break;
            case (Buffs.SpeedUp):
                _movement.JumpPower /= 1.5f;
                _movement.DashVelocity /= 1.5f;
                _movement.MoveSpeed /= 2f;
                break;
            default:
                break;
        }

        Debug.WriteLine(buff + " removed");
    }

    public override void Start()
    {
        _shoot = GetComponent<PlayerShoot>();
        _movement = GetComponent<PlayerMovement>();
    }

    public override void Update(GameTime gameTime)
    {
        // handle active buffs
        for (int i = _activeBuffs.Count - 1; i >= 0; i--)
        {
            _buffTimes[_activeBuffs[i]] = (true, _buffTimes[_activeBuffs[i]].Item2 - (float)gameTime.ElapsedGameTime.TotalSeconds);

            if (_buffTimes[_activeBuffs[i]].Item2 <= 0)
            {
                _buffTimes[_activeBuffs[i]] = (false, 0);
                RemoveBuff(_activeBuffs[i]);
                _activeBuffs.RemoveAt(i);
            }
        }

        // handle buff statements
        if (_buffStatements.Count > 0)
        {
            float time = (float)gameTime.TotalGameTime.TotalSeconds;
            
            if (_nextStatementTime <= time)
            {
                string statement = _buffStatements.Dequeue();
                GameObject text = SceneTools.Instantiate(Prefabs.BuffStatement(), Transform.position - (Vector2.UnitY * Converter.PixelToUnit(4)));
                ((TextRenderer)text.Renderer).Text = statement;
                _nextStatementTime = time + _statementRate;
            }
        }
    }
}
