using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class EnemyMovement : BehaviorComponent
{
    private Transform _player;
    private SpriteRenderer _sr;
    private float _moveSpeed;

    public EnemyMovement(float speed)
    {
        _moveSpeed = speed;
    }

    public override void Start()
    {
        _player = SceneTools.GetGameObject("player").Transform;
        _sr = GetComponent<SpriteRenderer>();
    }

    public override void Update(GameTime gameTime)
    {
        if (_player.position.X > Transform.position.X)
        {
            Parent.Rigidbody.XVelocity = _moveSpeed;
            _sr.FlipX = false;
        }
        else
        {
            Parent.Rigidbody.XVelocity = -_moveSpeed;
            _sr.FlipX = true;

        }
    }
}
