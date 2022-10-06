using Flare.Grid.Models;
using Flare.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Flare.Grid.Exceptions;

namespace Flare.Tests
{
    [TestClass]
    public class RemoveRectangle
    {
        private uint gridWidth;
        private uint gridHeight;
        private IGridService gridService;

        public RemoveRectangle()
        {
            gridWidth = GridService.MAX_WIDTH;
            gridHeight = GridService.MAX_HEIGHT;
            gridService = new GridService(gridWidth, gridHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(RectangleWasNotFoundException))]
        public void Sucess()
        {
            var rectangle = new Rectangle
            {
                Position = new Position { X = 0, Y = 0 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Blue
            };
            gridService.PutRectangle(rectangle);

            gridService.RemoveRectangle(rectangle.Position);

            gridService.FindRectangle(rectangle.Position);
        }

        [TestMethod]
        [ExpectedException(typeof(RectangleWasNotFoundException))]
        public void RectangleWasNotFound()
        {
            var rectangle = new Rectangle
            {
                Position = new Position { X = 1, Y = 1 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Blue
            };

            gridService.PutRectangle(rectangle);

            gridService.RemoveRectangle(new Position { X = 0, Y = 0 });
        }
    }
}
