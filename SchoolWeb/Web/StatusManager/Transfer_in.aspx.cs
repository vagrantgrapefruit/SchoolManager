using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SchoolManager.Models;
using SchoolManager.BLL;
using System.Web.Script.Serialization;
using SchoolManager.Common;


namespace SchoolWeb.Web.StatusManager
{
    public partial class Transfer_in : System.Web.UI.Page
    {
        static YZJ_StatusBLL StatusBLL = new YZJ_StatusBLL();
        static YZJ_CheckRecordBLL CheckRecordBLL = new YZJ_CheckRecordBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            switch(Request.QueryString["action"])
            {
                case "submit":
                    submit(Request.QueryString["StdRollId"], Request.QueryString["StdName"], Request.QueryString["StdSex"],
                        Request.QueryString["native"],Request.QueryString["nation"], Request.QueryString["HouseholdAddress"],
                        Request.QueryString["CurrAddress"], Request.QueryString["inputfile"], Request.QueryString["PhoneNumber"],
                        Request.QueryString["PaperNumber"], Request.QueryString["UsedName"], Request.QueryString["StdCategory"],
                        Request.QueryString["email"],Request.QueryString["PoseCode"], Request.QueryString["IsIEagueeMember"],
                        Request.QueryString["IsYoungPineer"], Request.QueryString["GuardianNo1"], Request.QueryString["G1PhoneNumber"],
                        Request.QueryString["G1Relationship"], Request.QueryString["GuardianNo2"], Request.QueryString["G2PhoneNumber"],
                        Request.QueryString["G2Relationship"], Request.QueryString["AlmaMater"],);
                    break;
            }
        }
        public void submit(string StdRollId,string StdName,string StdSex,string native,string nation,string HouseholdAdd,
            string CurrAddress,string photo,string PhoneNumber,string PaperNumber,string UsedName,string email,
            string PostCode,string IsLeagueeMember,string IsYoungPioneer,string GuardianNo1,string G1PhoneNumber,string Relationship,
            string GuardianNo2,string G2PhoneNumber,string G2Relationship,string AlmaMater,string StdCategory)

        {
            try
            {
                YZJ_StatusModel status = new YZJ_StatusModel();
              //  status.id = ResultHelper.NewId;
                status.available = true;
                status.StdRollId = StdRollId;
                status.StdName = StdName;
                status.StdSex = StdSex;
                status.native = native;
                status.nation = nation;
                status.HouseholdAddress = HouseholdAdd;
               

            }
            catch
            { }
        }
    }
}