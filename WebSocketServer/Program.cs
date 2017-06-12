using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Fleck;
using Repository;
using Repository.Entities.ConnectionAndState;
using Router;
using Castle.Windsor.Installer;
using Castle.Windsor;

namespace WebSocketServer
{
    class Program
    {
        static List<IWebSocketConnection> _allSockets;

        static void Main(string[] args)
        {
            var container = new WindsorContainer();
            container.Install(FromAssembly.This());
            container.Install(FromAssembly.Named("Router"));
            container.Install(FromAssembly.Named("Repository"));
            //container.Install(FromAssembly.Named("Mapper"));

            //container.Register(Castle.MicroKernel.Registration.Component.For<Router.Router>().ImplementedBy<Router.Router>());
            //container.Register(Castle.MicroKernel.Registration.Component.For<Router.Styler>().ImplementedBy<Router.Styler>());
            //container.Register(Castle.MicroKernel.Registration.Component.For<Router.IStyler>().ImplementedBy<Router.IStyler>());
            //container.Register(Castle.MicroKernel.Registration.Component.For<Repository.MapRepo>().ImplementedBy<Repository.MapRepo>());

            var router = container.Resolve<Router.Router>();
        //    private readonly IRepository<State> _stateRepo;
        //private readonly IRepository<Connection> _connectionRepo;
        //private readonly IRepository<User> _userRepo;
        //private readonly IRepository<NavCategory> _navCategoryRepo;
        //private readonly IRepository<StatusBarItem> _statusBarRepo;
        //private readonly IRepository<Subscription> _subscriptionRepository;
        //private readonly IStyler _styler;


        _allSockets = new List<IWebSocketConnection>();
            var websocketServer = new Fleck.WebSocketServer("ws://127.0.0.1:58951");
            
            websocketServer.Start(socket =>
            {
                socket.OnOpen = () =>
                {
                    Console.WriteLine("Open!");
                    CreateConnection(socket);
                    _allSockets.Add(socket);
                };
                socket.OnClose = () =>
                {
                    Console.WriteLine("Close!");
                    DeleteConnection(socket);
                    _allSockets.Remove(socket);
                };
                socket.OnMessage = message =>
                {
                    switch (message)
                    {
                        case "seed":
                            var initializer = container.Resolve<Repository.SockMinInitializer>();
                            var context = container.Resolve<Repository.SockMinDbContext>();
                            initializer.Seed(context);
                            break;
                        case "query1":
                            socket.Send(@"content~<table><tr><td>Name</td><td>Address</td><td>Phone</td></tr>
                                    <tr><td>Jeff</td><td>the place</td><td>234234</td></tr></table>");
                            Console.WriteLine(message + " received");
                            break;
                        case "query2":
                            socket.Send(@"content~<table><tr><td>Year</td><td>Quarter</td><td>Sales(£k)</td></tr>
                                    <tr><td>2016</td><td>Q1</td><td>437</td></tr></table>");
                            Console.WriteLine(message + " received");
                            break;
                        case "query3":
                            socket.Send(@"content~<table><tr><td>Computer</td><td>Software</td><td>Version</td></tr>
                                    <tr><td>TG-IIS01</td><td>Amadeus</td><td>1.2.3</td></tr></table>");
                            Console.WriteLine(message + " received");
                            break;
                        case "query4":
                            socket.Send(@"content~
<svg class='chart' width='420' height='150' aria-labelledby='title desc' role='img'>
  <title id = 'title'> A bar chart showing information </title>
  <desc id = 'desc'> 4 apples; 8 bananas; 15 kiwis; 16 oranges; 23 lemons </desc>
     
       <g class='bar'>
    <rect width = '40' height='19'></rect>
    <text x = '45' y='9.5' dy='.35em'>4 apples</text>
  </g>
  <g class='bar'>
    <rect width = '80' height='19' y='20'></rect>
    <text x = '85' y='28' dy='.35em'>8 bananas</text>
  </g>
  <g class='bar'>
    <rect width = '150' height='19' y='40'></rect>
    <text x = '150' y='48' dy='.35em'>15 kiwis</text>
  </g>
  <g class='bar'>
    <rect width = '160' height='19' y='60'></rect>
    <text x = '161' y='68' dy='.35em'>16 oranges</text>
  </g>
  <g class='bar'>
    <rect width = '230' height='19' y='80'></rect>
    <text x = '235' y='88' dy='.35em'>23 lemons</text>
  </g>
</svg>");
                            Console.WriteLine(message + " received");
                            break;
                        case "query5":
                            socket.Send(@"content~<table><tr><td>Computer</td><td>Software</td><td>Version</td></tr>
                                    <tr><td>TG-IIS01</td><td>Amadeus</td><td>1.2.3</td></tr></table>");
                            Console.WriteLine(message + " received");
                            break;
                        default:
                            var command = message.Split(':');
                            switch (command[0])
                            {
                                case "updateState":
                                    router.ChangeConnectionState(socket,command[1]);
                                    break;
                                default:
                                    break;
                            }
                            socket.Send("messages~" + message + " received");
                            Console.WriteLine(message + " received");
                            break;
                    }
                };
            });
            while (true)
            {
                System.Threading.Thread.Sleep(10000);
                foreach (var socket in _allSockets.ToList())
                {
                    socket.Send("status~" + DateTime.UtcNow.ToString("o") + " all is well on connection " + socket.ConnectionInfo.Id);
                }
            }
        }

        private static void CreateConnection(IWebSocketConnection socket)
        {
            using (var context = new SockMinDbContext())
            {
                IRepository<State> states = new Repository<State>(context);
                var notLoggedInState = states.All().SingleOrDefault(s => s.Name == "NotLoggedIn");

                //will be null if database is not seeded yet
                if (notLoggedInState != null)
                {
                    IRepository<Connection> connections = new Repository<Connection>(context);
                    connections.Insert(new Connection
                    {
                        Id = Guid.NewGuid(),
                        UserId = new Guid(), //0000-0000-00000 when not logged in
                        CurrentState = notLoggedInState,
                        SocketIdentifier = socket.ConnectionInfo.Id
                    });
                    context.SaveChanges();
                }
            }
        }

        private static void DeleteConnection(IWebSocketConnection socket)
        {
            using (var context = new SockMinDbContext())
            {
                IRepository<Connection> connections = new Repository<Connection>(context);
                var connection = connections.Find(socket.ConnectionInfo.Id);
                connections.Delete(connection);
            }
        }

        public static void SendMessage(Connection connection, string message)
        {
            var socket = _allSockets.Single(s => s.ConnectionInfo.Id == connection.SocketIdentifier);
            socket.Send(message);
        }
    }
}