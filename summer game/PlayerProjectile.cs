using System;
using System.ComponentModel;
using Microsoft.Xna.Framework;
using MyMonoGameLibrary;
using MyMonoGameLibrary.Scenes;
using MyMonoGameLibrary.Tilemap;


namespace summer_game;

public class PlayerProjectile : BehaviorComponent
{
    public GameObject Portal { get; set; }

    private TileMap _tilemap;

    public override void Start()
    {
        _tilemap = SceneTools.GetTilemap();
    }

    public override void OnCollisionEnter(ICollider other)
    {
        string layer = other.Layer;
        
        if (layer == "wall" || layer == "portal")
        {
            if (layer == "portal")
            {
                TileCollider tile = (TileCollider)other;
                Vector2 gridPos = tile.Parent.GridPosition;
                int gridRow = (int)gridPos.X;
                int gridCol = (int)gridPos.Y;

                if (_tilemap.GetTile("portal_col_sol", gridRow, gridCol - 1) == null &&
                    _tilemap.GetTile("regular_col_sol", gridRow, gridCol - 1) == null)
                {
                    Portal.GetComponent<Portal>().Activate(new Vector2(tile.Left - 0.5f, Transform.position.Y), 270f);
                }

                else if (_tilemap.GetTile("portal_col_sol", gridRow, gridCol + 1) == null &&
                        _tilemap.GetTile("regular_col_sol", gridRow, gridCol + 1) == null)
                {
                    Portal.GetComponent<Portal>().Activate(new Vector2(tile.Right + 0.5f, Transform.position.Y), 90f);
                }

                else if (_tilemap.GetTile("portal_col_sol", gridRow - 1, gridCol) == null &&
                        _tilemap.GetTile("regular_col_sol", gridRow - 1, gridCol) == null)
                {
                    Portal.GetComponent<Portal>().Activate(new Vector2(Transform.position.X, tile.Top - 0.5f), 0f);
                }

                else if (_tilemap.GetTile("portal_col_sol", gridRow + 1, gridCol) == null &&
                        _tilemap.GetTile("regular_col_sol", gridRow + 1, gridCol) == null)
                {
                    Portal.GetComponent<Portal>().Activate(new Vector2(Transform.position.X, tile.Bottom + 0.5f), 180f);
                }
            }
            
            SceneTools.Destroy(this.Parent);
        }
    }
}
