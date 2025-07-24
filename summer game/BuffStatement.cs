using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class BuffStatement : BehaviorComponent
{
    private float _destroyTimer = 0.5f;
    private float _speed = 3f;

    public override void Start()
    {

    }

    public override void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

        Transform.position.Y -= _speed * deltaTime;

        _destroyTimer -= deltaTime;
        if (_destroyTimer <= 0)
        {
            SceneTools.Destroy(Parent);
        }
    }
}
