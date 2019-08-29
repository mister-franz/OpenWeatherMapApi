using Newtonsoft.Json.Linq;
using System;
using System.Net.Http;

namespace OpenWeatherMapApi
{
    /// <summary>
    /// Контроллер погоды.
    /// </summary>
    public class WeatherController
    {
        /// <summary>
        /// Api ключ сервиса openweathermap
        /// </summary>
        public string ApiKey { get; }

        /// <summary>
        /// Создать новый контроллер погоды.
        /// </summary>
        /// <param name="apiKey">Ваш api ключ сервиса openweathermap.</param>
        public WeatherController(string apiKey)
        {
            if (string.IsNullOrWhiteSpace(apiKey))
                throw new ArgumentNullException(nameof(apiKey), "Api ключ не может быть пустым.");

            ApiKey = apiKey;
        }

        /// <summary>
        /// Получить погоду в городе (полная информация).
        /// </summary>
        /// <param name="city">Город.</param>
        /// <returns>Погода в городе.</returns>
        public Weather GetWeather(string city)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={ApiKey}";

            var data = GetRequest(url);

            int temperature = data.main.temp;
            int pressure = data.main.pressure;
            int humidity = data.main.humidity;
            int visibility = data.visibility;
            double windSpeed = data.wind.speed;
            int clouds = data.clouds.all;

            return new Weather(city, temperature, pressure, humidity, visibility, windSpeed, clouds);
        }

        /// <summary>
        /// Получить погоду в городе (упрощённая версия).
        /// </summary>
        /// <param name="city">Город.</param>
        /// <returns>Погода в городе.</returns>
        public Weather GetSimpleWeather(string city)
        {
            string url = $"http://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&appid={ApiKey}";

            var data = GetRequest(url);

            int temperature = data.main.temp;
            int clouds = data.clouds.all;

            return new Weather(city, temperature, clouds);
        }

        /// <summary>
        /// Отправить GET запрос к openweathermapapi.
        /// </summary>
        /// <param name="url">Адрес запроса.</param>
        /// <returns>Данные в формате json.</returns>
        private dynamic GetRequest(string url)
        {
            var httpClient = new HttpClient();

            try
            {
                var json = httpClient.GetStringAsync(url).Result;
                return JObject.Parse(json);
            }
            catch
            {
                return null;
            }
        }
    }
}