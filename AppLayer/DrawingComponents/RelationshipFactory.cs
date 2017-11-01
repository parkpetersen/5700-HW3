using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

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

        public Relationship Create(string type, Point location1, Point location2, Drawing drawing)
        {
            if(type == "Binary")
            {
                return new BinaryRelationship(location1, location2, drawing.ForeGroundColor);
            }
            else if(type == "Aggregation")
            {
                Symbol symbol = drawing.FindSymbolAtPosition(location1); //get the class symbol that is has the diamond on it.
                ClassSymbol classSymbol = symbol as ClassSymbol;
                return new AggregationRelationship(location1, location2, classSymbol, drawing.ForeGroundColor);
            }
            else if(type == "Composition")
            {
                Symbol symbol = drawing.FindSymbolAtPosition(location1); //get the class symbol that is has the diamond on it.
                ClassSymbol classSymbol = symbol as ClassSymbol;
                return new CompositionRelationship(location1, location2, classSymbol, drawing.ForeGroundColor);
            }
            else if(type == "Generalization")
            {
                Symbol symbol = drawing.FindSymbolAtPosition(location1); //get the class symbol that is has the triangle on it.
                ClassSymbol classSymbol = symbol as ClassSymbol;
                return new GeneralizationRelationship(location1, location2, classSymbol, drawing.ForeGroundColor);
            }
            else if(type == "Dependency")
            {
                return new DependencyRelationship(location1, location2, drawing.ForeGroundColor);
            }
            else
            {
                return null;
            }
            
        }
    }
}
