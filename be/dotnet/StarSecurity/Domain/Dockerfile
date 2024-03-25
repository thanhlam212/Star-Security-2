# Dockerfile cho Domain
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj files and restore dependencies
COPY ./Domain/*.csproj ./Domain/
RUN dotnet restore ./Domain/Domain.csproj

# Copy source code and build the domain
COPY ./Domain/ ./Domain/
RUN dotnet build -c Release -o /app/build ./Domain/Domain.csproj

# Publish Domain
RUN dotnet publish --self-contained --runtime linux-x64 --configuration Release -o /app/publish/Domain ./Domain/Domain.csproj

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/publish/Domain .
