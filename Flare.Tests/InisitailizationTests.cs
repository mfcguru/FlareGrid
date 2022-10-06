
namespace Flare.Tests
{
    using Flare.Grid;
    using Flare.Grid.Exceptions;

    [TestClass]
    public class Initialization
    {
        [TestMethod]
        public void Success()
        {
            uint gridWidth = GridService.MAX_WIDTH;
            uint gridHeight = GridService.MAX_HEIGHT;

            new GridService(gridWidth, gridHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(GridSizeException))]
        public void GridSize_LessThanMinimumWidth()
        {
            uint gridWidth = GridService.MIN_WIDTH - 1;
            uint gridHeight = GridService.MAX_HEIGHT;
            
            new GridService(gridWidth, gridHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(GridSizeException))]
        public void GridSize_GreaterThanMaximumWidth()
        {
            uint gridWidth = GridService.MAX_WIDTH + 1;
            uint gridHeight = GridService.MAX_HEIGHT;
            
            new GridService(gridWidth, gridHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(GridSizeException))]
        public void GridSize_LessThanMinimumHeight()
        {
            uint gridWidth = GridService.MIN_WIDTH;
            uint gridHeight = GridService.MIN_HEIGHT - 1;
            
            new GridService(gridWidth, gridHeight);
        }

        [TestMethod]
        [ExpectedException(typeof(GridSizeException))]
        public void GridSize_GreaterThanMaximumHeight()
        {
            uint gridWidth = GridService.MAX_WIDTH;
            uint gridHeight = GridService.MAX_HEIGHT + 1;
            
            new GridService(gridWidth, gridHeight);
        }
    }
}
