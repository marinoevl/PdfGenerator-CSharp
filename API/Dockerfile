FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["PdfGenerator-CSharp.API/PdfGenerator-CSharp.API.csproj", "PdfGenerator-CSharp.API/"]
RUN dotnet restore "PdfGenerator-CSharp.API/PdfGenerator-CSharp.API.csproj"
COPY . .
WORKDIR "/src/PdfGenerator-CSharp.API"
RUN dotnet build "PdfGenerator-CSharp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "PdfGenerator-CSharp.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "PdfGenerator-CSharp.API.dll"]
