FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["PresentationTier.csproj", "PresentationTier/"]
RUN dotnet restore "PresentationTier/PresentationTier.csproj"
COPY . .
WORKDIR "/src/PresentationTier"
RUN dotnet build "PresentationTier.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PresentationTier.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PresentationTier.dll"]
