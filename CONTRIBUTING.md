
<details closed="closed">
  <summary><h2 style="display: inline-block">Table of Contents</h2></summary>
  <ol>
    <li><a href="#1-installation">Installation</a></li>
    <li><a href="#2-backend">Backend</a></li>
    <li><a href="#3-frontend">Frontend</a></li>
  </ol>
</details>

## 1. Installation.
## 2. Backend.
### API Development
### Infrastructure Development
####  DB Migration
Since we use code first apporach, database can be migrated from Models on a Context baiss by the following steps.
  1. Install dotnet-ef.<br>
    `dotnet tool install --global dotnet-ef` 
  1. Change directory to Backend Project.<br>
      `cd $(ProjectDir)` 
  1. Check [Model](https://github.com/shunmaruko/ASP.NET-React-WebApp/tree/master/Backend/Models) and specify [Context](https://github.com/shunmaruko/ASP.NET-React-WebApp/tree/master/Backend/Infrastructure/Context).Then edit some model.
  1. Generate migration file from CLI.Yon can name XXX freely and need to designate some context specified by the above step.<br>
      `dotnet ef migrations add XXX -o Infrastructure/Migrations --context SomeContext`
  1. Execute migration.<br>
      `dotnet ef database update --context SomeContext`
  1. Finally you can check how it changed in SSOX.<br>
#### DB rollback 
When you want to cancel migration, you can do it by the following procedure.
  1. Revert migration to previsous migration (XXX).<br>
    `dotnet ef database update XXX --context SomeContext` <br>
     Or, if you go back before first migration, you can run:<br>
    `dotnet ef database update 0 --context SomeContext` <br>
  1. Remove last migration files. <br>
    `ef database migrations remove --context SomeContext`<br>
For more inforamation, you can see [here](https://learn.microsoft.com/ja-jp/ef/core/managing-schemas/migrations/applying?tabs=dotnet-core-cli).
## 3. Frontend.
TODO: add description
  