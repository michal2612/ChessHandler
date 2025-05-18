# At root: MySolution/Dockerfile

FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /App

COPY . ./

RUN dotnet restore ChessHandler.Api/ChessHandler.Api.csproj
RUN dotnet publish ChessHandler.Api/ChessHandler.Api.csproj -c Release -o /App/out

FROM mcr.microsoft.com/dotnet/aspnet:9.0
WORKDIR /App
COPY --from=build /App/out .

EXPOSE 5089

ENTRYPOINT ["dotnet", "ChessHandler.Api.dll"]

