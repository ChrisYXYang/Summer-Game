using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

// behavior for shooting projectile
public class PlayerShoot : BehaviorComponent
{
    public float ProjectileSpeed { get; set; }
    public int Damage { get; set; }
    public float ThrowRate { get; set; }
    public float HandRange { get; set; }


    private SpriteRenderer _sr;
    private GameObject _indicator;
    private float _timeToNextThrow = 0;

    public PlayerShoot(float speed, int damage, float throwRate, float handRange)
    {
        ProjectileSpeed = speed;
        Damage = damage;   
        ThrowRate = throwRate;
        HandRange = handRange;
    }

    public override void Start()
    {
        _sr = GetComponent<SpriteRenderer>();
        _indicator = Parent.GetChild(0);
    }

    public override void Update(GameTime gameTime)
    {
        float time = (float)gameTime.TotalGameTime.TotalSeconds;
        Vector2 mouseDist = Vector2.Normalize(Camera.PixelToUnit(InputManager.Mouse.Position) - Transform.position);

        _indicator.Transform.position = mouseDist * HandRange;
        float readyScale = MathF.Min(1, (time + ThrowRate - _timeToNextThrow) / ThrowRate);
        _indicator.Transform.Scale = new Vector2(readyScale, readyScale);

        if (InputManager.Mouse.WasButtonJustPressed(MouseButton.Left) && time >= _timeToNextThrow)
        {
            GameObject projectile = SceneTools.Instantiate(Prefabs.Snowball(), Transform.position + (mouseDist * HandRange), 0f);
            projectile.GetComponent<Snowball>().Damage = Damage;
            projectile.Rigidbody.XVelocity = mouseDist.X * ProjectileSpeed;
            projectile.Rigidbody.YVelocity = mouseDist.Y * ProjectileSpeed;
            Core.Audio.PlaySoundEffect(Core.GlobalLibrary.GetSoundEffect("bounce"));
            _timeToNextThrow = time + ThrowRate;
        }

        if (Camera.PixelToUnit(InputManager.Mouse.Position).X > Transform.position.X)
        {
            _sr.FlipX = true;
        }
        else
        {
            _sr.FlipX = false;
        }
    }
}
