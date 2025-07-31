using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.Tools;

namespace summer_game;

public class PlayerState : BehaviorComponent
{
    private Dictionary<Buffs, (bool, float)> _buffTimes = [];
    private List<(Buffs, float)> _activeBuffs = [];
    private Queue<string> _buffStatements = [];

    private float _statementRate = 0.3f;
    private float _statementTimer = 0;

    private PlayerShoot _shoot;
    private PlayerMovement _movement;

    public override void Start()
    {
        _shoot = GetComponent<PlayerShoot>();
        _movement = GetComponent<PlayerMovement>();
    }

    public override void Update(GameTime gameTime)
    {
        _statementTimer -= SceneTools.DeltaTime;

        // handle active buffs
        for (int i = _activeBuffs.Count - 1; i >= 0; i--)
        {
            Buffs buff = _activeBuffs[i].Item1;
            _buffTimes[buff] = (true, _buffTimes[buff].Item2 - (float)gameTime.ElapsedGameTime.TotalSeconds);
            _activeBuffs[i] = (buff, _buffTimes[buff].Item2);

            if (_buffTimes[buff].Item2 <= 0)
            {
                _buffTimes[buff] = (false, 0);
                ChooseBuff(buff, false);
                _activeBuffs.RemoveAt(i);
                Debug.WriteLine(buff + " removed");
            }
        }

        // update the ui
        BuffUI.Instance.Update([.. _activeBuffs]);

        // handle buff statements
        if (_buffStatements.Count > 0)
        {            
            if (_statementTimer <= 0)
            {
                string statement = _buffStatements.Dequeue();
                GameObject text = SceneTools.Instantiate(Prefabs.BuffStatement(), Transform.position - (Vector2.UnitY * Converter.PixelToUnit(4)));
                ((TextRenderer)text.Renderer).Text = statement;
                _statementTimer = _statementRate;
            }
        }
    }

    public void QueueStatement(string statement)
    {
        _buffStatements.Enqueue(statement);
    }

    public void AddBuff(Buffs buff, string statement, float time)
    {
        QueueStatement(statement);

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
            ChooseBuff(buff, true);
            _activeBuffs.Add((buff, time));
            Debug.WriteLine(buff + " activated");
        }
    }

    private void ChooseBuff(Buffs buff, bool add)
    {
        switch (buff)
        {
            case (Buffs.TripleShot):
                TripleShot(add);
                break;
            case (Buffs.EnhancedThrowing):
                EnhancedThrowing(add);
                break;
            case (Buffs.DoubleDamage):
                DoubleDamage(add);
                break;
            case (Buffs.SpeedUp):
                SpeedUp(add);
                break;
            default:
                break;
        }
    }

    private void TripleShot(bool add)
    {
        _shoot.TripleShot = add;
    }

    private void EnhancedThrowing(bool add)
    {
        _shoot.ModifyRate(add, false, 0.5f);
        _shoot.ModifySpeed(add, false, 1.5f);
        _shoot.ModifyKnockback(add, false, 2f);
    }

    private void DoubleDamage(bool add)
    {
        _shoot.DoubleDamage = add;
    }

    private void SpeedUp(bool add)
    {
        _movement.ModifyJump(add, false, 1.5f);
        _movement.ModifyDash(add, false, 1.5f);
        _movement.ModifyMove(add, false, 2f);
        _movement.ModifyFall(add, false, 2f);
    }
}
