using System;

namespace OpenWeatherMapApi
{
    /// <summary>
    /// Погода.
    /// </summary>
    public class Weather
    {
        /// <summary>
        /// Город.
        /// </summary>
        public string City { get; }
        /// <summary>
        /// Температура.
        /// </summary>
        public int Temperature { get; }
        /// <summary>
        /// Давление.
        /// </summary>
        public int Pressure { get; }
        /// <summary>
        /// Влажность.
        /// </summary>
        public int Humidity { get; }
        /// <summary>
        /// Видимость.
        /// </summary>
        public int Visibility { get; }
        /// <summary>
        /// Скорость ветра.
        /// </summary>
        public double WindSpeed { get; }
        /// <summary>
        /// Облачность (в процентах).
        /// </summary>
        public int Clouds { get; }

        /// <summary>
        /// Создать новую погоду (полная версия).
        /// </summary>
        /// <param name="city">Город.</param>
        /// <param name="temperature">Температура.</param>
        /// <param name="pressure">Давление.</param>
        /// <param name="humidity">Влажность.</param>
        /// <param name="visibility">Видимость.</param>
        /// <param name="windSpeed">Скорость ветра.</param>
        /// <param name="clouds">Облачность (в процентах).</param>
        public Weather(string city, int temperature, int pressure, int humidity, int visibility, double windSpeed, int clouds)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentNullException(nameof(city), "Название города не может быть пустым.");
            if (temperature > 100 || temperature < 100)
                throw new ArgumentException("Некорректная температура.", nameof(temperature));
            if (pressure < 0)
                throw new ArgumentException("Некорректное давление.", nameof(pressure));
            if (humidity < 0)
                throw new ArgumentException("Некорректная влажность.", nameof(humidity));
            if (visibility < 0)
                throw new ArgumentException("Некорректная видимость.", nameof(visibility));
            if (clouds < 0)
                throw new ArgumentException("Некорректная облачность.", nameof(clouds));

            City = city;
            Temperature = temperature;
            Pressure = pressure;
            Humidity = humidity;
            Visibility = visibility;
            WindSpeed = windSpeed;
            Clouds = clouds;
        }

        /// <summary>
        /// Создать новую погоду (упрощённая версия).
        /// </summary>
        /// <param name="city">Город.</param>
        /// <param name="temperature">Температура.</param>
        /// <param name="clouds">Облачность.</param>
        public Weather(string city, int temperature, int clouds)
        {
            if (string.IsNullOrWhiteSpace(city))
                throw new ArgumentNullException(nameof(city), "Название города не может быть пустым.");
            if (temperature > 100 || temperature < 100)
                throw new ArgumentException("Некорректная температура.", nameof(temperature));
            if (clouds < 0)
                throw new ArgumentException("Некорректная облачность.", nameof(clouds));

            City = city;
            Temperature = temperature;
            Clouds = clouds;
        }
    }
}