# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copy csproj files and restore dependencies
COPY ./Application/*.csproj ./Application/
COPY ./Domain/*.csproj ./Domain/
RUN dotnet restore ./Application/

# Copy source code and build the Application
COPY ./Application/ ./Application/
COPY ./Domain/ ./Domain/
RUN dotnet build -c Release -o /app/publish ./Application/

# Publish Application
RUN dotnet publish --self-contained --runtime linux-x64 --configuration Release -o /app/publish ./Application/

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /src

# Copy published output from the build stage
COPY --from=build-env /app/publish /src/

EXPOSE 8443

# ENTRYPOINT ["dotnet", "Application.dll"]
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]

# Stage 1: Build
# FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

# WORKDIR /app

# # Copy csproj files and restore dependencies
# COPY ./Application/*.csproj ./Application/

# COPY ./Domain/*.csproj ./Domain/

# RUN dotnet restore ./Application/Application.csproj

# # Copy source code and build the Application
# COPY ./Application/ ./Application/

# COPY ./Domain/ ./Domain/

# RUN dotnet build -c Release -o /app/publish ./Application/Application.csproj

# # Publish Application
# RUN dotnet publish  --self-contained --runtime linux-x64 --configuration Release -o /app/publish ./Application/Application.csproj

# # Stage 2: Runtime
# FROM mcr.microsoft.com/dotnet/aspnet:8.0

# WORKDIR /src

# # Copy published output from the build stage
# COPY --from=build-env /app/publish /src/

# EXPOSE 8443

# ENTRYPOINT ["dotnet", "Application.dll"]





# # Stage 1: Build
# FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
# WORKDIR /src

# # Copy csproj files and restore dependencies for Application
# COPY ./Application/*.csproj /src/Application/
# RUN dotnet restore /src/Application/*.csproj

# # Copy csproj files and restore dependencies for Domain
# COPY ./Domain/*.csproj /src/Domain/
# RUN dotnet restore /src/Domain/*.csproj

# # Copy source code and build the Application for Application
# COPY ./Application/ /src/Application/
# RUN dotnet build -o /src/publish -r linux-x64 /p:PublishReadyToRun=true /src/Application/*.csproj

# # Copy source code and build the Application for Domain
# COPY ./Domain/ /src/Domain/
# RUN dotnet build -o /src/domain -r linux-x64 /p:PublishReadyToRun=true /src/Domain/*.csproj

# # Publish Application
# RUN dotnet publish -o /src/publish -r linux-x64 --self-contained true --no-restore /p:PublishTrimmed=true /p:PublishReadyToRun=true /p:PublishSingleFile=true /src/Application/*.csproj

# # Stage 2: Runtime
# FROM mcr.microsoft.com/dotnet/aspnet:8.0 as base

# # Copy published output from the build stage for Application
# COPY --from=build /src/publish /src
# WORKDIR /src

# # Copy published output from the build stage for Domain
# COPY --from=build /src/domain /src

# # Expose port
# EXPOSE 8443

# # Healthcheck
# HEALTHCHECK CMD curl --fail http://localhost || exit 1

# # Command to start the Application
# CMD ["./starSecurity"]



