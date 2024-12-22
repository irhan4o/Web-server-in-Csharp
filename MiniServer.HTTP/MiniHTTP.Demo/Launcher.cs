using MiniServer.WebServer;
using MiniServer.WebServer.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniHTTP.Demo
{
    public class Launcher
    {
        public static void Main(string[] args)
        {
            IServerRoutingTable serverRoutingTable = new ServerRoutingTable();
            serverRoutingTable.Add
            (
                HTTP.Enums.HttpRequestMethod.Get,
                "/",
                request => new HomeController().Index(request)
            );
            Server server = new Server(8000, serverRoutingTable);
            server.Run();
        }
    }
}
