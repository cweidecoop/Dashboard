using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Dashboard.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the DashboardUser class
    public class DashboardUser : IdentityUser
    {
        [PersonalData]
        public int UserID{ get; set; }

        [PersonalData]
        public string FirstName { get; set; }
        
        [PersonalData]
        public string LastName { get; set; }

        [PersonalData]
        public DateTime StartDate { get; set; }
        
        [PersonalData]
        public string SupervisorName { get; set; }
        
        [PersonalData]
        public int SupervisorID { get; set; }

        [PersonalData]
        public int DistrictNumber { get; set; }

        [PersonalData]
        public int Tier { get; set; }

        [PersonalData]
        public int InserviceRequired { get; set; }

        [PersonalData]
        public int InserviceCompleted { get; set; }

        [PersonalData]
        public int InserviceTimeRemaining { get; set; }
    }
}
