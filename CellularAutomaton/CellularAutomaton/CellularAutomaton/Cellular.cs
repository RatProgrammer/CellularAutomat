using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CellularAutomaton
{
    class Cellular
    {
        public Point CellularPosition { get; set; }
        public Rectangle Bounds { get; set; }
        public bool IsCellularAlive { get; set; }
        public bool X { get; set; }

        public Cellular(Point position)
        {
            CellularPosition = position;
            Bounds = new Rectangle(CellularPosition.X * GameOfLife.CellularSize, CellularPosition.Y*GameOfLife.CellularSize, GameOfLife.CellularSize, GameOfLife.CellularSize);
            IsCellularAlive = false;
            X = true;
        }

        public void DrawCellular(SpriteBatch spriteBatch)
        {
            if (IsCellularAlive)
            {
                spriteBatch.Draw(GameOfLife.Pixel, Bounds, Color.OrangeRed);
                X = false;
            }
            if (X)
            {
                spriteBatch.Draw(GameOfLife.Pixel, Bounds, Color.Green);
            }
        }

        public void UpdateState(MouseState mouseState)
        {
            if(Bounds.Contains(new Point(mouseState.X, mouseState.Y)))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    IsCellularAlive = true;
                }
                else if(mouseState.RightButton==ButtonState.Pressed)
                {
                    IsCellularAlive = false;
                    X = true;
                }
            }
        }
    }
}
