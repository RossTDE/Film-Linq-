using System;
using System.Collections.Generic;
using System.Linq;


namespace Classes {

    // - - - - - - - - - FILM - - - - - - - - -

    public class Film {
        public string Title { get; set; }
        public string Director { get; set; }
        public string Style { get; set; }
        public int Premier { get; set; }
        public int Money { get; set; }

        public Film(string title = "Unknown", 
                    string director = "Unknown",
                    string style = "Unknown",
                    int premiere = 0,
                    int money = 0) 
        {
            this.Title = title; //тут можно было не писать this, но мне очень нравится :Ь
            this.Director = director;
            this.Style = style;
            this.Premier = premiere;
            this.Money = Money;
        }

        public override string ToString() {
            return $"Title: {Title}, Director: {Director}, Style: {Style}, Premier: {Premier}";
        }
    }

    // - - - - - - - - - SEARCH - - - - - - - - -

    delegate IEnumerable<string> Sort(Film[] films); //делегат функции сортировки
    class Search {
        public static IEnumerable<string> Sort_by_name(Film[] films) {
            IEnumerable<string> names = 
                                from s in films
                                orderby s.Title
                                select s.Title;
            return names;
        }

        public static IEnumerable<string> Sort_by_money(Film[] films) {
            IEnumerable<string> names = 
                                from s in films
                                orderby s.Money
                                select s.Title;
            return names;
        }

        public static IEnumerable<string> Sort_by_hor_style(Film[] films) {
            IEnumerable<string> names = 
                                from s in films
                                where s.Style == "Horror"
                                orderby s.Title
                                select s.Title;
            return names;
        }

        public static IEnumerable<string> Sort_styles(Film[] films) {
            IEnumerable<string> names = 
                                from s in films
                                orderby s.Style
                                select s.Style;
            return names;
        }
    }

    // - - - - - - - - - UserInterface - - - - - - - - -

    class UserInterface {
        public static byte GetKey() {
            Console.WriteLine("Hello!");
            Console.WriteLine("If you want to sort your films by Titles press 1");
            Console.WriteLine("If you want to sort your films by Money press 2");
            Console.WriteLine("If you want to sort your films by Style \"Horror\" press 3");
            Console.WriteLine("If you want to see all Styles press 4");

            byte key;
            key = Convert.ToByte(Console.ReadLine());
            
            return key;
        }
        
        public static Sort Choose(byte key) {

            switch(key) {
                case 1 :
                    return Search.Sort_by_name;
                case 2 :
                    return Search.Sort_by_money;
                case 3 :
                    return Search.Sort_by_hor_style;
                default :
                    return Search.Sort_styles;

            }
        }
    }
}

