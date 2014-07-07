using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using Xero.Api.Core.Model;
using Xero.Api.Core.Model.Types;

namespace Xero.Api.Example.Creation.Creator
{
    public class Creator
    {
        public IEnumerable<Name> People(int count)
        {
            IList<string> given;
            IList<string> surname;

            using (var g = new StreamReader("data/Given.txt"))
            using (var s = new StreamReader("data/Surnames.txt"))
            {
                given = g.ReadToEnd().Split('\n');
                surname = s.ReadToEnd().Split('\n');
            }

            var givenCount = given.Count;
            var surnameCount = surname.Count;
            var rnd = new Random();
            var names = new List<Name>();

            for (int i = 0; i < count; i++)
            {
                names.Add(new Name
                {
                    Given = given[rnd.Next(givenCount)].Trim(),
                    Family = surname[rnd.Next(surnameCount)].Trim()
                });
            }

            return names;
        }

        public IEnumerable<Address> Addresses(int count)
        {
            IList<string> places;
            IList<string> streets;

            using (var p = new StreamReader("data/place_index.txt"))
            using (var s = new StreamReader("data/street_index.txt"))
            {
                places = (p.ReadToEnd().Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries)
                    .Where(street => !(string.IsNullOrWhiteSpace(street) || street.StartsWith(" ")))
                    .Select(street => Regex.Match(street, @"(.*)\,.*"))
                    .Where(match => match.Success)
                    .Select(match => match.Groups[1].Value)).ToList();

                streets = (s.ReadToEnd().Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries)
                    .Where(street => !(string.IsNullOrWhiteSpace(street) || street.StartsWith(" ")))
                    .Select(street => Regex.Match(street, @"(.*)\,.*"))
                    .Where(match => match.Success)
                    .Select(match => match.Groups[1].Value)).ToList();
            }

            var placeCount = places.Count;
            var streetCount = streets.Count;
                
            var rnd = new Random();
            var addresses = new List<Address>();

                for (int i = 0; i < count; i++)
                {
                    addresses.Add(new Address
                    {
                        AddressLine1 = string.Format("{0} {1}", rnd.Next(1000), streets[rnd.Next(streetCount)]),
                        City = places[rnd.Next(placeCount)],
                        AddressType = AddressType.Street
                    });
                }

            return addresses;
        }

        public IEnumerable<string> Descriptions(int count)
        {
            using (var d = new StreamReader("data/Descriptions.txt"))
            {
                return (d.ReadToEnd().Split(new[] {'\n'}, StringSplitOptions.RemoveEmptyEntries))
                    .Take(count)
                    .Select(p => p.Trim());                
            }
        }
    }
}
