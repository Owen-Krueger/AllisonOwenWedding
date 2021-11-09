FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/AllisonOwenWedding.csproj", "out/"]
RUN dotnet restore "out/AllisonOwenWedding.csproj"
COPY . .
WORKDIR "/src/out"
RUN dotnet build "AllisonOwenWedding.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AllisonOwenWedding.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AllisonOwenWedding.dll"]