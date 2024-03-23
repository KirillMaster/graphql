FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["EntityFrameworkGraphQL/EntityFrameworkGraphQL.csproj", "EntityFrameworkGraphQL/"]
RUN dotnet restore "EntityFrameworkGraphQL/EntityFrameworkGraphQL.csproj"
COPY . .
WORKDIR "/src/EntityFrameworkGraphQL"
RUN dotnet build "EntityFrameworkGraphQL.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "EntityFrameworkGraphQL.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "EntityFrameworkGraphQL.dll"]
