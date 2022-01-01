FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY AllisonOwenWedding.Server.csproj /opt/app
RUN dotnet restore "AllisonOwenWedding.Server.csproj"
COPY . .
WORKDIR /opt/app
RUN dotnet build "/opt/app/AllisonOwenWedding.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "/opt/app/AllisonOwenWedding.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "/opt/appAllisonOwenWedding.Server.dll"]