#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["PatientsDatabase.Web/PatientsDatabase.Web.csproj", "PatientsDatabase.Web/"]
COPY ["PatientsDatabase.Infrastructure/PatientsDatabase.Infrastructure.csproj", "PatientsDatabase.Infrastructure/"]
COPY ["PatientsDatabase/PatientsDatabase.Domain.csproj", "PatientsDatabase/"]
RUN dotnet restore "PatientsDatabase.Web/PatientsDatabase.Web.csproj"
COPY . .
WORKDIR "/src/PatientsDatabase.Web"
RUN dotnet build "PatientsDatabase.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PatientsDatabase.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
COPY PatientsDatabase.Web/Database.xml .
COPY PatientsDatabase.Web/Database.xsd .
ENTRYPOINT ["dotnet", "PatientsDatabase.Web.dll"]