
namespace Flare.Grid
{
    using Flare.Grid.Models;

    public interface IGridService
    {
        void PutRectangle(Rectangle rectangle);
        Rectangle FindRectangle(Position position);
        void RemoveRectangle(Position position);
        void RenderGrid();
    }
}