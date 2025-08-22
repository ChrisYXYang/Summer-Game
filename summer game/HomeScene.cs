using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.UI;

namespace summer_game;

public class HomeScene : Scene
{
    public override void Initialize()
    {
        UICamera.Scale = 10;
        Settings.MusicSound = 3;
        base.Initialize();
    }

    public override void LoadContent()
    {
        Setup
        (
            "title",
            [
                new Transform(new Vector2(960, 250)),
                new UISprite(Core.GlobalLibrary.GetSprite("ui", "title"))
            ]
        );

        Setup
        (
            "credit",
            [
                new Transform(new Vector2(1760, 1050), Vector2.One * 0.5f, 0f),
                        new UISprite(Core.GlobalLibrary.GetSprite("ui", "credit"))
            ]
        );

        Setup
        (
            "play button",
            [
                new Transform(new Vector2(960, 510)),
                new UISprite(),
                new BoxCollider(220, 120),
                new Button(Core.GlobalLibrary.GetSprite("ui", "play"), Core.GlobalLibrary.GetSprite("ui", "play_h"), ()=>Core.ChangeScene(new GameScene()))
            ]
        );

        Setup
        (
            "howto button",
            [
                new Transform(new Vector2(960, 660)),
                                new UISprite(),
                                new BoxCollider(360, 120),
                                new Button(Core.GlobalLibrary.GetSprite("ui", "howto"), Core.GlobalLibrary.GetSprite("ui", "howto_h"), ()=>Core.ChangeScene(new HowToScene()))
            ]
        );

        Setup
        (
            "settings button",
            [
                new Transform(new Vector2(960, 810)),
                        new UISprite(),
                        new BoxCollider(360, 120),
                        new Button(Core.GlobalLibrary.GetSprite("ui", "settings"), Core.GlobalLibrary.GetSprite("ui", "settings_h"), ()=>Core.ChangeScene(new SettingScene()))
            ]
        );

        Setup
        (
            "exit button",
            [
                new Transform(new Vector2(960, 960)),
                new UISprite(),
                new BoxCollider(200, 120),
                new Button(Core.GlobalLibrary.GetSprite("ui", "exit"), Core.GlobalLibrary.GetSprite("ui", "exit_h"), ()=>Core.Instance.Exit())
            ]
        );

        base.LoadContent();
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
