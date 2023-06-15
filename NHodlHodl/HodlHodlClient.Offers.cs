using NHodlHodl.Models;

namespace NHodlHodl;

public partial class HodlHodlClient
{

    
    public Task<OfferResponse> GetOffer(string id, CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<OfferResponse>($"v1/offers/{id}", null, cancellationToken:cancellationToken);
    }
    public Task<CurrencyValueResponse> GetCurrencyValue(string currencyCode, CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<CurrencyValueResponse>($"v1/offers/currency_value?currency_code={currencyCode}", null, cancellationToken:cancellationToken);
    } 
    public Task<ExchangeRatePriceResponse> GetExchangeRatePrice(string assetCode, string currencyCode, string provider, decimal deviation, string sign, string unit, CancellationToken cancellationToken = default)
    {
        Dictionary<string, object> query = new Dictionary<string, object>
        {
            { "asset_code", assetCode },
            { "currency_code", currencyCode },
            { "provider", provider },
            { "deviation", deviation },
            { "sign", sign },
            { "unit", unit }
        };

        return SendHttpRequest<ExchangeRatePriceResponse>("v1/offers/exchange_rate_price", query, cancellationToken: cancellationToken);
    }

    public Task<OffersResponse> GetOffers(int? limit = null, int? offset = null, string assetCode = null, string side = null, bool? includeGlobal = null, bool? onlyWorkingNow = null, string country = null, string currencyCode = null, string paymentMethodId = null, string paymentMethodType = null, string paymentMethodName = null, decimal? amount = null, int? paymentWindowMinutesMax = null, int? userAveragePaymentTimeMinutesMax = null, int? userAverageReleaseTimeMinutesMax = null, string sortDirection = null, string sortBy = null, CancellationToken cancellationToken = default)
    {
        Dictionary<string, object> query = new();
        if (limit.HasValue)
            query["pagination.limit"] = limit.Value;

        if (offset.HasValue)
            query["pagination.offset"] = offset.Value;

        if (!string.IsNullOrEmpty(assetCode))
            query["filters[asset_code]"] = assetCode;

        if (!string.IsNullOrEmpty(side))
            query["filters[side]"] = side;

        if (includeGlobal.HasValue)
            query["filters[include_global]"] = includeGlobal.Value;

        if (onlyWorkingNow.HasValue)
            query["filters[only_working_now]"] = onlyWorkingNow.Value;

        if (!string.IsNullOrEmpty(country))
            query["filters[country]"] = country;

        if (!string.IsNullOrEmpty(currencyCode))
            query["filters[currency_code]"] = currencyCode;

        if (!string.IsNullOrEmpty(paymentMethodId))
            query["filters[payment_method_id]"] = paymentMethodId;

        if (!string.IsNullOrEmpty(paymentMethodType))
            query["filters[payment_method_type]"] = paymentMethodType;

        if (!string.IsNullOrEmpty(paymentMethodName))
            query["filters[payment_method_name]"] = paymentMethodName;

        if (amount.HasValue)
            query["filters[amount]"] = amount.Value;

        if (paymentWindowMinutesMax.HasValue)
            query["filters[payment_window_minutes_max]"] = paymentWindowMinutesMax.Value;

        if (userAveragePaymentTimeMinutesMax.HasValue)
            query["filters[user_average_payment_time_minutes_max]"] = userAveragePaymentTimeMinutesMax.Value;

        if (userAverageReleaseTimeMinutesMax.HasValue)
            query["filters[user_average_release_time_minutes_max]"] = userAverageReleaseTimeMinutesMax.Value;

        if (!string.IsNullOrEmpty(sortDirection))
            query["sort[direction]"] = sortDirection;

        if (!string.IsNullOrEmpty(sortBy))
            query["sort[by]"] = sortBy;
        return SendHttpRequest<OffersResponse>($"v1/offers", query, cancellationToken:cancellationToken);
    }
    public Task DeleteOffer(string id, CancellationToken cancellationToken = default)
    {
        return SendHttpRequest($"v1/offers/{id}", null, HttpMethod.Delete,cancellationToken:cancellationToken);
    }
    public Task<OffersResponse> GetMyOffers(CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<OffersResponse>($"v1/offers/my", null, cancellationToken:cancellationToken);
    }
    public Task<OfferResponse> CreateOffer(CreateOfferRequest request,CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<OfferResponse>($"v1/offers", request, HttpMethod.Post,cancellationToken:cancellationToken);
    }
    public Task UpdateOffer(string id, UpdateOfferRequest request,CancellationToken cancellationToken = default)
    {
        return SendHttpRequest($"v1/offers/{id}", request, HttpMethod.Put,cancellationToken:cancellationToken);
    }
    
    
    
    
}