<Query Kind="Statements">
  <Connection>
    <ID>2dc8d0b5-afa3-4864-acfc-967c94988add</ID>
    <NamingServiceVersion>2</NamingServiceVersion>
    <Persist>true</Persist>
    <Driver Assembly="EF7Driver" PublicKeyToken="469b5aa5a4331a8c">EF7Driver.StaticDriver</Driver>
    <CustomAssemblyPath>C:\Projects\dotnet_core_practice\LINQPad\EntityFramework Experiments\AdventureWorks\AdventureWorks.Data\bin\Debug\netcoreapp3.1\AdventureWorks.Data.dll</CustomAssemblyPath>
    <CustomTypeName>AdventureWorks.Data.Context.AdventureWorksContext</CustomTypeName>
    <CustomCxString>Server=.;Database=AdventureWorks2019;Trusted_Connection=True;</CustomCxString>
    <DisplayName>Context.AdventureWorks2019</DisplayName>
    <DriverData>
      <UseDbContextOptions>true</UseDbContextOptions>
      <EFProvider>Microsoft.EntityFrameworkCore.SqlServer</EFProvider>
    </DriverData>
  </Connection>
  <Reference Relative="AdventureWorks\AdventureWorks.Data\bin\Debug\netcoreapp3.1\AdventureWorks.Data.dll">C:\Projects\dotnet_core_practice\LINQPad\EntityFramework Experiments\AdventureWorks\AdventureWorks.Data\bin\Debug\netcoreapp3.1\AdventureWorks.Data.dll</Reference>
  <NuGetReference>Microsoft.EntityFrameworkCore</NuGetReference>
  <NuGetReference>Microsoft.EntityFrameworkCore.SqlServer</NuGetReference>
  <Namespace>Microsoft.EntityFrameworkCore</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.Diagnostics</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.Infrastructure</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.Metadata</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.Metadata.Conventions</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.Migrations</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.Migrations.Operations</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.Design.Internal</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.Diagnostics.Internal</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.Infrastructure.Internal</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.Internal</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.Metadata.Internal</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.Migrations.Internal</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.Query.Internal</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.Scaffolding.Internal</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.Storage.Internal</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.Update.Internal</Namespace>
  <Namespace>Microsoft.EntityFrameworkCore.SqlServer.ValueGeneration.Internal</Namespace>
  <Namespace>Microsoft.Extensions.DependencyInjection</Namespace>
</Query>

// Using Entity Framework Core instead of Linq to SQL
var listOfIds = Enumerable.Range(1,100).Where(e => e % 3 == 0)
				.Concat(Enumerable.Range(1,100).Where(e => e % 5 == 0))
				.OrderBy(e => e)
				.Distinct()
				.ToList();
//listOfIds.Dump();

var raw_sql = ";with cte as (select CAST(value as int) as businessEntityID from STRING_SPLIT(@p0, ','))  select * from Person.Person where BusinessEntityID IN (select * from cte);";

Person
	.FromSqlRaw(raw_sql, string.Join(",", listOfIds))
	.AsEnumerable()
	.OrderBy(p => p.LastName)
	.ThenBy(p => p.FirstName)
	.Select(p => $"{p.BusinessEntityId:00}:  {p.LastName}, {p.FirstName}")
	.Dump();
	
/*
	------------------
	-- Region Parameters
	-- p0='3,5,6,9,10,12,15,18,20,21,24,25,27,30,33,35,36,39,40,42,45,48,50,51,54,55,57,60,63,65,66,69,70,72,75,78,80,81,84,85,87,90,93,95,96,99,100' (Size = 4000)
	-- EndRegion
	;with cte as (select CAST(value as int) as businessEntityID from STRING_SPLIT(@p0, ','))  select * from Person.Person where BusinessEntityID IN (select * from cte);
	GO
	------------------

*/
