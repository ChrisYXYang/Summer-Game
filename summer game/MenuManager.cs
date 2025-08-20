using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using MyMonoGameLibrary.Input;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class MenuManager : BehaviorComponent
{
    public static MenuManager Instance {  get; private set; }
    
    private GameObject _pause;
    private GameObject _resume;

    public override void Awake()
    {
        Instance = this;

        Parent.IgnorePause = true;
    }

    public override void Start()
    {
        _pause = Parent.GetChild(0);
        _resume = Parent.GetChild(1);

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
    }

    public void Resume()
    {
        SceneTools.Paused = false;

        _resume.Enabled = false;

        _pause.Enabled = true;
    }
}
