using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SchoolManager.Models;
using System.Linq.Expressions;

namespace SchoolManager.BLL
{
    public partial class wyqstudentBLL
    {
        public List<wyqstudentModel> GetList(Expression<Func<wyqstudent, bool>> whereLambda)
        {
            var query = m_Rep.GetList(whereLambda);
            return CreateModelList(ref query);
        }
    }
}
