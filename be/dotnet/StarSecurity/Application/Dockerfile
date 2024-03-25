# Dockerfile cho Application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env
WORKDIR /app

# Copy csproj files and restore dependencies
COPY ./Application/*.csproj ./Application/
RUN dotnet restore ./Application/Application.csproj

# Copy source code and build the application
COPY ./Application/ ./Application/
RUN dotnet build -c Release -o /app/build ./Application/Application.csproj

# Publish Application
RUN dotnet publish --self-contained --runtime linux-x64 --configuration Release -o /app/publish/Application ./Application/Application.csproj

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build-env /app/publish/Application .
EXPOSE 5000
ENTRYPOINT ["dotnet", "Application.dll"]
