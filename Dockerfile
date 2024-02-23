FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source
COPY . .
RUN dotnet restore "./AccountManagement.Web/AccountManagement.Web.csproj" --disable-parallel
RUN dotnet publish "./AccountManagement.Web/AccountManagement.Web.csproj" -c release -o /app --no-restore

FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app ./

EXPOSE 5000

ENTRYPOINT [ "dotnet", "AccountManagement.Web.dll" ]