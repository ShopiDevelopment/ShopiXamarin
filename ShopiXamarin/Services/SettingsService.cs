using System;
using ShopiXamarin.Services.Contracts;
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace ShopiXamarin.Services
{
    public class SettingsService : ISettingsService
    {
        private const string DEFAULT_CONTAINER = "ShopiXamarin.DEFAULT_CONTAINER";

        private readonly ISettings _settings;
        public SettingsService()
        {
            _settings = CrossSettings.Current;
        }

        public void AddItem(string key, string value, string container = null)
        {
            if (string.IsNullOrEmpty(container))
            {
                container = DEFAULT_CONTAINER;
            }
            _settings.AddOrUpdateValue(key, value ?? "", container);
        }

        public string GetItem(string key, string defaultValue = null, string container = null)
        {
            if (string.IsNullOrEmpty(container))
            {
                container = DEFAULT_CONTAINER;
            }
            return _settings.GetValueOrDefault(key, defaultValue, container);
        }

        public void DeleteItem(string key, string container = null)
        {
            if (string.IsNullOrEmpty(container))
            {
                container = DEFAULT_CONTAINER;
            }
            _settings.Remove(key, container);
        }

        public void Clear(string container = null)
        {
            if (string.IsNullOrEmpty(container))
            {
                container = DEFAULT_CONTAINER;
            }
            _settings.Clear(container);
        }
    }
}
