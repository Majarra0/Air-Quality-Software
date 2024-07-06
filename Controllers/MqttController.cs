using Google.Protobuf;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using uPLibrary.Networking.M2Mqtt.Messages;
using WebApplication8.Services;

namespace WebApplication8.Controllers
{
    [Route("api/[controller]")]
    public class MqttController : Controller
    {
        private readonly MqttService _mqttService;

        public MqttController(MqttService mqttService)
        {
            _mqttService = mqttService;
        }

        [HttpPost("connect")]
        public IActionResult Connect()
        {
            _mqttService.Connect();
            return Ok("Connected to MQTT broker.");
        }

        [HttpPost("subscribe")]
        public IActionResult Subscribe([FromBody] string topic)
        {
            _mqttService.Subscribe(topic);
            return Ok($"Subscribed to topic: {topic}");
        }

        [HttpPost("disconnect")]
        public IActionResult Disconnect()
        {
            _mqttService.Disconnect();
            return Ok("Disconnected from MQTT broker.");
        }
    }
}
