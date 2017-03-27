using System;
using ConsoleApplication.ServiceReference;
using DotNet;

namespace ConsoleApplication
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
                        //Update();
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
            MyServiceClient client = new MyServiceClient();

            int table = ChooseTable();
            switch (table)
            {
                case 1:
                    Console.WriteLine("Id Name NrRooms City Address");
                    foreach (var x in client.GetCinemas())
                        Console.WriteLine("{0} {1} {2} {3} {4}", x.CinemaId, x.Name, x.NrRooms, x.City, x.Address);
                    break;
                case 2:                    
                    Console.WriteLine("Id Title Genre AgeRestriction");
                    foreach (var x in client.GetMovies())
                    {
                        Console.WriteLine("{0} {1} {2} {3}", x.MovieId, x.Title, x.Genre, x.AgeRestriction);
                        foreach (var y in x.Actors)
                            Console.WriteLine("\t{0} {1}", y.FirstName, y.LastName);
                    }
                    break;
                case 3:
                    Console.WriteLine("Id FirstName LastName BirthDate");
                    foreach (var x in client.GetActors())
                    {
                        Console.WriteLine("{0} {1} {2} {3}", x.ActorId, x.FirstName, x.LastName,
                            x.BirthDate.ToString("dd/MM/yyyy"));
                        foreach (var y in x.Movies)
                            Console.WriteLine("\t{0}", y.Title);
                    }
                    break;
                case 4:
                    Console.WriteLine("Id Movie Room DateTime Price");
                    foreach (var x in client.GetTickets())
                        Console.WriteLine("{0} {1} {2} {3} {4}", x.TicketId, x.Movie.Title, x.Cinema.Name,
                            x.DateTime, x.Price);
                    break;
                default:
                    Console.WriteLine("Wrong table");
                    break;
            }
            client.Close();
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

            MyServiceClient client = new MyServiceClient();
            client.AddCinema(cinema);
            client.Close();
        }

        static void InsertMovies()
        {
            MyServiceClient client = new MyServiceClient();

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
            var items = client.GetActors();
            for (int i = 0; i < items.Length; i++)
                Console.WriteLine(i + ". " + items[i].FirstName + " " + items[i].LastName);
            while (actor != -1)
            {
                Console.WriteLine("Choose one or \"-1\" to save");
                actor = Convert.ToInt16(Console.ReadLine());
                if (actor >= 0 && actor < items.Length)
                {
                    movie.Actors.Add(items[actor]);
                }
            }
            
            client.AddMovie(movie);
            client.Close();

        }

        static void InsertActors()
        {
            MyServiceClient client = new MyServiceClient();

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
            var items = client.GetMovies();
            for (int i = 0; i < items.Length; i++)
                Console.WriteLine(i + ". " + items[i].Title);
            while (movie != -1)
            {
                Console.WriteLine("Choose one or \"-1\" to save");
                movie = Convert.ToInt16(Console.ReadLine());
                if (movie >= 0 && movie < items.Length)
                {
                    actor.Movies.Add(items[movie]);
                }
            }

            client.AddActor(actor);
            client.Close();
        }

        static void InsertTickets()
        {
            MyServiceClient client = new MyServiceClient();

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
            
            var items =client.GetMovies();
            for (int i = 0; i < items.Length; i++)
                Console.WriteLine(i + ". " + items[i].Title);
            while (movie < 0 || movie > items.Length - 1)
            {
                Console.WriteLine("Choose one: ");
                movie = Convert.ToInt16(Console.ReadLine());
            }
            ticket.Movie = items[movie];

            var items2 = client.GetCinemas();
            for (int i = 0; i < items2.Length; i++)
                Console.WriteLine(i + ". " + items2[i].Name);
            while (cinema < 0 || cinema > items2.Length - 1)
            {
                Console.WriteLine("Choose one: ");
                cinema = Convert.ToInt16(Console.ReadLine());
            }
            ticket.Cinema = items2[cinema];

            
            client.AddTicket(ticket);
            client.Close();
        }

        static void Delete()
        {
            MyServiceClient client = new MyServiceClient();
            int choice = -1;

            int table = ChooseTable();
            switch (table)
            {
                case 1:
                    var items = client.GetCinemas();
                    Console.WriteLine("Id Name NrRooms City Address");
                    for (int i = 0; i < items.Length; i++)
                        Console.WriteLine("{0} {1} {2} {3} {4}", i, items[i].Name, items[i].NrRooms, items[i].City,
                            items[i].Address);
                    while (choice < 0 || choice > items.Length - 1)
                    {
                        Console.WriteLine("Choose one: ");
                        choice = Convert.ToInt16(Console.ReadLine());
                    }
                    client.DeleteCinema(items[choice]);
                    break;
                case 2:
                    
                    var items3 = client.GetMovies();
                    Console.WriteLine("Id Title Genre AgeRestriction");
                    for (int i = 0; i < items3.Length; i++)
                        Console.WriteLine("{0} {1} {2} {3}", i, items3[i].Title, items3[i].Genre,
                            items3[i].AgeRestriction);
                    while (choice < 0 || choice > items3.Length - 1)
                    {
                        Console.WriteLine("Choose one: ");
                        choice = Convert.ToInt16(Console.ReadLine());
                    }
                    client.DeleteMovie(items3[choice]);
                    break;
                case 3:
                    
                    var items4 = client.GetActors();
                    Console.WriteLine("Id FirstName LastName BirthDate");
                    for (int i = 0; i < items4.Length; i++)
                        Console.WriteLine("{0} {1} {2} {3}", i, items4[i].FirstName, items4[i].LastName,
                            items4[i].BirthDate.ToString("dd/MM/yyyy"));
                    while (choice < 0 || choice > items4.Length - 1)
                    {
                        Console.WriteLine("Choose one: ");
                        choice = Convert.ToInt16(Console.ReadLine());
                    }
                    client.DeleteActor(items4[choice]);
                    break;
                case 4:
                    var items5 = client.GetTickets();
                    Console.WriteLine("Id Movie Room DateTime Price");
                    for (int i = 0; i < items5.Length; i++)
                        Console.WriteLine("{0} {1} {2} {3} {4}", i, items5[i].Movie.Title, items5[i].Cinema.CinemaId,
                            items5[i].DateTime,
                            items5[i].Price);
                    while (choice < 0 || choice > items5.Length - 1)
                    {
                        Console.WriteLine("Choose one: ");
                        choice = Convert.ToInt16(Console.ReadLine());
                    }
                    client.DeleteTicket(items5[choice]);
                    break;
                default:
                    Console.WriteLine("Wrong table");
                    break;
            }
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
