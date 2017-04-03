using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CellularAutomaton.Model.GameOfLiveSymulationItems
{
    class GameOfLifeCellular
    {
        public Point CellularPosition { get; set; }
        public Rectangle Bounds { get; set; }
        public bool IsCellularAlive { get; set; }

        public GameOfLifeCellular(Point position)
        {
            CellularPosition = position;
            Bounds = new Rectangle(CellularPosition.X * FireSymulationGame.CellularSize, CellularPosition.Y * FireSymulationGame.CellularSize, FireSymulationGame.CellularSize, FireSymulationGame.CellularSize);
            IsCellularAlive = false;
        }

        public void DrawCellular(SpriteBatch spriteBatch)
        {
            if (IsCellularAlive)
            {
                spriteBatch.Draw(FireSymulationGame.Pixel, Bounds, Color.Black);
            }
            else
            {
                spriteBatch.Draw(FireSymulationGame.Pixel, Bounds, Color.White);
            }
        }

        public void UpdateState(MouseState mouseState)
        {
            if (Bounds.Contains(new Point(mouseState.X, mouseState.Y)))
            {
                if (mouseState.LeftButton == ButtonState.Pressed)
                {
                    IsCellularAlive = true;
                }
                else if (mouseState.RightButton == ButtonState.Pressed)
                {
                    IsCellularAlive = false;
                }
            }
        }
    }
}
