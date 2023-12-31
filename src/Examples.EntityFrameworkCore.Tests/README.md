# Examples.EntityFrameworkCore.Tests

## Project Initialize

```shell
## Solution
dotnet new sln -o .

## Examples.EntityFrameworkCore
## Examples.ContosoUniversity
## Examples.Xunit

## Examples.EntityFrameworkCore.Tests
dotnet new xunit -o src/Examples.EntityFrameworkCore.Tests
dotnet sln add src/Examples.EntityFrameworkCore.Tests
cd src/Examples.EntityFrameworkCore.Tests

dotnet add reference src/Examples.EntityFrameworkCore/
dotnet add reference src/Examples.Xunit/
dotnet add reference src/Examples.ContosoUniversity/

dotnet add package Microsoft.NET.Test.Sdk
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package coverlet.collector
dotnet add package Moq
dotnet add package ChainingAssertion.Core.Xunit

dotnet add package Microsoft.EntityFrameworkCore.InMemory
dotnet add package Microsoft.EntityFrameworkCore.Design

cd ../../

# Update outdated package
dotnet list package --outdated
```

