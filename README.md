# codenow-net-settings
* NetStandards 2.1
* .NET 5/C# 9.0


# build package

`dotnet pack -c Release -o Packages`


# changelog
**1.0.0**
- extension method for IConfiguration - will replace placeholders in appsettings.json with env variable value
- extension method for IConfigurationBuilder