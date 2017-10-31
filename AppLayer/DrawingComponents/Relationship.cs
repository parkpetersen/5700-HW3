using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public abstract class Relationship : Symbol
    {
        [DataMember]
        public virtual Point Location1 { get; set; } = new Point(0, 0);
        [DataMember]
        public virtual Point Location2 { get; set; } = new Point(0, 0);

        public void MoveLine(Point oldLocation, Point newLocation)
        {
            if(Location1 == oldLocation)
            {
                Location1 = newLocation;
            }
            else if(Location2 == oldLocation)
            {
                Location2 = newLocation;
            }
        }

    }
}
