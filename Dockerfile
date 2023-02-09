FROM microsoft/dotnet:1.1.2-runtime
WORKDIR /app
COPY . .
EXPOSE 5050
ENTRYPOINT ["dotnet", "HelloWorld.dll"]
