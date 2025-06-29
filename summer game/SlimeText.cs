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

public class SlimeText : UIBehavior
{
    public override void Update(GameTime gameTime)
    {
        base.Update(gameTime);

        ((TextUI)Parent).Text = "Slimes Collected: " + GameManager.Instance.SlimesCollected;
    }
}
