# Grab The SDK Image, Create a Name For It
FROM mcr.microsoft.com/dotnet/sdk:latest AS build
WORKDIR /app

# Copy csproj And Restore As Distinct Layers
COPY *.props .
COPY *.sln .

# Copy All Project Files

# API Data Transfer Objects
COPY Api.DTO.v1/*.csproj ./Api.DTO.v1/

# Testing Layer
COPY Testing.WebApp/*.csproj ./Testing.WebApp/

# App Layer
COPY App.BLL/*.csproj ./App.BLL/
COPY App.BLL.DTO/*.csproj ./App.BLL.DTO/
COPY App.DAL.DTO/*.csproj ./App.DAL.DTO/
COPY App.DAL.EF/*.csproj ./App.DAL.EF/
COPY App.Domain/*.csproj ./App.Domain/
COPY App.Resources/*.csproj ./App.Resources/
COPY WebApp/*.csproj ./WebApp/

# App Contracts Layer
COPY App.Contracts.BLL/*.csproj ./App.Contracts.BLL/
COPY App.Contracts.DAL/*.csproj ./App.Contracts.DAL/

# Base Layer
COPY Base.BLL/*.csproj ./Base.BLL/
COPY Base.DAL.EF/*.csproj ./Base.DAL.EF/
COPY Base.DAL.EF.Exceptions/*.csproj ./Base.DAL.EF.Exceptions/
COPY Base.DAL.EF.Helpers/*.csproj ./Base.DAL.EF.Helpers/
COPY Base.Domain/*.csproj ./Base.Domain/
COPY Base.Extensions/*.csproj ./Base.Extensions/
COPY Base.Extensions.Exceptions/*.csproj ./Base.Extensions.Exceptions/
COPY Base.Resources/*.csproj ./Base.Resources/
COPY Base.WebApp.Helpers/*.csproj ./Base.WebApp.Helpers/

# Base Contracts Layer
COPY Base.Contracts.BLL/*.csproj ./Base.Contracts.BLL/
COPY Base.Contracts.DAL/*.csproj ./Base.Contracts.DAL/
COPY Base.Contracts.Domain/*.csproj ./Base.Contracts.Domain/

RUN dotnet restore

# Copy Everything Else And Build App

# API Data Transfer Objects
COPY Api.DTO.v1/. ./Api.DTO.v1/

# Testing Layer
COPY Testing.WebApp/. ./Testing.WebApp/

# App Layer
COPY App.BLL/. ./App.BLL/
COPY App.BLL.DTO/. ./App.BLL.DTO/
COPY App.DAL.DTO/. ./App.DAL.DTO/
COPY App.DAL.EF/. ./App.DAL.EF/
COPY App.Domain/. ./App.Domain/
COPY App.Resources/. ./App.Resources/
COPY WebApp/. ./WebApp/

# App Contracts Layer
COPY App.Contracts.BLL/. ./App.Contracts.BLL/
COPY App.Contracts.DAL/. ./App.Contracts.DAL/

# Base Layer
COPY Base.BLL/. ./Base.BLL/
COPY Base.DAL.EF/. ./Base.DAL.EF/
COPY Base.DAL.EF.Exceptions/. ./Base.DAL.EF.Exceptions/
COPY Base.DAL.EF.Helpers/. ./Base.DAL.EF.Helpers/
COPY Base.Domain/. ./Base.Domain/
COPY Base.Extensions/. ./Base.Extensions/
COPY Base.Extensions.Exceptions/. ./Base.Extensions.Exceptions/
COPY Base.Resources/. ./Base.Resources/
COPY Base.WebApp.Helpers/. ./Base.WebApp.Helpers/

# Base Contracts Layer
COPY Base.Contracts.BLL/. ./Base.Contracts.BLL/
COPY Base.Contracts.DAL/. ./Base.Contracts.DAL/
COPY Base.Contracts.Domain/. ./Base.Contracts.Domain/

WORKDIR /app/WebApp
RUN dotnet publish -c Release -o out

FROM mcr.microsoft.com/dotnet/aspnet:latest AS runtime
WORKDIR /app

ENV ConnectionStrings:NpgsqlConnection="Host=postgress-pocket-bar.postgres.database.azure.com;Port=5432;Username=romake;Password=Qq123!Qq123!;database=PocketBar";

COPY --from=build /app/WebApp/out ./
ENTRYPOINT ["dotnet", "WebApp.dll"]