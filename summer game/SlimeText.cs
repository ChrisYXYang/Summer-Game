using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class SlimeText : BehaviorComponent
{
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        ((UIText)Parent.Renderer).Text = "Slimes Collected: " + GameManager.Instance.SlimesCollected;
    }
}
