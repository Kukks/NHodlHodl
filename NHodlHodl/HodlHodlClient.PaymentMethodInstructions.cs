using NHodlHodl.Models;

namespace NHodlHodl;

public partial class HodlHodlClient
{

    public Task<PaymentMethodInstructionsResponse> GetPaymentMethodInstructions(CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<PaymentMethodInstructionsResponse>($"v1/payment_method_instructions", null, cancellationToken:cancellationToken);
    }

    public Task<PaymentMethodInstructionsResponse> GetPaymentMethodInstruction(string id,CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<PaymentMethodInstructionsResponse>($"v1/payment_method_instructions/{id}", null, cancellationToken:cancellationToken);
    }

    public Task RemovePaymentMethodInstruction(string id,CancellationToken cancellationToken = default)
    {
        return SendHttpRequest($"v1/payment_method_instructions/{id}", null, HttpMethod.Delete,cancellationToken:cancellationToken);
    }

    public Task CreatePaymentMethodInstruction(PaymentMethodInstructionRequest request,CancellationToken cancellationToken = default)
    {
        return SendHttpRequest($"v1/payment_method_instructions", request,  HttpMethod.Post,cancellationToken:cancellationToken);
    }

    public Task UpdatePaymentMethodInstruction(string id, PaymentMethodInstructionRequest request,CancellationToken cancellationToken = default)
    {
        return SendHttpRequest($"v1/payment_method_instructions/{id}", request,  HttpMethod.Put,cancellationToken:cancellationToken);
    }
}