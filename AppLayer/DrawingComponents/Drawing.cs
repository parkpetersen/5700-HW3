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
        private List<Symbol> _Symbols = new List<Symbol>();
        public Symbol SelectedSymbol { get; set; }
        public bool IsDirty { get; set; }

        private readonly object _myLock = new object();

        public void Clear()
        {
            lock (_myLock)
            {
                _Symbols.Clear();
                IsDirty = true;
            }
        }

        public void Add(Symbol symbol)
        {
            if(symbol != null)
            {
                lock (_myLock)
                {
                    _Symbols.Add(symbol);
                    IsDirty = true;
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
                    _Symbols.Remove(symbol);
                    IsDirty = true;
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
        { //needs work
            Symbol result;
            lock (_myLock)
            {
                
            }

            return result;
        }

        public void DeselectAll()
        {
            lock (_myLock)
            {
                foreach (var s in _Symbols)
                    s.IsSelected = false;
                IsDirty = true;
                SelectedSymbol = null;
            }
        }

        public void DeleteAllSelected()
        {
            lock (_myLock)
            {
                _Symbols.RemoveAll(s => s.IsSelected);
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
                    foreach (var s in _Symbols)
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
