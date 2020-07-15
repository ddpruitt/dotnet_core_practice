<Query Kind="Statements">
  <Connection>
    <ID>b6800bda-3ba8-4aaa-b17e-5ae7673d5c6f</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>AdventureWorks2019</Database>
  </Connection>
  <NuGetReference>LINQKit.Core</NuGetReference>
  <Namespace>LinqKit</Namespace>
</Query>

// Using LINQKit for the PredicateBuilder to be able to OR all of the ID's

var predicate = PredicateBuilder.New<Person>();

Enumerable.Range(1, 5000)
	.Where(e => e % 12 == 0)
	.ToList()
	.ForEach(oi => predicate = predicate.Or(p=>p.BusinessEntityID==oi));

var personQuery = Persons.Where(predicate);

personQuery.Dump();