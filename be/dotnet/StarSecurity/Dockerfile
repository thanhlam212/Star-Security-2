# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copy inside container
COPY Application/ ./Application/
COPY Domain/ ./Domain/
COPY Infrastructure/ ./Infrastructure/
COPY StarSecurityAPI/ ./StarSecurityAPI/

# Restore Nuget for each one
RUN dotnet restore Application/Application.csproj
RUN dotnet restore Domain/Domain.csproj
RUN dotnet restore Infrastructure/Infrastructure.csproj
RUN dotnet restore StarSecurityAPI/StarSecurityAPI.csproj

# Build for each pattern
RUN dotnet build Application/Application.csproj -c Release -o /app/Application
RUN dotnet build Domain/Domain.csproj -c Release -o /app/Domain
RUN dotnet build Infrastructure/Infrastructure.csproj -c Release -o /app/Infrastructure
RUN dotnet build StarSecurityAPI/StarSecurityAPI.csproj -c Release -o /app/StarSecurityAPI

# Stage 2: Publish
FROM build AS publish
RUN dotnet publish Application/Application.csproj -c Release -o /app/Application
RUN dotnet publish Domain/Domain.csproj -c Release -o /app/Domain
RUN dotnet publish Infrastructure/Infrastructure.csproj -c Release -o /app/Infrastructure
RUN dotnet publish StarSecurityAPI/StarSecurityAPI.csproj -c Release -o /app/StarSecurityAPI

# Stage 3: Final
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app

# Copy build & publish app into container
COPY --from=publish /app/Application ./Application
COPY --from=publish /app/Domain ./Domain
COPY --from=publish /app/Infrastructure ./Infrastructure
COPY --from=publish /app/StarSecurityAPI ./StarSecurityAPI

# Expose port
EXPOSE 8080
EXPOSE 443

CMD ["dotnet", "StarSecurityAPI/StarSecurityAPI.dll"]
