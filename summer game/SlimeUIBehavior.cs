using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class SlimeUIBehavior : UIBehavior
{
    private bool _justPointed = true;


    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        if (Collisions.MouseInUICollider(Parent.Collider))
        {
            if (!_justPointed)
            {
                ((SpriteUI)Parent).Animator.Animation = Core.GlobalLibrary.GetAnimation("characters", "green_slime");
                _justPointed = true;
            }
        }
        else
        {
            ((SpriteUI)Parent).Animator.Animation = null;
            _justPointed = false;

        }
    }
}
