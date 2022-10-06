
namespace Flare.Grid.Exceptions
{
    public class GridSizeException : Exception
    {
        public GridSizeException() :
            base("Grid with and height cannot be less than 5 and cannot be greater than 25")
        {

        }
    }
}
