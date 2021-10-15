#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["ELibrary.MVC/ELibrary.MVC.csproj", "ELibrary.MVC/"]
RUN dotnet restore "ELibrary.MVC/ELibrary.MVC.csproj"
COPY . .
WORKDIR "/src/ELibrary.MVC"
RUN dotnet build "ELibrary.MVC.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ELibrary.MVC.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ELibrary.MVC.dll"]