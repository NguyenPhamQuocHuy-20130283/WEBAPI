# -------- Build Stage --------
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /app

# Copy solution file and restore dependencies
COPY *.sln .
COPY API/*.csproj ./API/
RUN dotnet restore

# Copy everything else and build
COPY API/. ./API/
WORKDIR /app/API
RUN dotnet publish -c Release -o out

# -------- Runtime Stage --------
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

# Copy published output from build stage
COPY --from=build /app/API/out ./

# Set environment variable for Railway port
ENV ASPNETCORE_URLS=http://*:$PORT
EXPOSE $PORT

# Set environment variable for DB connection (Railway)
# Railway sẽ cung cấp USER_DB_CONNECTION
ENV USER_DB_CONNECTION="Server=containers-us-west-***.railway.app,*****;Database=railway;User Id=sa;Password=*******;"

ENTRYPOINT ["dotnet", "API.dll"]
