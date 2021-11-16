# build/build-image.dockerfile
### build stage
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
ARG project_name
COPY . ./app/
WORKDIR /app
RUN dotnet publish $project_name -o out -c Release 

### publish stage
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
ARG project_name
COPY --from=build /app/out ./
EXPOSE 80
ENV project_dll="${project_name}.dll"
ENTRYPOINT dotnet $project_dll

# sample:
# docker build -f build/build-image.kestrel.dockerfile -t mvc6 --build-arg project_name=WebApplication1 .
# docker run -d --name=m6 --rm -p 41234:80 mvc6