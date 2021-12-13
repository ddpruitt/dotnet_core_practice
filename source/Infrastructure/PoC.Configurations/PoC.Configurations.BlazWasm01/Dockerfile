#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /app
COPY . ./
RUN dotnet publish -c Release -o output

FROM nginx:alpine
ENV BLAZOR_ENVIRONMENT "Development"
ENV ASPNETCORE_ENVIRONMENT "Development"
ENV SomeComplexSection__Key04 "Key04 is from Docker Environment (WASM)"
WORKDIR /var/www/web
COPY --from=build /app/output/wwwroot .
COPY nginx.conf /etc/nginx/nginx.conf
EXPOSE 80
EXPOSE 443
