using System;
namespace ShopiXamarin.Services.Contracts
{
    public interface IAnalyticService
    {
        void Init(string userName, string customerId);

        void SessionStarted();

        void LoginAttempted(string userName);

        void LoginSuccess();

        void LoggedOut(string userName);

        void ForgotPassword(string userName);

        void CategoryViewed(string categoryName, string categoryId, string resultCount, string source);

        void ProductSearched(string searchText, string resultCount);

        void ProductListFiltered(string filter, string filterQuery, string resultCount);

        void ProductListSorted(string sortType, string sortId, string resultCount);

        void BannerItemTapped(string itemName, string itemType, string itemId);

        void ProductViewed(string productName, string productId, string source);

        void ProductVariantChanged(string productName, string productId, string variantName, string variantValue);

        void ProductShared(string productName, string productId);

        void ProductAddedToBag(string productName, string productId, string source);

        void ProductAddedToWishlist(string productName, string productId);

        void WishlistShared();

        void WishlistItemRemoved(string productName, string productId);
    }
}
