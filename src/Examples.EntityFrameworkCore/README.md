# Examples.EntityFrameworkCore

## Project Initialize

```shell
## Solution
dotnet new sln -o .

## Examples.EntityFrameworkCore
dotnet new classlib -o src/Examples.EntityFrameworkCore
dotnet sln add src/Examples.EntityFrameworkCore
cd src/Examples.EntityFrameworkCore

dotnet add package Microsoft.EntityFrameworkCore.Relational

cd ../../

# Update outdated package
dotnet list package --outdated
```

