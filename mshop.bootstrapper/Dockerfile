# Use the .NET SDK for building the project
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

EXPOSE 8080
EXPOSE 8081

WORKDIR /src

# Copy project files
COPY ["mshop.bootstrapper/mshop.bootstrapper.csproj", "mshop.bootstrapper/"]
COPY ["mshop.discounts/mshop.discounts.api/mshop.discounts.api.csproj", "mshop.discounts/mshop.discounts.api/"]
COPY ["mshop.discounts/mshop.discounts.application/mshop.discounts.application.csproj", "mshop.discounts/mshop.discounts.application/"]
COPY ["mshop.sharedkernel.messaging/mshop.sharedkernel.messaging.csproj", "mshop.sharedkernel.messaging/"]
COPY ["mshop.sharedkernel.coredata/mshop.sharedkernel.coredata.csproj", "mshop.sharedkernel.coredata/"]
COPY ["mshop.discounts/mshop.discounts.domain/mshop.discounts.domain.csproj", "mshop.discounts/mshop.discounts.domain/"]
COPY ["mshop.discounts/mshop.discounts.infrastructure/mshop.discounts.infrastructure.csproj", "mshop.discounts/mshop.discounts.infrastructure/"]
COPY ["mshop.orders/mshop.orders.api/mshop.orders.api.csproj", "mshop.orders/mshop.orders.api/"]
COPY ["mshop.orders/mshop.orders.application/mshop.orders.application.csproj", "mshop.orders/mshop.orders.application/"]
COPY ["mshop.orders/mshop.orders.domain/mshop.orders.domain.csproj", "mshop.orders/mshop.orders.domain/"]
COPY ["mshop.orders/mshop.orders.infrastructure/mshop.orders.infrastructure.csproj", "mshop.orders/mshop.orders.infrastructure/"]
COPY ["mshop.products/mshop.products.api/mshop.products.api.csproj", "mshop.products/mshop.products.api/"]
COPY ["mshop.products/mshop.products.application/mshop.products.application.csproj", "mshop.products/mshop.products.application/"]
COPY ["mshop.products/mshop.products.domain/mshop.products.domain.csproj", "mshop.products/mshop.products.domain/"]
COPY ["mshop.products/mshop.products.infrastructure/mshop.products.infrastructure.csproj", "mshop.products/mshop.products.infrastructure/"]

# Restore dependencies
RUN dotnet restore "mshop.bootstrapper/mshop.bootstrapper.csproj"

# Copy the remaining source code
COPY . .

# Zmiana nazw plików konfiguracyjnych
RUN rm /src/mshop.discounts/mshop.discounts.api/appsettings.json
RUN rm /src/mshop.orders/mshop.orders.api/appsettings.json 
RUN rm /src/mshop.products/mshop.products.api/appsettings.json
RUN rm /src/mshop.discounts/mshop.discounts.api/appsettings.Development.json
RUN rm /src/mshop.orders/mshop.orders.api/appsettings.Development.json 
RUN rm /src/mshop.products/mshop.products.api/appsettings.Development.json

# Set the working directory for the build
WORKDIR /src/mshop.bootstrapper

# Build the project
RUN dotnet build "mshop.bootstrapper.csproj" -c Release -o /app/build

# Publish the project
RUN dotnet publish "mshop.bootstrapper.csproj" -c Release -o /app/publish /p:UseAppHost=false

# Final stage - Use the ASP.NET runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

WORKDIR /app

# Copy the published output from the build stage to the runtime image
COPY --from=build /app/publish .

# Set the entry point to the main project
ENTRYPOINT ["dotnet", "mshop.bootstrapper.dll"]
