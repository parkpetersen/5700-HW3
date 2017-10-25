using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.IO;
using System.Runtime.Serialization.Json;


namespace AppLayer.DrawingComponents
{
    public class Drawing
    {
        private List<ClassSymbol> _ClassSymbols = new List<ClassSymbol>();
        private List<Symbol> _RelationShipLines = new List<Symbol>();
        public Symbol SelectedSymbol { get; set; }
        public bool IsDirty { get; set; }

        private readonly object _myLock = new object();

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
                        _RelationShipLines.Add(symbol);
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
                        _RelationShipLines.Remove(symbol);
                        IsDirty = true;
                    }
                }
            }
        }

        public void SelectSymbolAtPosition(Point location)
        {
            if (SelectedSymbol != null)
                SelectedSymbol.IsSelected = false;
            //SelectedSymbol = FindSymbolAtPosition(location);

            if (SelectedSymbol != null)
                SelectedSymbol.IsSelected = true;

            IsDirty = true;
        }

        public Symbol FindSymbolAtPosition(Point location)
        { //needs work
            ClassSymbol result;
            lock (_myLock)
            {
                result = _ClassSymbols.FindLast(t => location.X >= t.Location.X &&
                                              location.X < t.Location.X + t.Size.Width &&
                                              location.Y >= t.Location.Y &&
                                              location.Y < t.Location.Y + t.Size.Height);

            }

            return result;
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
                    graphics.Clear(Color.White);
                    foreach (var s in _RelationShipLines)  //draw lines first
                        s.Draw(graphics);
                    foreach (var s in _ClassSymbols)
                        s.Draw(graphics);
                    IsDirty = false;
                    didARedraw = true;
                }
            }

            return didARedraw;
        }

        public void LoadFromStream(Stream stream)
        {

        }

        public void SaveToStream(Stream stream)
        {

        }
    }
}
