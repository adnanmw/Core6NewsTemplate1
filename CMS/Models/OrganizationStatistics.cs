using System.ComponentModel.DataAnnotations;

namespace CMS.Models
{
    public class OrganizationStatistics
    {
        public int Id { get; set; }

        [Range(0, 1000000, ErrorMessage = "Statistics must be between 0 and 1000000.")]
        public int Statistics { get; set; }

        [Range(0, 1000000, ErrorMessage = "Committees must be between 0 and 1000000.")]
        public int Committees { get; set; }

        [Range(0, 1000000, ErrorMessage = "Team members must be between 0 and 1000000.")]
        public int TeamMembers { get; set; }

        [Range(0, 1000000, ErrorMessage = "Beneficiaries must be between 0 and 1000000.")]
        public int Beneficiaries { get; set; }

        [Range(0, 1000000, ErrorMessage = "Scientific activities must be between 0 and 1000000.")]
        public int ScientificActivities { get; set; }
    }
}
