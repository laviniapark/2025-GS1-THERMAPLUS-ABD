# ===== Stage 1: Build =====
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src

# Copiar csproj e restaurar dependências
COPY Therma-Plus-DotNet/*.csproj ./Therma-Plus-DotNet/
RUN dotnet restore ./Therma-Plus-DotNet/Therma-Plus-DotNet.csproj

# Copiar restante do código e publicar
COPY . .
RUN dotnet publish ./Therma-Plus-DotNet/Therma-Plus-DotNet.csproj -c Release -o /app/publish

# ===== Stage 2: Runtime =====
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS runtime
WORKDIR /app
COPY --from=build /app/publish .

# Expõe a porta (mesma do compose)
EXPOSE 8080
ENV ASPNETCORE_URLS=http://0.0.0.0:8080

# Aqui você precisa usar o nome EXATO do seu DLL
ENTRYPOINT ["dotnet","Therma-Plus-DotNet.dll"]
