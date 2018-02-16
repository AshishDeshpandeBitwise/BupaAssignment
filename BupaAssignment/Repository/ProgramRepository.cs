using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using BupaAssignment.Data;

namespace BupaAssignment.Repository
{
    public class ProgramRepository
    {
        BupaEntities context = new BupaEntities();

        public IEnumerable<BupaProgram> GetPrograms(bool isPaid)
        {
            return context.BupaPrograms.Where(p => p.IsPaidProgram == isPaid).ToList();
        }

        public BupaProgram GetProgramDetails(int Id)
        {
            return context.Set<BupaProgram>().Find(Id);
        }

        public bool isPaidProgram(int Id)
        {
            return context.BupaPrograms
                          .Where(p => p.ProgramId == Id)
                          .Where(p => p.IsPaidProgram == true)
                          .Any();
        }
    }
}