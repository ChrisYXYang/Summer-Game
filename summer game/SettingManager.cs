using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class SettingManager : BehaviorComponent
{
    public static SettingManager Instance {  get; private set; }
    public bool Debug { get; set; } = false;
    
    private GameObject _pause;
    private GameObject _resume;
    private GameObject _debug;

    public override void Awake()
    {
        Instance = this;

        Parent.IgnorePause = true;
    }

    public override void Start()
    {
        _pause = Parent.GetChild(0);
        _resume = Parent.GetChild(1);
        _debug = Parent.GetChild(2);

        Resume();
    }

    public override void Update(GameTime gameTime)
    {
        // pause
        if (InputManager.Keyboard.WasKeyJustPressed(Keys.Escape))
        {
            if (SceneTools.Paused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }

        // debug
        if (Debug)
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

        Core.DrawTilemap = Debug;
    }

    public void Pause()
    {
        SceneTools.Paused = true; 
        
        _pause.Enabled = false;
        
        _resume.Enabled = true;
        _debug.Enabled = true;

    }

    public void Resume()
    {
        SceneTools.Paused = false;

        _resume.Enabled = false;
        _debug.Enabled = false;

        _pause.Enabled = true;
    }
}
