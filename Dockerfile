FROM microsoft/dotnet:sdk AS build-env

WORKDIR /socialback

COPY . .

CMD  dotnet restore

RUN dotnet build

RUN chmod +x ./entrypoint.sh

CMD /bin/bash ./entrypoint.sh