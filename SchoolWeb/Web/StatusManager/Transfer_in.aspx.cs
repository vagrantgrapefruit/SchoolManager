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
                        Request.QueryString["CurrAddress"], Request.QueryString["PhoneNumber"],/*Request.QueryString["Photo"],*/
                        Request.QueryString["PaperNumber"], Request.QueryString["UsedName"], Request.QueryString["StdCategory"],
                        Request.QueryString["email"],Request.QueryString["PoseCode"], Request.QueryString["IsIEagueeMember"],
                        Request.QueryString["IsYoungPineer"], Request.QueryString["GuardianNo1"], Request.QueryString["G1PhoneNumber"],
                        Request.QueryString["G1Relationship"], Request.QueryString["GuardianNo2"], Request.QueryString["G2PhoneNumber"],
                        Request.QueryString["G2Relationship"], Request.QueryString["AlmaMater"]);
                    break;
            }
        }
        public void submit(string StdRollId,string StdName,string StdSex,string native,string nation,string HouseholdAdd,
            string CurrAddress,string PhoneNumber,/*string photo,*/string PaperNumber,string UsedName,string email,
            string PostCode,string IsLeagueeMember,string IsYoungPioneer,string GuardianNo1,string G1PhoneNumber,string G1Relationship,
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
                status.CurrentAddress = CurrAddress;
             //   status.Photo = Convert.ToByte[](photo);
                status.PhoneNumber = PhoneNumber;
                status.PaperNumber = PaperNumber;
                status.UsedName = UsedName;
                status.email = email;
                status.PostCode = PostCode;
                status.IsLeagueeMember = Convert.ToInt16(IsLeagueeMember);
                status.IsYoungPineer =  Convert.ToInt16(IsYoungPioneer);
                status.GuardianNo1 = GuardianNo1;
                status.G1PhoneNumber = G1PhoneNumber;
                status.G1Relationship = G1Relationship;
                status.G2PhoneNumber = G2PhoneNumber;
                status.G2Relationship = G2Relationship;
                status.AlmaMater = AlmaMater;

                bool flag = StatusBLL.Create(status);

                Response.Clear();
                Response.Write("{'flag':" + flag + "}");
                Response.End();


            }
            catch
            { }
        }
    }
}