namespace CVproject.Models
{
    public class MasterEducation : BaseEntity
    {

        /// Major
        /// Description
        /// Place
        /// StartDate 
        /// EndDate
        /// IsExperience
        /// IsCurrent

        public string Major { get; set; }
        public string Description { get; set; }
        public string Place { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public bool IsExperience { get; set; }
        public bool IsCurrent { get; set; }


    }
}
