using System;

namespace Inspinia.Models
{
    public class WhatsAppMarketingCampaign
    {
        public int Id { get; set; }
        public string CampaignName { get; set; }
        public string Message { get; set; }
        public string TargetGroup { get; set; }
        public DateTime ScheduleDate { get; set; }
        public int Status { get; set; }
        public string Notes { get; set; }
    }
}