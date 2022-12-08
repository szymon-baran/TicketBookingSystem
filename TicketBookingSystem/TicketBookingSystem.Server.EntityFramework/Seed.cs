using TicketBookingSystem.Shared.Domain;

namespace TicketBookingSystem.Server.EntityFramework
{
    public static class Seed
    {
        public static void LoadInitialData(ApplicationDbContext context)
        {
            AddPlaces(context);
            AddArtists(context);
            AddEvents(context);
        }

        private static void AddPlaces(ApplicationDbContext context)
        {
            if (context.Places.Any())
            {
                return;
            }

            List<Place> places = new()
            {
                new Place
                {
                    Country = "Polska",
                    City = "Warszawa",
                    Name = "Stadion Narodowy w Warszawie",
                    PhotoUrl = "https://ocdn.eu/pulscms-transforms/1/uNRk9kpTURBXy85YmJlZGNkZWZhYjA1MGEyY2M0ZTk0NDFiMWVjNTRiNC5qcGeTlQMAzHDNB9DNBGWTBc0EsM0CpJMJpmRlOWJkMgbeAAGhMAE/decyzja-ministra-sportu-kamila-bortniczuka-stadion-narodowy-zostanie-bezterminowo-zamkniety.jpg",
                    MaxSittingCapacity = 58580,
                    MaxStandingCapacity = 15000
                },
                new Place
                {
                    Country = "Polska",
                    City = "Kielce",
                    Name = "Amfiteatr Kadzielnia",
                    PhotoUrl = "https://www.emkielce.pl/media/k2/items/cache/68f530690fd63d955a623f65b761e644_XL.jpg",
                    MaxSittingCapacity = 5000,
                    MaxStandingCapacity = 500
                },
                new Place
                {
                    Country = "Polska",
                    City = "Kraków",
                    Name = "TAURON Arena",
                    PhotoUrl = "https://www.tauronarenakrakow.pl/content/uploads/2020/03/21-810x550.jpg",
                    MaxSittingCapacity = 15030,
                    MaxStandingCapacity = 7000
                },
            };

            context.Places.AddRange(places);
            context.SaveChanges();
        }

        private static void AddArtists(ApplicationDbContext context)
        {
            if (context.Artists.Any())
            {
                return;
            }

            List<Artist> artists = new()
            {
                new Artist
                {
                    FirstName = "Edward",
                    LastName = "Sheeran",
                    NickName = "Ed Sheeran",
                    AverageFanbaseAge = 25,
                    Description = @"Brytyjski piosenkarz, autor tekstów, gitarzysta, producent muzyczny i aktor, wykonujący muzykę z pogranicza popu, rocka, folku i hip-hopu.",
                    PhotoUrl = "https://bi.im-g.pl/im/e0/75/14/z21451232AMP,Ed-Sheeran-podczas-Brit-Awards--22-lutego-2017.jpg",
                    PrimaryMusicGenre = Shared.Dictionaries.MusicGenre.Pop,
                    SecondaryMusicGenre = Shared.Dictionaries.MusicGenre.RandB,
                    SpotifyUrl = "6eUKZXaKkcviH0Ku9w2n3V",
                    Events = null
                },
                new Artist
                {
                    FirstName = "Kanye",
                    LastName = "West",
                    NickName = "Ye",
                    AverageFanbaseAge = 27,
                    Description = @"Amerykański raper, wokalista, producent muzyczny, projektant mody oraz kandydat na prezydenta Stanów Zjednoczonych w 2020 roku. Uznawany jest za jedną z najważniejszych gwiazd muzyki popularnej XXI wieku.",
                    PhotoUrl = "https://bi.im-g.pl/im/99/6c/1a/z27705753AMP,Dzis-Ye--Kiedys-Kanye-West.jpg",
                    PrimaryMusicGenre = Shared.Dictionaries.MusicGenre.HipHop,
                    SecondaryMusicGenre = Shared.Dictionaries.MusicGenre.Pop,
                    SpotifyUrl = "5K4W6rqBFWDnAN6FQUkS6x",
                    Events = null
                },
                new Artist
                {
                    FirstName = "Robyn",
                    LastName = "Fenty",
                    NickName = "Rihanna",
                    AverageFanbaseAge = 32,
                    Description = @"Barbadoska piosenkarka R&B i pop, modelka, aktorka, autorka tekstów, projektantka mody i businesswoman. Realizacje z udziałem Rihanny były wielokrotnie wyróżniane i nagradzane. Artystka zebrała dziewięć nagród Grammy, pięć nagród przyznawanych corocznie dla najlepszego amerykańskiego muzyka American Music Awards, 22 nagrody Billboard Music Awards i dwie Brit Awards. Rihanna sprzedała ponad 250 milionów płyt na całym świecie, co daje jej wysokie miejsce na liście najlepiej sprzedających się artystów wszech czasów",
                    PhotoUrl = "https://www.elle.pl/media/cache/default_view/uploads/media/default/0008/90/rihanna-zwiazki-kto-byl-chlopakiem-gwiazdy-z-kim-spotyka-sie-teraz.jpeg",
                    PrimaryMusicGenre = Shared.Dictionaries.MusicGenre.Pop,
                    SecondaryMusicGenre = Shared.Dictionaries.MusicGenre.RandB,
                    SpotifyUrl = "5pKCCKE2ajJHZ9KAiaK11H",
                    Events = null
                },
                new Artist
                {
                    FirstName = "Zuzanna",
                    LastName = "Grabowska",
                    NickName = "Sanah",
                    AverageFanbaseAge = 17,
                    Description = @"Polska piosenkarka, skrzypaczka, autorka tekstów i kompozytorka, wykonująca muzykę z pogranicza indie pop i art pop, a także pop cyfrowy. Pseudonim „sanah” powstał po skróceniu angielskiej wersji pierwszego imienia piosenkarki – Susannah.",
                    PhotoUrl = "https://ocdn.eu/pulscms-transforms/1/aqAk9kpTURBXy8zNzYwOGM5Yjk4YjY1MmYyMzM1NTAxNDA1YzdkOTk0MC5qcGeTlQMAzKPNBDjNAl-TCaYxYmM0ZDAGkwXNBLDNAnbeAAGhMAE/sanah-czyli-zuzanna-jurczak.jpg",
                    PrimaryMusicGenre = Shared.Dictionaries.MusicGenre.Pop,
                    SecondaryMusicGenre = Shared.Dictionaries.MusicGenre.Classical,
                    SpotifyUrl = "0TMvoNR0AIJV138mHY6jdE",
                    Events = null
                },
                new Artist
                {
                    FirstName = "Patryk",
                    LastName = "Woziński",
                    NickName = "Kizo",
                    AverageFanbaseAge = 14,
                    Description = @"Pierwsze numery udostępniał już w 2009 roku. W początkach swoich działań był związany z Ciemną Strefą. W 2018 został wydany jego debiutancki album Ortalion przy współpracy ze Step Records oraz album Czempion. W 2019 wydał album Pegaz, a w 2020 wydał za pośrednictwem wytwórni chillwagon album Posejdon. Z kolejnej płyty Jeszcze pięć minut, wydanej w 2021, pochodzi przebój „Disney”, który 10 miesięcy po premierze przekroczył ponad 100 mln wyświetleń w serwisie YouTube. Pracuje również wraz z raperami takimi jak Jongmen i Bonus RPK nad projektem Heavyweight.",
                    PhotoUrl = "https://ocdn.eu/pulscms-transforms/1/MXok9kpTURBXy80NTYyZDBhMzMyM2YxOWRhMjU3NWE3ZDBjNDg1NTdkNC5qcGeTlQPNAczMTs0FUM0C_pUCzQSwAMPDkwmmZjhkYTgxBt4AAaEwAQ/kizo.jpg",
                    PrimaryMusicGenre = Shared.Dictionaries.MusicGenre.HipHop,
                    SecondaryMusicGenre = Shared.Dictionaries.MusicGenre.Pop,
                    SpotifyUrl = "2IHoZ3RrDJIikMRsYgHjhy",
                    Events = null
                }
            };

            context.Artists.AddRange(artists);
            context.SaveChanges();
        }

        private static void AddEvents(ApplicationDbContext context)
        {
            if (context.Events.Any())
            {
                return;
            }

            List<Event> events = new()
            {
                new Event
                {
                    Name = "Koncert Kizo Warszawa",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Kizo").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "Stadion Narodowy w Warszawie").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2022, 12, 20, 21, 00, 00),
                    Description = "Koncert Kizo w Warszawie rozpoczynający jego nową trasę koncertową!",
                    PhotoUrl = "https://gfx.dlastudenta.pl/photo_new/5b1/c8e/d5a/cfb/1565355",
                    AvailableSittingTickets = 1,
                    AvailableStandingTickets = 6,
                    SittingTicketPrice = 200,
                    StandingTicketPrice = 100,
                    ReducedDiscount = 0.5
                },
                new Event
                {
                    Name = "Koncert Sanah w Kielcach",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Sanah").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "Amfiteatr Kadzielnia").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2023, 3, 10, 15, 00, 00),
                    Description = "To wyjątkowy koncert, zarówno pod względem muzycznym, jak i wizualnym, podczas którego Artystce towarzyszyć będzie 10-osobowa orkiestra smyczkowa POLISH SOLOISTS oraz jeden z jej muzycznych idoli.",
                    PhotoUrl = "https://bi.im-g.pl/im/51/33/1a/z27472977IER,sanah.jpg",
                    AvailableSittingTickets = 100,
                    AvailableStandingTickets = 0,
                    SittingTicketPrice = 80,
                    StandingTicketPrice = 60.50,
                    ReducedDiscount = 0.25
                },
                new Event
                {
                    Name = "Powrót Kanye West do Polski",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Ye").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "TAURON Arena").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2023, 1, 5, 20, 00, 00),
                    Description = "Zobacz na własne oczy artystę, który po od wielu latach powraca do Polski!",
                    PhotoUrl = "https://rytmy.pl/wp-content/uploads/2022/07/kanye-west-koncert-e1657092428108.jpg",
                    AvailableSittingTickets = 200,
                    AvailableStandingTickets = 50,
                    SittingTicketPrice = 2000,
                    StandingTicketPrice = 1900,
                    ReducedDiscount = 0
                }
            };

            context.AddRange(events);
            context.SaveChanges();
        }
    }
}
