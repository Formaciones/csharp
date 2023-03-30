# Entity Framework Core
### ***Las herramientas de la interfaz de l�nea de comandos (CLI) Entity Framework Core realizar tareas de desarrollo en tiempo de dise�o.***
&nbsp;
&nbsp;
### ***INSTALACI�N DE DEPENDENCIAS***
---
***Instalaci�n indicando �ltima versi�n***
```
Install-Package Microsoft.EntityFrameworkCore
Install-Package Microsoft.EntityFrameworkCore.SqlServer
Install-Package Microsoft.EntityFrameworkCore.SqlServer.Design
Install-Package Microsoft.EntityFrameworkCore.Design
Install-Package Microsoft.EntityFrameworkCore.Tools
```

***Instalaci�n indicando una versi�n concreta***
```
Install-Package Microsoft.EntityFrameworkCore -Version 7.0.4
```

***Instalaci�n con el comando dotnet***
Tambi�n podemos instalar con el comando dotnet (el comando dotnet le ejecutamos desde la carpeta donde esta el fichero *.csproj):
```
dotnet add package Microsoft.EntityFrameworkCore -v 7.0.4
```
&nbsp;
&nbsp;
### ***GENERACI�N DEL MODELO DE DATOS***
---
```
Scaffold-DbContext "Server=LOCALHOST;Database=NORTHWIND;Trusted_Connection=True;" "Microsoft.EntityFrameworkCore.SqlServer" -OutputDir "Models" -ContextDir "Models" -Context "ModelNorthwind" -UseDatabaseNames -Force
```

```
Scaffold-DbContext "server=localhost;port=3306;user=root;password=pass;database=northwind" MySql.Data.EntityFrameworkCore -OutputDir "Models" -ContextDir "Models" -Context "ModelAnatteaSGIIC" -UseDatabaseNames -Force
```

```
Scaffold-DbContext "Server=tcp:dbname.database.windows.net,1433;Initial Catalog=DBNAME_DB;Persist Security Info=False;User ID=username;Password=password;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models
```

```
dotnet tool install --global dotnet-ef
dotnet ef dbcontext scaffold "Server=localhost;Database=NORTHWIND;Trusted_Connection=True;" Microsoft.EntityFrameworkCore.SqlServer -c ModelNorthwind -o Models --use-database-names
```