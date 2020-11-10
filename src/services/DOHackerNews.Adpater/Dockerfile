#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["./services/DOHackerNews.Adpater/DOHackerNews.Adpater.csproj", "services/DOHackerNews.Adpater/"]
COPY ["./buildingBlocks/core/DOHackerNews.Core/DOHackerNews.Core.csproj", "buildingBlocks/core/DOHackerNews.Core/"]
COPY ["./buildingBlocks/services/DOHackerNews.WebAPI.Core/DOHackerNews.WebAPI.Core.csproj", "buildingBlocks/services/DOHackerNews.WebAPI.Core/"]
RUN dotnet restore "src/services/DOHackerNews.Adpater/DOHackerNews.Adpater.csproj"
COPY . .
WORKDIR "services/DOHackerNews.Adpater"
RUN dotnet build "DOHackerNews.Adpater.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DOHackerNews.Adpater.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DOHackerNews.Adpater.dll"]