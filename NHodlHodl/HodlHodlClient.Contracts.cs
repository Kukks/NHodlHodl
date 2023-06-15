using NHodlHodl.Models;

namespace NHodlHodl;

public partial class HodlHodlClient
{
    public Task<ContractResponse> GetContract(string contract, CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<ContractResponse>($"v1/contracts/{contract}", null,
            cancellationToken: cancellationToken);
    }

    public Task<ContractsResponse> GetContracts(int? limit = null, int? offset = null, string? side = null,
        string? status = null, string? orderId = null, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, string>();
        if (limit is not null)
        {
            query.Add("pagination[limit]", limit.Value.ToString());
        }

        if (offset is not null)
        {
            query.Add("pagination[offset]", offset.Value.ToString());
        }

        if (side is not null)
        {
            query.Add("filters[side]", side);
        }

        if (status is not null)
        {
            query.Add("filters[status]", status);
        }

        if (orderId is not null)
        {
            query.Add("filters[order_id]", orderId);
        }

        return SendHttpRequest<ContractsResponse>($"v1/contracts/my", query,
            cancellationToken: cancellationToken);
    }

    public Task<ContractsResponse> FetchUpdatedContracts(int? limit, string updatedSince,
        string status, CancellationToken cancellationToken = default)
    {
        var query = new Dictionary<string, string>();
        if (limit is not null)
        {
            query.Add("pagination[limit]", limit.Value.ToString());
        }

        if (updatedSince is not null)
        {
            query.Add("pagination[updated_at_or_later_than]", updatedSince.ToString());
        }

        if (status is not null)
        {
            query.Add("filters[status]", status);
        }

        return SendHttpRequest<ContractsResponse>($"integrator/v1/contracts/fetch_new", query,
            cancellationToken: cancellationToken);
    }

    public Task<ContractResponse> CreateContract(CreateContractRequest request,
        CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<ContractResponse>($"v1/contracts", request, HttpMethod.Post,
            cancellationToken: cancellationToken);
    }

    public Task<ContractResponse> ConfirmContractEscrow(string contract, CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<ContractResponse>($"v1/contracts/{contract}/confirm", null, HttpMethod.Post,
            cancellationToken: cancellationToken);
    }

    public Task<ContractResponse> MarkContractPaid(string contract, CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<ContractResponse>($"v1/contracts/{contract}/mark_as_paid", null, HttpMethod.Post,
            cancellationToken: cancellationToken);
    }

    public Task<ContractResponse> CancelContract(string contract, CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<ContractResponse>($"v1/contracts/{contract}/cancel", null, HttpMethod.Post,
            cancellationToken: cancellationToken);
    }

    public Task<TransactionResponse> ReleaseContractTransaction(string contract,
        CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<TransactionResponse>($"v1/contracts/{contract}/release_transaction", null,
            HttpMethod.Get,
            cancellationToken: cancellationToken);
    }

    public Task<TransactionResponse> RefundContractTransaction(string contract, string refundAddress,
        CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<TransactionResponse>($"v1/contracts/{contract}/refund_transaction",
            new Dictionary<string, object>()
            {
                {"refundAddress", refundAddress}
            }, HttpMethod.Get,
            cancellationToken: cancellationToken);
    }

    public Task<ContractResponse> SignReleaseTransaction(string contract, NBitcoin.Transaction transaction,
        CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<ContractResponse>($"v1/contracts/{contract}/release_transaction",
            new SignTransactionRequest()
            {
                Hex = transaction.ToHex()
            }, HttpMethod.Post,
            cancellationToken: cancellationToken);
    }

    public Task<ContractResponse> SignRefundTransaction(string contract, NBitcoin.Transaction transaction,
        CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<ContractResponse>($"v1/contracts/{contract}/refund_transaction",
            new SignTransactionRequest()
            {
                Hex = transaction.ToHex()
            }, HttpMethod.Post,
            cancellationToken: cancellationToken);
    }

    public Task<ContractResponse> StartDispute(string contract, CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<ContractResponse>($"v1/contracts/{contract}/dispute", null, HttpMethod.Post,
            cancellationToken: cancellationToken);
    }

    public Task<Response> VerifySignatureKey(VerifySignatureRequest request,
        CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<Response>($"v1/contracts/verify_signature_key", request, HttpMethod.Post,
            cancellationToken: cancellationToken);
    }

}