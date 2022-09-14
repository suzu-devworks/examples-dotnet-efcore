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
dotnet add package Moq
dotnet add package ChainingAssertion.Core.Xunit
dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Xunit.DependencyInjection
cd ../../


## Tools
dotnet new tool-manifest
dotnet tool install dotnet-ef

```

### Build

```shell
dotnet tool restore

dotnet build

# Update outdated package
dotnet list package --outdated

```
