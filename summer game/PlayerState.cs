using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class PlayerState : BehaviorComponent
{
    public Queue<string> _buffStatements = [];

    private float _statementRate = 01f;
    private float _nextStatementTime = 0;

    public void QueueStatement(string statement)
    {
        _buffStatements.Enqueue(statement);
    }

    public override void Update(GameTime gameTime)
    {
        if (_buffStatements.Count > 0)
        {
            float time = (float)gameTime.TotalGameTime.TotalSeconds;
            
            if (_nextStatementTime <= time)
            {
                string statement = _buffStatements.Dequeue();
                _nextStatementTime = time + _statementRate;
                Debug.WriteLine(statement);
            }
        }
    }
}
