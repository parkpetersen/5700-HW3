using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Serialization;

namespace AppLayer.DrawingComponents
{
    [DataContract]
    public abstract class Symbol
    {
        [DataMember]
        public string type { get; set; }
        public virtual bool IsSelected { get; set; } = false;
        public virtual void Draw(Graphics graphics) { }
        [DataMember]
        public string label { get; set; }
        public virtual void Randomize() { }

    }
}
