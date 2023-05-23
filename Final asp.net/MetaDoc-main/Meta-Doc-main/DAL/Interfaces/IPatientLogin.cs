using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Interfaces
{
    public interface IPatientLogin <RET, TYPE>
    {
        RET Match(TYPE username);
    }
}
