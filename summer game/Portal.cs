using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class Portal : BehaviorComponent
{
    private bool _active = false;
    
    public override void Start()
    {
        this.GetComponent<SpriteRenderer>().IsVisible = false;
    }

    public void Activate(Vector2 position, float rotation)
    {
        _active = true;
        this.GetComponent<SpriteRenderer>().IsVisible = true;
        Transform.position = position;
        Transform.Rotation = rotation;
    }
}
