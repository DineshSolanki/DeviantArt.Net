# DeviantArt.Net

DeviantArt.Net is a .NET client library for interacting with the DeviantArt API. 
It provides a simple and easy-to-use interface for accessing various endpoints of the DeviantArt API.

## Features

- OAuth2 authentication
- Token management
- Supported Endpoints
    - [x] Browse
    - [ ] Collections
    - [ ] Comments
    - [x] Data
    - [ ] Deviation
    - [ ] Feed
    - [ ] Gallery
    - [x] Messages
    - [ ] Notes
    - [ ] Stash
    - [x] User
    - [x] Util

## Installation

To install DeviantArt.Net, add the following package to your project:

```sh
dotnet add package DeviantArt.Net
```

## Usage

### Initialization

To use the client, you need to initialize it with your DeviantArt API credentials:

There are two grant types supported: `AuthorizationCode` and `ClientCredentials`.

#### AuthorizationCode
```csharp
using DeviantArt.Net.Api;

var clientId = "your-client-id";
var clientSecret = "your-client-secret";
var redirectUri = "your-redirect-uri"; // e.g. "http://localhost:8080/"
var tokenStore = new YourTokenStoreImplementation(); // e.g. JsonTokenStore

var client = new Client(clientId, clientSecret, redirectUri, tokenStore);
```

#### ClientCredentials
```csharp
using DeviantArt.Net.Api;

var clientId = "your-client-id";
var clientSecret = "your-client-secret";
var tokenStore = new YourTokenStoreImplementation(); // e.g. JsonTokenStore

var client = new Client(clientId, clientSecret, tokenStore);
```

### Using API Endpoints

All API endpoints are available as methods on the client object.
Methods are well-documented and self-explanatory.
for example, to fetch a deviation by its ID::

```csharp
var deviationId = "some-deviation-id";
Deviation deviation = await Client.GetDeviationAsync(deviationId);
Console.WriteLine(deviation.Url);
```

## Customization
DeviantArt.Net uses ITokenStore interface (originally from [kamranayub/igdb-dotnet](https://github.com/kamranayub/igdb-dotnet?tab=readme-ov-file#custom-token-management)) to store and retrieve tokens. You can implement your own token store by implementing this interface.
currently, there are two implementations available: `JsonTokenStore` and `InMemoryTokenStore`.
To provide your own token store such as a database, you can implement the ITokenStore interface and pass it to the client constructor.

```csharp
using namespace DeviantArt.Net.Modules.TokenStore;

class CustomTokenStore : ITokenStore {

  Task<DeviantArtAccessToken> GetTokenAsync() {

    // Get token from database, etc.
    var token = // ...
    return token;
  }

  Task<DeviantArtAccessToken> StoreTokenAsync(DeviantArtAccessToken token) {
    // Store new token in database, etc.
    return token;
  }

}

// Create an DeviantArt API client, passing custom token store
var api = new Client(clientId, clientSecret, new CustomTokenStore());
```
## Contributing

Contributions are welcome! Please open an issue or submit a pull request.

## License

This project is licensed under the MIT License.
