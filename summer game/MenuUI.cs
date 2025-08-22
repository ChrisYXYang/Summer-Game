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

public class MenuUI : BehaviorComponent
{
    public static MenuUI Instance {  get; private set; }

    // buttons
    private GameObject _pause;
    private GameObject _resume;
    private GameObject _debug;
    private GameObject _sound;
    private GameObject _particle;
    private GameObject _exit;
    private GameObject _credit;

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
        _sound = Parent.GetChild(3);
        _particle = Parent.GetChild(4);
        _exit = Parent.GetChild(5);
        _credit = Parent.GetChild(6);

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
    }

    public void Pause()
    {
        SceneTools.Paused = true; 
        
        _pause.Enabled = false;
        
        _resume.Enabled = true;
        _debug.Enabled = true;
        _sound.Enabled = true;
        _particle.Enabled = true;
        _exit.Enabled = true;
        _credit.Enabled = true;
    }

    public void Resume()
    {
        SceneTools.Paused = false;

        _resume.Enabled = false;
        _debug.Enabled = false;
        _sound.Enabled = false;
        _particle.Enabled = false;
        _exit.Enabled = false;
        _credit.Enabled = false;

        _pause.Enabled = true;
    }
}
