#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
ENV SomeComplexSection__Key04 "Key04 is from Docker Environment (Server)"


FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PoC.Configurations.BlazServerApp01/PoC.Configurations.BlazServerApp01.csproj", "PoC.Configurations.BlazServerApp01/"]
RUN dotnet restore "PoC.Configurations.BlazServerApp01/PoC.Configurations.BlazServerApp01.csproj"
COPY . .
WORKDIR "/src/PoC.Configurations.BlazServerApp01"
RUN dotnet build "PoC.Configurations.BlazServerApp01.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PoC.Configurations.BlazServerApp01.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PoC.Configurations.BlazServerApp01.dll"]