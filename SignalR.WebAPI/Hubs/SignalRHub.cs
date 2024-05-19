using Microsoft.AspNetCore.SignalR;
using SignalR.DataAccessLayer.Concrete;

namespace SignalR.WebAPI.Hubs
{
    public class SignalRHub:Hub
    {
        SignalRContex contex = new SignalRContex();

        public async Task SendCategorySound()
        {
            var value = contex.Categories.Count();

            await Clients.All.SendAsync("RecieveCategoryCount", value);
        }
    }
}
