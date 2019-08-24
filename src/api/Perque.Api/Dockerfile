FROM microsoft/dotnet:2.1-aspnetcore-runtime AS base

ENV ASPNETCORE_ENVIRONMENT=Development

WORKDIR /app

COPY ./bin/Debug/netcoreapp2.1/publish .

ENTRYPOINT ["dotnet", "Perque.Api.dll"]