using System.Text;
using Newtonsoft.Json;
using OllamaBookingDemo.Models;

namespace OllamaBookingDemo.Services;

public interface IOllamaService
{
    Task<BookingIntent> GetBookingIntentAsync(string userInput);
}

public class OllamaService(HttpClient httpClient) : IOllamaService
{
    // 記得將此處的模型名稱換成您在本機下載的
    private const string ModelName = "llama3:8b-instruct-q4_K_M";
    private const string OllamaApiUrl = "http://localhost:11434/api/chat";

    public async Task<BookingIntent> GetBookingIntentAsync(string userInput)
    {
        string systemPrompt = @"
You are an expert meeting room booking assistant. Your task is to analyze the user's request and extract booking information.
You MUST respond ONLY with a valid JSON object. Do not add any introduction, explanation, or any text outside of the JSON object.
The JSON object must have two keys: ""intent"" and ""entities"".
Possible intents are: ""book_room"", ""query_booking"", ""cancel_booking"", ""unknown"".
The ""entities"" object should contain extracted information like ""room_name"", ""date"", ""start_time"", ""duration_minutes"".
Today's date is 2025-09-27.
If any information is missing, set its value to null.
";
        var requestPayload = new OllamaRequest
        {
            Model = ModelName,
            Messages =
            [
                new OllamaMessage { Role = "system", Content = systemPrompt },
                new OllamaMessage { Role = "user", Content = userInput }
            ],
            Format = "json",
            Stream = false
        };

        var jsonPayload = JsonConvert.SerializeObject(requestPayload);
        var content = new StringContent(jsonPayload, Encoding.UTF8, "application/json");

        try
        {
            var response = await httpClient.PostAsync(OllamaApiUrl, content);
            response.EnsureSuccessStatusCode();

            var responseString = await response.Content.ReadAsStringAsync();
            var ollamaResponse = JsonConvert.DeserializeObject<OllamaResponse>(responseString);

            // Ollama 回傳的 content 本身是一個 JSON 字串，需要再解析一次
            if (ollamaResponse?.Message?.Content == null) return null;
            var bookingIntent = JsonConvert.DeserializeObject<BookingIntent>(ollamaResponse.Message.Content);
            return bookingIntent;

        }
        catch (Exception ex)
        {
            // 實際應用中應該加入更完善的錯誤處理和日誌
            Console.WriteLine($"Error calling Ollama API: {ex.Message}");
            return null;
        }
    }
}