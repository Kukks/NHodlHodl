using NHodlHodl.Models;

namespace NHodlHodl;

public partial class HodlHodlClient
{
    public Task<CountriesResponse> GetCountries(CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<CountriesResponse>($"v1/countries", null, cancellationToken: cancellationToken);
    }

    public Task<CurrenciesResponse> GetCurrencies(CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<CurrenciesResponse>($"v1/currencies", null, cancellationToken: cancellationToken);
    }

    public Task<ExchangeRateProvidersResponse> GetExchangeRateProviders(CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<ExchangeRateProvidersResponse>($"v1/exchange_rate_providers", null,
            cancellationToken: cancellationToken);
    }

    public Task<TimezonesResponse> GetTimezones(CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<TimezonesResponse>($"v1/timezones", null, cancellationToken: cancellationToken);
    }

    public Task<PaymentMethodResponse> GetPaymentMethods(string? country = null,
        CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, object>();
        if (country is not null)
        {
            query.Add("filters[country]", country);
        }

        return SendHttpRequest<PaymentMethodResponse>($"v1/payment_methods", query,
            cancellationToken: cancellationToken);
    }

    public Task<NotificationsResponse> GetNotifications(CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<NotificationsResponse>($"v1/notifications/read", null, HttpMethod.Post,
            cancellationToken: cancellationToken);
    }

    public Task<UserResponse> GetMe(CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<UserResponse>($"v1/users/me", null, HttpMethod.Get,
            cancellationToken: cancellationToken);
    }
}