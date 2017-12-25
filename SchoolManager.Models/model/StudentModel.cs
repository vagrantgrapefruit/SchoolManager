using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolManager.Models
{
    public  class StudentModel
    {
        public   string Statusid { get; set; }
        public   string StdRollId { get; set; }
        public   string StdName { get; set; }
        public   string StdSex { get; set; }
        public   string native { get; set; }
        public   string nation { get; set; }
        public   string Entrance_Year { get; set; }
        public   string Household_Registration_Category { get; set; }
        public   string HouseholdAddress { get; set; }
        public   string CurrentAddress { get; set; }
        public   string PhoneNumber { get; set; }
        public   string UrgentPhoneNumber { get; set; }
        public   string PaperType { get; set; }
        public   string PaperNumber { get; set; }
        public   string UsedName { get; set; }
        public   string email { get; set; }
        public   string PostCode { get; set; }
        public   Nullable<int> IsLeagueeMember { get; set; }
        public   Nullable<int> IsYoungPineer { get; set; }
        public   string GuardianNo1 { get; set; }
        public   string G1PhoneNumber { get; set; }
        public   string G1Relationship { get; set; }
        public   string GuardianNo2 { get; set; }
        public   string G2PhoneNumber { get; set; }
        public   string G2Relationship { get; set; }
        public   string AlmaMater { get; set; }
        public   string StdCategory { get; set; }
        public   string StatusState { get; set; }
        public   string INforid { get; set; }
        //以上为学籍内容，以下为基本信息
        public   string StdId { get; set; }
        public   string RepeatNo { get; set; }
        public   string ClassNo { get; set; }
        public   Nullable<bool> InResidence { get; set; }
        public   string DormitoryBuilding { get; set; }
        public   string DormitoryNo { get; set; }
        public   string AddProvince { get; set; }
        public   string AddCity { get; set; }
        public   string AddArea { get; set; }
        public   string AddStreet { get; set; }
        public   string AddDetail { get; set; }
    }
}
