using System.Web.Mvc;

namespace DoAnCN.Areas.Admin
{
    public class AdminAreaRegistration : AreaRegistration 
    {
        public override string AreaName 
        {
            get 
            {
                return "AdminV";
            }
        }

        public override void RegisterArea(AreaRegistrationContext context) 
        {
            
           
            
            context.MapRoute(
                "Admin_default",
                "Admin/{ controller}/{ action}/{ id}",
                new { controller = "Dashboard", action = "Homea", id = UrlParameter.Optional }
            );
        }
       


    }
}