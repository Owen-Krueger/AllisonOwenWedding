FROM mcr.microsoft.com/dotnet/core/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY AllisonOwenWedding.csproj .
RUN dotnet restore
COPY . .
RUN dotnet build "AllisonOwenWedding.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AllisonOwenWedding.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllisonOwenWedding.dll"]