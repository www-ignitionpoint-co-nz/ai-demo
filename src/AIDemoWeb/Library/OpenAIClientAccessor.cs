using Azure;
using Azure.AI.OpenAI;
using Haack.AIDemoWeb.Startup.Config;
using Microsoft.Extensions.Options;

namespace Serious;

/// <summary>
/// Used to access a configured <see cref="OpenAIClient"/> instance.
/// </summary>
public class OpenAIClientAccessor
{
    readonly OpenAIOptions _options;

    public OpenAIClientAccessor(IOptions<OpenAIOptions> options)
    {
        _options = options.Value;

        Client = new OpenAIClient(_options.ApiKey);
    }

    /// <summary>
    /// Get chat completions for provided chat context messages.
    /// </summary>
    /// <param name="chatCompletionsOptions">The options for this chat completions request.</param>
    /// <param name="cancellationToken">The cancellation token to use.</param>
    public async Task<Response<ChatCompletions>> GetChatCompletionsAsync(
        ChatCompletionsOptions chatCompletionsOptions,
        CancellationToken cancellationToken = default) =>
        await Client.GetChatCompletionsAsync(
            _options.Model,
            chatCompletionsOptions,
            cancellationToken);

    /// <summary>
    /// Return the computed embeddings for a given prompt.
    /// </summary>
    /// <param name="embeddingsOptions">The options for this embeddings request.</param>
    /// <param name="cancellationToken">The cancellation token to use.</param>
    public async Task<Response<Embeddings>> GetEmbeddingsAsync(
        EmbeddingsOptions embeddingsOptions,
        CancellationToken cancellationToken = default) =>
        await Client.GetEmbeddingsAsync(
            _options.EmbeddingModel,
            embeddingsOptions,
            cancellationToken);


    /// <summary>
    /// Return the computed embeddings for a given prompt.
    /// </summary>
    /// <param name="prompt">The prompt for this embeddings request.</param>
    /// <param name="cancellationToken">The cancellation token to use.</param>
    public async Task<List<float>> GetEmbeddingsAsync(string prompt, CancellationToken cancellationToken)
    {
        var response = await GetEmbeddingsAsync(new EmbeddingsOptions(prompt), cancellationToken);
        if (response.HasValue)
        {
            var embedding = response.Value.Data;
            if (embedding is { Count: > 0 })
            {
                return embedding[0].Embedding.ToList();
            }
        }

        return new List<float>();
    }

    public OpenAIClient Client { get; }
}