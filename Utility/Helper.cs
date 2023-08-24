using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;

namespace AMS.Utility
{
    public static class Helper
    {

        //Priority
        public static string Personal = "personal";
        public static string Home = "home";
        public static string Vehicle = "vehicle";

        //communicationType
        public static string Email = "email";
        public static string Sms = "sms";
        public static string Both = "both";

        //accomodataion type
        public static string studio = "studio";
        public static string one = "one room";
        public static string two = "two room";

        //yes no
        public static string yes = "yes";
        public static string no = "no";

        //owner
        public static string tenant = "tenant";
        public static string visitor = "visitor";
        public static string stuff = "stuff";

        public static List<SelectListItem> GetOwnerDropDown()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.tenant,Text=Helper.tenant},
                    new SelectListItem{Value=Helper.visitor,Text=Helper.visitor},
                    new SelectListItem{Value=Helper.stuff,Text=Helper.stuff},
                };
        }
        public static List<SelectListItem> GetYesNoDropDown()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.yes,Text=Helper.yes},
                    new SelectListItem{Value=Helper.no,Text=Helper.no},
                };
        }
        public static List<SelectListItem> GetRoomIntrestedDropDown()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.studio,Text=Helper.studio},
                    new SelectListItem{Value=Helper.one,Text=Helper.one},
                    new SelectListItem{Value=Helper.two,Text=Helper.two},
                };
        }
        public static List<SelectListItem> GetLoanTypeDropDown()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Personal,Text=Helper.Personal},
                    new SelectListItem{Value=Helper.Home,Text=Helper.Home},
                    new SelectListItem{Value=Helper.Vehicle,Text=Helper.Vehicle},
                };
        }

        public static List<SelectListItem> GetCommunicationTypeDropDown()
        {
            return new List<SelectListItem>
                {
                    new SelectListItem{Value=Helper.Email,Text=Helper.Email},
                    new SelectListItem{Value=Helper.Sms,Text=Helper.Sms},
                    new SelectListItem{Value=Helper.Both,Text=Helper.Both},
                };
        }


    }
}
