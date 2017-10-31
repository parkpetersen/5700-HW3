using System;
using System.Runtime.Serialization.Json;
using System.IO;

namespace AppLayer.Commands
{
    public class SaveCommand : Command
    {
        private readonly string _filename;

        public SaveCommand(params object[] commandParameters)
        {
            if(commandParameters.Length > 0)
                _filename = commandParameters[0] as string;
        }

        public override bool Execute()
        {
            StreamWriter writer = new StreamWriter(_filename);
            TargetDrawing?.SaveToStream(writer.BaseStream);
            writer.Close();
            return true;
        }

        public override void Undo()
        {
            
        }
    }
}
