
namespace Flare.Grid.Exceptions
{
    using Flare.Grid.Models;

    public class RectangleWasNotFoundException : Exception
    {
        public RectangleWasNotFoundException(Position position) : 
            base(string.Format("No rectangle was found on the position ({0}, {1})", position.X, position.Y))
        {

        }
    }
}
