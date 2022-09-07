using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ClassVenueInfo.Models
{
    public class VenueModels
    {
        public List<VenueModel> VenueModel { get; set; }
    }

    public class VenueModel
    {
        public string CourseCode { get; set; }
        public string CourseDesc { get; set; }
        public string ClassTime { get; set; }
        public string ClassTimeCode { get; set; }
        public string ClassDate { get; set; }
        public string RoomCode { get; set; }
        public string RoomType { get; set; }
    }
}