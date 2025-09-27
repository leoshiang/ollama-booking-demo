using Newtonsoft.Json;

namespace OllamaBookingDemo.Models;

// 對應從 Ollama API 收到的回應 body
public class OllamaResponse
{
    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("created_at")]
    public string CreatedAt { get; set; }

    [JsonProperty("message")]
    public OllamaMessage Message { get; set; }

    [JsonProperty("done")]
    public bool Done { get; set; }
}