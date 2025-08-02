using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.Tools;

namespace summer_game;

public class Hat : BehaviorComponent
{
    private float _destroyTimer = 0.5f;
    private bool _right;

    public override void Start()
    {
        Parent.Rigidbody.YVelocity = -5;
        _right = Tools.HalfChance();
    }

    public override void Update(GameTime gameTime)
    {
        float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;


        if (_right)
            Transform.Rotation += 300 * deltaTime;
        else
            Transform.Rotation -= 300 * deltaTime;


        _destroyTimer -= deltaTime;
        if (_destroyTimer <= 0)
        {
            SceneTools.Destroy(Parent);
        }
    }
}
