# Build stage
FROM mcr.microsoft.com/dotnet/sdk:8.0@sha256:35792ea4ad1db051981f62b313f1be3b46b1f45cadbaa3c288cd0d3056eefb83 AS build-env
WORKDIR /App

# Copy everything and restore dependencies
COPY . ./
RUN dotnet restore

# Publish the application to a folder
RUN dotnet publish -c Release -o out

# Runtime stage using a smaller image (Alpine-based)
FROM mcr.microsoft.com/dotnet/sdk:8.0-alpine as runtime
WORKDIR /App
COPY --from=build-env /App/out .

# Set entrypoint to your application
ENTRYPOINT ["dotnet", "DotNet.Docker.dll"]
