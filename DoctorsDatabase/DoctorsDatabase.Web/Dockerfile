#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DoctorsDatabase.Web/DoctorsDatabase.Web.csproj", "DoctorsDatabase.Web/"]
COPY ["DoctorsDatabase.Infrastructure/DoctorsDatabase.Infrastructure.csproj", "DoctorsDatabase.Infrastructure/"]
COPY ["DoctorsDatabase.Domain/DoctorsDatabase.Domain.csproj", "DoctorsDatabase.Domain/"]
RUN dotnet restore "DoctorsDatabase.Web/DoctorsDatabase.Web.csproj"
COPY . .
WORKDIR "/src/DoctorsDatabase.Web"
RUN dotnet build "DoctorsDatabase.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DoctorsDatabase.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DoctorsDatabase.Web.dll"]