FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443


ENV ASPNETCORE_ENVIRONMENT=Development 
# Creates a non-root user with an explicit UID and adds permission to access the /app folder
# For more info, please refer to https://aka.ms/vscode-docker-dotnet-configure-containers
RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["orderservice/orderservice.csproj", "orderservice/"]
RUN dotnet restore "orderservice/orderservice.csproj"
COPY . .
WORKDIR "/src/orderservice"
RUN dotnet build "orderservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "orderservice.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "orderservice.dll"]
