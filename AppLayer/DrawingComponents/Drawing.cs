using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;


namespace AppLayer.DrawingComponents
{
    [DataContract]
    [KnownType(typeof(AggregationRelationship))]
    [KnownType(typeof(BinaryRelationship))]
    [KnownType(typeof(CompositionRelationship))]
    [KnownType(typeof(DependencyRelationship))]
    [KnownType(typeof(GeneralizationRelationship))]
    [KnownType(typeof(AggregationRelationship))]
    public class Drawing
    {
        [DataMember]
        public List<ClassSymbol> _ClassSymbols = new List<ClassSymbol>();
        [DataMember]
        public List<Relationship> _RelationShipLines = new List<Relationship>();
        [DataMember]
        public string DrawingName { get; set; } = "New Drawing";
        [DataMember]
        public Color BackGroundColor { get; set; } = Color.White;
        [DataMember]
        public Color ForeGroundColor { get; set; } = Color.Black;
        [DataMember]
        public Color DefaultClassColor { get; set; } = Color.LightBlue;
        public Symbol SelectedSymbol { get; set; }
        public bool IsDirty { get; set; }

        private readonly object _myLock = new object();

        private static readonly DataContractJsonSerializer JsonSerializer =
            new DataContractJsonSerializer(typeof(Drawing));



        public void Clear()
        {
            lock (_myLock)
            {
                _ClassSymbols.Clear();
                _RelationShipLines.Clear();
                IsDirty = true;
            }
        }

        public void Add(Symbol symbol)
        {
            if(symbol != null)
            {
                lock (_myLock)
                {
                    if (symbol.type == "Class")
                    {
                        ClassSymbol classSymbol = symbol as ClassSymbol;
                        _ClassSymbols.Add(classSymbol);
                        IsDirty = true;
                    }
                    else
                    {
                        Relationship relationship = symbol as Relationship;
                        _RelationShipLines.Add(relationship);
                        IsDirty = true;
                    }
                }
            }
        }

        public void RemoveSymbol(Symbol symbol)
        {
            if(symbol != null)
            {
                lock (_myLock)
                {
                    if (SelectedSymbol == symbol)
                        SelectedSymbol = null;
                    if (symbol.type == "Class")
                    {
                        ClassSymbol classSymbol = symbol as ClassSymbol;
                        _ClassSymbols.Remove(classSymbol);
                        IsDirty = true;
                    }
                    else
                    {
                        Relationship relationship = symbol as Relationship;
                        _RelationShipLines.Remove(relationship);
                        IsDirty = true;
                    }
                }
            }
        }

        public void SelectSymbolAtPosition(Point location)
        {
            if (SelectedSymbol != null)
                SelectedSymbol.IsSelected = false;
            SelectedSymbol = FindSymbolAtPosition(location);

            if (SelectedSymbol != null)
                SelectedSymbol.IsSelected = true;

            IsDirty = true;
        }

        public Symbol FindSymbolAtPosition(Point location)
        {
            Symbol result = null;
            lock (_myLock)
            {
                foreach (var s in _ClassSymbols)
                {
                    if (location.X >= s.Location.X - (s.Size.Width / 2) &&
                        location.X < s.Location.X - (s.Size.Width / 2) + s.Size.Width &&
                        location.Y >= s.Location.Y - (s.Size.Height/2) &&
                        location.Y < s.Location.Y - (s.Size.Height/2) + s.Size.Height)
                    {
                        result = s;
                    }
                }
                foreach(var l in _RelationShipLines)
                {
                    if(location.X >= ((l.Location2.X + l.Location1.X) / 2) - 40 &&
                        location.X < ((l.Location2.X + l.Location1.X) / 2) + 40 &&
                        location.Y >= ((l.Location2.Y + l.Location1.Y) / 2) - 40 &&
                        location.Y < ((l.Location2.Y + l.Location1.Y) / 2) + 40)
                    {
                        result = l;
                    } 
                }

            }
            return result;
        }

        public void DeleteConnectedLines(ClassSymbol classSymbol)
        {
            lock (_myLock)
            {
                for(int i = 0; i < _RelationShipLines.Count; i++)
                {
                    if (_RelationShipLines[i].Location1 == classSymbol.Location || _RelationShipLines[i].Location2 == classSymbol.Location)
                    {
                        RemoveSymbol(_RelationShipLines[i]);
                    }
                }
            }
        }

        public void DeselectAll()
        {
            lock (_myLock)
            {
                foreach (var s in _ClassSymbols)
                    s.IsSelected = false;
                foreach (var s in _RelationShipLines)
                    s.IsSelected = false;
                IsDirty = true;
                SelectedSymbol = null;
            }
        }

        public void DeleteAllSelected()
        {
            lock (_myLock)
            {
                _ClassSymbols.RemoveAll(s => s.IsSelected);
                _RelationShipLines.RemoveAll(s => s.IsSelected);

            }
        }

        public void RemoveSelectedSymbols()
        {
            if(SelectedSymbol != null)
            {
                RemoveSymbol(SelectedSymbol);
                SelectedSymbol = null;
            }
        }

        public bool Draw(Graphics graphics)
        {
            bool didARedraw = false;
            lock (_myLock)
            {
                if (IsDirty)
                {
                    graphics.Clear(BackGroundColor);
                    foreach (var s in _RelationShipLines)  //draw lines first
                    {
                        s.Draw(graphics);
                    }
                    foreach (var s in _ClassSymbols)
                    {
                        s.Draw(graphics);
                    }
                    IsDirty = false;
                    didARedraw = true;
                }
            }

            return didARedraw;
        }

        public void LoadFromStream(Stream stream)
        {
            _ClassSymbols.Clear();
            _RelationShipLines.Clear();
            var loadedSymbols = JsonSerializer.ReadObject(stream) as Drawing;

            lock (_myLock)
            {
                this._ClassSymbols = loadedSymbols._ClassSymbols;
                this._RelationShipLines = loadedSymbols._RelationShipLines;
                this.BackGroundColor = loadedSymbols.BackGroundColor;
                this.ForeGroundColor = loadedSymbols.ForeGroundColor;
                this.DefaultClassColor = loadedSymbols.DefaultClassColor;
                this.DrawingName = loadedSymbols.DrawingName;
                IsDirty = true;
            }
        }

        public void SaveToStream(Stream stream)
        {
            lock (_myLock)
            {
                JsonSerializer.WriteObject(stream, this);
            }
        }

        public void EditDiagramOptions(string newName, Color newBackgroundColor, Color newForegroundColor, Color newClassColor)
        {
            DrawingName = newName;
            BackGroundColor = newBackgroundColor;
            ForeGroundColor = newForegroundColor;
            DefaultClassColor = newClassColor;
        }
    }
}
