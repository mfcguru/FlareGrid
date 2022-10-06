
namespace Flare.Grid
{
    using Flare.Grid.Exceptions;
    using Flare.Grid.Models;

    public class GridService : IGridService
    {
        public const int MIN_WIDTH = 5;
        public const int MIN_HEIGHT = 5;
        public const int MAX_WIDTH = 25;
        public const int MAX_HEIGHT = 25;

        private uint[,] gridData;
        private readonly uint gridWidth;
        private readonly uint gridHeight;

        private List<Rectangle> rectangles = new List<Rectangle>();

        public GridService(uint gridWidth, uint gridHeight)
        {
            this.gridWidth = gridWidth;
            this.gridHeight = gridHeight;

            Initialisation();
        }

        private void Initialisation()
        {
            if (gridWidth < MIN_WIDTH || gridHeight < MIN_HEIGHT || gridWidth > MAX_WIDTH || gridHeight > MAX_HEIGHT)
            {
                throw new GridSizeException();
            }

            gridData = new uint[gridWidth, gridHeight];
        }

        public void PutRectangle(Rectangle rectangle)
        {
            foreach (var otherRectangle in rectangles)
            {
                if (IsOverLapping(rectangle, otherRectangle))
                {
                    throw new OverlappingRectangleException();
                }
            }

            if (rectangle.Position.X + rectangle.Width >= gridWidth)
            {
                throw new RectangleExtendsBeyondGridException();
            }

            if (rectangle.Position.Y + rectangle.Height >= gridWidth)
            {
                throw new RectangleExtendsBeyondGridException();
            }

            rectangles.Add(rectangle);
        }

        public Rectangle FindRectangle(Position position)
        {
            foreach (var rectangle in rectangles.ToList())
            {
                if (position.X == rectangle.Position.X && position.Y == rectangle.Position.X)
                {
                    return rectangle;
                }
            }

            throw new RectangleWasNotFoundException(position);
        }

        public void RemoveRectangle(Position position)
        {
            foreach (var rectangle in rectangles.ToList())
            {
                if (position.X >= rectangle.Position.X && position.X <= rectangle.Position.X + rectangle.Width)
                {
                    if (position.Y >= rectangle.Position.Y && position.Y <= rectangle.Position.Y + rectangle.Height)
                    {
                        rectangles.Remove(rectangle);
                        return;
                    }
                }
            }

            throw new RectangleWasNotFoundException(position);
        }

        public void RenderGrid()
        {
            RefreshGridData();

            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    Console.BackgroundColor = (ConsoleColor)gridData[x, y];
                    Console.Write(" ");
                }

                Console.WriteLine("");
            }
        }

        private void RefreshGridData()
        {
            Console.Clear();

            for (int y = 0; y < gridHeight; y++)
            {
                for (int x = 0; x < gridWidth; x++)
                {
                    gridData[x, y] = (int)ConsoleColor.Black;
                }
            }

            foreach (var rectangle in rectangles)
            {
                for (int y = 0; y < rectangle.Height; y++)
                {
                    for (int x = 0; x < rectangle.Width; x++)
                    {
                        gridData[rectangle.Position.X + x, rectangle.Position.Y + y] = (uint)rectangle.Color;
                    }
                }
            }
        }

        private bool IsOverLapping(Rectangle rectangle, Rectangle otherRectangle)
        {
            if (rectangle.Position.X + rectangle.Width <= otherRectangle.Position.X ||
                otherRectangle.Position.X + otherRectangle.Width <= rectangle.Position.X ||
                rectangle.Position.Y + rectangle.Height <= otherRectangle.Position.Y ||
                otherRectangle.Position.Y + otherRectangle.Height <= rectangle.Position.Y)
                return false;
            else
                return true;
        }
    }
}
