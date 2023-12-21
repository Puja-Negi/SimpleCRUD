using Bulky.Model;
using Microsoft.AspNetCore.SignalR;
using System.Reactive.Subjects;

namespace BulkyWeb
{
    public class CategoryService
    {
        private readonly IHubContext<BulkyHub> _hubContext;
        private readonly Subject<Category> _updateStream = new Subject<Category>();

        public CategoryService(IHubContext<BulkyHub> hubContext)
        {
            _hubContext = hubContext;
            Program();
        }
        public void SendUpdate(Category data)
        {
            _updateStream.OnNext(data);
        }

        // Subscribe to the updates and send them to clients
        public void Program()
        {
            _updateStream.Subscribe(async data =>
            {
                await _hubContext.Clients.All.SendAsync("ReceiveUpdate", data);
            });
        }


    }
}
