FROM mcr.microsoft.com/dotnet/core/sdk:3.1 AS build-env
WORKDIR /app

# Copy csproj and restore as distinct layers
COPY *.sln ./
COPY Wunderlist.Api/*.csproj ./Wunderlist.Api/
COPY Wunderlist.Business/*.csproj ./Wunderlist.Business/
COPY Wunderlist.DataAccess/*.csproj ./Wunderlist.DataAccess/
COPY Wunderlist.DataStore/*.csproj ./Wunderlist.DataStore/
RUN dotnet restore

# Copy everything else and build
COPY . ./
RUN dotnet publish -c Release -o out

# Build runtime image
FROM mcr.microsoft.com/dotnet/core/aspnet:3.1
WORKDIR /app
COPY --from=build-env /app/out .
COPY entrypoint.sh ./
RUN chmod +x ./entrypoint.sh
ENTRYPOINT ["./entrypoint.sh"]
