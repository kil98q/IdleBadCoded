using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Idle
{
    public class Grid2D
    {
        GameObject[,] _grid;
        int _sizeX;
        int _sizeY;
        public Grid2D(int SizeX, int SizeY)
        {
            _sizeX = SizeX;
            _sizeY = SizeY;
            if (!CheckBounds(new Vector2(_sizeX, _sizeY)))
            {
                throw new System.ArgumentException("Can't use negative grid size", " SizeY" + SizeX + " SizeY" + SizeY);
            }
            _grid = new GameObject[_sizeX, _sizeY];
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    _grid[x, y] = new GameObjectEmpty();
                }
            }
        }
        public GameObject GetObject(Vector2 Cords)
        {
            CheckBounds(new Vector2((int)Cords.X, (int)Cords.Y));
            return _grid[(int)Cords.X, (int)Cords.Y];

        }
        public Vector2 GetObjectCords(GameObject Object)
        {
            for (int y = 0; y < _sizeY; y++)
            {
                for (int x = 0; x < _sizeX; x++)
                {
                    if(_grid[x, y].ObjectID == Object.ObjectID)
                        return new Vector2(x, y);
                }
            }
            return new Vector2(-1,-1);
        }
        public bool CheckBounds(Vector2 Cords)
        {
            if ((int)Cords.X < 0 || (int)Cords.Y < 0)
                return false;
            if ((int)Cords.X > _sizeX || (int)Cords.Y > _sizeY)
                return false;

            return true;
        }
        public GameObject[] GetNearby(Vector2 Cords)
        {
            if (!CheckBounds(new Vector2((int)Cords.X, (int)Cords.Y)))
                throw new System.ArgumentException("Out of grid range", "(int)Cords.X: " + (int)Cords.X + " (int)Cords.Y: " + (int)Cords.Y);
            List<GameObject> TmpCollection = new List<GameObject>();
            for (int y = (int)Cords.Y - 1; y <= (int)Cords.Y + 1; y++)
            {
                for (int x = (int)Cords.X - 1; x <= (int)Cords.X + 1; x++)
                {
                    if (x == (int)Cords.X && y == (int)Cords.Y)
                        continue;
                    if (CheckBounds(new Vector2(x, y)))
                        TmpCollection.Add(_grid[x, y]);
                }
            }
            return TmpCollection.ToArray();
        }
        public GameObject[] GetTouching(Vector2 Cords)
        {
            if (!CheckBounds(new Vector2((int)Cords.X, (int)Cords.Y)))
                throw new System.ArgumentException("Out of grid range", "(int)Cords.X: " + (int)Cords.X + " (int)Cords.Y: " + (int)Cords.Y);
            List<GameObject> TmpCollection = new List<GameObject>();
            for (int y = (int)Cords.Y - 1; y <= (int)Cords.Y + 1; y++)
            {
                if (y == (int)Cords.Y)
                    continue;
                if (CheckBounds(new Vector2((int)Cords.X, y)))
                    TmpCollection.Add(_grid[(int)Cords.X, y]);
            }
            for (int x = (int)Cords.X - 1; x <= (int)Cords.X + 1; x++)
            {
                if (x == (int)Cords.X)
                    continue;
                if (CheckBounds(new Vector2(x, (int)Cords.Y)))
                    TmpCollection.Add(_grid[x, (int)Cords.Y]);
            }
            return TmpCollection.ToArray();
        }
    }
}
