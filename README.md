# Property Management Api

Rest API in .NET 8 that allows to obtain information about properties in the United States, uses SQL Server Database.

PropertyManagementApi.Infrastructure require:
```
dotnet add package Microsoft.EntityFrameworkCore v8.0.8
dotnet add package Microsoft.EntityFrameworkCore.SqlServer v8.0.8
dotnet add package Microsoft.EntityFrameworkCore.Tools v8.0.8
```

PropertyManagementApi.Application require:
```
dotnet add package AutoMapper.Extensions.Microsoft.DependencyInjection
dotnet add package Microsoft.AspNetCore.Authentication.JwtBearer
```

Apply Migrations and Update Database:
```
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Use this payload to get JWT token:
```
{
  "email": "valid-email",
  "password": "valid-password"
}
```


![alt text](https://github.com/sfgomezc/PropertyManagement/blob/master/Captures/Img_PropertyManagementApi1.png?raw=true)

**Endpoint to get all properties:**
GET: api/Properties/GetProperties

**Endpoint to get a property by ID:**
GET: api/Properties/GetProperty/3

**Endpoint to list properties by filters:**
GET: api/Properties/GetPropertyWithFilters/filter

**Endpoint to create a property:**
POST: api/Properties/CreateProperty
```
{
  "address": "Adrees",
  "city": "City",
  "state": "State",
  "zipCode": "Zip code",
  "description": "Full description",
  "propertiesForSale": [
    {
      "ownerID": 1,
      "price": 500000,
      "dateListed": "2024-10-04T04:29:57.976Z",
      "isActive": true
    }
  ]
}
```

**Endpoint to add an image to a property:**
PUT: api/Properties/AddImagetoProperty/3
```
{
  "propertyID": 1,
  "imageData": "Image from base64",
  "description": "Image description"
}
```

