FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /src
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY . .
RUN dotnet restore "AllisonOwenWedding.Server.csproj"
RUN dotnet build "AllisonOwenWedding.Server.csproj" -c Release -o /app/build
RUN dotnet publish "AllisonOwenWedding.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllisonOwenWedding.Server.dll"]