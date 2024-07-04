# Utiliser l'image SDK officielle de .NET 6 pour construire l'application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build

WORKDIR /app

# Copier les fichiers du projet et restaurer les dépendances
COPY *.csproj ./
RUN dotnet restore

# Copier tout le reste et construire l'application
COPY . ./
RUN dotnet publish -c Release -o out

# Étape de production : Utiliser l'image runtime de .NET 6 pour exécuter l'application
FROM mcr.microsoft.com/dotnet/sdk:6.0 AS runtime

# Installation de dotnet-counters
RUN dotnet tool install --global dotnet-counters 
ENV PATH="${PATH}:/root/.dotnet/tools"

WORKDIR /app
COPY --from=build /app/out ./

# Exposer le port 80 (ou le port sur lequel votre application écoute)
ENV ASPNETCORE_URLS=http://+:5000
# ENV DOTNET_SYSTEM_GLOBALIZATION_INVARIANT=false
# ENV DOTNET_GC_SERVER=true
# ENV DOTNET_GC_HEAPSIZE=1g
# ENV DOTNET_GC_HeapCount=c
# ENV DOTNET_GC_CONCURRENT=true
ENV DOTNET_GCHeapHardLimitPercent=4B
EXPOSE 5000
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
