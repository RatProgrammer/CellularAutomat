using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CellularAutomaton.Model
{
    class Grid
    {
        public Point PointSize { get; set; }
        private Cellular[,] _cellulars;
        private bool[,] _next;
        private TimeSpan _time;

        public Grid()
        {
            PointSize = new Point(GameOfLife.CellularX, GameOfLife.CellulatY);
            _cellulars = new Cellular[PointSize.X,PointSize.Y];
            _next = new bool[PointSize.X,PointSize.Y];
            Random random = new Random();

            for (int i = 0; i < PointSize.X; i++)
            {
                for (int j = 0; j < PointSize.Y; j++)
                {
                    _cellulars[i, j] = new Cellular(new Point(i, j));
                    _next[i, j] = false;
                }
            }
            _time = TimeSpan.Zero;
        }


        public void Clear()
        {
            for (int i = 0; i < PointSize.X; i++)
            {
                for (int j = 0; j < PointSize.Y; j++)
                {
                    _next[i, j] = false;
                }
            }
            SetNext();
        }

        private void SetNext()
        {
            for (int i = 0; i < PointSize.X; i++)
            {
                for (int j = 0; j < PointSize.Y; j++)
                {
                    _cellulars[i, j].IsCellularAlive = _next[i, j];
                }
            }
        }

        public void Update(GameTime gameTime)
        {
            MouseState mouseState = Mouse.GetState();

            foreach (Cellular cellular in _cellulars)
            {
                cellular.UpdateState(mouseState);
            }


            if (GameOfLife.IsPaused)
            {
                return;
            }
             

            _time += gameTime.ElapsedGameTime;

            if (_time.TotalMilliseconds > 1000f / GameOfLife.Ups)
            {
                _time = TimeSpan.Zero;

                // Loop through every cell on the grid.
                for (int i = 0; i < PointSize.X; i++)
                {
                    for (int j = 0; j < PointSize.Y; j++)
                    {
                        // Check the cell's current state, count its living neighbors, and apply the rules to set its next state.
                        bool living = _cellulars[i, j].IsCellularAlive;
                        int count = GetLivingNeighbors(i, j);
                        bool result = false;

                        if (living && count < 2)
                            result = false;
                        if (living && (count == 2 || count == 3))
                            result = true;
                        if (living && count > 3)
                            result = false;
                        if (!living && count == 3)
                            result = true;

                        _next[i, j] = result;
                    }
                }

                SetNext();
            }
        }

        private int GetLivingNeighbors(int x, int y)
        {
            int count = 0;

            // Check cell on the right.
            if (x != PointSize.X - 1)
                if (_cellulars[x + 1, y].IsCellularAlive)
                    count++;

            // Check cell on the bottomw right.
            if (x != PointSize.X - 1 && y != PointSize.Y - 1)
                if (_cellulars[x + 1, y + 1].IsCellularAlive)
                    count++;

            // Check cell on the bottom.
            if (y != PointSize.Y - 1)
                if (_cellulars[x, y + 1].IsCellularAlive)
                    count++;

            // Check cell on the bottom left.
            if (x != 0 && y != PointSize.Y - 1)
                if (_cellulars[x - 1, y + 1].IsCellularAlive)
                    count++;

            // Check cell on the left.
            if (x != 0)
                if (_cellulars[x - 1, y].IsCellularAlive)
                    count++;

            // Check cell on the top left.
            if (x != 0 && y != 0)
                if (_cellulars[x - 1, y - 1].IsCellularAlive)
                    count++;

            // Check cell on the top.
            if (y != 0)
                if (_cellulars[x, y - 1].IsCellularAlive)
                    count++;

            // Check cell on the top right.
            if (x != PointSize.X - 1 && y != 0)
                if (_cellulars[x + 1, y - 1].IsCellularAlive)
                    count++;

            return count;
        }
        
        public void Draw(SpriteBatch spriteBatch)
        {
            foreach (Cellular cellular in _cellulars)
            {
                cellular.DrawCellular(spriteBatch);
            }
            for (int i = 0; i < PointSize.X; i++)
            {
                //spriteBatch.Draw(GameOfLife.Pixel, new Rectangle(i+GameOfLife.CellularSize-10 ,0,1,PointSize.Y*GameOfLife.CellularSize),Color.Black );
                spriteBatch.Draw(GameOfLife.Pixel, new Rectangle(i * GameOfLife.CellularSize - 1, 0, 1, PointSize.Y * GameOfLife.CellularSize), Color.Black);
            }
            for (int i = 0; i < PointSize.Y; i++)
            {
                spriteBatch.Draw(GameOfLife.Pixel, new Rectangle(0, i * GameOfLife.CellularSize - 1, PointSize.X * GameOfLife.CellularSize, 1), Color.DarkCyan);
                // spriteBatch.Draw(GameOfLife.Pixel, new Rectangle(100, i * GameOfLife.CellularSize - 1, PointSize.X * GameOfLife.CellularSize, 1), Color.DarkCyan);
            }
        }
    }
}