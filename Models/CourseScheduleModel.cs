using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassVenueInfo.Models
{
    public class CourseScheduleModel
    {
        public String CourseTitle { get; set; }

        public String ScheduleLocation { get; set; }

        public String SessionFacilityCategory { get; set; }

        public String SessionFacilityName { get; set; }

        public String ScheduleStartDateTime { get; set; }

        public String ScheduleEndDateTime { get; set; }

        public String ScheduleId { get; set; }

        public int SessionNum { get; set; }

        public String SessionFirstDate { get; set; }

        public String SessionLastDate { get; set; }

        public String SessionCurrentDate { get; set; }

        public String SessionCurrentStartTime { get; set; }

        public DateTime SessionCurrentStartDateTime { get; set; }

        public String SessionCurrentEndTime { get; set; }

        public List<String> SessionIdList { get; set; }

        public String DisplayTitle { get; set; }
    }

    public class CourseScheduleModels
    {
        public List<CourseScheduleModel> CourseScheduleModel { get; set; }
    }
}