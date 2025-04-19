# Use the official Microsoft image for .NET SDK as the build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copy the .csproj file and restore dependencies
COPY interestapp/interestapp.csproj ./interestapp/
WORKDIR /app/interestapp
RUN dotnet restore

# Copy the entire project
COPY interestapp/. ./
RUN dotnet publish interestapp.csproj -c Release -o /app/publish

# Runtime image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

EXPOSE 80

ENTRYPOINT ["dotnet", "interestapp.dll"]

