using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class SlimeUIBehavior : UIBehavior
{
    public override void Update(GameTime gameTime)
    {
        if (Collisions.MouseInUICollider(Parent.Collider))
        {
            Parent.Color = Color.Purple * 0.3f;
        }
        else
        {
            Parent.Color = Color.White * 0.3f;
        }
    }
}
