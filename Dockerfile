FROM mcr.microsoft.com/dotnet/core/aspnet:3.1 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build
WORKDIR /src
COPY ./crudapi.csproj ./
RUN dotnet restore ./crudapi.csproj
COPY . .
WORKDIR /src
RUN dotnet build crudapi.csproj -c Release -o /app

FROM build AS publish
RUN dotnet publish crudapi.csproj -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "crudapi.dll"]
