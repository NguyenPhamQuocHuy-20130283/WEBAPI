# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution and project
COPY *.sln .
COPY WEBAPI/*.csproj ./WEBAPI/
RUN dotnet restore

# Copy all source code
COPY WEBAPI/. ./WEBAPI/
WORKDIR /app/WEBAPI
RUN dotnet publish -c Release -o out

# Runtime stage
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app
COPY --from=build /app/WEBAPI/out ./
ENV ASPNETCORE_URLS=http://*:$PORT
EXPOSE $PORT

ENTRYPOINT ["dotnet", "WEBAPI.dll"]
