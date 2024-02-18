# MvcApp Template

## Migration Commands

```
dotnet ef migrations add TestMig -c AppDbContext --project MvcApp.Persistance --startup-project MvcAppTemplate
```

```
dotnet ef database update -c AppDbContext --project MvcApp.Persistance --startup-project MvcAppTemplate
```

