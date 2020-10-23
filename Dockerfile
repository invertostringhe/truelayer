FROM mcr.microsoft.com/dotnet/core/sdk:3.1-alpine AS build-env
COPY ./src/TrueLayer.WebApi /src
WORKDIR /src
RUN dotnet publish -c Release -r linux-musl-x64 -p:PublishTrimmed=true -o /app
RUN mv /app/TrueLayer.WebApi /app/TrueLayer

FROM mcr.microsoft.com/dotnet/core/runtime-deps:3.1-alpine
COPY --from=build-env /app /app
EXPOSE 80

ENTRYPOINT [ "/app/TrueLayer" ]