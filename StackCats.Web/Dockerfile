FROM mcr.microsoft.com/dotnet/core/aspnet:3.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/core/sdk:3.0-buster AS build
WORKDIR /src
COPY ["StackCats.Web.csproj", ""]
RUN dotnet restore "StackCats.Web.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "StackCats.Web.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "StackCats.Web.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS http://+:5000
EXPOSE 5000
ENTRYPOINT ["dotnet", "StackCats.Web.dll"]