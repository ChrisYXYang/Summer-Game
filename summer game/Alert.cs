using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class Alert : BehaviorComponent
{
    private SpriteRenderer _sr;

    private float _timer;

    public override void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
    }

    public override void Update(GameTime gameTime)
    {
        _timer -= SceneTools.DeltaTime;

        if (_timer >= 0)
        {
            _sr.IsVisible = true;
        }
        else
        {
            _sr.IsVisible = false;
        }
    }

    public void Alerted(float time)
    {
        _timer = time;
    }
}
