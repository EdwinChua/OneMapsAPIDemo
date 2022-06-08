#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Maps Temp/Maps Temp.csproj", "Maps Temp/"]
RUN dotnet restore "Maps Temp/Maps Temp.csproj"
COPY . .
WORKDIR "/src/Maps Temp"
RUN dotnet build "Maps Temp.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Maps Temp.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Maps Temp.dll"]