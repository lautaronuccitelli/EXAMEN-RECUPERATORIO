using Models;
using Views;

namespace Controllers
{
    internal class ClientController
    {
        public Client LoadClient() => ClientView.CreateClient();
        public void ShowClient(Client c) => ClientView.ShowClient(c);
    }
}
