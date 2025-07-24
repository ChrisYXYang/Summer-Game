using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class HealthUI : BehaviorComponent
{
    public static HealthUI Instance { get; private set; }

    private float _y = 80;
    private float _x = 80;
    private float _spacing = 80;
    private Func<PrefabInstance> _heart;
    private List<HeartIcon> _hearts = [];

    public HealthUI(Func<PrefabInstance> heart)
    {
        _heart = heart;
    }

    public override void Awake()
    {
        if (Instance == null)
        {

            Instance = this;
        }
        else
        {
            SceneTools.Destroy(this.Parent);
        }
    }

    public void Update(int health, int maxHealth)
    {
        // calculate number of heart icons needed
        int heartIcons = (int)MathF.Max(0, maxHealth / 2);

        // create/update/destroy all relevant heart icons
        for (int i = 0; i < MathF.Max(heartIcons, _hearts.Count); i++)
        {
            // in this case there are still heart icons to update/create
            if (i < heartIcons)
            {
                // create heart icons if needed
                while (_hearts.Count <= i)
                {
                    _hearts.Add(SceneTools.Instantiate(_heart.Invoke()).GetComponent<HeartIcon>());
                    _hearts.Last().Transform.position = new Vector2(_x + ((_hearts.Count - 1) * _spacing), _y);
                }

                // update regular heart icons
                int iconHealth = 2 * (i + 1);
                if (health >= iconHealth)
                {
                    _hearts[i].Full();
                }
                else if (health == iconHealth - 1)
                {
                    _hearts[i].Half();
                }
                else
                {
                    _hearts[i].Empty();
                }
            }
            else // in this case there are none left so remaining must be destroyed
            {
                int heartCount = _hearts.Count;
                for (int j = i; j < heartCount; j++)
                {
                    SceneTools.Destroy(_hearts[i].Parent);
                    _hearts.RemoveAt(i);
                }

                break;
            }
        }
    }
}
