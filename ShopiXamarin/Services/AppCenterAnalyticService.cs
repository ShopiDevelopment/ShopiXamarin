using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using ShopiXamarin.Services.Contracts;
using Microsoft.AppCenter.Analytics;

namespace ShopiXamarin.Services
{
    public class AppCenterAnalyticService : IAnalyticService
    {
        private string _userName;
        private string _customerId;

        private readonly ISettingsService _settingsService;
        public AppCenterAnalyticService(ISettingsService settingsService)
        {
            _settingsService = settingsService;
        }

        public void Init(string userName, string customerId)
        {
            _userName = userName.ToLower();
            _customerId = customerId;
        }

        public void SessionStarted()
        {
            TrackEvent(new Dictionary<string, string>());
        }

        public void LoginAttempted(string userName)
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(0).GetMethod();
            Analytics.TrackEvent(methodBase.Name, new Dictionary<string, string>
            {
                { "UserName", userName.ToLower()}
            });
        }

        public void LoginSuccess()
        {
            TrackEvent(new Dictionary<string, string>());
        }

        public void ForgotPassword(string userName)
        {
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(0).GetMethod();
            Analytics.TrackEvent(methodBase.Name, new Dictionary<string, string>
            {
                { "UserName", userName.ToLower()}
            });
        }

        public void LoggedOut(string userName)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "UserName", userName.ToLower()}
            });
        }

        public void CategoryViewed(string categoryName, string categoryId, string resultCount)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "CategoryName", categoryName},
                { "CategoryId", categoryId},
                { "ResultCount", resultCount},
            });
        }

        public void ProductSearched(string searchText, string resultCount)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "SearchText", searchText},
                { "ResultCount", resultCount},
            });
        }

        public void CategoryViewed(string categoryName, string categoryId, string resultCount, string source)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "CategoryName", categoryName},
                { "CategoryId", categoryId},
                { "ResultCount", resultCount},
                { "Source", source},
            });
        }

        public void ProductListFiltered(string filter, string filterQuery, string resultCount)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "Filter", filter},
                { "FilterQuery", filterQuery},
                { "ResultCount", resultCount},
            });
        }

        public void ProductListSorted(string sortType, string sortId, string resultCount)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "SortType", sortType},
                { "SortId", sortId},
            });
        }

        public void BannerItemTapped(string itemName, string itemType, string itemId)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "ItemName", itemName},
                { "ItemType", itemType},
                { "ItemId", itemId},
            });
        }

        public void ProductViewed(string productName, string productId, string source)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "ProductName", productName},
                { "ProductId", productId},
                { "Source", source},
            });
        }

        public void ProductVariantChanged(string productName, string productId, string variantName, string variantValue)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "ProductName", productName},
                { "ProductId", productId},
                { "VariantName", variantName},
                { "VariantValue", variantValue},
            });
        }

        public void ProductShared(string productName, string productId)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "ProductName", productName},
                { "ProductId", productId},
            });
        }

        public void ProductAddedToBag(string productName, string productId, string source)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "ProductName", productName},
                { "ProductId", productId},
                { "Source", source},
            });
        }

        public void ProductAddedToWishlist(string productName, string productId)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "ProductName", productName},
                { "ProductId", productId},
            });
        }

        public void WishlistShared()
        {
            TrackEvent(new Dictionary<string, string>());
        }

        public void WishlistItemRemoved(string productName, string productId)
        {
            TrackEvent(new Dictionary<string, string>
            {
                { "ProductName", productName},
                { "ProductId", productId},
            });
        }

        private void TrackEvent(Dictionary<string, string> parameters)
        {
#if DEBUG
            return;
#endif
            parameters.Add("UserName", _userName);
            parameters.Add("CustomerId", _customerId);
            StackTrace stackTrace = new StackTrace();
            MethodBase methodBase = stackTrace.GetFrame(1).GetMethod();
            Analytics.TrackEvent(methodBase.Name, parameters);
        }
    }
}
