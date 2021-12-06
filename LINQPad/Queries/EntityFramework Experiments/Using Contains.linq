<Query Kind="Statements">
  <Connection>
    <ID>b6800bda-3ba8-4aaa-b17e-5ae7673d5c6f</ID>
    <Persist>true</Persist>
    <Server>.</Server>
    <Database>AdventureWorks2019</Database>
  </Connection>
</Query>

var listOfIds = Enumerable.Range(1,500).Where(e => e % 12 == 0).ToList();
//listOfIds.Dump();

Persons.Where(p => listOfIds.Contains(p.BusinessEntityID)).Dump();