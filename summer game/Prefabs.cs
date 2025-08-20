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
    public static PrefabInstance Player()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Tools.PixelToUnit(6), Tools.PixelToUnit(8), "player"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player"), 0.6f),
            new Animator(),
            new PlayerMovement(5, 13, 10, 0.2f),
            new PlayerShoot(12, false, false, 4, 0.4f, 0.5f),
            new PlayerHealth(6, 1.5f),
            new PlayerState(),
            new ParticleSystem([Core.GlobalLibrary.GetSprite("characters", "snow")], true, 0.2f, 2, -70f, 20f, 4f,  0.3f, Tools.PixelToUnit(3), Tools.PixelToUnit(4))
            ];

        return new PrefabInstance("player", components, [(SnowballIndicator(), Vector2.Zero), (Hat(), new Vector2(0, Tools.PixelToUnit(-4)))]);
    }

    public static PrefabInstance Hat()
    {
        Component[] components =
        [
            new Transform(),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player hat"), 0.61f),
        ];

        return new PrefabInstance("hat", components);
    }

    public static PrefabInstance DiscardedHat()
    {
        Component[] components =
        [
            new Transform(),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "player hat"), 0.61f),
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
                new CircleCollider(Tools.PixelToUnit(4), "attack"),
                new Rigidbody(true, false),
                new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowball"), 0.63f),
                new Animator(Core.GlobalLibrary.GetAnimation("characters", "snowball")),
                new Snowball(),
                new ParticleSystem
                (
                    [Core.GlobalLibrary.GetSprite("characters", "snowball_debris_0"), 
                    Core.GlobalLibrary.GetSprite("characters", "snowball_debris_1")],
                    true,
                    3,
                    120f,
                    4f,
                    0.5f
                )
            ];

        return new PrefabInstance("snowball", components);
    }

    public static PrefabInstance SnowballIndicator()
    {
        Component[] components =
            [
            new Transform(),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowball"), 0.62f)
            ];

        return new PrefabInstance("snowball indicator", components);
    }

    // enemies
    public static PrefabInstance Snowman()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Tools.PixelToUnit(8), Tools.PixelToUnit(9), Tools.PixelToUnit(0), Tools.PixelToUnit(-0.5f), "enemy"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "snowman"), 0.4f),
            new Animator(),
            new EnemyBehavior(7f, false, 2.5f, 0.5f, 2.75f, 3, Prefabs.Carrot, Core.GlobalLibrary.GetAnimation("characters", "snowman_run")),
            new EnemyHealth(3),
            new ParticleSystem([Core.GlobalLibrary.GetSprite("characters", "snow")], true, 0.3f, 3, -70f, 25f, 5f,  0.4f, Tools.PixelToUnit(2), Tools.PixelToUnit(4))
            ];

        return new PrefabInstance("snowman", components, [(Alerted(), new Vector2(0, -1.5f))]);
    }

    public static PrefabInstance Iceman()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Tools.PixelToUnit(8), Tools.PixelToUnit(10), "enemy"),
            new Rigidbody(true, true),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "iceman"), 0.4f),
            new Animator(),
            new EnemyBehavior(3.5f, true, 4f, 0.6f, 2, 4, Prefabs.Icicle, Core.GlobalLibrary.GetAnimation("characters", "iceman_run")),
            new EnemyHealth(6),
            new ParticleSystem([Core.GlobalLibrary.GetSprite("characters", "snow")], true, 0.5f, 5, -70f, 40f, 8f,  0.6f, Tools.PixelToUnit(3), Tools.PixelToUnit(5))
            ];

        return new PrefabInstance("iceman", components, [(Alerted(), new Vector2(0, -1.5f))]);
    }

    public static PrefabInstance Alerted()
    {
        Component[] components =
            [
                new Transform(),
                new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "alerted"), 0.4f),
                new Alert()
            ];

        return new PrefabInstance("alert", components);
    }

    public static PrefabInstance Carrot()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(Tools.PixelToUnit(4), "hurt"),
            new Rigidbody(false, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "carrot"), 0.5f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "carrot")),
            new EnemyProjectile(),
            new ParticleSystem
                (
                    [Core.GlobalLibrary.GetSprite("characters", "carrot_debris_0"),
                    Core.GlobalLibrary.GetSprite("characters", "carrot_debris_1")],
                    true,
                    3,
                    120f,
                    3f,
                    0.5f
                )
            ];

        return new PrefabInstance("carrot", components);
    }

    public static PrefabInstance Icicle()
    {
        Component[] components =
            [
            new Transform(),
            new CircleCollider(Tools.PixelToUnit(6), "hurt"),
            new Rigidbody(false, false),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "icicle"), 0.5f),
            new Animator(Core.GlobalLibrary.GetAnimation("characters", "icicle")),
            new EnemyProjectile(),
                        new ParticleSystem
                (
                    [Core.GlobalLibrary.GetSprite("characters", "icicle_debris_0"),
                    Core.GlobalLibrary.GetSprite("characters", "icicle_debris_1")],
                    true,
                    3,
                    120f,
                    2f,
                    0.5f
                )
            ];

        return new PrefabInstance("icicle", components);
    }

    // pickups
    public static PrefabInstance BuffStatement()
    {
        Component[] components =
            [
            new Transform(),
            new TextRenderer(Core.GlobalLibrary.GetFont("04B_30_small"), "", AnchorMode.MiddleCenter, 0.71f),
            new BuffStatement(),
            ];

        return new PrefabInstance("buff statement", components);
    }

    public static PrefabInstance Fish()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Tools.PixelToUnit(6), Tools.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "fish"), 0.7f),
            new ScorePickup(1),
            ];

        return new PrefabInstance("fish", components);
    }

    public static PrefabInstance Heart()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Tools.PixelToUnit(6), Tools.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "heart"), 0.7f),
            new HealthPickup(2),
            ];

        return new PrefabInstance("heart", components);
    }

    public static PrefabInstance HalfHeart()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Tools.PixelToUnit(6), Tools.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "half heart"), 0.7f),
            new HealthPickup(1),
            ];

        return new PrefabInstance("half heart", components);
    }

    public static PrefabInstance SpeedUp()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Tools.PixelToUnit(6), Tools.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "speed up"), 0.7f),
            new BuffPickup(Buffs.SpeedUp, "speed up!", 10),
            ];

        return new PrefabInstance("speed up", components);
    }

    public static PrefabInstance EnhancedThrowing()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Tools.PixelToUnit(6), Tools.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "enhanced throwing"), 0.7f),
            new BuffPickup(Buffs.EnhancedThrowing, "enhanced throwing!", 10),
            ];

        return new PrefabInstance("enhanced throwing", components);
    }
    public static PrefabInstance DoubleDamage()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Tools.PixelToUnit(6), Tools.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "double damage"), 0.7f),
            new BuffPickup(Buffs.DoubleDamage, "double damage!", 10),
            ];

        return new PrefabInstance("double damage", components);
    }

    public static PrefabInstance TripleShot()
    {
        Component[] components =
            [
            new Transform(),
            new BoxCollider(Tools.PixelToUnit(6), Tools.PixelToUnit(6), "buff"),
            new SpriteRenderer(Core.GlobalLibrary.GetSprite("characters", "triple shot"), 0.7f),
            new BuffPickup(Buffs.TripleShot, "triple shot!", 10),
            ];

        return new PrefabInstance("triple shot", components);
    }

    // player UI
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

        return new PrefabInstance("buff icon", components, [(BuffText(), new Vector2(90, 0))]);
    }

    public static PrefabInstance BuffText()
    {
        Component[] components =
            [
                new Transform(),
                new UIText(Core.GlobalLibrary.GetFont("04B_30"), "", AnchorMode.MiddleLeft),
            ];

        return new PrefabInstance("buff text", components);
    }

    // menu UI

    public static PrefabInstance FullscreenButton()
    {
        Component[] components =
            [
                new Transform(),
                new UISprite(),
                new BoxCollider(600, 120),
                new FullscreenButton(Core.GlobalLibrary.GetSprite("ui", "fullscreen"), Core.GlobalLibrary.GetSprite("ui", "fullscreen_h"))
            ];

        return new PrefabInstance("fullscreen button", components, [(Check(), new Vector2(500, 0))]);
    }

    public static PrefabInstance Check()
    {
        Component[] components =
            [
                new Transform(),
                new UISprite(),
                new Check()
            ];

        return new PrefabInstance("check", components);
    }
}
