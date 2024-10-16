using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography.X509Certificates;
using Newtonsoft.Json;
namespace Lab4
{
    class Buhalteria
    {
        public string surname;
        public int age;
        public int childCount;
        public string position;
        public int experiance;
        public Buhalteria(string sur, int age, int cCount, string position, int exp)
        {
            this.age = age;
            this.position = position;
            this.experiance = exp;
            this.childCount = cCount;
            this.surname = sur;
        }
    }
    public class Program
    {

        public static void Main()
        {
            List<Buhalteria> list1 = new List<Buhalteria>();
            list1.Add(new Buhalteria("Stepanenko", 24, 0, "Worker", 4));
            list1.Add(new Buhalteria("Ivanov", 30, 2, "Manager", 10));
            list1.Add(new Buhalteria("Petrenko", 28, 1, "Analyst", 7));
            list1.Add(new Buhalteria("Shevchenko", 35, 3, "Director", 12));
            list1.Add(new Buhalteria("Koval", 22, 0, "Intern", 1));

            string filename = "Buhalteria.json";
            string json = JsonConvert.SerializeObject(list1, Formatting.Indented);
            File.WriteAllText(filename, json);
            Console.WriteLine(File.ReadAllText(filename));
            searchByName("koval", json);
            searchByPosAndChilds("director", 3, json);
        }
        public static void searchByName(string surname, string json)
        {
            List<Buhalteria> buhalterias = JsonConvert.DeserializeObject<List<Buhalteria>>(json);
            for (int i = 0; i < buhalterias.Count; i++)
            {
                if (buhalterias[i].surname.ToLower() == surname.ToLower())
                {
                    Console.WriteLine($"Імя = {buhalterias[i].surname}, посада = {buhalterias[i].position}, ДІтей = {buhalterias[i].childCount}, Досвід = {buhalterias[i].experiance}");
                }
            }


        }
        public static void searchByPosAndChilds(string position, int childCount , string json)
        {
            List<Buhalteria> buhalterias = JsonConvert.DeserializeObject<List<Buhalteria>>(json);
            for (int i = 0; i < buhalterias.Count; i++)
            {
                if (buhalterias[i].position.ToLower() == position.ToLower()&& buhalterias[i].childCount==childCount)
                {
                    Console.WriteLine($"Імя = {buhalterias[i].surname}, посада = {buhalterias[i].position}, ДІтей = {buhalterias[i].childCount}, Досвід = {buhalterias[i].experiance}");
                }
            }
        }
    }
}