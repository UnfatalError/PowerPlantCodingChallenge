#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.
# Use the official ASP.NET 7.0 runtime image as the base image
FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 8888

# Use the official ASP.NET 7.0 SDK image for building the application
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src

# Copy the .csproj files for all your project layers (Application, Domain, Infrastructure, and API)
COPY ["PowerPlantProduction.Api/PowerPlantProduction.Api.csproj", "PowerPlantProduction.Api/"]
COPY ["../PowerPlantProduction.Application/PowerPlantProduction.Application.csproj", "PowerPlantProduction.Application/"]
COPY ["../PowerPlantProduction.Domain/PowerPlantProduction.Domain.csproj", "PowerPlantProduction.Domain/"]
COPY ["../PowerPlantProduction.Infrastructure/PowerPlantProduction.Infrastructure.csproj", "PowerPlantProduction.Infrastructure/"]

# Restore NuGet packages for all projects
RUN dotnet restore "PowerPlantProduction.Api/PowerPlantProduction.Api.csproj"

# Copy the entire solution and source code
COPY . .

# Build the solution using the Release configuration
WORKDIR "/src/PowerPlantProduction.Api"
RUN dotnet build "PowerPlantProduction.Api.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "PowerPlantProduction.Api.csproj" -c Release -o /app/publish

# Create a final image for running the application
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PowerPlantProduction.Api.dll"]