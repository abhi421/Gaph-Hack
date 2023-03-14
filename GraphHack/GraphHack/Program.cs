using Azure.Identity;
using Microsoft.Graph;

var scopes = new[] { "User.Read" };
var interactiveBrowserCredentialOptions = new InteractiveBrowserCredentialOptions
{
    ClientId = "CLIENT_ID"
};
var tokenCredential = new InteractiveBrowserCredential(interactiveBrowserCredentialOptions);

var graphClient = new GraphServiceClient(tokenCredential, scopes);

var result = await graphClient.Chats["{chat-id}"].GetAsync((requestConfiguration) =>
{
    requestConfiguration.QueryParameters.Expand = new string[] { "members" };
});

Console.WriteLine(result);