# Dockerfile cho Infrastructure
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj files and restore dependencies
COPY ./Infrastructure/*.csproj ./Infrastructure/
RUN dotnet restore ./Infrastructure/Infrastructure.csproj

# Copy source code and build the infrastructure
COPY ./Infrastructure/ ./Infrastructure/
RUN dotnet build -c Release -o /app/build ./Infrastructure/Infrastructure.csproj

# Publish Infrastructure
RUN dotnet publish --self-contained --runtime linux-x64 --configuration Release -o /app/publish/Infrastructure ./Infrastructure/Infrastructure.csproj

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/publish/Infrastructure .
