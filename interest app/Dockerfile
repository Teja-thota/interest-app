# Use the official Microsoft image for .NET SDK as the build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file from the subfolder and restore any dependencies
COPY interest-app/InterestApp.csproj ./interest-app/
WORKDIR /app/interest-app
RUN dotnet restore

# Copy the entire project and build it
COPY . ./
RUN dotnet publish interest-app/InterestApp.csproj -c Release -o /app/publish

# Use the official image for ASP.NET Core runtime for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the build output from the build image
COPY --from=build /app/publish .

# Expose the port the app will run on (default for ASP.NET Core apps)
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "interest-app/InterestApp.dll"]
