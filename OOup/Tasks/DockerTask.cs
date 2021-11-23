using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOup.Tasks
{
    public class DockerTask : CommandLine
    {
        public DockerTask(DockerCommand dCommand, string command, string arguments) : base("docker", $"{dCommand.ToString()} {command} {arguments}")
        {

        }
    }
    public class DockerImageList : DockerTask
    {
        public DockerImageList(string arguments) : base(DockerCommand.images, "list", arguments)
        {
        }
    }

    public enum DockerCommand
    {
        builder,
        buildx,
        compose,
        config,
        container,
        context,
        image,
        manifest,
        network,
        node,
        plugin,
        scan,
        secret,
        service,
        stack,
        swarm,
        system,
        trust,
        volume,
        attach,
        build,
        commit,
        cp,
        create,
        diff,
        events,
        exec,
        export,
        history,
        images,
        import,
        info,
        inspect,
        kill,
        load,
        login,
        logout,
        logs,
        pause,
        port,
        ps,
        pull,
        push,
        rename,
        restart,
        rm,
        rmi,
        run,
        save,
        search,
        start,
        stats,
        stop,
        tag,
        top,
        unpause,
        update,
        version,
        wait,
    }
}
