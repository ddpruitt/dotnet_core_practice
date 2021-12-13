#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV SomeComplexSection__Key04 "Key04 is from Docker Environment (WASM - Hosted)"

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PoC.Configurations.BlazWasm02/Server/PoC.Configurations.BlazWasm02.Server.csproj", "PoC.Configurations.BlazWasm02/Server/"]
COPY ["PoC.Configurations.BlazWasm02/Shared/PoC.Configurations.BlazWasm02.Shared.csproj", "PoC.Configurations.BlazWasm02/Shared/"]
COPY ["PoC.Configurations.BlazWasm02/Client/PoC.Configurations.BlazWasm02.Client.csproj", "PoC.Configurations.BlazWasm02/Client/"]
RUN dotnet restore "PoC.Configurations.BlazWasm02/Server/PoC.Configurations.BlazWasm02.Server.csproj"
COPY . .
WORKDIR "/src/PoC.Configurations.BlazWasm02/Server"
RUN dotnet build "PoC.Configurations.BlazWasm02.Server.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PoC.Configurations.BlazWasm02.Server.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PoC.Configurations.BlazWasm02.Server.dll"]