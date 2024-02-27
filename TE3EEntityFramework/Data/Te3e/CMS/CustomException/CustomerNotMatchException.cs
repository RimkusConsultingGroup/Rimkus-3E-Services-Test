using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.Te3e.CMS.CustomException
{
    public class CustomerNotMatchException : Exception
    {
        public CustomerNotMatchException()
        {
        }

        public CustomerNotMatchException(string message)
            : base(message)
        {
        }

        public CustomerNotMatchException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
