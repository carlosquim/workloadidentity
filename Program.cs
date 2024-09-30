// the includeInteractiveCredentials constructor parameter can be used to enable interactive authentication
using System.Net.Http.Headers;
using System.Net.Http.Json;
using Azure.Core;
using Azure.Identity;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;

String generateToken(){

// message to be shown in the page
var stringData="";
// Init default credential
var credential = new Azure.Identity.DefaultAzureCredential();
var contentType = new MediaTypeWithQualityHeaderValue("application/json");
//init token
var token = new AccessToken();

try
{
    token = credential.GetToken(new Azure.Core.TokenRequestContext(scopes:["api://644e0700-85ae-4de0-83dd-a876d692e693/.default"]));
    stringData=stringData + "roles:"+ "\r\nToken:" +token.Token.ToString()+"\r\n";
}
catch (System.Exception e)
{
    stringData=stringData+"Error getting token1: "+e.Message;
}

return stringData;
} 

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/", () => "The execution has finished please check the logs "+ generateToken() +System.DateTime.UtcNow.ToString());

app.Run();
public record Record(
    string appservicename,
    string app,
    string id,
    string category,
    string name,
    double responseTime,
    DateTime date
);