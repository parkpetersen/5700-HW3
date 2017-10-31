using System;
using System.IO;
using AppLayer.DrawingComponents;

namespace AppLayer.Commands
{
    public class OpenCommand : Command
    {
        private readonly string _filename;
        Drawing OldDrawing;

        public OpenCommand(Drawing drawing, params object[] commandParameters)
        {
            OldDrawing = drawing;
            if (commandParameters.Length > 0)
                _filename = commandParameters[0] as string;
        }

        public override bool Execute()
        {
            TargetDrawing?.Clear();

            StreamReader reader = new StreamReader(_filename);
            TargetDrawing?.LoadFromStream(reader.BaseStream);
            reader.Close();

            return true;
        }

        public override void Undo()
        {
            TargetDrawing?.Clear();
            TargetDrawing = OldDrawing;
            TargetDrawing.IsDirty = true;
        }
    }
}
