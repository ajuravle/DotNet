using System;
using DotNet.Repositories;

namespace DotNet
{
    class Program
    {
        static void Main()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("---------------------\n" +
                                  "1. Print\n" +
                                  "2. Insert\n" +
                                  "3. Delete\n" +
                                  "4. Update\n" +
                                  "5. Exit\n" +
                                  "---------------------\n" +
                                  "Choose action:");
                int action = Convert.ToInt32(Console.ReadLine());
                switch (action)
                {
                    case 1:
                        Print();
                        break;
                    case 2:
                        Insert();
                        break;
                    case 3:
                        Delete();
                        break;
                    case 4:
                        Update();
                        break;
                    case 5:
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Wrong action");
                        break;
                }
            }
        }

        static void Print()
        {
            int table = ChooseTable();
            switch (table)
            {
                case 1:
                    CinemasRepository cinemaRepo = new CinemasRepository();
                    Console.WriteLine("Id Name NrRooms City Address");
                    foreach (var x in cinemaRepo.GetAll())
                        Console.WriteLine("{0} {1} {2} {3} {4}", x.CinemaId, x.Name, x.NrRooms, x.City, x.Address);
                    break;
                case 2:
                    MoviesRepository moviesRepo = new MoviesRepository();
                    Console.WriteLine("Id Title Genre AgeRestriction");
                    foreach (var x in moviesRepo.GetAll())
                    {
                        Console.WriteLine("{0} {1} {2} {3}", x.MovieId, x.Title, x.Genre, x.AgeRestriction);
                        foreach (var y in x.Actors)
                            Console.WriteLine("\t{0} {1}", y.FirstName, y.LastName);
                    }
                    break;
                case 3:
                    ActorsRepository actorsRepo = new ActorsRepository();
                    Console.WriteLine("Id FirstName LastName BirthDate");
                    foreach (var x in actorsRepo.GetAll())
                    {
                        Console.WriteLine("{0} {1} {2} {3}", x.ActorId, x.FirstName, x.LastName,
                            x.BirthDate.ToString("dd/MM/yyyy"));
                        foreach (var y in x.Movies)
                            Console.WriteLine("\t{0}", y.Title);
                    }
                    break;
                case 4:
                    var ticketsRepo = new TicketsRepository();
                    Console.WriteLine("Id Movie Room DateTime Price");
                    foreach (var x in ticketsRepo.GetAll())
                        Console.WriteLine("{0} {1} {2} {3} {4}", x.TicketId, x.Movie.Title, x.Cinema.Name,
                            x.DateTime, x.Price);
                    break;
                default:
                    Console.WriteLine("Wrong table");
                    break;
            }
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }


        static void Insert()
        {
            int table = ChooseTable();
            switch (table)
            {
                case 1:
                    InsertCinemas();
                    break;
                case 2:
                    InsertMovies();
                    break;
                case 3:
                    InsertActors();
                    break;
                case 4:
                    InsertTickets();
                    break;
                default:
                    Console.WriteLine("Wrong table");
                    break;
            }
        }

        static void InsertCinemas()
        {
            string name, city, address;
            short nrRooms;
            Console.WriteLine("Name: ");
            name = Console.ReadLine();
            Console.WriteLine("Number rooms: ");
            nrRooms = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("City: ");
            city = Console.ReadLine();
            Console.WriteLine("Address: ");
            address = Console.ReadLine();

            Cinema cinema = new Cinema()
            {
                Name = name,
                NrRooms = nrRooms,
                City = city,
                Address = address
            };
            CinemasRepository cinemaRepo = new CinemasRepository();
            cinemaRepo.Add(cinema);
            
        }

        static void InsertMovies()
        {
            string title, genre;
            short duration, ageRestriction, actor = -2;
            Console.WriteLine("Title: ");
            title = Console.ReadLine();
            Console.WriteLine("Genre: ");
            genre = Console.ReadLine();
            Console.WriteLine("Duration: ");
            duration = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Age restrition: ");
            ageRestriction = Convert.ToInt16(Console.ReadLine());


            Movie movie = new Movie()
            {
                Title = title,
                Genre = genre,
                Duration = duration,
                AgeRestriction = ageRestriction
            };

            Console.WriteLine("Actors: ");
            var repo = new ActorsRepository();
            var items = repo.GetAll();
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine(i + ". " + items[i].FirstName + " " + items[i].LastName);
            while (actor != -1)
            {
                Console.WriteLine("Choose one or \"-1\" to save");
                actor = Convert.ToInt16(Console.ReadLine());
                if (actor >= 0 && actor < items.Count)
                {
                    movie.Actors.Add(items[actor]);
                }
            }

            MoviesRepository moviesRepo = new MoviesRepository();
            moviesRepo.Add(movie);
            

        }

        static void InsertActors()
        {
            string firstName, lastName;
            DateTime birthDate;
            int movie = -2;
            Console.WriteLine("First name: ");
            firstName = Console.ReadLine();
            Console.WriteLine("Last name: ");
            lastName = Console.ReadLine();
            Console.WriteLine("Birth date (dd/mm/yyyy): ");
            birthDate = Convert.ToDateTime(Console.ReadLine());

            Actor actor = new Actor()
            {
                FirstName = firstName,
                LastName = lastName,
                BirthDate = birthDate,
            };

            Console.WriteLine("Movies: ");
            var repo = new MoviesRepository();
            var items = repo.GetAll();
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine(i + ". " + items[i].Title);
            while (movie != -1)
            {
                Console.WriteLine("Choose one or \"-1\" to save");
                movie = Convert.ToInt16(Console.ReadLine());
                if (movie >= 0 && movie < items.Count)
                {
                    actor.Movies.Add(items[movie]);
                }
            }

            ActorsRepository actorsRepo = new ActorsRepository();
            actorsRepo.Add(actor);
            
        }

        static void InsertTickets()
        {
            DateTime dateTime;
            short price, movie = -2, cinema = -2;
            Console.WriteLine("Price: ");
            price = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Date and time (dd/mm/yyyy HH:mm): ");
            dateTime = Convert.ToDateTime(Console.ReadLine());

            Ticket ticket = new Ticket()
            {
                Price = price,
                DateTime = dateTime
            };

            var repo = new MoviesRepository();
            var items = repo.GetAll();
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine(i + ". " + items[i].Title);
            while (movie < 0 || movie > items.Count - 1)
            {
                Console.WriteLine("Choose one: ");
                movie = Convert.ToInt16(Console.ReadLine());
            }
            ticket.Movie = items[movie];

            var repo2 = new CinemasRepository();
            var items2 = repo2.GetAll();
            for (int i = 0; i < items2.Count; i++)
                Console.WriteLine(i + ". " + items2[i].Name);
            while (cinema < 0 || cinema > items2.Count - 1)
            {
                Console.WriteLine("Choose one: ");
                cinema = Convert.ToInt16(Console.ReadLine());
            }
            ticket.Cinema = items2[cinema];

            TicketsRepository ticketsRepo = new TicketsRepository();
            ticketsRepo.Add(ticket);

        }

        static void Delete()
        {

            int choice = -1;

            int table = ChooseTable();
            switch (table)
            {
                case 1:
                    var cinemaRepo = new CinemasRepository();
                    var items = cinemaRepo.GetAll();
                    Console.WriteLine("Id Name NrRooms City Address");
                    for (int i = 0; i < items.Count; i++)
                        Console.WriteLine("{0} {1} {2} {3} {4}", i, items[i].Name, items[i].NrRooms, items[i].City,
                            items[i].Address);
                    while (choice < 0 || choice > items.Count - 1)
                    {
                        Console.WriteLine("Choose one: ");
                        choice = Convert.ToInt16(Console.ReadLine());
                    }
                    cinemaRepo.Delete(items[choice]);
                    break;
                case 2:
                    var moviesRepo = new MoviesRepository();
                    var items3 = moviesRepo.GetAll();
                    Console.WriteLine("Id Title Genre AgeRestriction");
                    for (int i = 0; i < items3.Count; i++)
                        Console.WriteLine("{0} {1} {2} {3}", i, items3[i].Title, items3[i].Genre,
                            items3[i].AgeRestriction);
                    while (choice < 0 || choice > items3.Count - 1)
                    {
                        Console.WriteLine("Choose one: ");
                        choice = Convert.ToInt16(Console.ReadLine());
                    }
                    moviesRepo.Delete(items3[choice]);
                    break;
                case 3:
                    var actorsRepo = new ActorsRepository();
                    var items4 = actorsRepo.GetAll();
                    Console.WriteLine("Id FirstName LastName BirthDate");
                    for (int i = 0; i < items4.Count; i++)
                        Console.WriteLine("{0} {1} {2} {3}", i, items4[i].FirstName, items4[i].LastName,
                            items4[i].BirthDate.ToString("dd/MM/yyyy"));
                    while (choice < 0 || choice > items4.Count - 1)
                    {
                        Console.WriteLine("Choose one: ");
                        choice = Convert.ToInt16(Console.ReadLine());
                    }
                    actorsRepo.Delete(items4[choice]);
                    break;
                case 4:
                    var ticketsRepo = new TicketsRepository();
                    var items5 = ticketsRepo.GetAll();
                    Console.WriteLine("Id Movie Room DateTime Price");
                    for (int i = 0; i < items5.Count; i++)
                        Console.WriteLine("{0} {1} {2} {3} {4}", i, items5[i].Movie.Title, items5[i].Cinema.CinemaId,
                            items5[i].DateTime,
                            items5[i].Price);
                    while (choice < 0 || choice > items5.Count - 1)
                    {
                        Console.WriteLine("Choose one: ");
                        choice = Convert.ToInt16(Console.ReadLine());
                    }
                    ticketsRepo.Delete(items5[choice]);
                    break;
                default:
                    Console.WriteLine("Wrong table");
                    break;
            }
        }

        static void Update()
        { 
            int table = ChooseTable();
            switch (table)
            {
                case 1:
                    UpdateCinemas();
                    break;
                case 2:
                    UpdateMovies();
                    break;
                case 3:
                    UpdateActors();
                    break;
                default:
                    Console.WriteLine("Wrong table");
                    break;
            }
        }

        static void UpdateCinemas()
        {
            int choice = -1;
            var repo = new CinemasRepository();
            var items = repo.GetAll();
            Console.WriteLine("Id Name NrRooms City Address");
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine("{0} {1} {2} {3} {4}", i, items[i].Name, items[i].NrRooms, items[i].City,
                    items[i].Address);
            while (choice < 0 || choice > items.Count - 1)
            {
                Console.WriteLine("Choose one: ");
                choice = Convert.ToInt16(Console.ReadLine());
            }

            string name, city, address;
            short nrRooms;
            Console.WriteLine("Name (OLD: {0}): ", items[choice].Name);
            name = Console.ReadLine();
            Console.WriteLine("Number rooms: (OLD: {0})", items[choice].NrRooms);
            nrRooms = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("City: (OLD: {0})", items[choice].City);
            city = Console.ReadLine();
            Console.WriteLine("Address: (OLD: {0})", items[choice].Address);
            address = Console.ReadLine();

            Cinema cinema = items[choice];
            cinema.Name = name;
            cinema.NrRooms = nrRooms;
            cinema.City = city;
            cinema.Address = address;

            CinemasRepository cinemaRepo = new CinemasRepository();
            cinemaRepo.Update(cinema);
            
        }

        static void UpdateMovies()
        {
            int choice = -1;
            var repo = new MoviesRepository();
            var items3 = repo.GetAll();
            Console.WriteLine("Id Title Genre AgeRestriction");
            for (int i = 0; i < items3.Count; i++)
                Console.WriteLine("{0} {1} {2} {3}", i, items3[i].Title, items3[i].Genre, items3[i].AgeRestriction);
            while (choice < 0 || choice > items3.Count - 1)
            {
                Console.WriteLine("Choose one: ");
                choice = Convert.ToInt16(Console.ReadLine());
            }

            string title, genre;
            short duration, ageRestriction, actor = -2;
            Console.WriteLine("Title (OLD: {0}): ", items3[choice].Title);
            title = Console.ReadLine();
            Console.WriteLine("Genre (OLD: {0}): ", items3[choice].Genre);
            genre = Console.ReadLine();
            Console.WriteLine("Duration (OLD: {0}): ", items3[choice].Duration);
            duration = Convert.ToInt16(Console.ReadLine());
            Console.WriteLine("Age restrition (OLD: {0}): ", items3[choice].AgeRestriction);
            ageRestriction = Convert.ToInt16(Console.ReadLine());

            Movie movie = items3[choice];

            movie.Title = title;
            movie.Genre = genre;
            movie.Duration = duration;
            movie.AgeRestriction = ageRestriction;
            
            Console.WriteLine("Actors: ");
            var repo2= new ActorsRepository();
            var items = repo2.GetAll();
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine(i + ". " + items[i].FirstName + " " + items[i].LastName);
            while (actor != -1)
            {
                Console.WriteLine("Choose one or \"-1\" to save");
                actor = Convert.ToInt16(Console.ReadLine());
                if (actor >= 0 && actor < items.Count)
                {
                    movie.Actors.Add(items[actor]);
                }
            }

            MoviesRepository moviesRepo = new MoviesRepository();
            moviesRepo.Update(movie);

        }

        static void UpdateActors()
        {
            int choice = -1;
            var repo = new ActorsRepository();
            var items4 = repo.GetAll();
            Console.WriteLine("Id FirstName LastName BirthDate");
            for (int i = 0; i < items4.Count; i++)
                Console.WriteLine("{0} {1} {2} {3}", i, items4[i].FirstName, items4[i].LastName,
                    items4[i].BirthDate.ToString("dd/MM/yyyy"));
            while (choice < 0 || choice > items4.Count - 1)
            {
                Console.WriteLine("Choose one: ");
                choice = Convert.ToInt16(Console.ReadLine());
            }

            string firstName, lastName;
            DateTime birthDate;
            int movie = -2;
            Console.WriteLine("First name (OLD: {0}): ", items4[choice].FirstName);
            firstName = Console.ReadLine();
            Console.WriteLine("Last name (OLD: {0}): ", items4[choice].LastName);
            lastName = Console.ReadLine();
            Console.WriteLine("Birth date (dd/mm/yyyy) (OLD: {0}): ",
                items4[choice].BirthDate.ToString("dd/MM/yyyy"));
            birthDate = Convert.ToDateTime(Console.ReadLine());

            Actor actor = items4[choice];

            actor.FirstName = firstName;
            actor.LastName = lastName;
            actor.BirthDate = birthDate;
           
            Console.WriteLine("Movies: ");
            var repo2 = new MoviesRepository();
            var items = repo2.GetAll();
            for (int i = 0; i < items.Count; i++)
                Console.WriteLine(i + ". " + items[i].Title);
            while (movie != -1)
            {
                Console.WriteLine("Choose one or \"-1\" to save");
                movie = Convert.ToInt16(Console.ReadLine());
                if (movie >= 0 && movie < items.Count)
                {
                    actor.Movies.Add(items[movie]);
                }
            }
            ActorsRepository actorsRepo = new ActorsRepository();
            actorsRepo.Update(actor);
            
        }

        static int ChooseTable()
        {
            Console.Clear();
            Console.WriteLine("---------------------\n" +
                              "1. Cinemas\n" +
                              "2. Movies\n" +
                              "3. Actors\n" +
                              "4. Tickets\n" +
                              "---------------------\n" +
                              "Choose table:");
            int table = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            return table;
        }
    }
}
