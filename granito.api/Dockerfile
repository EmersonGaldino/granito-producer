FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["granito.api/granito.api.csproj", "granito.api/"]
RUN dotnet restore "granito.api/granito.api.csproj"
COPY . .
WORKDIR "/src/granito.api"
RUN dotnet build "granito.api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "granito.api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "granito.api.dll"]
