FROM mcr.microsoft.com/dotnet/runtime:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Literally drawing a line in a console/Literally drawing a line in a console.csproj", "Literally drawing a line in a console/"]
RUN dotnet restore "Literally drawing a line in a console/Literally drawing a line in a console.csproj"
COPY . .
WORKDIR "/src/Literally drawing a line in a console"
RUN dotnet build "Literally drawing a line in a console.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Literally drawing a line in a console.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Literally drawing a line in a console.dll"]
