using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary.Scenes;

namespace summer_game;

public class BuffUI : BehaviorComponent
{
    public static BuffUI Instance { get; set; }

    private float _y = 220;
    private float _x = 60;
    private float _spacing = 90;
    private Func<PrefabInstance> _icon = Prefabs.BuffIcon;
    private List<BuffIcon> _buffs = [];

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

    public void Update((Buffs, float)[] buffs)
    {
        // calculate number of buff icons needed
        int icons = buffs.Length;

        // create/update/destroy all relevant buff icons
        for (int i = 0; i < MathF.Max(icons, _buffs.Count); i++)
        {
            // in this case there are still buff icons to update/create
            if (i < icons)
            {
                // create buff icons if needed
                while (_buffs.Count <= i)
                {
                    _buffs.Add(SceneTools.Instantiate(_icon.Invoke(), Parent).GetComponent<BuffIcon>());
                    _buffs.Last().Transform.position = new Vector2(_x, _y + ((_buffs.Count - 1) * _spacing));
                }

                // update buff icons
                BuffIcon currentIcon = _buffs[i];

                currentIcon.UpdateText(string.Format("{0:N1}", buffs[i].Item2));

                switch (buffs[i].Item1)
                {
                    case (Buffs.TripleShot):
                        currentIcon.TripleShot();
                        break;
                    case (Buffs.EnhancedThrowing):
                        currentIcon.EnhancedThrowing();
                        break;
                    case (Buffs.DoubleDamage):
                        currentIcon.DoubleDamage();
                        break;
                    case (Buffs.SpeedUp):
                        currentIcon.SpeedUp();
                        break;
                    default:
                        break;
                }
            }
            else // in this case there are none left so remaining must be destroyed
            {
                int buffCount = _buffs.Count;
                for (int j = i; j < buffCount; j++)
                {
                    SceneTools.Destroy(_buffs[i].Parent);
                    _buffs.RemoveAt(i);
                }

                break;
            }
        }
    }
}
