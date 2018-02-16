using BupaAssignment.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace BupaAssignment.Repository
{
    public interface IprogramRepository
    {
        IEnumerable<BupaProgram> GetPrograms(bool isPaid);

        BupaProgram GetProgramDetails(int Id);

        bool isPaidProgram(int Id);
    }
}