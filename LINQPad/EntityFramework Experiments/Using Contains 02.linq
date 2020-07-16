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
var listOfIds = Enumerable.Range(1,500).Where(e => e % 13 == 0).ToList();
//listOfIds.Dump();

Person.Where(p => listOfIds.Contains(p.BusinessEntityId)).Dump();

/*
	Generated SQL:

		SELECT [p].[BusinessEntityID], [p].[AdditionalContactInfo], [p].[Demographics], [p].[EmailPromotion], [p].[FirstName], [p].[LastName], [p].[MiddleName], [p].[ModifiedDate], [p].[NameStyle], [p].[PersonType], [p].[rowguid], [p].[Suffix], [p].[Title]
		FROM [Person].[Person] AS [p]
		WHERE [p].[BusinessEntityID] IN (12, 24, 36, 48, 60, 72, 84, 96, 108, 120, 132, 144, 156, 168, 180, 192, 204, 216, 228, 240, 252, 264, 276, 288, 300, 312, 324, 336, 348, 360, 372, 384, 396, 408, 420, 432, 444, 456, 468, 480, 492)
		GO

	Note the WHERE Clause does not contain parameters.

*/