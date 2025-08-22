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
    private GameObject _over;
    private GameObject _exit2;
    private GameObject _retry;

    private bool _gameOver = false;

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
        _over = Parent.GetChild(7);
        _exit2 = Parent.GetChild(8);
        _retry = Parent.GetChild(9);

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
                if (!_gameOver)
                    Pause();
            }
        }
    }

    public void Pause()
    {
        if (!_gameOver)
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
        _over.Enabled = false;
        _exit2.Enabled = false;
        _retry.Enabled = false;

        _pause.Enabled = true;
    }

    public void GameOver()
    {
        _gameOver = true;

        _resume.Enabled = false;
        _debug.Enabled = false;
        _sound.Enabled = false;
        _particle.Enabled = false;
        _exit.Enabled = false;
        _pause.Enabled = false;

        _credit.Enabled = true;
        _over.Enabled = true;
        _exit2.Enabled = true;
        _retry.Enabled = true;
    }
}
