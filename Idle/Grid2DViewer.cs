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
    class Grid2DViewer : GameObject
    {
        public int PosX;
        public int PosY;
        public Grid2D Grid;
        public int CellSize = 10;
        public int CellSpacingDistance = 2;
        SpriteBatch _spritebatch;

        Grid2DViewer(SpriteBatch Spritebatch, int PosX, int PosY, Grid2D Grid)
        {
            this.PosX = PosX;
            this.PosY = PosY;
            this.Grid = Grid;
            this._spritebatch = Spritebatch;
        }
        public override void Draw()
        {
            DrawUtils.DrawRectangle(_spritebatch,10,10,100,100,DrawUtils.Texture2DGenerator(90,90,Color.Red));
        }
        public override void Update()
        {

        }
    }
}
