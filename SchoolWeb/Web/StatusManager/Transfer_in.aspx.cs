﻿using System;
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
        protected void Page_Load(object sender, EventArgs e)
        {
            switch (Request.QueryString["action"])
            {
                case "transferIn":
                    transferIn(Request.QueryString["StdRollId"], Request.QueryString["StdName"],Request.QueryString["StdSex"],
                                 Request.QueryString["native"], Request.QueryString["nation"],
                                 Request.QueryString["HouseholdAddress"],Request.QueryString["CurrAddress"],
                                 Request.QueryString["PhoneNumber"],Request.QueryString["PaperNumber"], 
                                 Request.QueryString["UsedName"], Request.QueryString["StudentCategory"],
                                 Request.QueryString["email"], Request.QueryString["PostCode"],
                                 Request.QueryString["IsLeagueeMember"],Request.QueryString["IsYoungPineer"],
                                 Request.QueryString["GuardianNO1"], Request.QueryString["G1PhoneNumber"],
                                 Request.QueryString["G1Relationship"], Request.QueryString["GuardianNO2"], Request.QueryString["G2PhoneNumber"],
                                 Request.QueryString["G2Relationship"], Request.QueryString["AlmaMater"]
                    );
                    break;
            }
        }
        public void transferIn(string StdRollId,string StdName,string StdSex,string native, string nation ,
                                string HouseholdAddress, string CurrAddress, string PhoneNumber,
                              string PaperNumber, string UsedName,  string StudentCategory,
                               string email, string PostCode,string IsLeagueeMember,string IsYoungPineer,
                               string GuardianNO1, string G1PhoneNumber, string G1Relationship,string GuardianNO2,
                               string G2PhoneNumber, string G2Relationship, string AlmaMater
            )
        {
            try
            {
                YZJ_StatusModel status = new YZJ_StatusModel();
                status.id = ResultHelper.NewId;
                status.available = true;
                status.StdRollId = StdRollId;
                status.StdName = StdName;
                status.StdSex = StdSex;
                status.native = native;
                status.nation = nation;
                status.HouseholdAddress = HouseholdAddress;
                status.CurrentAddress = CurrAddress;
                status.PhoneNumber = PhoneNumber;
                status.PaperNumber = PaperNumber;
                status.UsedName = UsedName;
                status.email = email;
                status.PostCode = PostCode;
                if (IsLeagueeMember == "是")
                {
                    status.IsLeagueeMember = 1;
                }
                else
                {
                    status.IsLeagueeMember = 0;
                }
                if (IsYoungPineer == "是")
                {
                    status.IsYoungPineer = 1;
                }
                else
                {
                    status.IsYoungPineer = 0;
                }

                
                status.GuardianNo1 = GuardianNO1;
                status.G1PhoneNumber = G1PhoneNumber;
                status.G1Relationship = G1Relationship;
                status.GuardianNo2 = GuardianNO2;
                status.G2PhoneNumber = G2PhoneNumber;
                status.G2Relationship = G2Relationship;
                DateTime dt = new DateTime();
                status.Entrance_Year = dt.Year.ToString();
                status.AlmaMater = AlmaMater;
                status.StdCategory = StudentCategory;

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