using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SchoolManager.Models;
using SchoolManager.BLL;
using System.Web.Script.Serialization;

namespace SchoolWeb.Web.Handler
{
    /// <summary>
    /// GetStudent 的摘要说明
    /// </summary>
    public class GetStudent : IHttpHandler
    {
        YZJ_StatusBLL StaBLL = new YZJ_StatusBLL();
        YZJ_InfoBLL InforBLL = new YZJ_InfoBLL();
        JavaScriptSerializer js = new JavaScriptSerializer();

        public void ProcessRequest(HttpContext context)
        {
            context.Response.ContentType = "text/plain";
            if (context.Request.QueryString["action"] == "getStudent")
            {
                var id = context.Request.QueryString["Param"];
                var jsondata = GetStudentinfor(id);
                context.Response.Write(jsondata);
            }
            else if (context.Request.Form["Statusid"] != null)
            {
                YZJ_InfoModel inforModel = new YZJ_InfoModel
                {
                    
                    StdRollId = context.Request.Form["StdRollId"],
                    StdName = context.Request.Form["StdName"],
                    StdSex = context.Request.Form["StdSex"],                    
                    id = context.Request.Form["INforid"],
                    StdId = context.Request.Form["StdId"],
                    RepeatNo = context.Request.Form["RepeatNo"],
                    ClassNo = context.Request.Form["ClassNo"],
                    Entrance_Year = context.Request.Form["Entrance_Year"],
                    InResidence = Convert.ToBoolean(context.Request.Form["InResidence"]),
                    DormitoryBuilding = context.Request.Form["DormitoryBuilding"],
                    DormitoryNo = context.Request.Form["DormitoryNo"],
                    AddProvince = context.Request.Form["AddProvince"],
                    AddCity = context.Request.Form["AddCity"],
                    AddArea = context.Request.Form["AddArea"],
                    AddStreet = context.Request.Form["AddStreet"],
                    AddDetail = context.Request.Form["AddDetail"],
                };
                YZJ_StatusModel staModel = new YZJ_StatusModel
                {
                    id = context.Request.Form["Statusid"],
                    available=true,
                    StdRollId = context.Request.Form["StdRollId"],
                    StdName = context.Request.Form["StdName"],
                    StdSex = context.Request.Form["StdSex"],
                    native = context.Request.Form["native"],
                    nation = context.Request.Form["nation"],
                    Photo = null,
                    Entrance_Year = context.Request.Form["Entrance_Year"],
                    Household_Registration_Category = context.Request.Form["Household_Registration_Category"],
                    HouseholdAddress = context.Request.Form["HouseholdAddress"],
                    CurrentAddress = context.Request.Form["AddProvince"]+context.Request.Form["AddCity"]+ context.Request.Form["AddArea"]+ context.Request.Form["AddStreet"] + context.Request.Form["AddDetail"],
                    PhoneNumber = context.Request.Form["PhoneNumber"],
                    UrgentPhoneNumber = context.Request.Form["UrgentPhoneNumber"],
                    PaperType = context.Request.Form["PaperType"],
                    PaperNumber = context.Request.Form["PaperNumber"],
                    UsedName = context.Request.Form["UsedName"],
                    email = context.Request.Form["email"],
                    PostCode = context.Request.Form["PostCode"],
                    IsLeagueeMember = Convert.ToInt32(context.Request.Form["IsLeagueeMember"]),
                    IsYoungPineer = Convert.ToInt32(context.Request.Form["IsYoungPineer"]),
                    GuardianNo1 = context.Request.Form["GuardianNo1"],
                    G1PhoneNumber = context.Request.Form["G1PhoneNumber"],
                    G1Relationship = context.Request.Form["G1Relationship"],
                    GuardianNo2 = context.Request.Form["GuardianNo2"],
                    G2PhoneNumber = context.Request.Form["G2PhoneNumber"],
                    G2Relationship = context.Request.Form["G2Relationship"],
                    AlmaMater = context.Request.Form["AlmaMater"],
                    StdCategory = context.Request.Form["StdCategory"],
                    StatusState = context.Request.Form["StatusState"],
                };
                var flag1 = StaBLL.Edit(staModel);
                var flag2 = InforBLL.Edit(inforModel);
                var jsondata= js.Serialize(new { flag1 = flag1, flag2= flag2 });
                context.Response.Write(jsondata);
            }
        }
        
        string GetStudentinfor (string id)
        {
            YZJ_InfoModel inforModel = InforBLL.GetbyStdId(id);
            YZJ_StatusModel staModel = StaBLL.GetbyStdRoolId(inforModel.StdRollId);

            StudentModel stdModel = new StudentModel
            {
                Statusid = staModel.id,
                StdRollId = staModel.StdRollId,
                StdName = staModel.StdName,
                StdSex = staModel.StdSex,
                native = staModel.native,
                nation = staModel.nation,
                Entrance_Year = staModel.Entrance_Year,
                Household_Registration_Category = staModel.Household_Registration_Category,
                HouseholdAddress = staModel.HouseholdAddress,
                CurrentAddress = staModel.CurrentAddress,
                PhoneNumber = staModel.PhoneNumber,
                UrgentPhoneNumber = staModel.UrgentPhoneNumber,
                PaperType = staModel.PaperType,
                PaperNumber = staModel.PhoneNumber,
                UsedName = staModel.UsedName,
                email = staModel.email,
                PostCode = staModel.PostCode,
                IsLeagueeMember = staModel.IsLeagueeMember,
                IsYoungPineer = staModel.IsYoungPineer,
                GuardianNo1 = staModel.GuardianNo1,
                G1PhoneNumber = staModel.G1PhoneNumber,
                G1Relationship = staModel.G1Relationship,
                GuardianNo2 = staModel.GuardianNo2,
                G2PhoneNumber = staModel.G2PhoneNumber,
                G2Relationship = staModel.G2Relationship,
                AlmaMater = staModel.AlmaMater,
                StdCategory = staModel.StdCategory,
                StatusState = staModel.StatusState,
                //以上为学籍内容，以下为基本信息
                INforid = inforModel.id,
                StdId = inforModel.StdId,
                RepeatNo = inforModel.RepeatNo,
                ClassNo = inforModel.ClassNo,
                InResidence = inforModel.InResidence,
                DormitoryBuilding = inforModel.DormitoryBuilding,
                DormitoryNo = inforModel.DormitoryNo,
                AddProvince = inforModel.AddProvince,
                AddCity = inforModel.AddCity,
                AddArea = inforModel.AddArea,
                AddStreet = inforModel.AddStreet,
                AddDetail = inforModel.AddDetail,
            };
            return js.Serialize(new { model = stdModel });


        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }
    }
}