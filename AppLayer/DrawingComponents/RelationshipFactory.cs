using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AppLayer.DrawingComponents
{
    public class RelationshipFactory
    {
        private static RelationshipFactory _instance;
        private static readonly object MyLock = new object();

        private RelationshipFactory() { }

        public static RelationshipFactory Instance
        {
            get
            {
                lock (MyLock)
                {
                    if (_instance == null)
                        _instance = new RelationshipFactory();
                }
                return _instance;
            }
        }

        public Relationship Create(string type)
        {
            if(type == "Binary")
            {
                return new BinaryRelationship();
            }
            else
            {
                return null;
            }
            
        }
    }
}
