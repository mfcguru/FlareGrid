
namespace Flare.Tests
{
    using Flare.Grid;
    using Flare.Grid.Exceptions;
    using Flare.Grid.Models;

    [TestClass]
    public class FindRectangle
    {
        private uint gridWidth;
        private uint gridHeight;
        private IGridService gridService;

        public FindRectangle()
        {
            gridWidth = GridService.MAX_WIDTH;
            gridHeight = GridService.MAX_HEIGHT;
            gridService = new GridService(gridWidth, gridHeight);
        }

        [TestMethod]
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

            var foundRectangle = gridService.FindRectangle(rectangle.Position);

            Assert.AreEqual(rectangle.Position.X, foundRectangle.Position.X);
            Assert.AreEqual(rectangle.Position.Y, foundRectangle.Position.Y);
            Assert.AreEqual(rectangle.Width, foundRectangle.Width);
            Assert.AreEqual(rectangle.Height, foundRectangle.Height);
        }

        [TestMethod]
        [ExpectedException(typeof(RectangleWasNotFoundException))]
        public void RectangleWasNotFound()
        {
            var rectangle = new Rectangle
            {
                Position = new Position { X = 0, Y = 0 },
                Width = 4,
                Height = 10,
                Color = ConsoleColor.Blue
            };

            gridService.PutRectangle(rectangle);

            gridService.FindRectangle(new Position { X = 1, Y = 1 });            
        }
    }
}
