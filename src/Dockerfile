#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["Web/Antigaspi.Web.csproj", "Web/"]
COPY ["Core/Services.Abstractions/Services.Abstractions.csproj", "Core/Services.Abstractions/"]
COPY ["Core/Contracts/Contracts.csproj", "Core/Contracts/"]
COPY ["Core/Services/Services.csproj", "Core/Services/"]
COPY ["Core/Domain/Domain.csproj", "Core/Domain/"]
COPY ["Infrastructure/Persistence/Persistence.Tsql.csproj", "Infrastructure/Persistence/"]
COPY ["Infrastructure/Presentation/Presentation.Rest.csproj", "Infrastructure/Presentation/"]
COPY ["Infrastructure/CustomLoggerManager/CustomLoggerManager.csproj", "Infrastructure/CustomLoggerManager/"]
RUN dotnet restore "Web/Antigaspi.Web.csproj"
COPY . .
WORKDIR "/src/Web"
RUN dotnet build "Antigaspi.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Antigaspi.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Antigaspi.Web.dll"]