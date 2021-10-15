#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ELibrary.API/ELibrary.API.csproj", "ELibrary.API/"]
RUN dotnet restore "ELibrary.API/ELibrary.API.csproj"
COPY . .
WORKDIR "/src/ELibrary.API"
RUN dotnet build "ELibrary.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ELibrary.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ELibrary.API.dll"]