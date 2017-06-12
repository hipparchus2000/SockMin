using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repository;
using Repository.Entities;
using Repository.Entities.ConnectionAndState;
using Repository.Entities.Html;
using Repository.Entities.UserAndPermissions;
using Fleck;

namespace Router
{
    public class Router
    {
        private readonly IRepository<State> _stateRepo;
        private readonly IRepository<Connection> _connectionRepo;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<NavCategory> _navCategoryRepo;
        private readonly IRepository<StatusBarItem> _statusBarRepo;
        private readonly IRepository<Subscription> _subscriptionRepository;
        private readonly IStyler _styler;

        public Router(IRepository<State> stateRepo, IRepository<Connection> connectionRepo, IRepository<User> userRepo, 
            IRepository<NavCategory> navCategoryRepo, IRepository<StatusBarItem> statusBarRepo,
            IRepository<Subscription> subscriptionRepository, IStyler styler)
        {
            _stateRepo = stateRepo;
            _connectionRepo = connectionRepo;
            _userRepo = userRepo;
            _navCategoryRepo = navCategoryRepo;
            _statusBarRepo = statusBarRepo;
            _subscriptionRepository = subscriptionRepository;
            _styler = styler;
        }

        public void ChangeConnectionState(IWebSocketConnection socket, string newStateName)
        {
            var connection = _connectionRepo.All().Single(c => c.SocketIdentifier == socket.ConnectionInfo.Id);
            var newState = _stateRepo.All().Single(c => c.Name == newStateName);
            ChangeConnectionState(socket, connection.Id, newState.Id);
        }

        public void ChangeConnectionState(IWebSocketConnection socket, Guid connectionId, Guid newStateId)
        {
            //take existing connection, lookup current state, find legal future states based on state and permissions and check new state against this
            var user = _connectionRepo.All().Single(c => c.Id == connectionId).User;
            if (user.Roles != null)
            {
                var permissions = user.Roles.SelectMany(p => p.Permissions).ToList();
                var futureLegalStates = _stateRepo.All();
            }

            //TODO sort out how to do this
            //var futureLegalStates = _stateRepo.All().Single(s=>s.Id == _connectionRepo.All()
            //    .Single(c => c.Id == connectionId).CurrentStateId).LegalNextStates.ToList();

            //foreach (var futureLegalState in futureLegalStates)
            //    if (permissions.Contains(futureLegalState.RequiredPermissionForThisState) == false)
            //        futureLegalStates.Remove(futureLegalState);

            var newState = _stateRepo.All().Single(s=>s.Id == newStateId);

            //if (!futureLegalStates.Contains(newState))
            //{
            //    SendError(socket, connectionId, "failed to change state - the requested new state is invalid");
            //}

            var currentConnectionState = _connectionRepo.All().Single(c => c.Id == connectionId).CurrentState;
            var navCategories = _navCategoryRepo.All().Where(nc => nc.VisibleInStates.Contains(currentConnectionState)).OrderBy(i=>i.Name).ToArray();
            var statusBarItems = _statusBarRepo.All().Where(nc => nc.VisibleInStates.Contains(currentConnectionState)).OrderBy(i => i.Name).ToArray();
            var subscriptions = _subscriptionRepository.All().Where(nc => nc.VisibleInStates.Contains(currentConnectionState)).OrderBy(i => i.Name).ToArray();

            var newNavCategories = _navCategoryRepo.All().Where(nc => nc.VisibleInStates.Contains(currentConnectionState)).OrderBy(i => i.Name).ToArray();
            var newStatusBarItems = _statusBarRepo.All().Where(nc => nc.VisibleInStates.Contains(currentConnectionState)).OrderBy(i => i.Name).ToArray();
            var newSubscriptions = _subscriptionRepository.All().Where(nc => nc.VisibleInStates.Contains(currentConnectionState)).OrderBy(i => i.Name).ToArray();

            //todo better to implement these as subscriptions with changeDetector pushing changes
            if (!newNavCategories.SequenceEqual(navCategories))
                SendConnectionUpdateNav(socket, connectionId, newNavCategories);

            if (!newStatusBarItems.SequenceEqual(statusBarItems))
                SendConnectionUpdateStatusBar(socket, connectionId, newStatusBarItems);

            if (!newSubscriptions.SequenceEqual(subscriptions))
                SendConnectionUpdateSubscriptions(socket, connectionId, newSubscriptions);
            
        }

        private void SendConnectionUpdateSubscriptions(IWebSocketConnection socket, Guid connectionId, Subscription[] newSubscriptions)
        {
            //TODO

            //foreach(var subscription in newSubscriptions)
            //{
            //    socket.Send(_styler.MakeHtmlForSubscription(connectionId, subscription));
            //}
        }

        private void SendConnectionUpdateStatusBar(IWebSocketConnection socket, Guid connectionId, StatusBarItem[] newStatusBarItems)
        {
            socket.Send(_styler.MakeHtmlForStatusBar(connectionId,newStatusBarItems));
        }

        private void SendConnectionUpdateNav(IWebSocketConnection socket, Guid connectionId, NavCategory[] newNavCategories)
        {
            socket.Send(_styler.MakeHtmlForNav(connectionId, newNavCategories));
        }

        private void SendError(IWebSocketConnection socket, Guid connectionId, string failedToChangeStateTheRequestedNewStateIsInvalid)
        {
            socket.Send(_styler.MakeErrorMessage(connectionId, failedToChangeStateTheRequestedNewStateIsInvalid));
        }
    }
}
