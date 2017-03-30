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
    public static class DrawUtils
    {
        static GraphicsDeviceManager _graphics;

        public static void DrawRectangle(SpriteBatch _spritebatch,int PosX, int PosY, int Width, int Height, Texture2D Texture)
        {
            _spritebatch.Draw(Texture, new Rectangle(PosX, PosY, Width, Height),Color.White);
        }
        public static Texture2D Texture2DGenerator(int Width,int Heigth, Color Color)
        {
            Texture2D _tempTexture;
            int _dataSize = Width * Heigth;
            Color[] _data = new Color[_dataSize];
            for(int i = 0; i < _data.Length; i++)
            {
                _data[i] = Color;
            }
            _tempTexture = new Texture2D(_graphics.GraphicsDevice, Width, Heigth);
            _tempTexture.SetData(_data);
            return _tempTexture;
        }
    }
}
