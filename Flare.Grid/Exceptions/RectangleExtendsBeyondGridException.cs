
namespace Flare.Grid.Exceptions
{
    public class RectangleExtendsBeyondGridException : Exception
    {
        public RectangleExtendsBeyondGridException() :
            base("Cannot place new rectangle as it extends beyond the grid")
        {

        }
    }
}