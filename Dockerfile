FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
RUN dotnet --version
WORKDIR /src
COPY ["Apps/ThePlaceToMeet.WebApi/ThePlaceToMeet.WebApi.csproj", "Apps/ThePlaceToMeet.WebApi/"]
COPY ["Libraries/ThePlaceToMeet.Contracts/ThePlaceToMeet.Contracts.csproj", "Libraries/ThePlaceToMeet.Contracts/"]
COPY ["Libraries/ThePlaceToMeet.Infrastructure/ThePlaceToMeet.Infrastructure.csproj", "Libraries/ThePlaceToMeet.Infrastructure/"]
COPY ["Libraries/ThePlaceToMeet.Domain/ThePlaceToMeet.Domain.csproj", "Libraries/ThePlaceToMeet.Domain/"]

RUN dotnet restore "./Apps/ThePlaceToMeet.WebApi/ThePlaceToMeet.WebApi.csproj"
COPY . .
WORKDIR "/src/Apps/ThePlaceToMeet.WebApi"
RUN dotnet build "ThePlaceToMeet.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "ThePlaceToMeet.WebApi.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
#COPY ["servercert.pfx", "/https/servercert.pfx"]
#COPY ["cacert.crt", "/usr/local/share/ca-certificates/cacert.crt"]
#RUN update-ca-certificates
ENTRYPOINT ["dotnet", "ThePlaceToMeet.WebApi.dll"]