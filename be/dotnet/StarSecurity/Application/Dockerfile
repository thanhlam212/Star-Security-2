FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app
COPY . /app/

COPY ./Application/*.csproj /app/Application
COPY ./Domain/*.csproj ./app/Domain
COPY ./Infrastructure/*.csproj ./app/Infrastructure
COPY ./StarSecurityAPI/*.csproj ./app/StarSecurityAPI

RUN dotnet restore

RUN dotnet build -c Release -o /app/build

FROM build AS publish
RUN dotnet publish -c Release -o /app/publish

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Application.dll"]

