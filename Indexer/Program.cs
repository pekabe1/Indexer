using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Indexer
{
    class Program
    {
        static void Main(string[] args)
        {
            //List<Animal> animals = new List<Animal>();
            //List<Country> countries = new List<Country>
            //{
            //    new Country { Name = "Uganda", CountryId = 1 },
            //    new Country { Name = "Poland", CountryId = 2 }
            //};


            //AddAniamals(animals);

            //var elephant = from zwierz in animals
            //               where zwierz.Name == "Elephant"
            //               select zwierz.Name;

            //var mumifant = animals.Where(x => x.Name == "Elephant").FirstOrDefault().Name;

            //var avg = animals.Average(x => x.Age);
            //var min = animals.Min(x => x.Age);
            //var max = animals.Max(x => x.Age);
            //var groupByName = animals.GroupBy(e => new { e.Name }).Select(g => new { Name = g.Key, Age = g.Sum(a => a.Age) });


            //// Console.WriteLine(groupByName.FirstOrDefault().Age+""+ groupByName.FirstOrDefault().Name);
            //// LinQ super

            ////animals.ForEach(a =>
            ////Console.WriteLine(a.Name)
            ////);
            ////   var toAdd = elephant.ToList();
            //var isŃ = animals.Where(a => a.Name.Contains("e"));


            //var IsValid = animals.Where((a => a.Id > 1 && a.Age < 21 || a.Age % 2 == 1)).Distinct().ToList();
            ////  IsValid.ForEach(a => Console.WriteLine(a.Name));
            //var polskieZierzaki = animals.Join(countries,
            //    animal => animal.CountryId,
            //    country => country.CountryId,
            //    (animal, country) => new
            //    {
            //        id = animal.Id,
            //        Name = animal.Name,
            //        Age = animal.Age,
            //        CountryName = country.Name
            //    }).Select(a => new Animal
            //    {}).ToList();
            //polskieZierzaki.ForEach(a => Console.WriteLine(a));






            //foreach (var item in isŃ)
            //{
            //    Console.WriteLine(item.Name);
            //}

            //Console.WriteLine(elephant.FirstOrDefault());
            //Console.WriteLine(mumifant);
            //Console.WriteLine(avg);
            //Console.WriteLine(min);
            //Console.WriteLine(max);

            var users = getUsers();// lista do czego rzutujemy
            //users.ForEach(a => Add(new WareHouser
            //{
                
            //    Name = "Test",
            //    Password = "Ka!@#2",
            //    Role = "Tester"

            //}));

          

            

         
            for (int i = 0; i < 1000; i++)
            {
                Delete(i);
            }
           
            users.ForEach(a => Console.WriteLine(a));
            Console.Read();
        }

        private static List<WareHouser> getUsers()
        {
            var users = new List<WareHouser>();
            XDocument document = XDocument.Load("XMLFile1.xml");//
            return
                document
                .Element("root")
                .Elements()
                .Select(e => new WareHouser
                {
                    Id = int.Parse(e.Attribute(nameof(WareHouser.Id)).Value),// use nameoff
                    Name = e.Attribute(nameof(WareHouser.Name)).Value,
                    Role = e.Attribute("Role").Value,
                    Password = e.Attribute("Password").Value,

                })
                .ToList();//


        }
        private static void Add(WareHouser item)
        {
            int ID = GetLastID() ?? 0;
            XDocument document = XDocument.Load("XMLFile1.xml");
            XElement element = new XElement("User",
                new XAttribute(nameof(WareHouser.Id), ID + 1),
                new XAttribute(nameof(WareHouser.Name), item.Name),
                new XAttribute(nameof(WareHouser.Role), item.Role),
                new XAttribute(nameof(WareHouser.Password), item.Password));
            document.Element("root").Add(element);
            document.Save("XMLFile1.xml");
        }

        private static bool Delete(int id)
        {
            XDocument document = XDocument.Load("XMLFile1.xml");
            var user = getUsers();
            document.Root.Elements().Where(a => a.Attribute("Id").Value == id.ToString()).Remove();
            
          
            return true;

        }

        private static int? GetLastID()
        {
            return getUsers().Count != 0 ? getUsers().Max(a => a.Id) : 0;
        }




        public static void AddAniamals(List<Animal> animals)
        {

            animals.Add(new Animal
            {
                Age = 85,
                Id = 1,
                Name = "Elephant",
                CountryId = 2

            });

            animals.Add(new Animal
            {
                Age = 8,
                Id = 2,
                Name = "Dog",
                CountryId = 1


            });

            animals.Add(new Animal
            {
                Age = 4,
                Id = 3,
                Name = "Cat",
                CountryId = 2

            });

            animals.Add(new Animal
            {
                Age = 6,
                Id = 4,
                Name = "Horse 1",
                CountryId = 1

            }); animals.Add(new Animal
            {
                Age = 7,
                Id = 5,
                Name = "Horse 2",
                CountryId = 2

            }); animals.Add(new Animal
            {
                Age = 9,
                Id = 6,
                Name = "Horse 3",
                CountryId = 1

            });


        }
    }
}
