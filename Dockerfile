FROM microsoft/dotnet:2.2-aspnetcore-runtime AS base
WORKDIR /app
EXPOSE 3000

FROM microsoft/dotnet:2.2-sdk AS build
WORKDIR /src
COPY ["TAS.SL.Api/TAS.SL.Api.csproj", "TAS.SL.Api/"]
RUN dotnet restore "TAS.SL.Api/TAS.SL.Api.csproj"
COPY . .
WORKDIR "/src/TAS.SL.Api"
RUN dotnet build "TAS.SL.Api.csproj" -c Release -o /app

FROM build AS publish
RUN dotnet publish "TAS.SL.Api.csproj" -c Release -o /app

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "TAS.SL.Api.dll"]
