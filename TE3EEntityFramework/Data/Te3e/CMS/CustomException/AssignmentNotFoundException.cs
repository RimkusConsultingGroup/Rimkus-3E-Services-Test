using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TE3EEntityFramework.Data.Te3e.CMS.CustomException
{
    public class AssignmentNotFoundException : Exception
    {
        public AssignmentNotFoundException()
        {
        }

        public AssignmentNotFoundException(string message)
            : base(message)
        {
        }

        public AssignmentNotFoundException(string message, Exception inner)
            : base(message, inner)
        {
        }
    }
}
