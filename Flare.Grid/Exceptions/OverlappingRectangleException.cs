
namespace Flare.Grid.Exceptions
{
    public class OverlappingRectangleException : Exception
    {
        public OverlappingRectangleException() :
            base("Cannot place new rectangle as it will be overlapping on an already existing rectangle")
        {

        }
    }
}
