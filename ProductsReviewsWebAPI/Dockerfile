# Learn about building .NET container images:
# https://github.com/dotnet/dotnet-docker/blob/main/samples/README.md
FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /source

# copy csproj and restore as distinct layers
COPY ProductsReviewsWebAPI/*.csproj .
RUN dotnet restore --use-current-runtime  

# copy everything else and build app
COPY ProductsReviewsWebAPI/. .
RUN dotnet publish -c Release -o /app


# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:7.0
WORKDIR /app
COPY --from=build /app .
ENTRYPOINT ["dotnet", "ProductsReviewsWebAPI.dll"]
