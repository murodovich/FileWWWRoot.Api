FROM mcr.microsoft.com/dotnet/sdk:7.0-alpine as build

WORKDIR /src

COPY *.csproj ./

RUN dotnet restore 

COPY . ./ 

RUN dotnet publish -c Release -o output

FROM mcr.microsoft.com/dotnet/aspnet:7.0-alpine as base

WORKDIR /app

COPY --from=build /src/output . 

EXPOSE 80

EXPOSE 443

ENTRYPOINT [ "dotnet", "FileWwwroot.Api.dll"] 

