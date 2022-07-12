using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DoctorsDatabase.Web.Application.Commands
{
    public class RemoveAvailabilityCommand : ICommand
    {
        public string PWZ { get; set; }
        public int Id { get; set; }
    }
}
