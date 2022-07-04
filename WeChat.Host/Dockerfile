#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 9999/tcp

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WeChat.Host/WeChat.Host.csproj", "WeChat.Host/"]
COPY ["WeChat.EntityFramewoekCore/WeChat.EntityFramewoekCore.csproj", "WeChat.EntityFramewoekCore/"]
COPY ["WeChat.Domain/WeChat.Domain.csproj", "WeChat.Domain/"]
COPY ["WeChat.Shared/WeChat.Shared.csproj", "WeChat.Shared/"]
COPY ["WeChat.Application/WeChat.Application.csproj", "WeChat.Application/"]
COPY ["WeChat.Http/WeChat.Http.csproj", "WeChat.Http/"]
RUN dotnet restore "WeChat.Host/WeChat.Host.csproj"
COPY . .
WORKDIR "/src/WeChat.Host"
RUN dotnet build "WeChat.Host.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeChat.Host.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENV ASPNETCORE_URLS=http://+:9999 
ENTRYPOINT ["dotnet", "WeChat.Host.dll"]