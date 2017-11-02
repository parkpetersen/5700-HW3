using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppLayer.DrawingComponents;
using System.Drawing;

namespace AppLayer.Commands
{
    public class NewDrawingCommand : Command
    {
        ClassSymbol[] OldClassSymbols;
        Relationship[] OldRelationships;
        string OldName;
        Color OldBackgroundColor;
        Color OldForegroundColor;
        Color OldClassColor;
        
        public NewDrawingCommand(Drawing drawing)
        {
            TargetDrawing = drawing;
            int size = TargetDrawing._ClassSymbols.Count();
            OldClassSymbols = new ClassSymbol[size];
            TargetDrawing._ClassSymbols.CopyTo(OldClassSymbols);

            size = TargetDrawing._RelationShipLines.Count();
            OldRelationships = new Relationship[size];
            TargetDrawing._RelationShipLines.CopyTo(OldRelationships);
            OldName = TargetDrawing.DrawingName;
            OldBackgroundColor = TargetDrawing.BackGroundColor;
            OldForegroundColor = TargetDrawing.ForeGroundColor;
            OldClassColor = TargetDrawing.DefaultClassColor;
        }

        public override bool Execute()
        {
            TargetDrawing.Clear();
            /**
            TargetDrawing._ClassSymbols.Clear();
            TargetDrawing._RelationShipLines.Clear();
    **/
            TargetDrawing.DrawingName = "New Drawing";
            TargetDrawing.BackGroundColor = Color.White;
            TargetDrawing.ForeGroundColor = Color.Black;
            TargetDrawing.DefaultClassColor = Color.LightBlue;
            TargetDrawing.IsDirty = true;
    
            return true;
        }

        public override void Undo()
        {
            //TargetDrawing._ClassSymbols = OldClassSymbols;
            foreach(var s in OldClassSymbols)
            {
                TargetDrawing.Add(s);
            }
            //TargetDrawing._RelationShipLines = OldRelationships;
            foreach(var l in OldRelationships)
            {
                TargetDrawing.Add(l);
            }
            TargetDrawing.DrawingName = OldName;
            TargetDrawing.BackGroundColor = OldBackgroundColor;
            TargetDrawing.ForeGroundColor = OldForegroundColor;
            TargetDrawing.DefaultClassColor = OldClassColor;
            TargetDrawing.IsDirty = true;
        }
    }
}
