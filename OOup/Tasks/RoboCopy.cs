using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public class RoboCopy : CommandLine
    {
        public RoboCopy(string source, string destination, bool MirrorEntireStructure=true) : base("ROBOCOPY", $"{source} {destination}{(MirrorEntireStructure ? " /MIR":"")}")
        {
        }
    }
}
