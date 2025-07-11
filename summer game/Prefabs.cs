using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary;
using MyMonoGameLibrary.UI;
using static System.Net.Mime.MediaTypeNames;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Tools;

namespace summer_game;

// this class contains static methods corresponding to prefabs to use in scenes.
public static class Prefabs
{
    // player
    public static (string, Component[]) Player()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(8), Converter.PixelToUnit(8), "player"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player_0")),
            new PlayerMovement(4, 10),
            new PlayerShoot(10)
            ];

        return ("player", components);
    }

    // spark
    public static (string, Component[]) Spark()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(Converter.PixelToUnit(4), "spark"),
            new Rigidbody(false, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "spark")),
            new Spark()
            ];

        return ("spark", components);
    }

    // appear!
    public static (string, Component[]) Appear()
    {
        Component[] components =
            [
                new Transform(new Vector2(960, 540)),
                new UIText(Core.GlobalLibrary.GetFont("04B_30"), "appear!", AnchorMode.MiddleCenter)
            ];

        return ("appear", components);
    }

    // label
    public static (string, Component[]) Label()
    {
        Component[] components =
            [
            new Transform(new Vector2(0, -0.75f)),
            new TextRenderer(Core.GlobalLibrary.GetFont("04B_30_small"), "", AnchorMode.MiddleCenter, Color.Lavender, 0.2f),
            new TextCollider(1, 0),
            new BoxCollider(0,0)
            ];

        return ("label", components);
    }
}
