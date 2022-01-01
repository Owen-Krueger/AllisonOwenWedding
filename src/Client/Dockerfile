FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o output
FROM nginx:alpine
WORKDIR /var/www/web
COPY --from=build-env /app/output/wwwroot .
COPY Client/nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
EXPOSE 443