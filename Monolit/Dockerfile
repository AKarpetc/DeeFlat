FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS prod
WORKDIR /app
ENV ASPNETCORE_URLS=https://*:443
EXPOSE 5000
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS dev
WORKDIR /src
COPY . .

RUN dotnet restore "DeeFlat.WebHost.sln"
RUN dotnet build "DeeFlat.WebHost.sln" -c Release -o /app/build


FROM dev AS published
RUN dotnet publish "DeeFlat.WebHost.sln" -c Release -o /app/publish

FROM prod as final
WORKDIR /app
COPY --from=published /app/publish ./
CMD dotnet DeeFlat.WebHost.dll
