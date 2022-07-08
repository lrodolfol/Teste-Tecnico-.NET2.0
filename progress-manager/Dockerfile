#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["progress-manager/progress-manager.csproj", "progress-manager/"]
RUN dotnet restore "progress-manager/progress-manager.csproj"
COPY . .
WORKDIR "/src/progress-manager"
RUN dotnet build "progress-manager.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "progress-manager.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "progress-manager.dll"]