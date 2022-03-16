using Classes;

class Program {   
    
    static void Main(string[] args) {
        Film[] films = new Film[] { new Film("Avengers", "Brothers Russo", "Action", 2012), //база данных с фильмами, хочу сделать чтение
                                    new Film("Rapunzel", "Jeff Bezos", "Romantic", 2020),   //из файла, но пока времени не хватило
                                    new Film("Iron Man", "I dont know", "Action", 2012),
                                    new Film("Grinch","Mark Zuckerberg", "Funny", 1999) };

        
        Sort sorted = UserInterface.Choose(UserInterface.GetKey());

        IEnumerable<string> names = sorted(films);

        foreach(string s in names) {
            Console.WriteLine(s);
        }
        
    }
}

