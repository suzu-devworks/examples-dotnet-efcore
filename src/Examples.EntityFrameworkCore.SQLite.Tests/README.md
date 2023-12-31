# Examples.EntityFrameworkCore.SQLite.Tests

## Project Initialize

```shell
## Solution
dotnet new sln -o .

## Examples.EntityFrameworkCore
## Examples.ContosoUniversity
## Examples.Xunit

## Examples.EntityFrameworkCore.SQLite.Tests
dotnet new xunit -o src/Examples.EntityFrameworkCore.SQLite.Tests
dotnet sln add src/Examples.EntityFrameworkCore.SQLite.Tests
cd src/Examples.EntityFrameworkCore.SQLite.Tests

dotnet add reference src/Examples.EntityFrameworkCore/
dotnet add reference src/Examples.Xunit/
dotnet add reference src/Examples.ContosoUniversity/

dotnet add package Microsoft.NET.Test.Sdk
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package coverlet.collector
dotnet add package Moq
dotnet add package ChainingAssertion.Core.Xunit

dotnet add package Microsoft.EntityFrameworkCore.SQLite
dotnet add package Microsoft.EntityFrameworkCore.Design

cd ../../

# Update outdated package
dotnet list package --outdated
```

