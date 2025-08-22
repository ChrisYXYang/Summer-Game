using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;


namespace summer_game;

public class SettingScene : Scene
{
    public override void Initialize()
    {
        UICamera.Scale = 10;
        base.Initialize();
    }

    public override void LoadContent()
    {
        Setup
        (
            "credit",
            [
                new Transform(new Vector2(1760, 1050), Vector2.One * 0.5f, 0f),
                        new UISprite(Core.GlobalLibrary.GetSprite("ui", "credit"))
            ]
        );

        Setup(Prefabs.DebugButton(), new Vector2(960, 750));
        Setup(Prefabs.SoundSetting(), new Vector2(960, 340));
        Setup(Prefabs.ParticleButton(), new Vector2(960, 600));

        Setup
        (
            "back",
            [
                new Transform(new Vector2(960, 900)),
                        new UISprite(),
                        new BoxCollider(240, 120),
                        new Button(Core.GlobalLibrary.GetSprite("ui", "back"), Core.GlobalLibrary.GetSprite("ui", "back_h"), () => Core.ChangeScene(new HomeScene()))
            ]
        );

        base.LoadContent();
    }

    public override void Update(GameTime gameTime)
    {
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.Escape))
        {
            Core.ChangeScene(new HomeScene());
        }

        base.Update(gameTime);
    }

    public override void Draw(GameTime gameTime)
    {
        Core.GraphicsDevice.Clear(Color.PaleVioletRed);

        // set render modes
        Core.SpriteBatch.Begin(samplerState: SamplerState.PointClamp, sortMode: SpriteSortMode.FrontToBack);

        // debug
        if (Settings.Debug)
        {
            foreach (GameObject gameObject in SceneTools.GetGameDrawObjects())
            {
                if (gameObject.Enabled)
                {
                    Core.DrawOrigin(gameObject);
                    Core.DrawCollider(gameObject);
                }
            }

            foreach (GameObject gameObject in SceneTools.GetUIDrawObjects())
            {
                if (gameObject.Enabled)
                {
                    Core.DrawUIOrigin(gameObject);
                    Core.DrawUICollider(gameObject);
                }
            }
        }

        Core.DrawTilemap = Settings.Debug;

        base.Draw(gameTime);
    }
}