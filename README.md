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

GET: api/Properties/GetProperties

GET: api/Properties/GetProperty/3

GET: api/Properties/GetPropertyWithFilters/filter

POST: api/Properties/CreateProperty
```
{
  "address": "string",
  "city": "string",
  "state": "string",
  "zipCode": "string",
  "description": "string"
}
```

PUT: api/Properties/AddImagetoProperty/3
```
{
  "propertyID": 0,
  "imageData": "string",
  "description": "string"
}
```

