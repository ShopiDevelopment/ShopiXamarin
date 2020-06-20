using System;
using System.Collections.Generic;

namespace ShopiXamarin.Services.Contracts
{
    public interface IUtilities
    {
        Guid GetSysId();
        string GetComputerName();
        string GetModel();
        string GetOs();
        string GetOsVersion();
        string GetNotificationToken();
        bool SetThemeColor(string key, string color);
        string GetAppVersion();
        string GetShortVersion();
        string GetManufaturer();
        List<string> GetAppCultures();
        string GetCarrier();
        string GetCountry();
        string GetAdvertiserId();
        string GetLanguage();
        string GetPlatform();
        void Beep();
        void CloseApplication();
    }
}
