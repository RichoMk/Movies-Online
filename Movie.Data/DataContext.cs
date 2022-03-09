using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using Movie.Entities;

namespace Movie.Data
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {
        public DataContext(DbContextOptions options) : base(options) { }
        public DbSet<Movies> Movies { get; set; }
        public DbSet<MovieActor> MovieActors { get; set; }
        public DbSet<MovieCategory> MovieCategories { get; set; }
        public DbSet<Actor> Actors { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<Director> Directors { get; set; }
        public DbSet<Orders> Orders { get; set; }
        public DbSet<Publisher> Publisher { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<Wishlist> WishLists { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {


            modelBuilder.Entity<MovieActor>()
                .HasKey(ma => new { ma.MovieID, ma.ActorID });
            modelBuilder.Entity<MovieActor>()
                .HasOne(m => m.Movie)
                .WithMany(a => a.MovieActors)
                .HasForeignKey(m => m.MovieID);
            modelBuilder.Entity<MovieActor>()
                .HasOne(a => a.Actor)
                .WithMany(m => m.MovieActors)
                .HasForeignKey(a => a.ActorID);

            modelBuilder.Entity<MovieCategory>()
                .HasKey(ma => new { ma.MovieID, ma.CategoryID });
            modelBuilder.Entity<MovieCategory>()
                .HasOne(m => m.Movie)
                .WithMany(a => a.MovieCategories)
                .HasForeignKey(m => m.MovieID);
            modelBuilder.Entity<MovieCategory>()
                .HasOne(a => a.Category)
                .WithMany(m => m.MovieCategories)
                .HasForeignKey(a => a.CategoryID);


            #region Admin and Roles
            const string ADMIN_ID = "b4280b6a-0613-4cbd-a9e6-f1701e926e73";
            const string ROLE_ID = ADMIN_ID;
            const string password = "Test123!";

            modelBuilder.Entity<IdentityRole>().HasData(
                new IdentityRole
                {
                    Id = ROLE_ID,
                    Name = "admin",
                    NormalizedName = "ADMIN"
                },
                new IdentityRole
                {
                    Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e74",
                    Name = "editor",
                    NormalizedName = "EDITOR"
                },
                new IdentityRole
                {
                    Id = "b4280b6a-0613-4cbd-a9e6-f1701e926e75",
                    Name = "guest",
                    NormalizedName = "GUEST"
                }
            );

            var hasher = new PasswordHasher<IdentityUser>();

            modelBuilder.Entity<IdentityUser>().HasData(new IdentityUser
            {
                Id = ADMIN_ID,
                UserName = "Test@test.com",
                NormalizedUserName = "Test@TEST.COM",
                Email = "Test@test.com",
                NormalizedEmail = "TEST@TEst.COM",
                EmailConfirmed = true,
                PasswordHash = hasher.HashPassword(null, password),
                SecurityStamp = string.Empty,
                ConcurrencyStamp = "c8554266-b401-4519-9aeb-a9283053fc58"
            });

            modelBuilder.Entity<IdentityUserRole<string>>().HasData(new IdentityUserRole<string>
            {
                RoleId = ROLE_ID,
                UserId = ADMIN_ID
            });
            #endregion

            #region Movies
            modelBuilder.Entity<Movies>().HasData(
                new Movies
                {
                    Id = 1,
                    Title = "Hackers",
                    Categories = "Crime, Comedy, Drama",
                    ActorNames = "Jonny Lee Miller,Angelina Jolie,Jesse Bradford,Matthew Lillard,Laurence Mason,Renoly Santiago",
                    Country = "United States",
                    ShortDescription = "Hackers are blamed for making a virus that will capsize five oil tankers.",
                    Language = "English, Italian, Japanese, Russian",
                    DirectorId = 6,
                    DirectorName = "Iain Softley",
                    PublisherId = 6,
                    PublisherName = "United Artists",
                    TrailerURL = "Hackers Official Trailer.mp4",
                    PhotoURL = "Hackers1995Image.jpg",
                    Rating = 6.2,
                    WatchTime = "105min",
                    ReleaseDate = "15 September 1995"
                },
                new Movies
                {
                    Id = 2,
                    Title = "Rambo",   
                    Categories = "Action, Thriller",
                    ActorNames = "Sylvester Stallone,Julie Benz,Matthew Marsden",
                    Country = "Germany,USA,Thailand",
                    ShortDescription = "In Thailand, John Rambo joins a group of mercenaries to venture into war-torn Burma, and rescue a group of Christian aid workers who were kidnapped by the ruthless local infantry unit.",
                    Language = "English, Burmese, Thai",
                    DirectorId = 2,
                    DirectorName = "Sylvester Stallone",
                    PublisherId = 2,
                    PublisherName = "Lionsgate",
                    TrailerURL = "Rambo (2008) - Official Trailer.mp4",
                    PhotoURL = "Rambo2008Image.jpg",
                    Rating = 7.0,
                    WatchTime = "92min",
                    ReleaseDate = "25 January 2008"
                },
                new Movies
                {
                    Id = 3,
                    Title = "Titanic",       
                    ActorNames = "Leonardo Di Caprio,Kate Winslet,Billy Zane",
                    Categories = "Drama, Romance",
                    Country = "USA, Mexico, Australia, Canada",
                    ShortDescription = "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, Ill-fated R.M.S Titanic.",
                    Language = "English, Swedish, Italian, French",
                    DirectorId = 3,
                    DirectorName = "James Cameron",
                    PublisherId = 1,
                    PublisherName = "20th Century Fox",
                    TrailerURL = "Titanic  Official Trailer.mp4",
                    PhotoURL = "Titanic1997Image.jpg",
                    Rating = 7.8,
                    WatchTime = "194min",
                    ReleaseDate = "19 December 1997"
                },
                new Movies
                {
                    Id = 4,
                    Title = "Top Gun",   
                    ActorNames = "Tom Cruise,Tim Robbins,Kelly McGillis",
                    Categories = "Action, Drama",
                    Country = "USA",
                    ShortDescription = "As students at the United States Navy's elite fighter weapons school compete to be best in the class, one daring young pilot learns a few things from a civilian instructor that are not taught in the classroom.",
                    Language = "English",
                    DirectorId = 4,
                    DirectorName = "Tony Scott",
                    PublisherId = 4,
                    PublisherName = "Paramount Pictures",
                    TrailerURL = "Top Gun (1986) Official Trailer.mp4",
                    PhotoURL = "TopGun1986Image.jpg",
                    Rating = 6.9,
                    WatchTime = "110min",
                    ReleaseDate = "16 May 1986"
                },
                new Movies
                {
                    Id = 5,
                    Title = "The Terminator",
                    ActorNames = "Arnold Schwarzenegger,Linda Hamilton,Michael Biehn",
                    Categories = "Action, Sci-Fi",
                    Country = "UK",
                    ShortDescription = "A human soldier is sent from 2029 to 1984 to stop an almost indestructible cyborg killing machine, sent from the same year, which has been programmed to execute a young woman whose unborn son is the key to humanity's future salvation.",
                    Language = "English",
                    DirectorId = 3,
                    DirectorName = "James Cameron",
                    PublisherId = 5,
                    PublisherName = "Cinema '84",
                    TrailerURL = "The Terminator (1984) Official Trailer.mp4",
                    PhotoURL = "TheTerminator1984Image.jpg",
                    Rating = 8.0,
                    WatchTime = "107min",
                    ReleaseDate = "26 October 1984"

                },
                new Movies
                {
                    Id = 6,
                    Title = "Doctor Strange",
                    Categories = "Action, Adventure, Fanstasy",
                    ShortDescription = "While on a journey of physical and spiritual healing, a brilliant neurosurgeon is drawn into the world of the mystic arts.",
                    DirectorId = 15,
                    DirectorName = "Scott Derrickson",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "115min",
                    ActorNames = "Benedict Cumberbatch,Chiwetel Ejiofor,Rachel McAdams",
                    Language = "English",
                    Rating = 7.5,
                    ReleaseDate = "4 November, 2016",
                    PhotoURL = "DrStrange.jpg",
                },
                new Movies
                {
                    Id = 7,
                    Title = "The Social Network",
                    ActorNames = "Jesse Eisenberg,Andrew Garfield,Justin Timberlake,Rooney Mara",
                    Categories = "Drama, Biography",
                    Country = "USA",
                    ShortDescription = "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.",
                    Language = "English, French",
                    DirectorId = 7,
                    DirectorName = "David Fincher",
                    PublisherId = 7,
                    PublisherName = "Columbia Pictures",
                    TrailerURL = "THE SOCIAL NETWORK - Official Trailer.mp4",
                    PhotoURL = "TheSocialNetwork2010Image.png",
                    Rating = 7.7,
                    WatchTime = "120min",
                    ReleaseDate = "1 October 2010 "
                },
                new Movies
                {
                    Id = 8,
                    Title = "The Imitation Game",
                    ActorNames = "Benedict Cumberbatch,Keira Knightley,Matthew Goode",
                    Categories = "Drama, Biography, Thriller",
                    Country = "UK, USA",
                    ShortDescription = "During World War II, the English mathematical genius Alan Turing tries to crack the German Enigma code with help from fellow mathematicians.",
                    Language = "English, German",
                    DirectorId = 8,
                    DirectorName = "Morten Tyldum",
                    PublisherId = 8,
                    PublisherName = "Black Bear Pictures",
                    TrailerURL = "The Imitation Game Official Trailer.mp4",
                    PhotoURL = "TheImitationGame2014Image.jpg",
                    Rating = 8.0,
                    WatchTime = "114min",
                    ReleaseDate = "25 December 2014"
                },
                new Movies
                {
                    Id = 9,
                    Title = "Who Am I",
                    ActorNames = "Tom Schilling,Elyas M'Barek,Wotan Wilke Möhring",
                    Categories = "Crime, Drama, Mystery",
                    Country = "Germany",
                    ShortDescription = "Benjamin, a young German computer whiz, is invited to join a subversive hacker group that wants to be noticed on the world's stage.",
                    Language = "German, English",
                    DirectorId = 9,
                    DirectorName = "Baran bo Odar",
                    PublisherId = 9,
                    PublisherName = "SevenPictures Film",
                    TrailerURL = "Who Am I Official Trailer.mp4",
                    PhotoURL = "WhoAmI2014Image.jpg",
                    Rating = 7.5,
                    WatchTime = "102min",
                    ReleaseDate = "25 September 2014"
                },
                new Movies
                {
                    Id = 10,
                    Title = "Inception",
                    ActorNames = "Leonardo DiCaprio,Joseph Gordon-Levitt,Elliot Page,Ken Watanabe,Tom Hardy,Dileep Rao,Cillian Murphy,Tom Berenger,Marion Cotillard,Michael Caine",
                    Categories = "Action, Adventure, Sci-Fi",
                    Country = "USA, UK",
                    ShortDescription = "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.",
                    Language = "English, Japanese, French",
                    DirectorId = 10,
                    DirectorName = "Christopher Nolan",
                    PublisherId = 10,
                    PublisherName = "Legendary Entertainment",
                    TrailerURL = "Inception (2010) Official Trailer.mp4",
                    PhotoURL = "Inception2010Image.jpg",
                    Rating = 8.8,
                    WatchTime = "148min",
                    ReleaseDate = "16 July 2010"
                },
                new Movies
                {
                    Id = 11,
                    Title = "Captain America: The First Avenger",
                    Categories = "Action, Adventure, Sci-Fi",
                    ShortDescription = "Steve Rogers, a rejected military soldier, transforms into Captain America after taking a dose of a \"Super - Soldier serum\". But being Captain America comes at a price as he attempts to take down a war monger and a terrorist organization.",
                    DirectorId = 11,
                    DirectorName = "Joe Johnston",
                    PublisherId = 4,
                    PublisherName = "Paramount Pictures",
                    Country = "USA",
                    WatchTime = "124min",
                    ActorNames = "Chris Evans,Samuel L. Jackson,Hayley Atwell,Sebastian Bach",
                    Language = "English",
                    Rating = 6.9,
                    ReleaseDate = "Jyly 22, 2011",
                    PhotoURL = "CaptainAmerica.jpg",
                },
                new Movies
                {
                    Id = 12,
                    Title = "Captain Marvel",
                    Categories = "Action, Adventure, Sci-Fi",
                    ShortDescription = "Carol Danvers becomes one of the universe's most powerful heroes when Earth is caught in the middle of a galactic war between two alien races.",
                    DirectorId = 4,
                    DirectorName = "Anna Boden",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "123min",
                    ActorNames = "Brie Larson,Samuel L. Jackson,Clark Gregg",
                    Language = "English",
                    Rating = 6.8,
                    ReleaseDate = "March 8, 2019",
                    PhotoURL = "CaptainMarvel.jpg",
                },
                new Movies
                {
                    Id = 13,
                    Title = "Iron Man",
                    ShortDescription = "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.",
                    DirectorId = 5,
                    DirectorName = "Jon Favreau",
                    PublisherId = 4,
                    PublisherName = "Paramount Pictures",
                    Country = "USA",
                    WatchTime = "126min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Robert Downey Jr.,Gwyneth Paltrow,Jon Favreau,Samuel L. Jackson,Jeff Bridges,Terrence Howard,Paul Bettany,Clark Gregg",
                    Language = "English",
                    Rating = 7.9,
                    ReleaseDate = "May 2, 2008",
                    PhotoURL = "IronMan.jpg",
                },
                new Movies
                {
                    Id = 14,
                    Title = "Iron Man 2",
                    ShortDescription = "With the world now aware of his identity as Iron Man, Tony Stark must contend with both his declining health and a vengeful mad man with ties to his father's legacy.",
                    DirectorId = 5,
                    DirectorName = "Jon Favreau",
                    PublisherId = 4,
                    PublisherName = "Paramount Pictures",
                    Country = "USA",
                    WatchTime = "124min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Robert Downey Jr.,Gwyneth Paltrow,Jon Favreau,Samuel L. Jackson,Don Cheadle,Paul Bettany,Clark Gregg,Mickey Rourke",
                    Language = "English",
                    Rating = 7.0,
                    ReleaseDate = "May 7, 2010",
                    PhotoURL = "IronMan2.jpg",
                },
                new Movies
                {
                    Id = 15,
                    Title = "The Incredible Hulk",
                    ShortDescription = "Bruce Banner, a scientist on the run from the U.S. Government, must find a cure for the monster he turns into whenever he loses his temper.",
                    DirectorId = 7,
                    DirectorName = "Louis Leterrier",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "112min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Edward Norton,Tim Roth",
                    Language = "English",
                    Rating = 6.7,
                    ReleaseDate = "June 13, 2008",
                    PhotoURL = "TheIncredibleHulk.jpg",
                },
                new Movies
                {
                    Id = 16,
                    Title = "Thor",
                    ShortDescription = "The powerful but arrogant god Thor is cast out of Asgard to live amongst humans in Midgard (Earth), where he soon becomes one of their finest defenders.",
                    DirectorId = 17,
                    DirectorName = "Kenneth Branagh",
                    PublisherId = 4,
                    PublisherName = "Paramount Pictures",
                    Country = "USA",
                    WatchTime = "115min",
                    Categories = "Action, Adventure, Fanstasy",
                    ActorNames = "Chris Hemsworth,Natalie Portman,Jaimie Alexander,Idris Elba,Anthony Hopkins,Kat Dennings,Rene Russo,Ray Stevenson,Stellan Skarsgard,Tadanobu Asano,Clark Gregg,Samuel L. Jackson,Jeremy Lee Renner,Tom Hiddleston",
                    Language = "English",
                    Rating = 7.0,
                    ReleaseDate = "May 6, 2011",
                    PhotoURL = "Thor.jpg",
                },
                new Movies
                {
                    Id = 17,
                    Title = "The Avengers",
                    ShortDescription = "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.",
                    DirectorId = 2,
                    DirectorName = "Joe Russo",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "143min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Chris Hemsworth,Mark Ruffalo,Robert Downey Jr.,Jeremy Lee Renner,Tom Hiddleston,Chris Evans,Elizabeth Olsen,Paul Bettany,Scarlet Johansson,Samuel L. Jackson",
                    Language = "English, Russian, Hindi",
                    Rating = 8.0,
                    ReleaseDate = "May 4, 2012",
                    PhotoURL = "Avengers.jpg",
                },
                new Movies
                {
                    Id = 18,
                    Title = "Iron Man 3",
                    ShortDescription = "When Tony Stark's world is torn apart by a formidable terrorist called the Mandarin, he starts an odyssey of rebuilding and retribution.",
                    DirectorId = 6,
                    DirectorName = "Shane Black",
                    PublisherId = 4,
                    PublisherName = "Paramount Pictures",
                    Country = "USA",
                    WatchTime = "130min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Robert Downey Jr.,Gwyneth Paltrow,Jon Favreau,Samuel L. Jackson,Don Cheadle,Paul Bettany,Clark Gregg",
                    Language = "English",
                    Rating = 7.1,
                    ReleaseDate = "May 3, 2013",
                    PhotoURL = "IronMan3.jpg",
                },
                new Movies
                {
                    Id = 19,
                    Title = "Thor: The Dark World",
                    ShortDescription = "When the Dark Elves attempt to plunge the universe into darkness, Thor must embark on a perilous and personal journey that will reunite him with doctor Jane Foster.",
                    DirectorId = 9,
                    DirectorName = "Alan Taylor",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "112min",
                    Categories = "Action, Adventure, Fantasy",
                    ActorNames = "Chris Hemsworth,Natalie Portman,Jaimie Alexander,Idris Elba,Anthony Hopkins,Kat Dennings,Rene Russo,Ray Stevenson,Stellan Skarsgard,Tadanobu Asano,Tom Hiddleston",
                    Language = "English",
                    Rating = 6.9,
                    ReleaseDate = "November 8, 2013",
                    PhotoURL = "ThorTheDarkWorld.jpg",
                },
                new Movies
                {
                    Id = 20,
                    Title = "Captain America: Winter Soldier",
                    ShortDescription = "As Steve Rogers struggles to embrace his role in the modern world, he teams up with a fellow Avenger and S.H.I.E.L.D agent, Black Widow, to battle a new threat from history: an assassin known as the Winter Soldier.",
                    DirectorId = 3,
                    DirectorName = "Anthony Russo",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "136min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Chris Evans,Samuel L. Jackson,Hayley Atwell,Sebastian Bach,Anthony Mackie",
                    Language = "English",
                    Rating = 7.7,
                    ReleaseDate = "April 4, 2014",
                    PhotoURL = "CaptainAmericaWinterSoldier.jpg",
                },
                new Movies
                {
                    Id = 21,
                    Title = "Guardians of the Galaxy",
                    ShortDescription = "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.",
                    DirectorId = 12,
                    DirectorName = "James Gunn",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "121min",
                    Categories = "Action, Adventure, Comedy",
                    ActorNames = "Chris Pratt,Zoe Saldana,Vin Diesel,Bradley Cooper,Karen Gillan,Dave Bautista",
                    Language = "English",
                    Rating = 8.0,
                    ReleaseDate = "August 1, 2014",
                    PhotoURL = "GuardiansOfTheGalaxy.jpg",
                },
                new Movies
                {
                    Id = 22,
                    Title = "Guardians of the Galaxy Vol.2",
                    ShortDescription = "The Guardians struggle to keep together as a team while dealing with their personal family issues, notably Star-Lord's encounter with his father the ambitious celestial being Ego.",
                    DirectorId = 12,
                    DirectorName = "James Gunn",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "136min",
                    Categories = "Action, Adventure, Comedy",
                    ActorNames = "Chris Pratt,Zoe Saldana,Vin Diesel,Bradley Cooper,Karen Gillan,Dave Bautista,Kurt Russel",
                    Language = "English",
                    Rating = 7.6,
                    ReleaseDate = "May 5, 2017",
                    PhotoURL = "GuardiansOfTheGalaxyVol2.jpg",
                },
                new Movies
                {
                    Id = 23,
                    Title = "Avengers: Age of Ultron",
                    ShortDescription = "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.",
                    DirectorId = 10,
                    DirectorName = "Joss Whedon",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "141min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Chris Hemsworth,Mark Ruffalo,Robert Downey Jr.,Jeremy Lee Renner,Tom Hiddleston,Chris Evans,Elizabeth Olsen,Paul Bettany,Scarlet Johansson,Samuel L. Jackson",
                    Language = "English",
                    Rating = 7.3,
                    ReleaseDate = "May 1, 2015",
                    PhotoURL = "AvengersAgeOfUltron.jpg",
                },
                new Movies
                {
                    Id = 24,
                    Title = "Ant-Man",
                    ShortDescription = "Armed with a super-suit with the astonishing ability to shrink in scale but increase in strength, cat burglar Scott Lang must embrace his inner hero and help his mentor, Dr. Hank Pym, plan and pull off a heist that will save the world.",
                    DirectorId = 13,
                    DirectorName = "Peyton Reed",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "117min",
                    Categories = "Action, Adventure, Comedy",
                    ActorNames = "Paul Rudd,Michael Douglas",
                    Language = "English",
                    Rating = 7.3,
                    ReleaseDate = "Jyly 17, 2015",
                    PhotoURL = "AntMan.jpg",
                },
                new Movies
                {
                    Id = 25,
                    Title = "Captain America: Civil War",
                    ShortDescription = "Political involvement in the Avengers' affairs causes a rift between Captain America and Iron Man.",
                    DirectorId = 2,
                    DirectorName = "Joe Russo",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "147min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Chris Evans,Samuel L. Jackson,Robert Downey Jr.,Sebastian Bach,Anthony Mackie,Elizabeth Olsen,Scarlet Johansson,Jeremy Lee Renner,Paul Rudd,Tom Holland,Paul Bettany",
                    Language = "English",
                    Rating = 7.8,
                    ReleaseDate = "May 6, 2016",
                    PhotoURL = "CaptainAmericaCivilWar.jpg",
                },
                new Movies
                {
                    Id = 26,
                    Title = "Spider-Man: Homecoming",
                    ShortDescription = "Peter Parker balances his life as an ordinary high school student in Queens with his superhero alter-ego Spider-Man, and finds himself on the trail of a new menace prowling the skies of New York City.",
                    DirectorId = 14,
                    DirectorName = "Jon Watts",
                    PublisherId = 7,
                    PublisherName = "Columbia Pictures",
                    Country = "USA",
                    WatchTime = "133min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Tom Holland,Robert Downey Jr.,Jon Favreau,Zendaya",
                    Language = "English",
                    Rating = 7.4,
                    ReleaseDate = "Jyly 17, 2017",
                    PhotoURL = "SpidermanHomecoming.jpg",
                },
                new Movies
                {
                    Id = 27,
                    Title = "Murder On The Orient Express",
                    ActorNames = "Kenneth Branagh,Penélope Cruz,Willem Dafoe",
                    Categories = "Crime, Drama, Mystery",
                    Country = " Malta, USA, UK",
                    ShortDescription = "When a murder occurs on the train on which he's travelling, celebrated detective Hercule Poirot is recruited to solve the case.",
                    Language = "English, French, Arabic, German",
                    DirectorId = 1,
                    DirectorName = "Kenneth Branagh",
                    PublisherId = 1,
                    PublisherName = "20th Century Fox",
                    TrailerURL = "Murder on the Orient Express Official Trailer.mp4",
                    PhotoURL = "MurderOnTheOrientExpress2017Image.jpg",
                    Rating = 6.5,
                    WatchTime = "114min",
                    ReleaseDate = "10 November 2017"
                },
                new Movies
                {
                    Id = 28,
                    Title = "Black Panther",
                    ShortDescription = "T'Challa, heir to the hidden but advanced kingdom of Wakanda, must step forward to lead his people into a new future and must confront a challenger from his country's past.",
                    DirectorId = 16,
                    DirectorName = "Ryan Coogler",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "134min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Chadwick Boseman,Michael B. Jordan",
                    Language = "English",
                    Rating = 7.3,
                    ReleaseDate = "February 16, 2018",
                    PhotoURL = "BlackPanther.jpg",
                },
                new Movies
                {
                    Id = 29,
                    Title = "Thor: Ragnarok",
                    ShortDescription = "Imprisoned on the planet Sakaar, Thor must race against time to return to Asgard and stop Ragnarök, the destruction of his world, at the hands of the powerful and ruthless villain Hela.",
                    DirectorId = 8,
                    DirectorName = "Taika Waititi",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "130min",
                    Categories = "Action, Adventure, Comedy",
                    ActorNames = "Chris Hemsworth,Idris Elba,Anthony Hopkins,Ray Stevenson,Tadanobu Asano,Tom Hiddleston",
                    Language = "English",
                    Rating = 7.9,
                    ReleaseDate = "November 3, 2017",
                    PhotoURL = "ThorRagnarok.jpg",
                },
                new Movies
                {
                    Id = 30,
                    Title = "Avengers: Infinity War",
                    ShortDescription = "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.",
                    DirectorId = 3,
                    DirectorName = "Anthony Russo",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "149min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Chris Hemsworth,Mark Ruffalo,Scarlet Johannson,Karen Gillan,Robert Downey Jr.,Samuel L. Jackson,Jeremy Lee Renner,Tom Hiddleston,Chris Evans,Brie Larson,Josh Brolin,Chadwick Boseman,Elizabeth Olsen,Chris Pratt,Zoe Saldana,Benedict Cumberbatch,Paul Bettany,Anthony Mackie,Sebastian Bach,Vin Diesel,Tom Holland",
                    Language = "English",
                    Rating = 8.4,
                    ReleaseDate = "April 27, 2018",
                    PhotoURL = "AvengersInfinityWar.jpg",
                },
                new Movies
                {
                    Id = 31,
                    Title = "Ant-Man and The Wasp",
                    ShortDescription = "As Scott Lang balances being both a superhero and a father, Hope van Dyne and Dr. Hank Pym present an urgent new mission that finds the Ant-Man fighting alongside The Wasp to uncover secrets from their past.",
                    DirectorId = 13,
                    DirectorName = "Peyton Reed",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "118min",
                    Categories = "Action, Adventure, Comedy",
                    ActorNames = "Paul Rudd,Evangeline Lilly,Michael Douglas",
                    Language = "English",
                    Rating = 7.0,
                    ReleaseDate = "Jyly 6, 2018",
                    PhotoURL = "AntManAndTheWasp.jpg",
                },
                new Movies
                {
                    Id = 32,
                    Title = "Avengers: Endgame",
                    ShortDescription = "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.",
                    DirectorId = 3,
                    DirectorName = "Anthony Russo",
                    PublisherId = 11,
                    PublisherName = "Marvel Studios",
                    Country = "USA",
                    WatchTime = "181min",
                    Categories = "Action, Adventure, Drama",
                    ActorNames = "Chris Hemsworth,Mark Ruffalo,Scarlet Johannson,Karen Gillan,Robert Downey Jr.,Samuel L. Jackson,Jeremy Lee Renner,Tom Hiddleston,Chris Evans,Brie Larson,Josh Brolin,Chadwick Boseman,Elizabeth Olsen,Chris Pratt,Zoe Saldana,Benedict Cumberbatch,Paul Bettany,Anthony Mackie,Sebastian Bach,Vin Diesel,Tom Holland",
                    Language = "English",
                    Rating = 8.4,
                    ReleaseDate = "April 26, 2019",
                    PhotoURL = "AvengersEndGame.jpg",
                },
                new Movies
                {
                    Id = 33,
                    Title = "Spider-Man: Far From Home",
                    ShortDescription = "Following the events of Avengers: Endgame (2019), Spider-Man must step up to take on new threats in a world that has changed forever.",
                    DirectorId = 14,
                    DirectorName = "Jon Watts",
                    PublisherId = 7,
                    PublisherName = "Columbia Pictures",
                    Country = "USA",
                    WatchTime = "129min",
                    Categories = "Action, Adventure, Sci-Fi",
                    ActorNames = "Tom Holland,Jon Favreau,Zendaya,Samuel L. Jackson,Cobie Smulders,Jake Gyllenhaal",
                    Language = "English",
                    Rating = 7.5,
                    ReleaseDate = "Jyly 2, 2019",
                    PhotoURL = "SpidermanFarFromHome.jpg",
                }
                );
            #endregion

            #region Actors
            modelBuilder.Entity<Actor>().HasData(
                new Actor
                {
                    Id = 1,
                    Name = "Chris Hemsworth",
                    Country = "Melbourne, Victoria, Australia",
                    DateBirth = "August 11, 1983",
                    Gender = "Male",
                    ShortDescription = "Christopher Hemsworth was born on August 11, 1983 in Melbourne, Victoria, Australia to Leonie Hemsworth (née van Os), an English teacher & Craig Hemsworth, a social-services counselor. His brothers are actors, Liam Hemsworth & Luke Hemsworth; he is of Dutch (from his immigrant maternal grandfather), Irish, English, Scottish, and German ancestry. His uncle, by marriage, was Rod Ansell, the bushman who inspired the comedy film Crocodile Dundee (1986).",
                    Language = "English,",
                    PhotoURL = "ChrisHemsworthPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 2,
                    Name = "Robert Downey Jr.",
                    Country = "Manhattan, New York City, New York, USA",
                    DateBirth = "April 4, 1965",
                    Gender = "Male",
                    ShortDescription = "Downey was born April 4, 1965 in Manhattan, New York, the son of writer, director and filmographer Robert Downey Sr. and actress Elsie Downey (née Elsie Ann Ford). Robert's father is of half Lithuanian Jewish, one quarter Hungarian Jewish, and one quarter Irish, descent, while Robert's mother was of English, Scottish, German, and Swiss-German ancestry.",
                    Language = "English",
                    PhotoURL = "RobertDowneyJrPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 3,
                    Name = "Chris Evans",
                    Country = "Boston, Massachusetts, USA",
                    DateBirth = "June 13, 1981",
                    Gender = "Male",
                    ShortDescription = "Christopher Robert Evans began his acting career in typical fashion: performing in school productions and community theatre. He was born in Boston, Massachusetts, the son of Lisa (Capuano), who worked at the Concord Youth Theatre, and G. Robert Evans III, a dentist. His uncle is former U.S. Representative Mike Capuano. ",
                    Language = "English",
                    PhotoURL = "ChrisEvansPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 4,
                    Name = "Scarlett Johansson",
                    Country = "Manhattan, New York City, New York, USA",
                    DateBirth = "November 22, 1984",
                    Gender = "Female",
                    ShortDescription = "Scarlett Ingrid Johansson was born on November 22, 1984 in Manhattan, New York City, New York. Her mother, Melanie Sloan is from a Jewish family from the Bronx and her father, Karsten Johansson is a Danish-born architect from Copenhagen. She has a sister, Vanessa Johansson, who is also an actress, a brother, Adrian, a twin brother, Hunter Johansson, born three minutes after her, and a paternal half-brother, Christian. Her grandfather was writer Ejner Johansson.",
                    Language = "English",
                    PhotoURL = "ScarlettJohanssonPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 5,
                    Name = "Mark Ruffalo",
                    Country = "Kenosha, Wisconsin, USA",
                    DateBirth = "November 22, 1967",
                    Gender = "Male",
                    ShortDescription = "Award-winning actor Mark Ruffalo was born on November 22, 1967, in Kenosha, Wisconsin, of humble means to father Frank Lawrence Ruffalo, a construction painter and Marie Rose (Hebert), a stylist and hairdresser; his father's ancestry is Italian and his mother is of half French-Canadian and half Italian descent. Mark moved with his family to Virginia Beach, Virginia, where he lived out most of his teenage years. Following high school, Mark moved with his family to San Diego and soon migrated north, eventually settling in Los Angeles.",
                    Language = "English",
                    PhotoURL = "MarkRuffaloPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 6,
                    Name = "Jeremy Lee Renner",
                    Country = "Modesto, California, USA",
                    DateBirth = "January 7, 1971",
                    Gender = "Male",
                    ShortDescription = "Jeremy Lee Renner was born in Modesto, California, the son of Valerie (Tague) and Lee Renner, who managed a bowling alley. After a tumultuous yet happy childhood with his four younger siblings, Renner graduated from Beyer High School and attended Modesto Junior College. He explored several areas of study, including computer science, criminology, and psychology, before the theater department, with its freedom of emotional expression, drew him in.",
                    Language = "English",
                    PhotoURL = "JeremyLeeRennerPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 7,
                    Name = "Tom Hiddleston",
                    Country = "Westminster, London, England, UK",
                    DateBirth = "February 9, 1981",
                    Gender = "Male",
                    ShortDescription = "Thomas William Hiddleston was born in Westminster, London, to English-born Diana Patricia (Servaes) and Scottish-born James Norman Hiddleston. His mother is a former stage manager, and his father, a scientist, was the managing director of a pharmaceutical company. He started off at the preparatory school, The Dragon School in Oxford, and by the time he was 13, he boarded at Eton College, at the same time that his parents were going through a divorce. He continued on to the University of Cambridge, where he earned a double first in Classics. He continued to study acting at the Royal Academy of Dramatic Art, from which he graduated in 2005.",
                    Language = "English",
                    PhotoURL = "TomHiddlestonPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 8,
                    Name = "Robert Clark Gregg",
                    Country = "Boston, Massachusetts, USA",
                    DateBirth = "April 2, 1962",
                    Gender = "Male",
                    ShortDescription = "Clark Gregg was born on April 2, 1962 in Boston, Massachusetts, USA as Robert Clark Gregg. He is an actor and director, known for The Avengers (2012), Agents of S.H.I.E.L.D. (2013) and The New Adventures of Old Christine (2006).",
                    Language = "English",
                    PhotoURL = "RobertClarkGreggPhoto.jfif",
                    Popularity = false
                },
                new Actor
                {
                    Id = 9,
                    Name = "Cobie Smulders",
                    Country = "Vancouver, British Columbia, Canada",
                    DateBirth = "April 3, 1982",
                    Gender = "Female",
                    ShortDescription = "Cobie Smulders was born on April 3, 1982, in Vancouver, British Columbia, to a Dutch father and an English mother. As a girl, Cobie had set her sights on becoming a doctor or a marine biologist. In fact, it wasn't until high school that Cobie started to explore acting after appearing in several school productions. As a teenager, Cobie caught the eye of a modeling agency, which led to several years of world travel to places such as France, Japan, Italy, Greece, and Germany. Yet even as Cobie's modeling career was on the rise, she still managed to attend school, graduating from high school in 2000 with honors.",
                    Language = "English",
                    PhotoURL = "CobieSmuldersPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 10,
                    Name = "Stellan John Skarsgard",
                    Country = "Gothenburg, Västra Götalands län, Sweden",
                    DateBirth = "June 13, 1951",
                    Gender = "Male",
                    ShortDescription = "Stellan Skarsgård was born in Gothenburg, Västra Götalands län, Sweden, to Gudrun (Larsson) and Jan Skarsgård. He became a star in his teens through the title role in the TV-series Bombi Bitt och jag (1968). Between the years 1972-88 he was employed at The Royal Dramatic Theatre in Stockholm, where he participated in \"Vita rum\" (1988), August Strindberg's \"Ett drömspel\" (1986) and \"Mäster Olof\" (1988).",
                    Language = "Swedish,English",
                    PhotoURL = "StellanJohnSkarsgardPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 11,
                    Name = "Samuel L. Jackson",
                    Country = "Washington, District of Columbia, USA",
                    DateBirth = "December 21, 1948",
                    Gender = "Male",
                    ShortDescription = "Samuel L. Jackson is an American producer and highly prolific actor, having appeared in over 100 films, including Die Hard with a Vengeance (1995), Unbreakable (2000), Shaft (2000), Formula 51 (2001), Black Snake Moan (2006), Snakes on a Plane (2006), and the Star Wars prequel trilogy (1999-2005), as well as the Marvel Cinematic Universe.",
                    Language = "English",
                    PhotoURL = "SamuelJacksonPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 12,
                    Name = "Karen Gillan",
                    Country = "Inverness, Scotland, UK",
                    DateBirth = "November 28, 1987",
                    Gender = "Female",
                    ShortDescription = "Karen Sheila Gillan was born and raised in Inverness, Scotland, as the only child of Marie Paterson and husband John Gillan, who is a singer and recording artist. She developed a love for acting very early on, attending several youth theatre groups and taking part in a wide range of productions at her school, Charleston Academy.",
                    Language = "English",
                    PhotoURL = "KarenGillanPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 13,
                    Name = "Brie Larson",
                    Country = "Sacramento, California, USA",
                    DateBirth = "October 1, 1989",
                    Gender = "Female",
                    ShortDescription = "Brie Larson has built an impressive career as an acclaimed television actress, rising feature film star and emerging recording artist. A native of Sacramento, Brie started studying drama at the early age of 6, as the youngest student ever to attend the American Conservatory Theater in San Francisco. She starred in one of Disney Channel's most watched original movies, Right on Track (2003), as well as the WB's Raising Dad (2001) and MGM's teen comedy Sleepover (2004) - all before graduating from middle school.",
                    Language = "English",
                    PhotoURL = "BrieLarsonPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 14,
                    Name = "Jon Favreau",
                    Country = "Queens, New York City, New York, USA",
                    DateBirth = "October 19, 1966",
                    Gender = "Male",
                    ShortDescription = "The amiable, husky-framed actor with the tight, crinkly hair was born in Queens, New York on October 19, 1966, the only child of Madeleine (Balkoff), an elementary school teacher, and Charles Favreau, a special education teacher. His father has French-Canadian, German, and Italian ancestry, and his mother was from a Russian Jewish family. He attended the Bronx High School of Science before furthering his studies at Queens College in 1984. Dropping out just credits away from receiving his degree, Jon moved to Chicago where he focused on comedy and performed at several Chicago improvisational theaters, including the ImprovOlympic and the Improv Institute. He also found a couple of bit parts in films.",
                    Language = "English",
                    PhotoURL = "JonFavreauPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 15,
                    Name = "Bradley Cooper",
                    Country = "Philadelphia, Pennsylvania, USA",
                    DateBirth = "January 5, 1975",
                    Gender = "Male",
                    ShortDescription = "Bradley Charles Cooper was born on January 5, 1975 in Philadelphia, Pennsylvania. His mother, Gloria (Campano), is of Italian descent, and worked for a local NBC station. His father, Charles John Cooper, who was of Irish descent, was a stockbroker. Immediately after Bradley graduated from the Honors English program at Georgetown University in 1997, he moved to New York City to enroll in the Masters of Fine Arts program at the Actors Studio Drama School at New School University. There, he developed his stage work, culminating with his thesis performance as John Merrick in Bernard Pomerance's \"The Elephant Man\", performed in New York's Circle in the Square.",
                    Language = "English",
                    PhotoURL = "BradleyCooperPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 16,
                    Name = "Josh Brolin",
                    Country = "Santa Monica, California, USA",
                    DateBirth = "February 12, 1968",
                    Gender = "Male",
                    ShortDescription = "Brolin was born February 12, 1968 in Santa Monica, California, to Jane Cameron (Agee), a Texas-born wildlife activist, and James Brolin. Josh was not interested at first in the lifestyle of the entertainment business, in light of his parents' divorce, and both of them being actors. However, during junior year in high school, he took an acting class to see what it was like. He played Stanley in \"A Streetcar Named Desire\" and became hooked. His first major screen role was as the older brother in the film The Goonies (1985), based on a story by Steven Spielberg. He then immediately moved on to work on television, taking roles on such series as Private Eye: Pilot (1987) and The Young Riders (1989). \"Private Eye\" was a chance for Brolin to play a detective. \"The Young Riders\" was set just before the Civil War, and was co-directed by Brolin's father, James Brolin.",
                    Language = "English",
                    PhotoURL = "JoshBrolinPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 17,
                    Name = "Clark Gregg",
                    Country = "Boston, Massachusetts, USA",
                    DateBirth = "April 2, 1962",
                    Gender = "Male",
                    ShortDescription = "Clark Gregg was born on April 2, 1962 in Boston, Massachusetts, USA as Robert Clark Gregg. He is an actor and director, known for The Avengers (2012), Agents of S.H.I.E.L.D. (2013) and The New Adventures of Old Christine (2006).",
                    Language = "English",
                    PhotoURL = "ClarkGreggPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 18,
                    Name = "Paul Bettany",
                    Country = "Harlesden, London, England, UK",
                    DateBirth = "May 27, 1971",
                    Gender = "Male",
                    ShortDescription = "Paul Bettany is an English actor. He first came to the attention of mainstream audiences when he appeared in the British film Gangster No. 1 (2000), and director Brian Helgeland's film A Knight's Tale (2001). He has gone on to appear in a wide variety of films, including A Beautiful Mind (2001), Master and Commander: The Far Side of the World (2003), Dogville (2003), Wimbledon (2004), and the adaptation of the novel The Da Vinci Code (2006). He is also known for his voice role as J.A.R.V.I.S. in the Marvel Cinematic Universe, specifically the films Iron Man (2008), Iron Man 2 (2010), The Avengers (2012), Iron Man 3 (2013), and Avengers: Age of Ultron (2015), in which he also portrayed the Vision, for which he garnered praise. He reprised his role as the Vision in Captain America: Civil War (2016).",
                    Language = "English",
                    PhotoURL = "PaulBettanyPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 19,
                    Name = "Gwyneth Paltrow",
                    Country = "Los Angeles, California, USA",
                    DateBirth = "September 27, 1972",
                    Gender = "Female",
                    ShortDescription = "A tall, wafer thin, delicate beauty, Gwyneth Kate Paltrow was born in Los Angeles, the daughter of noted producer and director Bruce Paltrow and Tony Award-winning actress Blythe Danner. Her father was from a Jewish family, while her mother is of mostly German descent. When Gwyneth was eleven, the family moved to Massachusetts, where her father began working in summer stock productions in the Berkshires.",
                    Language = "English",
                    PhotoURL = "GwynethPaltrowPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 20,
                    Name = "Terrence Howard",
                    Country = "Chicago, Illinois, USA",
                    DateBirth = "March 11, 1969",
                    Gender = "Male",
                    ShortDescription = "Terrence Howard was born in Chicago, Illinois, to Anita Jeanine Williams (née Hawkins) and Tyrone Howard. He was raised in Cleveland, Ohio. His love for acting came naturally, through summers spent with his great-grandmother, New York stage actress Minnie Gentry. He later began his acting career after being discovered on a New York City street by a casting director. Soon, he followed with several notable TV appearances on shows such as Living Single (1993), NYPD Blue (1993) and Soul Food (2000). He became well known for his lead role in the UPN TV series Sparks (1996).",
                    Language = "English",
                    PhotoURL = "TerrenceHowardPhoto.jfif",
                    Popularity = false
                }
                ,
                new Actor
                {
                    Id = 21,
                    Name = "Jeff Bridges",
                    Country = "Los Angeles, California, USA",
                    DateBirth = "December 4, 1949",
                    Gender = "Male",
                    ShortDescription = "Jeffrey Leon Bridges was born on December 4, 1949 in Los Angeles, California, the son of well-known film and TV star Lloyd Bridges and his long-time wife Dorothy Dean Bridges (née Simpson). He grew up amid the happening Hollywood scene with big brother Beau Bridges. Both boys popped up, without billing, alongside their mother in the film The Company She Keeps (1951), and appeared on occasion with their famous dad on his popular underwater TV series Sea Hunt (1958) while growing up.",
                    Language = "English",
                    PhotoURL = "JeffBridgesPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 22,
                    Name = "Don Cheadle",
                    Country = "Kansas City, Missouri, USA",
                    DateBirth = "November 29, 1964",
                    Gender = "Male",
                    ShortDescription = "Donald Frank Cheadle was born in Kansas City, Missouri, on November 29, 1964. His childhood found him moving from city to city with his family: mother Bettye (née North), a teacher; father Donald Frank Cheadle Sr., a clinical psychologist; sister Cindy; and brother Colin.",
                    Language = "English",
                    PhotoURL = "DonCheadlePhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 23,
                    Name = "Edward Norton",
                    Country = "Boston, Massachusetts, USA",
                    DateBirth = "August 18, 1969",
                    Gender = "Male",
                    ShortDescription = "American actor, filmmaker and activist Edward Harrison Norton was born on August 18, 1969, in Boston, Massachusetts, and was raised in Columbia, Maryland.His mother,Lydia Robinson \"Robin\"(Rouse),was a foundation executive and teacher of English,and a daughter of famed real estate developer James Rouse,who developed Columbia,MD; she passed away of brain cancer on March 6, 1997.His father, Edward Mower Norton, Jr., was an environmental lawyer and conservationist, who works for the National Trust for Historic Preservation. Edward has two younger siblings, James and Molly.",
                    Language = "English",
                    PhotoURL = "EdwardNortonPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 24,
                    Name = "Tim Roth",
                    Country = "Dulwich, London, England, UK",
                    DateBirth = "May 14, 1961",
                    Gender = "Male",
                    ShortDescription = "Often mistaken for an American because of his skill at imitating accents, actor Tim Roth was born Timothy Simon Roth on May 14, 1961 in Lambeth, London, England. His mother, Ann, was a teacher and landscape painter. His father, Ernie, was a journalist who had changed the family name from \"Smith\" to \"Roth\"; Ernie was born in Brooklyn, New York, to an immigrant family of Irish ancestry.",
                    Language = "English",
                    PhotoURL = "TimRothPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 25,
                    Name = "Liv Tyler",
                    Country = "New York City, New York, USA",
                    DateBirth = "July 1, 1977",
                    Gender = "Male",
                    ShortDescription = "Liv Tyler is an actress of international renown and has been a familiar face on our screens for over two decades and counting. She began modelling at the age of fourteen before pursuing a career in acting. After making her film debut in Bruce Beresford's Silent Fall, she was cast by fledgling director James Mangold (who would go on to direct such hits as Girl, Interrupted, Walk the Line and Logan) in his first feature Heavy, a critical and commercial success that went on to gain cult status. This was followed by another indie cult hit, Empire Records, but it was the leading role in Bernardo Bertolucci's Stealing Beauty that catapulted her to stardom at the age of eighteen.",
                    Language = "English",
                    PhotoURL = "LivTylerPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 26,
                    Name = "Mickey Rourke",
                    Country = "Schenectady, New York, USA",
                    DateBirth = "September 16, 1952",
                    Gender = "Male",
                    ShortDescription = "Mickey Rourke was born Phillip Andre Rourke, Jr. on September 16, 1952, in Schenectady, New York, the son of Annette (Cameron) and Phillip Andre Rourke. His father was of Irish and German descent, and his mother was of French-Canadian, English, and German ancestry. When he was six years old, his parents divorced.",
                    Language = "English",
                    PhotoURL = "MickeyRourkePhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 27,
                    Name = "Natalie Portman",
                    Country = "Jerusalem, Israel",
                    DateBirth = "June 9, 1981",
                    Gender = "Female",
                    ShortDescription = "Natalie was born Natalie Hershlag on June 9, 1981, in Jerusalem, Israel. She is the only child of Avner Hershlag, a Israeli-born doctor, and Shelley Stevens, an American-born artist (from Cincinnati, Ohio), who also acts as Natalie's agent. Her parents are both of Ashkenazi Jewish descent. Natalie's family left Israel for Washington, D.C., when she was still very young. After a few more moves, her family finally settled in New York, where she still lives to this day. She graduated with honors, and her academic achievements allowed her to attend Harvard University. She was discovered by an agent in a pizza parlor at the age of 11. ",
                    Language = "Hebrew",
                    PhotoURL = "NataliePortmanPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 28,
                    Name = "Rene Russo",
                    Country = "Burbank, California, USA",
                    DateBirth = "February 17, 1954",
                    Gender = "Female",
                    ShortDescription = "Rene Russo was born in Burbank, California, to Shirley (Balocca), a barmaid and factory laborer, and Nino Russo. Her father, a sculptor and mechanic, left the family when Rene was just two, and thus her mother raised Rene and her sister, Toni, as a single mom. Her father was of Italian descent, and her mother was of Italian and German-English-Irish ancestry.",
                    Language = "English",
                    PhotoURL = "ReneRussoPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 29,
                    Name = "Idris Elba",
                    Country = "Hackney, London, England, UK",
                    DateBirth = "September 6, 1972",
                    Gender = "Male",
                    ShortDescription = "An only child, Idrissa Akuna Elba was born and raised in London, England. His father, Winston, is from Sierra Leone and worked at Ford Dagenham; his mother, Eve, is from Ghana and had a clerical duty. Idris attended school in Canning Town, where he first became involved in acting, before he dropped out. He gained a place in the National Youth Music Theatre - thanks to a £1,500 Prince's Trust grant.",
                    Language = "English",
                    PhotoURL = "IdrisElbaPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 30,
                    Name = "Tadanobu Asano",
                    Country = "Yokohama, Japan",
                    DateBirth = "November 27, 1973",
                    Gender = "Male",
                    ShortDescription = "Tadanobu Asano's a Japanese film actor. His father suggested he take on what became his first role in the TV show \"Kimpachi Sensei,\" at 16. His film debut was in the 1990 Swimming Upstream (Swimming Upstream (1990)), though his first major critical success was in Shunji Iwai's Fried Dragon Fish (1993). His first critical success in the West was in Hirokazu Koreeda's Maborosi (1995), in which he played a man who inexplicably throws himself in front of a train, widowing his wife and orphaning his infant son.",
                    Language = "Japanese",
                    PhotoURL = "TadanobuAsanoPhoto.jfif",
                    Popularity = false
                },
                new Actor
                {
                    Id = 31,
                    Name = "Kat Dennings",
                    Country = "Philadelphia, Pennsylvania, USA",
                    DateBirth = "June 13, 1986",
                    Gender = "Female",
                    ShortDescription = "Kat Dennings was born Katherine Victoria Litwack in Bryn Mawr, Pennsylvania, near Philadelphia, to Ellen (Schatz), a speech therapist and poet, and Gerald Litwack, a molecular pharmacologist. She is the youngest of five children. Her family is of Russian Jewish descent. Kat was predominantly home-schooled, graduating at the age of fourteen. Her family subsequently moved to Los Angeles, California to support Kat acting full-time.",
                    Language = "English",
                    PhotoURL = "KatDenningsPhoto.jfif",
                    Popularity = false
                },
                new Actor
                {
                    Id = 32,
                    Name = "Anthony Hopkins",
                    Country = "Margam, Port Talbot, West Glamorgan, Wales, UK",
                    DateBirth = "December 31, 1937",
                    Gender = "Male",
                    ShortDescription = "Anthony Hopkins was born on December 31, 1937, in Margam, Wales, to Muriel Anne (Yeats) and Richard Arthur Hopkins, a baker. His parents were both of half Welsh and half English descent. Influenced by Richard Burton, he decided to study at College of Music and Drama and graduated in 1957. In 1965, he moved to London and joined the National Theatre, invited by Laurence Olivier, who could see the talent in Hopkins. In 1967, he made his first film for television, A Flea in Her Ear (1967).",
                    Language = "English",
                    PhotoURL = "AnthonyHopkinsPhoto.jfif",
                    Popularity = false
                },
                new Actor
                {
                    Id = 33,
                    Name = "Jaimie Alexander",
                    Country = "Columbia, South Carolina, USA",
                    DateBirth = "March 12, 1984",
                    Gender = "Female",
                    ShortDescription = "Jaimie Alexander was born in Greenville, South Carolina, but moved with her family to Grapevine, Texas, when she was four years old. She took theatre classes in grade school as a hobby but was kicked out in high school because she could not sing, and so she took up sports instead. At age 17 she substituted for a friend at a meeting with a scouting agency and she met her manager, Randy James, who sent her some scripts. After graduating from high school she moved to Los Angeles, California, to pursue acting.",
                    Language = "English",
                    PhotoURL = "JaimieAlexanderPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 34,
                    Name = "Ray Stevenson",
                    Country = "Lisburn, Northern Ireland, UK",
                    DateBirth = "May 25, 1964",
                    Gender = "Male",
                    ShortDescription = "Tall, dark, but somewhat gentle-looking actor Ray Stevenson was born in Lisburn, Northern Ireland on 25 May 1964, on a British army base. His father was a British pilot in the Royal Air Force, and his mother is Irish. He moved with his family to Lemington, Newcastle-Upon-Tyne, England in 1972 at the age of eight, and later to Cramlington, Northumberland, where he was raised.",
                    Language = "English",
                    PhotoURL = "RayStevensonPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 35,
                    Name = "Sebastian Stan",
                    Country = "Constanta, Romania",
                    DateBirth = "August 13, 1982",
                    Gender = "Male",
                    ShortDescription = "Sebastian Stan was born on August 13, 1982, in Constanta, Romania. He moved with his mother to Vienna, Austria, when he was eight, and then to New York when he was twelve. Stan studied at Rutgers Mason Gross School of the Arts and spent a year at Shakespeare's Globe Theatre in London.",
                    Language = "Romanian",
                    PhotoURL = "SebastianStanPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 36,
                    Name = "Hayley Atwell",
                    Country = "London, England, UK",
                    DateBirth = "April 5, 1982",
                    Gender = "Female",
                    ShortDescription = "Born in London, England, Hayley Elizabeth Atwell has dual citizenship of the United Kingdom and the United States. An only child, Hayley was named after actress Hayley Mills. Her parents, Alison (Cain) and Grant Atwell, both motivational speakers, met at a London workshop of Dale Carnegie's self-help bible \"How to Win Friends and Influence People\". Her mother is English (with Irish ancestry) and her father is American; he was born in Kansas City, Missouri, and is partly of Native-American descent (his Native American name is Star Touches Earth).",
                    Language = "English",
                    PhotoURL = "HayleyAtwellPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 37,
                    Name = "Tommy Lee Jones",
                    Country = "San Saba, Texas, USA",
                    DateBirth = "September 15, 1946",
                    Gender = "Male",
                    ShortDescription = "Tommy Lee Jones was born in San Saba, Texas, the son of Lucille Marie (Scott), a police officer and beauty shop owner, and Clyde C. Jones, who worked on oil fields. Tommy himself worked in underwater construction and on an oil rig. He attended St. Mark's School of Texas, a prestigious prep school for boys in Dallas, on a scholarship, and went to Harvard on another scholarship. He roomed with future Vice President Al Gore and played offensive guard in the famous 29-29 Harvard-Yale football game of '68 known as \"The Tie.\" He received a B.A. in English literature and graduated cum laude from Harvard in 1969.",
                    Language = "English",
                    PhotoURL = "TommyLeeJonesPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 38,
                    Name = "Evangeline Lilly",
                    Country = "Fort Saskatchewan, Alberta, Canada",
                    DateBirth = "August 3, 1979",
                    Gender = "Female",
                    ShortDescription = "Evangeline Lilly, born in Fort Saskatchewan, Alberta, in 1979, was discovered on the streets of Kelowna, British Columbia, by the famous Ford modeling agency. Although she initially decided to pass on a modeling career, she went ahead and signed with Ford anyway, to help pay for her University of British Columbia tuition and expenses.",
                    Language = "English",
                    PhotoURL = "EvangelineLillyPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 39,
                    Name = "Chris Pratt",
                    Country = "Virginia, Minnesota, USA",
                    DateBirth = "June 21, 1979",
                    Gender = "Female",
                    ShortDescription = "Christopher Michael \"Chris\" Pratt was born on June 21, 1979 in Virginia, Minnesota and raised in Lake Stevens, Washington to Kathleen Louise Pratt (née Indahl), who worked at a supermarket & Daniel Clifton Pratt, who remodeled houses. He came to prominence for his small-screen roles, including Bright Abbott in Everwood (2002), Ché in The O.C. (2003), and Andy Dwyer and Parks and Recreation (2009), and notable film roles in Moneyball (2011), The Five-Year Engagement (2012), Zero Dark Thirty (2012), Delivery Man (2013), and Her (2013).",
                    Language = "English",
                    PhotoURL = "ChrisPrattPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 40,
                    Name = "Zoe Saldana",
                    Country = "Passaic, New Jersey, USA",
                    DateBirth = "June 19, 1978",
                    Gender = "Female",
                    ShortDescription = "Zoe Saldana was born on June 19, 1978 in Passaic, New Jersey, to Asalia Nazario and Aridio Saldaña. Her father was Dominican and her mother is Puerto Rican. She was raised in Queens, New York. When she was 10 years old, she and her family moved to the Dominican Republic, where they would live for the next seven years. While living there, Zoe discovered a keen interest in performance dance and began her training at the prestigious ECOS Espacio de Danza Dance Academy where she learned ballet as well as other dance forms.",
                    Language = "English",
                    PhotoURL = "ZoeSaldanaPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 41,
                    Name = "Vin Diesel",
                    Country = "Alameda County, California, USA",
                    DateBirth = "July 18, 1967",
                    Gender = "Male",
                    ShortDescription = "Vin Diesel was born Mark Sinclair in Alameda County, California, along with his fraternal twin brother, Paul Vincent. He was raised by his astrologer/psychologist mother, Delora Sherleen (Sinclair), and adoptive father, Irving H. Vincent, an acting instructor and theatre manager, in an artists' housing project in New York City's Greenwich Village.",
                    Language = "English",
                    PhotoURL = "VinDieselPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 42,
                    Name = "Dave Bautista",
                    Country = "Washington, District of Columbia, USA",
                    DateBirth = "January 18, 1969",
                    Gender = "Male",
                    ShortDescription = "When WCW officials told him he'd never make it in sports entertainment, Bautista pushed himself to achieve his dream of being a Superstar. In May 2002, he made his debut on SmackDown using the ring name Batista, but it wasn't until a move to Raw and two victories over Kane that \"The Animal\" began to make noise in the WWE Universe.",
                    Language = "English",
                    PhotoURL = "DaveBautistaPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 43,
                    Name = "Kurt Russell",
                    Country = "Springfield, Massachusetts, USA",
                    DateBirth = "March 17, 1951",
                    Gender = "Male",
                    ShortDescription = "Kurt Vogel Russell was born on March 17, 1951 in Springfield, Massachusetts, to Louise Julia Russell (née Crone), a dancer, and Bing Russell, an actor. He is of English, German, Scottish and Irish descent. His first roles were as a child on television series, including a lead role on the Western series The Travels of Jaimie McPheeters (1963). Russell landed a role in the Elvis Presley movie, It Happened at the World's Fair (1963), when he was eleven years old. Walt Disney himself signed Russell to a 10-year contract, and, according to Robert Osborne, he became the studio's top star of the 1970s.",
                    Language = "English",
                    PhotoURL = "KurtRussellPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 44,
                    Name = "Tom Holland",
                    Country = "Kingston upon Thames, England, UK",
                    DateBirth = "June 1, 1996",
                    Gender = "Male",
                    ShortDescription = "Thomas Stanley Holland was born in Kingston-upon-Thames, Surrey, to Nicola Elizabeth (Frost), a photographer, and Dominic Holland (Dominic Anthony Holland), who is a comedian and author. His paternal grandparents were from the Isle of Man and Ireland, respectively. He lives with his parents and three younger brothers - Paddy and twins Sam and Harry. Tom attended Donhead Prep School.",
                    Language = "English",
                    PhotoURL = "TomHollandPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 45,
                    Name = "Anthony Mackie",
                    Country = "New Orleans, Louisiana, USA",
                    DateBirth = "September 23, 1978",
                    Gender = "Male",
                    ShortDescription = "Anthony Mackie is an American actor. He was born in New Orleans, Louisiana, to Martha (Gordon) and Willie Mackie, Sr., who owned a business, Mackie Roofing. Anthony has been featured in feature films, television series and Broadway and Off-Broadway plays, including Ma Rainey's Black Bottom, Drowning Crow, McReele, A Soldier's Play, and Talk, by Carl Hancock Rux, for which he won an Obie Award in 2002. In 2002, he was featured in Eminem's debut film, 8 Mile, playing Papa Doc, a member of Leaders of the Free World.",
                    Language = "English",
                    PhotoURL = "AnthonyMackiePhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 46,
                    Name = "Elizabeth Olsen",
                    Country = "Los Angeles, California, USA",
                    DateBirth = "February 16, 1989",
                    Gender = "Female",
                    ShortDescription = "Elizabeth Chase \"Lizzie\" Olsen (born February 16, 1989) is an American actress. She is known for her roles in the films Silent House (2011), Liberal Arts (2012), Godzilla (2014), Avengers: Age of Ultron (2015), and Captain America: Civil War (2016). For her role in the critically-acclaimed Martha Marcy May Marlene (2011), she was nominated for numerous awards, including the Independent Spirit Award for Best Female Lead.",
                    Language = "English",
                    PhotoURL = "ElizabethOlsenPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 47,
                    Name = "Paul Rudd",
                    Country = "Passaic, New Jersey, USA",
                    DateBirth = "April 6, 1969",
                    Gender = "Male",
                    ShortDescription = "Paul Stephen Rudd was born in Passaic, New Jersey. His parents, Michael and Gloria, both from Jewish families, were born in the London area, U.K. He has one sister, who is three years younger than he is. Paul traveled with his family during his early years, because of his father's airline job at TWA. His family eventually settled in Overland Park, Kansas, where his mother worked as a sales manager for TV station KSMO-TV. Paul attended Broadmoor Junior High and Shawnee Mission West High School, from which he graduated in 1987, and where he was Student Body President.",
                    Language = "English",
                    PhotoURL = "PaulRuddPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 48,
                    Name = "Benedict Cumberbatch",
                    ShortDescription = "Benedict Timothy Carlton Cumberbatch was born and raised in London, England. His parents, Wanda Ventham and Timothy Carlton (born Timothy Carlton Congdon Cumberbatch), are both actors. He is a grandson of submarine commander Henry Carlton Cumberbatch, and a great-grandson of diplomat Henry Arnold Cumberbatch CMG.",
                    Popularity = false,
                    Country = "Hammersmith, London, England, UK",
                    Gender = "Male",
                    DateBirth = "July 19, 1976",
                    Language = "English",
                    PhotoURL = "BenedictCumberbatchPhoto.jpg"

                },
                new Actor
                {
                    Id = 49,
                    Name = "Michael B. Jordan",
                    Country = "Santa Ana, California, USA",
                    DateBirth = "February 9, 1987",
                    Gender = "Male",
                    ShortDescription = "Michael B. Jordan, the middle of three children, was born in Santa Ana, California and raised in Newark, New Jersey. He is the son of Donna (Davis), a high school counselor, and Michael A. Jordan. His middle name, Bakari, means \"noble promise\" in Swahili. (He is not related to, or named after, basketball legend Michael Jordan.)",
                    Language = "English",
                    PhotoURL = "MichaelJordanPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 50,
                    Name = "Chadwick Boseman",
                    Country = "Anderson, South Carolina, USA",
                    DateBirth = "November 29, 1976",
                    Gender = "Male",
                    ShortDescription = "Chadwick Boseman was an American actor. He is known for his portrayal of T'Challa / Black Panther in the Marvel Cinematic Universe from 2016 to 2019, particularly in Black Panther (2018), and for his starring roles as several pioneering Americans, Jackie Robinson in 42 (2013), James Brown in Get on Up (2014), and Thurgood Marshall in Marshall (2017).",
                    Language = "English",
                    PhotoURL = "ChadwickBosemanPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 51,
                    Name = "Jake Gyllenhaal",
                    Country = "Los Angeles, California, USA",
                    DateBirth = "December 19, 1980",
                    Gender = "Male",
                    ShortDescription = "Jacob Benjamin Gyllenhaal was born in Los Angeles, California, to producer/screenwriter Naomi Foner (née Achs) and director Stephen Gyllenhaal. He is the brother of actress Maggie Gyllenhaal, who played his sister in Donnie Darko (2001). His godmother is actress Jamie Lee Curtis. His mother is from a Jewish family, and his father's ancestry includes Swedish, English and Swiss-German.",
                    Language = "English",
                    PhotoURL = "JakeGyllenhaalPhoto.jpg",
                    Popularity = false
                },
                new Actor
                {
                    Id = 52,
                    Name = "Sylvester Stallone",
                    ShortDescription = "Sylvester Stallone is a athletically built, dark-haired American actor/screenwriter/director/producer, the movie fans worldwide have been flocking to see Stallone's films for over 40 years, making \"Sly\" one of Hollywood's biggest-ever box office draws.",
                    Popularity = false,
                    Country = "New York City",
                    Gender = "Male",
                    DateBirth = "July 6, 1946",
                    Language = "English",
                    PhotoURL = "SylvesterStallonePhoto.jpg"
                },
                new Actor
                {
                    Id = 53,
                    Name = "Leonardo Di Caprio",
                    ShortDescription = "Few actors in the world have had a career quite as diverse as Leonardo DiCaprio's. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies.",
                    Popularity = true,
                    Country = "Los Angeles, California",
                    Gender = "Male",
                    DateBirth = "November 11, 1974",
                    Language = "English",
                    PhotoURL = "LeonardoDiCaprioPhoto.jfif"

                },
                new Actor
                {
                    Id = 54,
                    Name = "Tom Cruse",
                    ShortDescription = "In 1976, if you had told fourteen-year-old Franciscan seminary student Thomas Cruise Mapother IV that one day in the not too distant future he would be Tom Cruise, one of the top 100 movie stars of all time, he would have probably grinned and told you that his ambition was to join the priesthood. Nonetheless, this sensitive, deeply religious youngster who was born in 1962 in Syracuse, New York, was destined to become one of the highest paid and most sought after actors in screen history.",
                    Popularity = false,
                    Country = "Syracuse, New York, USA",
                    Gender = "Male",
                    DateBirth = "July 3, 1962",
                    Language = "English",
                    PhotoURL = "TomCrusePhoto.jpg"

                },
                new Actor
                {
                    Id = 55,
                    Name = "Arnold Schwarcneger",
                    ShortDescription = "With an almost unpronounceable surname and a thick Austrian accent, who would have ever believed that a brash, quick talking bodybuilder from a small European village would become one of Hollywood's biggest stars, marry into the prestigious Kennedy family, amass a fortune via shrewd investments and one day be the Governor of California!",
                    Popularity = false,
                    Country = "Thal, Styria, Austria",
                    Gender = "Male",
                    DateBirth = "July 30, 1947",
                    Language = "English",
                    PhotoURL = "ArnoldSchwarcnegerPhoto.jpg"

                },
                new Actor
                {
                    Id = 56,
                    Name = "Angelina Jolie",
                    ShortDescription = "Angelina Jolie is an Academy Award-winning actress who rose to fame after her role in Girl, Interrupted (1999), playing the title role in the \"Lara Croft\" blockbuster movies, as well as Mr. & Mrs. Smith (2005), Wanted (2008), Salt (2010) and Maleficent (2014). Off-screen, Jolie has become prominently involved in international charity projects,.",
                    Popularity = true,
                    Country = "Los Angeles, California, USA",
                    Gender = "Female",
                    DateBirth = "June 4, 1975",
                    Language = "English",
                    PhotoURL = "AngelinaJoliePhoto.jpg"

                },
                new Actor
                {
                    Id = 57,
                    Name = "Jesse Eisenberg",
                    ShortDescription = "Curly haired and with a fast-talking voice, Jesse Eisenberg is a movie actor, known for his Academy Award nominated role as Mark Zuckerberg in the 2010 film The Social Network. He has also starred in the films The Squid and the Whale, Adventureland, The Education of Charlie Banks, 30 Minutes or Less, Now You See Me and Zombieland.",
                    Popularity = false,
                    Country = "New York City, New York, USA",
                    Gender = "Male",
                    DateBirth = "October 5, 1983",
                    Language = "English",
                    PhotoURL = "JesseEisenbergPhoto.jpg"

                },
                new Actor
                {
                    Id = 58,
                    Name = "Tom Schilling",
                    ShortDescription = "Tom Schilling was born on February 10, 1982 in Berlin, Germany. He is an actor, known for A Coffee in Berlin (2012), Before the Fall (2004) and Who Am I (2014).",
                    Popularity = false,
                    Country = "Berlin, Germany",
                    Gender = "Male",
                    DateBirth = "February 10, 1982",
                    Language = "German",
                    PhotoURL = "TomSchillingPhoto.jpeg"

                },
                new Actor
                {
                    Id = 59,
                    Name = "Penélope Cruz",
                    ShortDescription = "Known outside her native country as the \"Spanish enchantress\", Penélope Cruz Sánchez was born in Madrid to Eduardo Cruz, a retailer, and Encarna Sánchez, a hairdresser. As a toddler, she was already a compulsive performer, re-enacting TV commercials for her family's amusement, but she decided to focus her energies on dance. After studying classical ballet for nine years at Spain's National Conservatory, she continued her training under a series of prominent dancers.",
                    Popularity = true,
                    Country = "Alcobendas, Madrid, Spain",
                    Gender = "Female",
                    DateBirth = "April 28, 1974",
                    Language = "Spain",
                    PhotoURL = "PenélopeCruzPhoto.jpg"

                },
                new Actor
                {
                    Id = 60,
                    Name = "Jonny Lee Miller",
                    ShortDescription = "Jonny (sometimes credited as Johnny) Lee Miller was born on November 15, 1972, in Kingston, England, UK. He is the son of actors Anna Lee and Alan Miller and the grandson of actor Bernard Lee.",
                    Popularity = false,
                    Country = "Kingston upon Thames, Surrey,England,UK",
                    Gender = "Male",
                    DateBirth = "November 15, 1972",
                    Language = "English",
                    PhotoURL = "JonnyLeeMillerPhoto.jpg"
                },
                new Actor
                {
                    Id = 61,
                    Name = "Jesse Bradford",
                    ShortDescription = "Jesse Bradford was born Jesse Bradford Watrouse in Norwalk, Connecticut. Both of his parents, Curtis Watrouse and Terry Porter, are actors who have appeared in many television commercials. Jesse has been acting almost constantly since his big debut in a Q-Tip commercial when he was an 8-month-old baby.",
                    Popularity = false,
                    Country = "Norwalk, Connecticut, USA",
                    Gender = "Male",
                    DateBirth = "May 28, 1979",
                    Language = "English",
                    PhotoURL = "JesseBradfordPhoto.jpg"
                },
                new Actor
                {
                    Id = 62,
                    Name = "Matthew Lillard",
                    ShortDescription = "Matthew Lillard was born in Lansing, Michigan, to Paula and Jeffrey Lillard. He lived with his family in Tustin, California, from first grade to high school graduation. The summer after high school, he was hired as an extra for Ghoulies Go to College (1990).",
                    Popularity = false,
                    Country = "Lansing, Michigan, USA",
                    Gender = "Male",
                    DateBirth = "January 24, 1970",
                    Language = "English",
                    PhotoURL = "MatthewLillardPhoto.jpg"
                },
                new Actor
                {
                    Id = 63,
                    Name = "Laurence Mason",
                    ShortDescription = "Laurence Mason, is an American actor born in the Bronx, NYC to hard working Caribbean couple who wanted more for their son. He made his break into the world of the arts at age 10 after being recruited by The First All Children's Theatre.",
                    Popularity = false,
                    Country = "Bronx, NYC",
                    Gender = "Male",
                    DateBirth = "Don't know",
                    Language = "English",
                    PhotoURL = "LaurenceMasonPhoto.jpg"
                },
                new Actor
                {
                    Id = 64,
                    Name = "Renoly Santiago",
                    ShortDescription = "Renoly Santiago was born in Lajas, Puerto Rico and he spent his childhood in Union City, New Jersey. Before establishing himself as an accomplished entertainer, Renoly started singing, acting, dancing and writing early on, following his calling while very young; earning a dance scholarship to the Ballet Hispanico.",
                    Popularity = false,
                    Country = "Lajas, Puerto Rico",
                    Gender = "Male",
                    DateBirth = "March 15, 1974",
                    Language = "Spanish, English",
                    PhotoURL = "RenolySantiagoPhoto.jpg"
                },
                new Actor
                {
                    Id = 65,
                    Name = "Julie Benz",
                    ShortDescription = "Julie Benz was born in Pittsburgh, Pennsylvania, USA on May 1, 1972. Julie's father is a Pittsburgh surgeon and her mother is a figure skater. The family settled in nearby Murrysville, when Julie was two, and she started ice skating at age three.",
                    Popularity = false,
                    Country = "Pittsburgh, Pennsylvania, USA",
                    Gender = "Female",
                    DateBirth = "May 1, 1972",
                    Language = "English",
                    PhotoURL = "JulieBenzPhoto.jpg"
                },
                new Actor
                {
                    Id = 66,
                    Name = "Matthew Marsden",
                    ShortDescription = "British actor/singer/Producer Matthew Marsden began his acting career in the UK and rose to stardom from his role on the long-running ITV series Coronation Street (1960), as Chris Collins. He left the show to pursue a music and acting career in the US and hasn't looked back since.",
                    Popularity = false,
                    Country = "West Bromwich, West Midlands, England, UK",
                    Gender = "Male",
                    DateBirth = "March 3, 1973",
                    Language = "English",
                    PhotoURL = "MatthewMarsdenPhoto.jpg"
                },
                new Actor
                {
                    Id = 67,
                    Name = "Kate Winslet",  
                    ShortDescription = "Ask Kate Winslet what she likes about any of her characters, and the word \"ballsy\" is bound to pop up at least once. The British actress has made a point of eschewing straightforward pretty-girl parts in favor of more devilish damsels; as a result, she's built an eclectic resume that runs the gamut from Shakespearean tragedy to modern-day",
                    Popularity = false,
                    Country = "Reading, Berkshire, England, UK",
                    Gender = "Female",
                    DateBirth = "October 5, 1975",
                    Language = "English",
                    PhotoURL = "KateWinsletPhoto.jpg"
                },
                new Actor
                {
                    Id = 68,
                    Name = "Billy Zane",  
                    ShortDescription = "William George Zane, better known as Billy Zane, was born on February 24, 1966 in Chicago, Illinois, to Thalia (Colovos) and William Zane, both of Greek ancestry. His parents were amateur actors and managed a medical technical school. Billy has an older sister, actress and singer Lisa Zane. Billy was bitten by the acting bug early on.",
                    Popularity = false,
                    Country = "Chicago, Illinois, USA",
                    Gender = "Male",
                    DateBirth = "February 24, 1966",
                    Language = "English",
                    PhotoURL = "BillyZanePhoto.jpg"
                },
                new Actor
                {
                    Id = 69,
                    Name = "Tim Robbins",
                    ShortDescription = "Born in West Covina, California, but raised in New York City, Tim Robbins is the son of former The Highwaymen singer Gil Robbins and actress Mary Robbins (née Bledsoe). Robbins studied drama at UCLA, where he graduated with honors in 1981.",
                    Popularity = false,
                    Country = "West Covina, California, USA",
                    Gender = "Male",
                    DateBirth = "October 16, 1958",
                    Language = "English",
                    PhotoURL = "https://m.media-amazon.com/images/M/MV5BMTI1OTYxNzAxOF5BMl5BanBnXkFtZTYwNTE5ODI4._V1_UY1200_CR151,0,630,1200_AL_.jpg"
                },
                new Actor
                {
                    Id = 70,
                    Name = "Kelly McGillis",
                    ShortDescription = "Kelly Ann McGillis was born in Newport Beach, California, to Virginia Joan (Snell), a homemaker, and Donald Manson McGillis, a general practitioner of medicine. She has English, Welsh, Scots-Irish, and German ancestry.",
                    Popularity = false,
                    Country = "Newport Beach, California, USA",
                    Gender = "Male",
                    DateBirth = "July 9, 1957",
                    Language = "English",
                    PhotoURL = "https://m.media-amazon.com/images/M/MV5BMjA0OTg5ODY3Ml5BMl5BanBnXkFtZTgwNzkxOTU3MDI@._V1_.jpg"
                }
               //,new Actor
               // {
               //     Id = 71,
               //     Name = "",
               //     ShortDescription = "",
               //     Popularity = false,
               //     Country = "",
               //     Gender = "Male",
               //     DateBirth = "July 19, 1976",
               //     Language = "English",
               //     PhotoURL = ""
               // }

                );
            #endregion

            #region Category

            modelBuilder.Entity<Category>().HasData(
            new Category { ID = 1, Name = "Fiction" },
            new Category { ID = 2, Name = "Action" },
            new Category { ID = 3, Name = "Crime" },
            new Category { ID = 4, Name = "Adventure" },
            new Category { ID = 5, Name = "Drama" },
            new Category { ID = 6, Name = "Fantasy" },
            new Category { ID = 7, Name = "Thriller" },
            new Category { ID = 8, Name = "General" },
            new Category { ID = 9, Name = "Horror" },
            new Category { ID = 10, Name = "Comedy" },
            new Category { ID = 11, Name = "Sci-Fi" },
            new Category { ID = 12, Name = "Biography" },
            new Category { ID = 13, Name = "Mystery" },
            new Category { ID = 14, Name = "Uncategorised" }
            );

            #endregion

            #region Publishers

            modelBuilder.Entity<Publisher>().HasData(
              new Publisher
              {
                  Id = 1,
                  Name = "20th Century Fox",
                  Country = "USA",
                  Year = "1935"

              },
              new Publisher
              {
                  Id = 2,
                  Name = "Lionsgate",
                  Country = "Vancouver, British Columbia",
                  Year = "July 10, 1997"
              },
              new Publisher
              {
                  Id = 4,
                  Name = "Paramount Pictures",
                  Country = "USA",
                  Year = "1916"
              },
              new Publisher
              {
                  Id = 5,
                  Name = "Cinema '84",
                  Country = "Not known",
                  Year = "Not known"
              },
              new Publisher
              {
                  Id = 6,
                  Name = "United Artists",
                  Country = "USA",
                  Year = "1919"
              },
              new Publisher
              {
                  Id = 7,
                  Name = "Columbia Pictures",
                  Country = "USA",
                  Year = "1974"
              },
              new Publisher
              {
                  Id = 8,
                  Name = "Black Bear Pictures",
                  Country = "Santa Monica, California",
                  Year = "2011"
              },
              new Publisher
              {
                  Id = 9,
                  Name = "Wiedemann & Berg Film Production",
                  Country = "Germany",
                  Year = "2003"
              },
              new Publisher
              {
                  Id = 10,
                  Name = "Legendary Entertainment",
                  Country = "USA",
                  Year = "2000"
              },
              new Publisher
              {
                  Id = 11,
                  Name = "Marvel Studios",
                  Country = "USA",
                  Year = "1996"
              }
              );
            #endregion

            #region Directors

            modelBuilder.Entity<Director>().HasData(
            new Director
            {
                Id = 1,
                Name = "Kenneth Branagh",
                Country = "Belfast, Northern Ireland, UK",
                DateBirth = "December 10, 1960"

            },
            new Director
            {
                Id = 2,
                Name = "Sylvester Stallone",
                Country = "USA",
                DateBirth = "July 6, 1946"
            },
            new Director
            {
                Id = 3,
                Name = "James Cameron",
                Country = "Kapusaksing, Ontario, Canada",
                DateBirth = "August 16, 1954"
            },
            new Director
            {
                Id = 4,
                Name = "Tony Scott",
                Country = "North Shields, Northumberland, England, UK",
                DateBirth = "June 21, 1944"
            },
            new Director
            {
                Id = 5,
                Name = "Pixar",
                Country = "Ireland",
                DateBirth = "2012"

            },
            new Director
            {
                Id = 6,
                Name = "Iain Softley",
                Country = "London, England, UK",
                DateBirth = "1958"
            },
            new Director
            {
                Id = 7,
                Name = "David Fincher",
                Country = "Denver, Colorado, USA",
                DateBirth = "August 28, 1962"
            },
            new Director
            {
                Id = 8,
                Name = "Morten Tyldum",
                Country = "Bergen, Norway",
                DateBirth = "May 19, 1967"
            },
            new Director
            {
                Id = 9,
                Name = "Baran bo Odar",
                Country = "Olten, Switzerland",
                DateBirth = "April 18, 1978"
            },
            new Director
            {
                Id = 10,
                Name = "Christopher Nolan",
                Country = "London, England, UK",
                DateBirth = "July 30, 1970"
            },
            new Director
            {
                Id = 11,
                Name = "Joe Russo",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 12,
                Name = "Anthony Russo",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 13,
                Name = "Anna Boden",
                Country = "USA",
                Gender = "Female",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 14,
                Name = "Jon Favreau",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 15,
                Name = "Shane Black",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 16,
                Name = "Louis Leterrier",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 17,
                Name = "Taika Waititi",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 18,
                Name = "Alan Taylor",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 19,
                Name = "Joss Whedon",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 20,
                Name = "Joe Johnston",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 21,
                Name = "James Gunn",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 22,
                Name = "Peyton Reed",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 23,
                Name = "Jon Watts",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 24,
                Name = "Scott Derrickson",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 25,
                Name = "Ryan Coogler",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 26,
                Name = "Kenneth Branagh",
                Country = "Ireland",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            },
            new Director
            {
                Id = 27,
                Name = "Kevin Feige",
                Country = "USA",
                Gender = "Male",
                DateBirth = "",
                ShortDescription = ""
            }
            );
            #endregion

            base.OnModelCreating(modelBuilder);

        }
    }
}
