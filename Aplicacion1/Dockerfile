#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 32768

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Aplicacion1/Aplicacion1.csproj", "Aplicacion1/"]
RUN dotnet restore "Aplicacion1/Aplicacion1.csproj"
COPY . .
WORKDIR "/src/Aplicacion1"
RUN dotnet build "Aplicacion1.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Aplicacion1.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Aplicacion1.dll"]