FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WebApp test/WebApp test.csproj", "WebApp test/"]
RUN dotnet restore "WebApp test/WebApp test.csproj"
COPY . .
WORKDIR "/src/WebApp test"
RUN dotnet build "WebApp test.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApp test.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp test.dll"]
