# Examples.ContosoUniversity

## References

* [ASP.NET Core での Entity Framework Core を使用した Razor Pages - チュートリアル 1/8](https://docs.microsoft.com/ja-jp/aspnet/core/data/ef-rp/intro)

## Project Initialize

```shell
## Solution
dotnet new sln -o .

## Examples.ContosoUniversity
dotnet new classlib -o src/Examples.ContosoUniversity
dotnet sln add src/Examples.ContosoUniversity
cd src/Examples.ContosoUniversity

dotnet add package Microsoft.EntityFrameworkCore.Relational

cd ../../

# Update outdated package
dotnet list package --outdated
```

