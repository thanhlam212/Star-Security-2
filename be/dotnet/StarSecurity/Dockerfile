# Stage 1: Build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Sao chép file dự án từ các thư mục khác nhau vào container
COPY Application/ ./Application/
COPY Domain/ ./Domain/
COPY Infrastructure/ ./Infrastructure/
COPY StarSecurityAPI/ ./StarSecurityAPI/

# Khôi phục các gói NuGet bằng lệnh dotnet restore cho từng dự án
RUN dotnet restore Application/Application.csproj
RUN dotnet restore Domain/Domain.csproj
RUN dotnet restore Infrastructure/Infrastructure.csproj
RUN dotnet restore StarSecurityAPI/StarSecurityAPI.csproj

# Tiến hành xây dựng ứng dụng cho từng dự án
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

# Sao chép các ứng dụng đã được build và publish vào container
COPY --from=publish /app/Application ./Application
COPY --from=publish /app/Domain ./Domain
COPY --from=publish /app/Infrastructure ./Infrastructure
COPY --from=publish /app/StarSecurityAPI ./StarSecurityAPI

# Expose các cổng cần thiết
EXPOSE 80
EXPOSE 443

# Command để chạy các ứng dụng khi container được khởi chạy
CMD ["dotnet", "StarSecurityAPI/StarSecurityAPI.dll"]
# Hoặc bạn có thể thay thế "StarSecurityAPI/StarSecurityAPI.dll" bằng "Application/Application.dll", "Domain/Domain.dll", hoặc "Infrastructure/Infrastructure.dll" tùy thuộc vào ứng dụng bạn muốn chạy
