using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public class DockerTask : CommandLine
    {
        public DockerTask(string command, string arguments) : base("docker", $"{command} {arguments}")
        {

        }
    }
    public class DockerImageList : DockerTask
    {
        public DockerImageList(string arguments) : base("images list", arguments)
        {
        }
    }
}
