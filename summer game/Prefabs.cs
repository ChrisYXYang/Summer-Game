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
    // ui
    public static PrefabInstance HeartIcon()
    {
        Component[] components =
            [
                new Transform(),
                new UISprite(),
                new HeartIcon()
            ];

        return new PrefabInstance("heart icon", components);
    }

    public static PrefabInstance BuffIcon()
    {
        Component[] components =
            [
                new Transform(),
                new UISprite(),
                new BuffIcon()
            ];

        return new PrefabInstance("buff icon", components, [BuffText()]);
    }

    public static PrefabInstance BuffText()
    {
        Component[] components =
            [
                new Transform(new Vector2(90, 0)),
                new UIText(Core.GlobalLibrary.GetFont("04B_30"), "", AnchorMode.MiddleLeft),
            ];

        return new PrefabInstance("buff text", components);
    }

    public static PrefabInstance Player()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(6), Converter.PixelToUnit(8), "player"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player"), 0.6f),
            new Animator(),
            new PlayerMovement(5, 13, 9, 0.2f),
            new PlayerShoot(10, false, false, 4, 0.5f, 0.5f),
            new PlayerHealth(6),
            new PlayerState(),
            ];

        return new PrefabInstance("player", components, [SnowballIndicator(), Hat()]);
    }

    public static PrefabInstance Hat()
    {
        Component[] components =
        [
            new Transform(new Vector2(0, Converter.PixelToUnit(-4))),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player hat"), 0.63f),
        ];

        return new PrefabInstance("hat", components);
    }

    public static PrefabInstance DiscardedHat()
    {
        Component[] components =
        [
            new Transform(),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player hat"), 0.65f),
            new Rigidbody(true, false),
            new Hat()
        ];

        return new PrefabInstance("discarded hat", components);
    }

    public static PrefabInstance Snowball()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(Converter.PixelToUnit(4), "attack"),
            new Rigidbody(true, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowball"), 0.7f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "snowball")),
            new Snowball(),
            ];

        return new PrefabInstance("snowball", components);
    }

    public static PrefabInstance SnowballIndicator()
    {
        Component[] components =
            [
            new Transform(),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowball"), 0.7f)
            ];

        return new PrefabInstance("snowball indicator", components);
    }

    public static PrefabInstance Snowman()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(8), Converter.PixelToUnit(9), Converter.PixelToUnit(0), Converter.PixelToUnit(-0.5f), "enemy"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowman"), 0.4f),
            new Animator(),
            new EnemyBehavior(7.5f, false, 1.5f, 0.5f, 3, 3, Prefabs.Carrot, Core.GlobalLibrary.GetAnimation("characters", "snowman_run")),
            new EnemyHealth(4)
            ];

        return new PrefabInstance("snowman", components);
    }

    public static PrefabInstance Iceman()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(8), Converter.PixelToUnit(10), "enemy"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "iceman"), 0.4f),
            new Animator(),
            new EnemyBehavior(4f, true, 3, 0.6f, 2, 4, Prefabs.Icicle, Core.GlobalLibrary.GetAnimation("characters", "iceman_run")),
            new EnemyHealth(8)
            ];

        return new PrefabInstance("iceman", components);
    }

    public static PrefabInstance TestDummy()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(8), Converter.PixelToUnit(9), Converter.PixelToUnit(0), Converter.PixelToUnit(-0.5f), "enemy"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowman")),
            new Animator(),
            new EnemyBehavior(7.5f, false, 1, 0.5f, 3, 3, Prefabs.Carrot, Core.GlobalLibrary.GetAnimation("characters", "snowman_run")),
            new EnemyHealth(1000)
            ];

        return new PrefabInstance("test dummy", components, [SnowballIndicator()]);
    }

    public static PrefabInstance Carrot()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(Converter.PixelToUnit(4), "hurt"),
            new Rigidbody(false, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "carrot"), 0.5f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "carrot")),
            new EnemyProjectile(),
            ];

        return new PrefabInstance("carrot", components);
    }

    public static PrefabInstance Icicle()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(Converter.PixelToUnit(6), "hurt"),
            new Rigidbody(false, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "icicle"), 0.5f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "icicle")),
            new EnemyProjectile(),
            ];

        return new PrefabInstance("icicle", components);
    }

    // buffs
    public static PrefabInstance BuffStatement()
    {
        Component[] components =
            [
            new Transform(),
            new TextRenderer(Core.GlobalLibrary.GetFont("04B_30_small"), "", AnchorMode.MiddleCenter),
            new BuffStatement(),
            ];

        return new PrefabInstance("buff statement", components);
    }

    public static PrefabInstance Heart()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(6), Converter.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "heart"), 0.35f),
            new HealthItem(2),
            ];

        return new PrefabInstance("heart", components);
    }

    public static PrefabInstance HalfHeart()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(6), Converter.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "half heart"), 0.35f),
            new HealthItem(1),
            ];

        return new PrefabInstance("half heart", components);
    }

    public static PrefabInstance SpeedUp()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(6), Converter.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "speed up"), 0.35f),
            new BuffItem(Buffs.SpeedUp, "speed up!", 10),
            ];

        return new PrefabInstance("speed up", components);
    }

    public static PrefabInstance EnhancedThrowing()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(6), Converter.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "enhanced throwing"), 0.35f),
            new BuffItem(Buffs.EnhancedThrowing, "enhanced throwing!", 15),
            ];

        return new PrefabInstance("enhanced throwing", components);
    }
    public static PrefabInstance DoubleDamage()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(6), Converter.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "double damage"), 0.35f),
            new BuffItem(Buffs.DoubleDamage, "double damage!", 20),
            ];

        return new PrefabInstance("double damage", components);
    }

    public static PrefabInstance TripleShot()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Converter.PixelToUnit(6), Converter.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "triple shot"), 0.35f),
            new BuffItem(Buffs.TripleShot, "triple shot!", 25),
            ];

        return new PrefabInstance("triple shot", components);
    }
}
