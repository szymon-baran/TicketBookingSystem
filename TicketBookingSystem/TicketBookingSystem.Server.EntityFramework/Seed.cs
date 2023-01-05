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
                },
                new Artist
                {
                    FirstName = "Agnieszka",
                    LastName = "Chylińska",
                    NickName = "Agnieszka Chylińska",
                    AverageFanbaseAge = 40,
                    Description = @"Agnieszka Barbara Chylińska (ur. 23 maja 1976 w Gdańsku) – polska piosenkarka, autorka tekstów, felietonistka, osobowość telewizyjna oraz autorka książek dla dzieci. Członkini Akademii Fonograficznej ZPAV.",
                    PhotoUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/c/c8/Agnieszka_Chyli%C5%84ska%2C_Sopot_Top_of_the_Top_Festival_2022%2C_dzie%C5%84_2_04.jpg/240px-Agnieszka_Chyli%C5%84ska%2C_Sopot_Top_of_the_Top_Festival_2022%2C_dzie%C5%84_2_04.jpg",
                    PrimaryMusicGenre = Shared.Dictionaries.MusicGenre.Pop,
                    SecondaryMusicGenre = Shared.Dictionaries.MusicGenre.Rock,
                    SpotifyUrl = "0CEw36eWG0dYKCXOX8eUoO",
                    Events = null
                },
                new Artist
                {
                    FirstName = "Zenon",
                    LastName = "Martyniuk",
                    NickName = "Zenek",
                    AverageFanbaseAge = 45,
                    Description = @"Zenon Martyniuk (ur. 23 czerwca 1969 w Gredelach) – polski piosenkarz i gitarzysta wykonujący muzykę z gatunku disco polo.",
                    PhotoUrl = "https://i.ytimg.com/vi/TGS-cNUZIG8/maxresdefault.jpg",
                    PrimaryMusicGenre = Shared.Dictionaries.MusicGenre.DiscoPolo,
                    SecondaryMusicGenre = Shared.Dictionaries.MusicGenre.Pop,
                    SpotifyUrl = "10wjV72OetIdsUQEcjSnOd",
                    Events = null
                },
                new Artist
                {
                    FirstName = "Austin",
                    LastName = "Post",
                    NickName = "Post Malone",
                    AverageFanbaseAge = 24,
                    Description = @"Post Malone, właściwie Austin Richard Post (ur. 4 lipca 1995 w Syracuse) – amerykański piosenkarz, raper, producent muzyczny oraz autor tekstów. Po wydaniu w lutym 2015 r. utworu „White Iverson”, który osiągnął ponad milion odtworzeń w serwisie SoundCloud, Malone podpisał kontrakt muzyczny z wytwórnią Republic Records.",
                    PhotoUrl = "https://www.coolaccidents.com/sites/g/files/g2000012951/files/styles/og_image/public/2022-06/post-malone-toilet-songwriting.jpg?itok=XEK-B1_q",
                    PrimaryMusicGenre = Shared.Dictionaries.MusicGenre.HipHop,
                    SecondaryMusicGenre = Shared.Dictionaries.MusicGenre.Rock,
                    SpotifyUrl = "246dkjvS1zLTtiykXe5h60",
                    Events = null
                },
                new Artist
                {
                    FirstName = "John",
                    LastName = "Osbourne",
                    NickName = "Ozzy Osbourne",
                    AverageFanbaseAge = 49,
                    Description = @"Ozzy Osbourne, właściwie John Michael Osbourne (ur. 3 grudnia 1948 w Birmingham) – brytyjski wokalista, muzyk i autor tekstów. Wieloletni członek heavymetalowego zespołu Black Sabbath.",
                    PhotoUrl = "https://www.billboard.com/wp-content/uploads/media/Ozzy-Osbourne-2020-a-jkl-a-billboard-1548.jpg",
                    PrimaryMusicGenre = Shared.Dictionaries.MusicGenre.Rock,
                    SecondaryMusicGenre = Shared.Dictionaries.MusicGenre.Metal,
                    SpotifyUrl = "6ZLTlhejhndI4Rh53vYhrY",
                    Events = null
                },
                new Artist
                {
                    FirstName = "Marcin",
                    LastName = "Miller",
                    NickName = "Boys",
                    AverageFanbaseAge = 49,
                    Description = @"Boys - polski zespół muzyczny, od marca 1997 boysband, założony w 1990.",
                    PhotoUrl = "https://disco-polo.eu/wp-content/uploads/2019/01/Boys.jpg",
                    PrimaryMusicGenre = Shared.Dictionaries.MusicGenre.DiscoPolo,
                    SecondaryMusicGenre = Shared.Dictionaries.MusicGenre.Pop,
                    SpotifyUrl = "46REMeONa7gBl4h2CIdO7Y",
                    Events = null
                },
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
                    EventTime = new DateTime(2023, 01, 23, 21, 00, 00),
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
                    Name = "Koncert Kizo Kielce",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Kizo").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "Amfiteatr Kadzielnia").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2023, 01, 30, 20, 00, 00),
                    Description = "Koncert Kizo w Kielcach podczas jego trasy koncertowej.",
                    PhotoUrl = "https://i0.wp.com/cowkrakowie.pl/wp-content/uploads/2022/07/kizo14.png?resize=850%2C491&ssl=1",
                    AvailableSittingTickets = 353,
                    AvailableStandingTickets = 15,
                    SittingTicketPrice = 150,
                    StandingTicketPrice = 130,
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
                    AvailableSittingTickets = 123,
                    AvailableStandingTickets = 0,
                    SittingTicketPrice = 80,
                    StandingTicketPrice = 60.50,
                    ReducedDiscount = 0.25
                },
                new Event
                {
                    Name = "Koncert Sanah w Krakowie",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Sanah").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "TAURON Arena").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2023, 4, 21, 15, 00, 00),
                    Description = "To wyjątkowy koncert, zarówno pod względem muzycznym, jak i wizualnym, podczas którego Artystce towarzyszyć będzie 10-osobowa orkiestra smyczkowa POLISH SOLOISTS oraz jeden z jej muzycznych idoli.",
                    PhotoUrl = "https://i.iplsc.com/-/000FVFB5KE80BKXY-C122.jpg",
                    AvailableSittingTickets = 5124,
                    AvailableStandingTickets = 0,
                    SittingTicketPrice = 250,
                    StandingTicketPrice = 250,
                    ReducedDiscount = 0.5
                },
                new Event
                {
                    Name = "Powrót Kanye West do Polski",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Ye").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "TAURON Arena").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2023, 3, 21, 20, 00, 00),
                    Description = "Zobacz na własne oczy artystę, który po od wielu latach powraca do Polski!",
                    PhotoUrl = "https://rytmy.pl/wp-content/uploads/2022/07/kanye-west-koncert-e1657092428108.jpg",
                    AvailableSittingTickets = 193,
                    AvailableStandingTickets = 54,
                    SittingTicketPrice = 2000,
                    StandingTicketPrice = 1900,
                    ReducedDiscount = 0
                },
                new Event
                {
                    Name = "Zakończenie karnawału z Zenonem Martyniukiem",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Zenek").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "Amfiteatr Kadzielnia").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2023, 2, 16, 15, 00, 00),
                    Description = "Niezwykle taneczne zakończenie Karnawału 2023 z Zenonem Martyniukiem i zespołem Akcent! Zapraszamy już 20 lutego do Auli UAM w Poznaniu. Zenon Martyniuk i zespół Akcent bilety już w sprzedaży  !",
                    PhotoUrl = "https://operalovers.pl/wp-content/uploads/2022/12/zenek.jpg",
                    AvailableSittingTickets = 485,
                    AvailableStandingTickets = 91,
                    SittingTicketPrice = 70,
                    StandingTicketPrice = 90,
                    ReducedDiscount = 0.2
                },
                new Event
                {
                    Name = "Agnieszka Chylińska - Never Ending Sorry (Kielce)",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Agnieszka Chylińska").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "Amfiteatr Kadzielnia").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2023, 2, 21, 20, 00, 00),
                    Description = "Agnieszka Chylińska przez lata przyzwyczajała swoich słuchaczy i widzów do wielu zmian na swojej artystycznej drodze. Wokalistka, której twórczość zawsze cechowały przez nią same ukute słowa „Nigdy Taka Sama”. Tym razem postanowiła połączyć rockową siłę swojego nietuzinkowego głosu z pięknym rockowo-bluesowym brzmieniem. \r\n\r\n",
                    PhotoUrl = "https://czadrow24.pl/wp-content/uploads/2018/06/96978.jpg",
                    AvailableSittingTickets = 792,
                    AvailableStandingTickets = 35,
                    SittingTicketPrice = 139,
                    StandingTicketPrice = 129,
                    ReducedDiscount = 0.5
                },
                new Event
                {
                    Name = "Post Malone na Stadionie Narodowym w Warszawie",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Post Malone").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "Stadion Narodowy w Warszawie").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2023, 3, 13, 20, 00, 00),
                    Description = "",
                    PhotoUrl = "https://www.nme.com/wp-content/uploads/2018/10/post.jpg",
                    AvailableSittingTickets = 792,
                    AvailableStandingTickets = 35,
                    SittingTicketPrice = 139,
                    StandingTicketPrice = 129,
                    ReducedDiscount = 0.5
                },
                new Event
                {
                    Name = "Ozzy Osbourne No More Tours 2 (Kraków)",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Post Malone").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "Stadion Narodowy w Warszawie").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2023, 3, 19, 20, 00, 00),
                    Description = "Artysta wielokrotnie wzbudzał kontrowersje - wystarczy wspomnieć historię z odgryzionymi głowami nietoperza czy gołębia, które to uzyskały już status kultowy. Warto zaznaczyć, że inspiracje twórczością Ozzy'iego deklarują inni najważniejsi muzycy w historii rocka: James Hetfield (Metallica), Zakk Wylde (Black Label Society), Dave Grohl (Nirvana, Foo Fighters) i wielu innych. Warto wspomnieć, że Ozzy wielokrotnie pojawiał się na wielkim ekranie np. Moulin Rouge!, Sunset Strip czy... Gnomeo i Julia. Ozzy Osbourne  w  Polsce wystąpił ostatnio w 2018 roku - artysta został headlinerem IMPACT FESTIVAL, który odbył się w Tauron Arenie Kraków.",
                    PhotoUrl = "https://gfx.antyradio.pl/var/antyradio/storage/images/muzyka/koncerty/ozzy-osbourne-na-impact-festival-2018-w-krakowie-relacja-23684/1702849-1-pol-PL/Ozzy-Osbourne-na-Impact-Festival-2018-w-Krakowie-RELACJA_article.jpg",
                    AvailableSittingTickets = 792,
                    AvailableStandingTickets = 35,
                    SittingTicketPrice = 139,
                    StandingTicketPrice = 129,
                    ReducedDiscount = 0.5
                },
                new Event
                {
                    Name = "Koncert zespołu Boys na Kadzielni",
                    ArtistId = context.Artists.FirstOrDefault(x => x.NickName == "Boys").Id,
                    PlaceId = context.Places.FirstOrDefault(x => x.Name == "Amfiteatr Kadzielnia").Id,
                    CreatedTime = DateTime.Now,
                    EventTime = new DateTime(2023, 4, 13, 13, 00, 00),
                    Description = "Dołącz do nas na 8 Gali Disco na Hali RCS w Lubinie i wspólnie rozgrzejmy parkiet do czerwoności! Ostatnia edycja niezapomnianej imprezy w rytmach muzyki czołowych polskich wykonawców.",
                    PhotoUrl = "https://gfx.dlastudenta.pl/uploads/images/f/da/boys_1030x578.jpg",
                    AvailableSittingTickets = 1585,
                    AvailableStandingTickets = 145,
                    SittingTicketPrice = 49,
                    StandingTicketPrice = 35,
                    ReducedDiscount = 0.6
                },
            };

            context.AddRange(events);
            context.SaveChanges();
        }
    }
}
