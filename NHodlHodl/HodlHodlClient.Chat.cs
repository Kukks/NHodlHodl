using NHodlHodl.Models;

namespace NHodlHodl;

public partial class HodlHodlClient
{

    public Task<ChatMessagesResponse> GetChatMessages(string contract, CancellationToken cancellationToken = default)
    {
        return SendHttpRequest<ChatMessagesResponse>($"v1/contracts/{contract}/chat_messages", null, cancellationToken:cancellationToken);
    }
}