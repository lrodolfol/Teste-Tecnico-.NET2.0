#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugg
# busca imagem
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build 
WORKDIR /app

# copiar projeto e restaurar depedencias
COPY *.csproj ./
RUN dotnet restore

# carrega aplicação
COPY . ./
RUN dotnet publish -c Release -o out

# carrega imagem
FROM mcr.microsoft.com/dotnet/aspnet:6.0
WORKDIR /app
COPY --from=build /app/out .
ENTRYPOINT [ "dotnet", "done-manager.dll" ]
