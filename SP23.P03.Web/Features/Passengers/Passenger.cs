using System.ComponentModel.DataAnnotations.Schema;
using SP23.P03.Web.Features.Authorization;

namespace SP23.P03.Web.Features.Passengers
{
    public class Passenger
    {
        //do we want to implement a max/min age for children and seniors for different ticket prices??
        public int Id { get; set; }
        public int OwnerId { get; set; }
        public required virtual User Owner { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateTimeOffset Birthday { get; set; }

       
        
    }
}
