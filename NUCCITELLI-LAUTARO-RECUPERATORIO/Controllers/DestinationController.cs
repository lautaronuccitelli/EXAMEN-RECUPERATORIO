using Models;
using Views;
using System.Collections.Generic;
namespace Controllers
{
    internal class DestinationController
    {
        public List<Destination> CreateDestination() => DestinationView.CreateDestination();
        public void ShowDestinations(List<Destination> list) => DestinationView.ShowDestination(list); 
    }
}
