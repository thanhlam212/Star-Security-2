# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build-env

WORKDIR /app

# Copy csproj files and restore dependencies
COPY ./application/*.csproj ./application/

COPY ./Domain/*.csproj ./Domain/

RUN dotnet restore ./application/application.csproj

# Copy source code and build the application
COPY ./application/ ./application/

COPY ./Domain/ ./Domain/

RUN dotnet build -c Release -o /app/build ./application/application.csproj

# Publish Application
RUN dotnet publish  --self-contained --runtime linux-x64 --configuration Release -o /app/publish ./application/application.csproj

# Stage 2: Runtime
FROM mcr.microsoft.com/dotnet/aspnet:8.0

WORKDIR /src

# Copy published output from the build stage
COPY --from=build-env /app/publish /src/

EXPOSE 8443

ENTRYPOINT ["dotnet", "application.dll"]





# # Stage 1: Build
# FROM mcr.microsoft.com/dotnet/sdk:8.0 as build
# WORKDIR /src

# # Copy csproj files and restore dependencies for Application
# COPY ./application/*.csproj /src/application/
# RUN dotnet restore /src/application/*.csproj

# # Copy csproj files and restore dependencies for Domain
# COPY ./Domain/*.csproj /src/Domain/
# RUN dotnet restore /src/Domain/*.csproj

# # Copy source code and build the application for Application
# COPY ./application/ /src/application/
# RUN dotnet build -o /src/publish -r linux-x64 /p:PublishReadyToRun=true /src/application/*.csproj

# # Copy source code and build the application for Domain
# COPY ./Domain/ /src/Domain/
# RUN dotnet build -o /src/domain -r linux-x64 /p:PublishReadyToRun=true /src/Domain/*.csproj

# # Publish Application
# RUN dotnet publish -o /src/publish -r linux-x64 --self-contained true --no-restore /p:PublishTrimmed=true /p:PublishReadyToRun=true /p:PublishSingleFile=true /src/application/*.csproj

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

# # Command to start the application
# CMD ["./starSecurity"]



