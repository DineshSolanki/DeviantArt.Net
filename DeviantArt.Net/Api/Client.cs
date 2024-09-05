﻿using System.Text.Json;
using DeviantArt.Net.Api.Handler;
using DeviantArt.Net.Models.Stash;
using DeviantArt.Net.Modules;
using DeviantArt.Net.Modules.Util.converter;
using DeviantArt.Net.Modules.Util.Formatters;

namespace DeviantArt.Net.Api;

public partial class Client
{
    private readonly IDeviantArtApi _api;

    public Client(string clientId, string clientSecret, ITokenStore tokenStore)
        : this(new DeviantArtOAuthClient(clientId, clientSecret, tokenStore))
    {
    }
    
    public Client(string clientId, string clientSecret, ITokenStore tokenStore, string redirectUri,
        params Scope[] scope)
        : this(new DeviantArtOAuthClient(clientId, clientSecret, tokenStore, redirectUri, scope))
    {
    }
    private Client(DeviantArtOAuthClient oauthClient)
    {
        var handler = new AuthenticatedHttpClientHandler(oauthClient)
        {
            InnerHandler = new RetryHandler(new HttpClientHandler())
        };

        var httpClient = new HttpClient(handler)
        {
            BaseAddress = new Uri(Defaults.BaseAddress)
        };
        /*var jsonSerializerOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase,
            Converters = 
            {
                new EnumArrayConverter<MatureClassification>(),
            }
        };*/
        var settings = new RefitSettings
        {
            // UrlParameterFormatter = new CustomDateUrlParameterFormatter(),
        };
        _api = RestService.For<IDeviantArtApi>(httpClient);
    }
    
    public Task<PlaceboResponse> IsTokenValidAsync()
    {
        return _api.CheckTokenValidityAsync();
    }

    public async Task<Deviation> GetDeviationAsync(string deviationId)
    {
        return await _api.GetDeviationAsync(deviationId);
    }

    public async Task<Deviation> GetDeviationAsync(Deviation deviation)
    {
        return await GetDeviationAsync(deviation.DeviationId);
    }
    
}