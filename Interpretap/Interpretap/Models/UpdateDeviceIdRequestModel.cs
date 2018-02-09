using Newtonsoft.Json;

namespace Interpretap.Models
{
    public class UpdateDeviceIdRequestModel : BaseModel
    {
        [JsonProperty("device_id")]
        public string DeviceId { get; set; }
    }
}
