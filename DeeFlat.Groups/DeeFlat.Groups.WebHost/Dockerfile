#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DeeFlat.Groups/DeeFlat.Groups.WebHost/DeeFlat.Groups.WebHost.csproj", "DeeFlat.Groups/DeeFlat.Groups.WebHost/"]
RUN dotnet restore "DeeFlat.Groups/DeeFlat.Groups.WebHost/DeeFlat.Groups.WebHost.csproj"
COPY . .
WORKDIR "/src/DeeFlat.Groups/DeeFlat.Groups.WebHost"
RUN dotnet build "DeeFlat.Groups.WebHost.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DeeFlat.Groups.WebHost.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DeeFlat.Groups.WebHost.dll"]