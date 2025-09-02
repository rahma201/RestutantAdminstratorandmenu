namespace Pro2.View_Models
{
    public class MasterWorkingHourFullViewMdel
    {

        public int Id { get; set; }
        public string? MasterWorkingHoursIdName { get; set; }

        public string? MasterWorkingHoursIdTimeFormTo { get; set; }

        public bool IsActive { get; set; }

        public List<MasterWorkingHourViewMdel> MasterWorkingHourlist { get; set; }

    }
}
