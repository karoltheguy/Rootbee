using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RootBee
{
    /// <summary>
    /// A thrown exception type when the API returns the error message model response
    /// </summary>
    class ApiException : Exception
    {
        public EcobeeError ErrorMessage { get; set; }

        public ApiException(EcobeeError error) : base(error.error_description)
        {
            ErrorMessage = error;
        }

    }
}
