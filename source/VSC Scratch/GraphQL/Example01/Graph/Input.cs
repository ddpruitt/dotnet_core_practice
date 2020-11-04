using System;
using Example01.Data;
using HotChocolate.Types.Relay;

namespace Example01.Graph
{
    public record AddManufacturerInput(string Name);
    public record AddProductInput(string Name, float Price, DateTime LastUpdated, int ManufacturerId);
}