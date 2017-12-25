using SchoolManager.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.BLL
{
    public partial class YZJ_StatusBLL
    {
        public YZJ_StatusModel GetbyStdRoolId(string id)
        {
            IQueryable<YZJ_Status> queryData = null;
            if (!string.IsNullOrWhiteSpace(id))
            {
                queryData = m_Rep.GetList(
                                a => (a.StdRollId != null && a.StdRollId == id)
                                );
            }
            else
            {
                queryData = m_Rep.GetList();
            }
            List<YZJ_StatusModel> list = CreateModelList(ref queryData);
            return list[0];
        }
        public virtual List<YZJ_StatusModel> GetaviliableList(string queryStr)
        {

            IQueryable<YZJ_Status> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
                                a=>((a.id != null && a.id.Contains(queryStr))

                                || (a.StdRollId != null && a.StdRollId.Contains(queryStr))
                                || (a.StdName != null && a.StdName.Contains(queryStr))
                                || (a.StdSex != null && a.StdSex.Contains(queryStr))
                                || (a.native != null && a.native.Contains(queryStr))
                                || (a.nation != null && a.nation.Contains(queryStr))
                                || (a.Entrance_Year != null && a.Entrance_Year.Contains(queryStr))
                                || (a.Household_Registration_Category != null && a.Household_Registration_Category.Contains(queryStr))
                                || (a.HouseholdAddress != null && a.HouseholdAddress.Contains(queryStr))
                                || (a.CurrentAddress != null && a.CurrentAddress.Contains(queryStr))

                                || (a.PhoneNumber != null && a.PhoneNumber.Contains(queryStr))
                                || (a.UrgentPhoneNumber != null && a.UrgentPhoneNumber.Contains(queryStr))
                                || (a.PaperType != null && a.PaperType.Contains(queryStr))
                                || (a.PaperNumber != null && a.PaperNumber.Contains(queryStr))
                                || (a.UsedName != null && a.UsedName.Contains(queryStr))
                                || (a.email != null && a.email.Contains(queryStr))
                                || (a.PostCode != null && a.PostCode.Contains(queryStr))


                                || (a.GuardianNo1 != null && a.GuardianNo1.Contains(queryStr))
                                || (a.G1PhoneNumber != null && a.G1PhoneNumber.Contains(queryStr))
                                || (a.G1Relationship != null && a.G1Relationship.Contains(queryStr))
                                || (a.GuardianNo2 != null && a.GuardianNo2.Contains(queryStr))
                                || (a.G2PhoneNumber != null && a.G2PhoneNumber.Contains(queryStr))
                                || (a.G2Relationship != null && a.G2Relationship.Contains(queryStr))
                                || (a.AlmaMater != null && a.AlmaMater.Contains(queryStr))
                                || (a.StdCategory != null && a.StdCategory.Contains(queryStr))
                                || (a.StatusState != null && a.StatusState.Contains(queryStr)))&&(a.available==true));
            }
            else
            {
                queryData = m_Rep.GetList(a => (a.available == true));
            }
            return CreateModelList(ref queryData);
        }
        public virtual List<YZJ_StatusModel> GetNotaviliableList(string queryStr)
        {

            IQueryable<YZJ_Status> queryData = null;
            if (!string.IsNullOrWhiteSpace(queryStr))
            {
                queryData = m_Rep.GetList(
                                a => ((a.id != null && a.id.Contains(queryStr))

                                || (a.StdRollId != null && a.StdRollId.Contains(queryStr))
                                || (a.StdName != null && a.StdName.Contains(queryStr))
                                || (a.StdSex != null && a.StdSex.Contains(queryStr))
                                || (a.native != null && a.native.Contains(queryStr))
                                || (a.nation != null && a.nation.Contains(queryStr))
                                || (a.Entrance_Year != null && a.Entrance_Year.Contains(queryStr))
                                || (a.Household_Registration_Category != null && a.Household_Registration_Category.Contains(queryStr))
                                || (a.HouseholdAddress != null && a.HouseholdAddress.Contains(queryStr))
                                || (a.CurrentAddress != null && a.CurrentAddress.Contains(queryStr))

                                || (a.PhoneNumber != null && a.PhoneNumber.Contains(queryStr))
                                || (a.UrgentPhoneNumber != null && a.UrgentPhoneNumber.Contains(queryStr))
                                || (a.PaperType != null && a.PaperType.Contains(queryStr))
                                || (a.PaperNumber != null && a.PaperNumber.Contains(queryStr))
                                || (a.UsedName != null && a.UsedName.Contains(queryStr))
                                || (a.email != null && a.email.Contains(queryStr))
                                || (a.PostCode != null && a.PostCode.Contains(queryStr))


                                || (a.GuardianNo1 != null && a.GuardianNo1.Contains(queryStr))
                                || (a.G1PhoneNumber != null && a.G1PhoneNumber.Contains(queryStr))
                                || (a.G1Relationship != null && a.G1Relationship.Contains(queryStr))
                                || (a.GuardianNo2 != null && a.GuardianNo2.Contains(queryStr))
                                || (a.G2PhoneNumber != null && a.G2PhoneNumber.Contains(queryStr))
                                || (a.G2Relationship != null && a.G2Relationship.Contains(queryStr))
                                || (a.AlmaMater != null && a.AlmaMater.Contains(queryStr))
                                || (a.StdCategory != null && a.StdCategory.Contains(queryStr))
                                || (a.StatusState != null && a.StatusState.Contains(queryStr))) && (a.available == false));
            }
            else
            {
                queryData = m_Rep.GetList(a => (a.available == false));
            }
            return CreateModelList(ref queryData);
        }

        
    }
}
