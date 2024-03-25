# Dockerfile cho StarSecurityAPI
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj files and restore dependencies
COPY ./StarSecurityAPI/*.csproj ./StarSecurityAPI/
RUN dotnet restore ./StarSecurityAPI/StarSecurityAPI.csproj

# Copy source code and build the API
COPY ./StarSecurityAPI/ ./StarSecurityAPI/
RUN dotnet build -c Release -o /app/build ./StarSecurityAPI/StarSecurityAPI.csproj

# Publish API
RUN dotnet publish --self-contained --runtime linux-x64 --configuration Release -o /app/publish/StarSecurityAPI ./StarSecurityAPI/StarSecurityAPI.csproj

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/publish/StarSecurityAPI .
EXPOSE 5000
ENTRYPOINT ["dotnet", "StarSecurityAPI.dll"]
