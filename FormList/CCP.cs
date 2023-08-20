using System.Collections.Generic;
using System;
using System.Linq;

namespace FormList
{
    public partial class CCP : Services.BaseChildForm
    {
        private List<double> temperatureBuffer = new List<double>(); // Buffer to store recent temperature readings
        private List<double> pressureBuffer = new List<double>(); // Buffer to store recent pressure readings
        private object bufferLock = new object(); // Object used as a lock for synchronization
        private Random random = new Random(); // Create a single instance of Random

        public CCP()
        {
            InitializeComponent();
        }

        private void CCP_Load(object sender, EventArgs e)
        {
            // Start the timer when the form loads
            timerTemperature.Start();
        }

        private void timerTemperature_Tick(object sender, EventArgs e)
        {
            // Replace this with the actual code to read the temperature and pressure from your data source
            double temperature = GetTemperatureFromDataSource();
            double pressure = GetPressureFromDataSource();

            // Use lock to synchronize access to the temperatureBuffer list
            lock (bufferLock)
            {
                // Add the temperature and pressure readings to the buffers
                temperatureBuffer.Add(temperature);
                pressureBuffer.Add(pressure);

                // Remove older readings from the buffers (only keep readings from the last 10 seconds)
            }

            // Calculate the average temperature and pressure
            double averageTemperature;
            double averagePressure;

            // Use lock to synchronize access to the temperatureBuffer and pressureBuffer lists when calculating averages
            lock (bufferLock)
            {
                averageTemperature = temperatureBuffer.Any() ? temperatureBuffer.Average() : temperature;
                averagePressure = pressureBuffer.Any() ? pressureBuffer.Average() : pressure;
            }

            // Calculate the percentage values between 95% and 100%
            double temperaturePercentage = (averageTemperature - 120) / (123 - 120) * 5 + 95;
            double pressurePercentage = (averagePressure - 1000) / (2000 - 1000) * 5 + 95;

            // Clamp the percentage values between 95% and 100%
            temperaturePercentage = Math.Max(95, Math.Min(100, temperaturePercentage));
            pressurePercentage = Math.Max(95, Math.Min(100, pressurePercentage));

            // Update the respective labels with the percentage values
            label2.Text = $"{temperaturePercentage:F1}°C";
            label5.Text = $"{pressurePercentage:F1}%";
        }

        private double GetTemperatureFromDataSource()
        {
            // Replace this with code to read the temperature from your data source (e.g., sensor or database)
            // For this example, we'll just return a random temperature between 120 and 123 degrees.
            return random.Next(12000, 12301) / 100.0; // Generate values between 120.00 and 123.00 (inclusive)
        }

        private double GetPressureFromDataSource()
        {
            // Replace this with code to read the pressure from your data source (e.g., sensor or database)
            // For this example, we'll just return a random pressure between 1000 and 2000.
            return random.Next(1000, 2001);
        }
    }
}
