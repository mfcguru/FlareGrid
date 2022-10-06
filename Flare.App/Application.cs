
namespace Flare.App
{
    using Flare.Grid;
    using Flare.Grid.Models;

    internal class Application
    {
        public void Run()
        {
            var gridService = new GridService(GridService.MAX_WIDTH, GridService.MAX_HEIGHT);

            var position = new Position { X = 1, Y = 1 };
            var rectangle = new Rectangle { Position = position, Width = 3, Height = 4, Color = ConsoleColor.Yellow };
            gridService.PutRectangle(rectangle);

            position = new Position { X = 2, Y = 5 };
            rectangle = new Rectangle { Position = position, Width = 5, Height = 2, Color = ConsoleColor.Green};
            gridService.PutRectangle(rectangle);

            position = new Position { X = 6, Y = 0 };
            rectangle = new Rectangle { Position = position, Width = 4, Height = 4, Color = ConsoleColor.Magenta };
            gridService.PutRectangle(rectangle);

            gridService.RenderGrid();
        }
    }
}
