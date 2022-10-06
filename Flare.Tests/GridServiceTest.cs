
namespace Flare.Tests
{
    using Flare.Grid;
    using Flare.Grid.Exceptions;
    using Flare.Grid.Models;

    [TestClass]
    public class PutRectangle
    {
        private uint gridWidth;
        private uint gridHeight;
        private IGridService gridService;
     
        public PutRectangle()
        {
            gridWidth = GridService.MAX_WIDTH;
            gridHeight = GridService.MAX_HEIGHT;            
            gridService = new GridService(gridWidth, gridHeight);
        }

        [TestMethod]
        public void Sucess()
        {
            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 0, Y = 0 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Blue
            });
        }

        [TestMethod]
        [ExpectedException(typeof(RectangleExtendsBeyondGridException))]
        public void RectangleExtendsBeyondGrid_ByX()
        {
            uint x = gridWidth + 1;

            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = x, Y = 0 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Blue
            });
        }

        [TestMethod]
        [ExpectedException(typeof(RectangleExtendsBeyondGridException))]
        public void RectangleExtendsBeyondGrid_ByY()
        {
            uint y = gridWidth + 1;

            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 0, Y = y},
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Blue
            });
        }

        [TestMethod]
        [ExpectedException(typeof(RectangleExtendsBeyondGridException))]
        public void RectangleExtendsBeyondGrid_ByWidth()
        {
            uint width = gridWidth + 1;

            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 0, Y = 0 },
                Width = width,
                Height = 10,
                Color = ConsoleColor.Blue
            });
        }

        [TestMethod]
        [ExpectedException(typeof(RectangleExtendsBeyondGridException))]
        public void RectangleExtendsBeyondGrid_ByHeight()
        {
            uint height = gridHeight + 1;

            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 0, Y = 0 },
                Width = 4,
                Height = height,
                Color = ConsoleColor.Blue
            });
        }

        [TestMethod]
        [ExpectedException(typeof(OverlappingRectangleException))]
        public void OverlappingRectangle_TopCorner_LeftOverlapsRight()
        {
            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 1, Y = 1 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Blue
            });

            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 0, Y = 0 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Red
            });
        }

        [TestMethod]
        [ExpectedException(typeof(OverlappingRectangleException))]
        public void OverlappingRectangle_TopCorner_RightOverlapsLeft()
        {
            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 0, Y = 0 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Blue
            });

            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 1, Y = 1 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Red
            });
        }

        [TestMethod]
        [ExpectedException(typeof(OverlappingRectangleException))]
        public void OverlappingRectangle_BottomCorner_LeftOverlapsRight()
        {
            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 0, Y = 0 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Blue
            });

            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 3, Y = 9 },
                Width = 5,
                Height = 5,
                Color = ConsoleColor.Red
            });
        }

        [TestMethod]
        [ExpectedException(typeof(OverlappingRectangleException))]
        public void OverlappingRectangle_BottomCorner_RightOverlapsLeft()
        {
            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 3, Y = 9 },
                Width = 5,
                Height = 5,
                Color = ConsoleColor.Red
            });

            gridService.PutRectangle(new Rectangle
            {
                Position = new Position { X = 0, Y = 0 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Blue
            });
        }
    }
}