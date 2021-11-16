# 建置發行檔案
# copy 當前目錄檔案-->容器內app目錄
# 到容器目錄app底下執行donet publish到 /app/out
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build

COPY . ./app/
WORKDIR /app
RUN dotnet publish -c Release -o out

# 佈署RUNTIME容器並執行網站
# 從build容器內複製build好的檔案至runtime容器
FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS runtime
COPY --from=build /app/out ./

EXPOSE 80
ENTRYPOINT ["dotnet", "WebApplication1.dll"]

## docker build -t mvc6 .
## docker run -d --name=m6 --rm -p 41234:80 mvc6