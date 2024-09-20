#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Services/Catalog/VKEshop.Catalog.API/VKEshop.Catalog.API.csproj", "src/Services/Catalog/VKEshop.Catalog.API/"]
COPY ["src/Common/VKEshop.MessageBus/VKEshop.MessageBus.csproj", "src/Common/VKEshop.MessageBus/"]
COPY ["src/Services/Catalog/VKEshop.Catalog.Application/VKEshop.Catalog.Application.csproj", "src/Services/Catalog/VKEshop.Catalog.Application/"]
COPY ["src/Services/Catalog/VKEshop.Catalog.Domain/VKEshop.Catalog.Domain.csproj", "src/Services/Catalog/VKEshop.Catalog.Domain/"]
COPY ["src/Services/Catalog/VKEshop.Catalog.Persistence/VKEshop.Catalog.Persistence.csproj", "src/Services/Catalog/VKEshop.Catalog.Persistence/"]
RUN dotnet restore "./src/Services/Catalog/VKEshop.Catalog.API/VKEshop.Catalog.API.csproj"
COPY . .
WORKDIR "/src/src/Services/Catalog/VKEshop.Catalog.API"
RUN dotnet build "./VKEshop.Catalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./VKEshop.Catalog.API.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "VKEshop.Catalog.API.dll"]