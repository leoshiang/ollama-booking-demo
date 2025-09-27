using Newtonsoft.Json;

namespace OllamaBookingDemo.Models;

// 對應到傳送給 Ollama API 的請求 body
public class OllamaRequest
{
    [JsonProperty("model")]
    public string Model { get; set; }

    [JsonProperty("messages")]
    public List<OllamaMessage> Messages { get; set; }

    [JsonProperty("format")]
    public string Format { get; set; }

    [JsonProperty("stream")]
    public bool Stream { get; set; }
}

public class OllamaMessage
{
    [JsonProperty("role")]
    public string Role { get; set; }

    [JsonProperty("content")]
    public string Content { get; set; }
}