using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Encapsulation.Extra
{
    public class SmartDevice
    {
        private string _deviceName;
        private double _batteryPercentage;
        private bool _isOn;
        private double _memoryUsage;
        private readonly double _totalMemory;

        public string DeviceName
        {
            get { return _deviceName; }
            set { _deviceName = string.IsNullOrEmpty(value) ? "Unknown Device" : value; }
        }

        public double BatteryPercentage
        {
            get { return _batteryPercentage; }
            private set { _batteryPercentage = value < 0 ? 0 : (value > 100 ? 100 : value); }
        }

        public bool IsOn
        {
            get { return _isOn; }
            private set { _isOn = value; }
        }

        public double MemoryUsage
        {
            get { return _memoryUsage; }
            private set { _memoryUsage = value < 0 ? 0 : (value > _totalMemory ? _totalMemory : value); }
        }

        public SmartDevice(string deviceName, double totalMemory)
        {
            DeviceName = deviceName;
            _batteryPercentage = 100.0;
            _isOn = false;
            _memoryUsage = 0.0;
            _totalMemory = totalMemory > 0 ? totalMemory : 16.0;
        }

        public void TurnOn()
        {
            IsOn = true;
            Console.WriteLine($"{DeviceName} is now ON.");
        }

        public void TurnOff()
        {
            IsOn = false;
            MemoryUsage = 0; 
            Console.WriteLine($"{DeviceName} is now OFF.");
        }

        public void UseMemory(double memory)
        {
            if (IsOn)
            {
                MemoryUsage += memory;
                Console.WriteLine($"Memory used: {memory} GB. Total memory usage: {MemoryUsage}/{_totalMemory} GB.");
            }
            else
            {
                Console.WriteLine("Cannot use memory. Device is off.");
            }
        }

        public void ChargeBattery(double amount)
        {
            BatteryPercentage += amount;
            Console.WriteLine($"{DeviceName} is charging. Battery: {BatteryPercentage}%.");
        }

        public void DrainBattery(double amount)
        {
            BatteryPercentage -= amount;
            Console.WriteLine($"{DeviceName} battery drained. Remaining battery: {BatteryPercentage}%.");
        }

        public void GetDeviceStatus()
        {
            string status = IsOn ? "ON" : "OFF";
            Console.WriteLine($"Device: {DeviceName}\nBattery: {BatteryPercentage}%\nStatus: {status}\nMemory Usage: {MemoryUsage}/{_totalMemory} GB\n");
        }
    }
}
