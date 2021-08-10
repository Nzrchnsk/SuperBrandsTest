```
dotnet tool install --global dotnet-ef
dotnet restore
dotnet tool restore
```
Migrations
```
dotnet ef migrations add Initial --context BrandDBContext -p ../Brand.Infrastructure/Brand.Infrastructure.csproj -s ../Brand.API/Brand.API.csproj -o Data/Migrations
dotnet ef migrations add Initial --context ProductDBContext -p ../Product.Infrastructure/Product.Infrastructure.csproj --startup-project ../Product.API/Product.API.csproj -o ../Product.Infrastructure/Data/Migrations
```

```
dotnet ef database update -c BrandDBContext -p ../Brand.Infrastructure/Brand.Infrastructure.csproj -s ../Brand.API/Brand.API.csproj
dotnet ef database update -c ProductDBContext -p ../Product.Infrastructure/Product.Infrastructure.csproj -s ../Product.API/Product.API.csproj
```
