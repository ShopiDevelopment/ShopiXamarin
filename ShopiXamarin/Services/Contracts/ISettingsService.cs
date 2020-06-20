using System;
namespace ShopiXamarin.Services.Contracts
{
    public interface ISettingsService
    {
        void AddItem(string key, string value, string container = null);
        string GetItem(string key, string defaultValue = null, string container = null);
        void DeleteItem(string key, string container = null);
        void Clear(string container = null);
    }
}
