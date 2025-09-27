using Newtonsoft.Json;

namespace OllamaBookingDemo.Models;

public class BookingIntent
{
    [JsonProperty("intent")]
    public string Intent { get; set; }

    [JsonProperty("entities")]
    public BookingEntities Entities { get; set; }
}

public class BookingEntities
{
    [JsonProperty("room_name")]
    public string RoomName { get; set; }

    [JsonProperty("date")]
    public string Date { get; set; }

    [JsonProperty("start_time")]
    public string StartTime { get; set; }

    [JsonProperty("duration_minutes")]
    public int? DurationMinutes { get; set; }
}