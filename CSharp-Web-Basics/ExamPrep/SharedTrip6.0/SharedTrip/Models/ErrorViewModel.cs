using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SharedTrip.Models
{
    public class ErrorViewModel
    {
        public string ErrorMessage { get; init; }

        public ErrorViewModel(string message)
        {
            ErrorMessage = message;
        }
    }
}
