using System;
using System.Linq;
using System.Collections.Generic;

namespace TryParseGuidList
{
    class Program
    {
        static void Main(string[] args)
        {
            var ids = new List<string> {
                "Abc",
                "{780955E7-2F79-445F-83FE-6CF165051838}",
                "{E60B96A8-A54F-4C12-B1FA-B3CBD67AAD6A}",
                "A0A08607-7565-4042-A5C4-6C73D97FDE34",
                "This is not a guid, Dude"
            };

            var guids = ids
                .Select(id => Guid.TryParse(id, out Guid parsedId) ? parsedId : Guid.Empty)
                .Where(id=>!id.Equals(Guid.Empty))
                .ToList();

                foreach(var g in guids)
                {
                    Console.WriteLine($"{g}");
                }
        }
    }
}
