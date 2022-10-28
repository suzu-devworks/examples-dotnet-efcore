# docs

## The way to the present

### Clone repository

```shell
git clone https://github.com/suzu-devworks/examples-dotnet-efcore.git
```

### Create solution

```shell
cd examples-dotnet-efcore
dotnet new sln -o .

## Examples.EntityFrameworkCore
dotnet new classlib -o src/Examples.EntityFrameworkCore
dotnet sln add src/Examples.EntityFrameworkCore
cd src/Examples.EntityFrameworkCore
dotnet add package Microsoft.EntityFrameworkCore.Relational
cd ../../

## Examples.EntityFrameworkCore.Tests
dotnet new xunit -o src/Examples.EntityFrameworkCore.Tests
dotnet sln add src/Examples.EntityFrameworkCore.Tests/
dotnet add src/Examples.EntityFrameworkCore.Tests/ reference src/Examples.EntityFrameworkCore/
cd src/Examples.EntityFrameworkCore.Tests
dotnet add package Microsoft.Extensions.Logging.Debug
dotnet add package Moq
dotnet add package ChainingAssertion.Core.Xunit
dotnet add package Microsoft.EntityFrameworkCore.InMemory
cd ../../

## Examples.EntityFrameworkCore.SQLite.Tests
dotnet new xunit -o src/Examples.EntityFrameworkCore.SQLite.Tests
dotnet sln add src/Examples.EntityFrameworkCore.SQLite.Tests/
dotnet add src/Examples.EntityFrameworkCore.SQLite.Tests/ reference src/Examples.EntityFrameworkCore/
dotnet add src/Examples.EntityFrameworkCore.SQLite.Tests/ reference src/Examples.Xunit/
cd src/Examples.EntityFrameworkCore.SQLite.Tests
dotnet add package Moq
dotnet add package ChainingAssertion.Core.Xunit
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.Design
cd ../../

## Examples.EntityFrameworkCore.SqlServer.Tests
dotnet new xunit -o src/Examples.EntityFrameworkCore.SqlServer.Tests
dotnet sln add src/Examples.EntityFrameworkCore.SqlServer.Tests/
dotnet add src/Examples.EntityFrameworkCore.SqlServer.Tests/ reference src/Examples.EntityFrameworkCore/
dotnet add src/Examples.EntityFrameworkCore.SqlServer.Tests/ reference src/Examples.Xunit/
cd src/Examples.EntityFrameworkCore.SQLite.Tests
dotnet add package Moq
dotnet add package ChainingAssertion.Core.Xunit
dotnet add package Microsoft.EntityFrameworkCore.SqlServer
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.Data.SqlClient
cd ../../

## Tools
dotnet new tool-manifest
dotnet tool install dotnet-ef

## Migrations
dotnet ef migrations add InitialCreation
dotnet ef database update

```

### Build

```shell
dotnet restore
dotnet tool restore

dotnet build

# Update outdated package
dotnet list package --outdated

```


