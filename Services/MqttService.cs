using uPLibrary.Networking.M2Mqtt.Messages;
using System;
using uPLibrary.Networking.M2Mqtt;
using uPLibrary.Networking.M2Mqtt.Messages;
using Microsoft.Extensions.Hosting;
using WebApplication8.Data;
using WebApplication8.Repository.IRepository;
namespace WebApplication8.Services
{
    public class MqttService
    {
        private MqttClient _mqttClient;
        private readonly Imessage m;

        public MqttService(string brokerIpAddress)
        {
            _mqttClient = new MqttClient("broker.hivemq.com");
            _mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
        }

        public MqttService(string brokerIpAddress, Imessage me )
        {
            _mqttClient = new MqttClient("broker.hivemq.com");
            _mqttClient.MqttMsgPublishReceived += MqttClient_MqttMsgPublishReceived;
            m = me;
        }

        private void MqttClient_MqttMsgPublishReceived(object sender, MqttMsgPublishEventArgs e)
        {
            // Handle received MQTT messages here
            Console.WriteLine($"Received message from topic '{e.Topic}': {System.Text.Encoding.UTF8.GetString(e.Message)}");
            // Optionally, raise an event or perform other processing
            m.postMessage("Received message from topic '{e.Topic}': {System.Text.Encoding.UTF8.GetString(e.Message)}");
        }

        public void Connect()
        {
            _mqttClient.Connect(Guid.NewGuid().ToString());
        }

        public void Subscribe(string topic)
        {
            _mqttClient.Subscribe(new string[] { topic }, new byte[] { MqttMsgBase.QOS_LEVEL_AT_LEAST_ONCE });
        }

        public void Disconnect()
        {
            _mqttClient.Disconnect();
        }
    }
}