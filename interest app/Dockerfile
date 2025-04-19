# Use the official Microsoft image for .NET SDK as the build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

# Set the working directory in the container
WORKDIR /app

# Copy the .csproj file from the subfolder into the container
COPY interest app/interest app.csproj ./interest app/interest app.csproj

# Change the working directory to the location of the .csproj file
WORKDIR /app/interest app

# Run dotnet restore to restore the dependencies
RUN dotnet restore

# Copy the rest of the project files into the container
COPY interest app/. ./interest app/

# Build and publish the project
RUN dotnet publish interest app.csproj -c Release -o /app/publish

# Use the official image for ASP.NET Core runtime for the final image
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime

# Set the working directory in the container
WORKDIR /app

# Copy the build output from the build image
COPY --from=build /app/publish .

# Expose the port the app will run on (default for ASP.NET Core apps)
EXPOSE 80

# Start the application
ENTRYPOINT ["dotnet", "interest app.dll"]

