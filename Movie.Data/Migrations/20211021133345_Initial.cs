using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Movie.Data.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Actors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    DateBirth = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(maxLength: 1500, nullable: true),
                    Language = table.Column<string>(maxLength: 100, nullable: true),
                    Gender = table.Column<string>(maxLength: 100, nullable: true),
                    Popularity = table.Column<bool>(nullable: false),
                    PhotoURL = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Actors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Name = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    UserName = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(maxLength: 256, nullable: true),
                    Email = table.Column<string>(maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(nullable: false),
                    PasswordHash = table.Column<string>(nullable: true),
                    SecurityStamp = table.Column<string>(nullable: true),
                    ConcurrencyStamp = table.Column<string>(nullable: true),
                    PhoneNumber = table.Column<string>(nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(nullable: false),
                    TwoFactorEnabled = table.Column<bool>(nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(nullable: true),
                    LockoutEnabled = table.Column<bool>(nullable: false),
                    AccessFailedCount = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Category",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 50, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Category", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Directors",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    DateBirth = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Directors", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    MovieTitle = table.Column<string>(maxLength: 100, nullable: true),
                    MovieActor = table.Column<string>(maxLength: 100, nullable: true),
                    MovieCountry = table.Column<string>(maxLength: 100, nullable: true),
                    MoviePublisher = table.Column<string>(maxLength: 100, nullable: true),
                    MovieCategory = table.Column<string>(maxLength: 100, nullable: true),
                    MovieType = table.Column<string>(maxLength: 100, nullable: true),
                    Quantity = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    OrderDate = table.Column<DateTime>(nullable: false),
                    ShippedDate = table.Column<DateTime>(nullable: false),
                    DeliveryDate = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Publisher",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 100, nullable: true),
                    Year = table.Column<string>(maxLength: 50, nullable: true),
                    Gender = table.Column<string>(nullable: true),
                    ShortDescription = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Publisher", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ShoppingCart",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(nullable: false),
                    MovieId = table.Column<int>(nullable: false),
                    Price = table.Column<double>(nullable: false),
                    Discount = table.Column<double>(nullable: false),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingCart", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "WishLists",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: true),
                    MovieId = table.Column<int>(nullable: false),
                    ActorId = table.Column<int>(nullable: false),
                    CategoryId = table.Column<string>(nullable: true),
                    DateAdded = table.Column<DateTime>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WishLists", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(nullable: false),
                    ClaimType = table.Column<string>(nullable: true),
                    ClaimValue = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderKey = table.Column<string>(maxLength: 128, nullable: false),
                    ProviderDisplayName = table.Column<string>(nullable: true),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    RoleId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(nullable: false),
                    LoginProvider = table.Column<string>(maxLength: 128, nullable: false),
                    Name = table.Column<string>(maxLength: 128, nullable: false),
                    Value = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Movies",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(maxLength: 50, nullable: true),
                    ActorNames = table.Column<string>(nullable: true),
                    DirectorName = table.Column<string>(maxLength: 100, nullable: true),
                    DirectorId = table.Column<int>(nullable: false),
                    Categories = table.Column<string>(maxLength: 100, nullable: true),
                    PublisherId = table.Column<int>(nullable: false),
                    PublisherName = table.Column<string>(maxLength: 100, nullable: true),
                    Country = table.Column<string>(maxLength: 50, nullable: true),
                    Language = table.Column<string>(maxLength: 50, nullable: true),
                    WatchTime = table.Column<string>(nullable: true),
                    ReleaseDate = table.Column<string>(nullable: true),
                    CountryOfOrigin = table.Column<string>(maxLength: 50, nullable: true),
                    Rating = table.Column<double>(nullable: false),
                    ShortDescription = table.Column<string>(maxLength: 1500, nullable: true),
                    TrailerURL = table.Column<string>(maxLength: 100, nullable: true),
                    PhotoURL = table.Column<string>(nullable: true),
                    Popularity = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Movies", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Movies_Directors_DirectorId",
                        column: x => x.DirectorId,
                        principalTable: "Directors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Movies_Publisher_PublisherId",
                        column: x => x.PublisherId,
                        principalTable: "Publisher",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieActors",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false),
                    ActorID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieActors", x => new { x.MovieID, x.ActorID });
                    table.ForeignKey(
                        name: "FK_MovieActors_Actors_ActorID",
                        column: x => x.ActorID,
                        principalTable: "Actors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieActors_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MovieCategories",
                columns: table => new
                {
                    MovieID = table.Column<int>(nullable: false),
                    CategoryID = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieCategories", x => new { x.MovieID, x.CategoryID });
                    table.ForeignKey(
                        name: "FK_MovieCategories_Category_CategoryID",
                        column: x => x.CategoryID,
                        principalTable: "Category",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieCategories_Movies_MovieID",
                        column: x => x.MovieID,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Actors",
                columns: new[] { "Id", "Country", "DateBirth", "Gender", "Language", "Name", "PhotoURL", "Popularity", "ShortDescription" },
                values: new object[,]
                {
                    { 59, "Alcobendas, Madrid, Spain", "April 28, 1974", "Female", "Spain", "Penélope Cruz", "PenélopeCruzPhoto.jpg", true, "Known outside her native country as the \"Spanish enchantress\", Penélope Cruz Sánchez was born in Madrid to Eduardo Cruz, a retailer, and Encarna Sánchez, a hairdresser. As a toddler, she was already a compulsive performer, re-enacting TV commercials for her family's amusement, but she decided to focus her energies on dance. After studying classical ballet for nine years at Spain's National Conservatory, she continued her training under a series of prominent dancers." },
                    { 34, "Lisburn, Northern Ireland, UK", "May 25, 1964", "Male", "English", "Ray Stevenson", "RayStevensonPhoto.jpg", false, "Tall, dark, but somewhat gentle-looking actor Ray Stevenson was born in Lisburn, Northern Ireland on 25 May 1964, on a British army base. His father was a British pilot in the Royal Air Force, and his mother is Irish. He moved with his family to Lemington, Newcastle-Upon-Tyne, England in 1972 at the age of eight, and later to Cramlington, Northumberland, where he was raised." },
                    { 35, "Constanta, Romania", "August 13, 1982", "Male", "Romanian", "Sebastian Stan", "SebastianStanPhoto.jpg", false, "Sebastian Stan was born on August 13, 1982, in Constanta, Romania. He moved with his mother to Vienna, Austria, when he was eight, and then to New York when he was twelve. Stan studied at Rutgers Mason Gross School of the Arts and spent a year at Shakespeare's Globe Theatre in London." },
                    { 36, "London, England, UK", "April 5, 1982", "Female", "English", "Hayley Atwell", "HayleyAtwellPhoto.jpg", false, "Born in London, England, Hayley Elizabeth Atwell has dual citizenship of the United Kingdom and the United States. An only child, Hayley was named after actress Hayley Mills. Her parents, Alison (Cain) and Grant Atwell, both motivational speakers, met at a London workshop of Dale Carnegie's self-help bible \"How to Win Friends and Influence People\". Her mother is English (with Irish ancestry) and her father is American; he was born in Kansas City, Missouri, and is partly of Native-American descent (his Native American name is Star Touches Earth)." },
                    { 37, "San Saba, Texas, USA", "September 15, 1946", "Male", "English", "Tommy Lee Jones", "TommyLeeJonesPhoto.jpg", false, "Tommy Lee Jones was born in San Saba, Texas, the son of Lucille Marie (Scott), a police officer and beauty shop owner, and Clyde C. Jones, who worked on oil fields. Tommy himself worked in underwater construction and on an oil rig. He attended St. Mark's School of Texas, a prestigious prep school for boys in Dallas, on a scholarship, and went to Harvard on another scholarship. He roomed with future Vice President Al Gore and played offensive guard in the famous 29-29 Harvard-Yale football game of '68 known as \"The Tie.\" He received a B.A. in English literature and graduated cum laude from Harvard in 1969." },
                    { 38, "Fort Saskatchewan, Alberta, Canada", "August 3, 1979", "Female", "English", "Evangeline Lilly", "EvangelineLillyPhoto.jpg", false, "Evangeline Lilly, born in Fort Saskatchewan, Alberta, in 1979, was discovered on the streets of Kelowna, British Columbia, by the famous Ford modeling agency. Although she initially decided to pass on a modeling career, she went ahead and signed with Ford anyway, to help pay for her University of British Columbia tuition and expenses." },
                    { 39, "Virginia, Minnesota, USA", "June 21, 1979", "Female", "English", "Chris Pratt", "ChrisPrattPhoto.jpg", false, "Christopher Michael \"Chris\" Pratt was born on June 21, 1979 in Virginia, Minnesota and raised in Lake Stevens, Washington to Kathleen Louise Pratt (née Indahl), who worked at a supermarket & Daniel Clifton Pratt, who remodeled houses. He came to prominence for his small-screen roles, including Bright Abbott in Everwood (2002), Ché in The O.C. (2003), and Andy Dwyer and Parks and Recreation (2009), and notable film roles in Moneyball (2011), The Five-Year Engagement (2012), Zero Dark Thirty (2012), Delivery Man (2013), and Her (2013)." },
                    { 40, "Passaic, New Jersey, USA", "June 19, 1978", "Female", "English", "Zoe Saldana", "ZoeSaldanaPhoto.jpg", false, "Zoe Saldana was born on June 19, 1978 in Passaic, New Jersey, to Asalia Nazario and Aridio Saldaña. Her father was Dominican and her mother is Puerto Rican. She was raised in Queens, New York. When she was 10 years old, she and her family moved to the Dominican Republic, where they would live for the next seven years. While living there, Zoe discovered a keen interest in performance dance and began her training at the prestigious ECOS Espacio de Danza Dance Academy where she learned ballet as well as other dance forms." },
                    { 41, "Alameda County, California, USA", "July 18, 1967", "Male", "English", "Vin Diesel", "VinDieselPhoto.jpg", false, "Vin Diesel was born Mark Sinclair in Alameda County, California, along with his fraternal twin brother, Paul Vincent. He was raised by his astrologer/psychologist mother, Delora Sherleen (Sinclair), and adoptive father, Irving H. Vincent, an acting instructor and theatre manager, in an artists' housing project in New York City's Greenwich Village." },
                    { 42, "Washington, District of Columbia, USA", "January 18, 1969", "Male", "English", "Dave Bautista", "DaveBautistaPhoto.jpg", false, "When WCW officials told him he'd never make it in sports entertainment, Bautista pushed himself to achieve his dream of being a Superstar. In May 2002, he made his debut on SmackDown using the ring name Batista, but it wasn't until a move to Raw and two victories over Kane that \"The Animal\" began to make noise in the WWE Universe." },
                    { 43, "Springfield, Massachusetts, USA", "March 17, 1951", "Male", "English", "Kurt Russell", "KurtRussellPhoto.jpg", false, "Kurt Vogel Russell was born on March 17, 1951 in Springfield, Massachusetts, to Louise Julia Russell (née Crone), a dancer, and Bing Russell, an actor. He is of English, German, Scottish and Irish descent. His first roles were as a child on television series, including a lead role on the Western series The Travels of Jaimie McPheeters (1963). Russell landed a role in the Elvis Presley movie, It Happened at the World's Fair (1963), when he was eleven years old. Walt Disney himself signed Russell to a 10-year contract, and, according to Robert Osborne, he became the studio's top star of the 1970s." },
                    { 44, "Kingston upon Thames, England, UK", "June 1, 1996", "Male", "English", "Tom Holland", "TomHollandPhoto.jpg", false, "Thomas Stanley Holland was born in Kingston-upon-Thames, Surrey, to Nicola Elizabeth (Frost), a photographer, and Dominic Holland (Dominic Anthony Holland), who is a comedian and author. His paternal grandparents were from the Isle of Man and Ireland, respectively. He lives with his parents and three younger brothers - Paddy and twins Sam and Harry. Tom attended Donhead Prep School." },
                    { 45, "New Orleans, Louisiana, USA", "September 23, 1978", "Male", "English", "Anthony Mackie", "AnthonyMackiePhoto.jpg", false, "Anthony Mackie is an American actor. He was born in New Orleans, Louisiana, to Martha (Gordon) and Willie Mackie, Sr., who owned a business, Mackie Roofing. Anthony has been featured in feature films, television series and Broadway and Off-Broadway plays, including Ma Rainey's Black Bottom, Drowning Crow, McReele, A Soldier's Play, and Talk, by Carl Hancock Rux, for which he won an Obie Award in 2002. In 2002, he was featured in Eminem's debut film, 8 Mile, playing Papa Doc, a member of Leaders of the Free World." },
                    { 46, "Los Angeles, California, USA", "February 16, 1989", "Female", "English", "Elizabeth Olsen", "ElizabethOlsenPhoto.jpg", false, "Elizabeth Chase \"Lizzie\" Olsen (born February 16, 1989) is an American actress. She is known for her roles in the films Silent House (2011), Liberal Arts (2012), Godzilla (2014), Avengers: Age of Ultron (2015), and Captain America: Civil War (2016). For her role in the critically-acclaimed Martha Marcy May Marlene (2011), she was nominated for numerous awards, including the Independent Spirit Award for Best Female Lead." },
                    { 47, "Passaic, New Jersey, USA", "April 6, 1969", "Male", "English", "Paul Rudd", "PaulRuddPhoto.jpg", false, "Paul Stephen Rudd was born in Passaic, New Jersey. His parents, Michael and Gloria, both from Jewish families, were born in the London area, U.K. He has one sister, who is three years younger than he is. Paul traveled with his family during his early years, because of his father's airline job at TWA. His family eventually settled in Overland Park, Kansas, where his mother worked as a sales manager for TV station KSMO-TV. Paul attended Broadmoor Junior High and Shawnee Mission West High School, from which he graduated in 1987, and where he was Student Body President." },
                    { 48, "Hammersmith, London, England, UK", "July 19, 1976", "Male", "English", "Benedict Cumberbatch", "BenedictCumberbatchPhoto.jpg", false, "Benedict Timothy Carlton Cumberbatch was born and raised in London, England. His parents, Wanda Ventham and Timothy Carlton (born Timothy Carlton Congdon Cumberbatch), are both actors. He is a grandson of submarine commander Henry Carlton Cumberbatch, and a great-grandson of diplomat Henry Arnold Cumberbatch CMG." },
                    { 49, "Santa Ana, California, USA", "February 9, 1987", "Male", "English", "Michael B. Jordan", "MichaelJordanPhoto.jpg", false, "Michael B. Jordan, the middle of three children, was born in Santa Ana, California and raised in Newark, New Jersey. He is the son of Donna (Davis), a high school counselor, and Michael A. Jordan. His middle name, Bakari, means \"noble promise\" in Swahili. (He is not related to, or named after, basketball legend Michael Jordan.)" },
                    { 50, "Anderson, South Carolina, USA", "November 29, 1976", "Male", "English", "Chadwick Boseman", "ChadwickBosemanPhoto.jpg", false, "Chadwick Boseman was an American actor. He is known for his portrayal of T'Challa / Black Panther in the Marvel Cinematic Universe from 2016 to 2019, particularly in Black Panther (2018), and for his starring roles as several pioneering Americans, Jackie Robinson in 42 (2013), James Brown in Get on Up (2014), and Thurgood Marshall in Marshall (2017)." },
                    { 64, "Lajas, Puerto Rico", "March 15, 1974", "Male", "Spanish, English", "Renoly Santiago", "RenolySantiagoPhoto.jpg", false, "Renoly Santiago was born in Lajas, Puerto Rico and he spent his childhood in Union City, New Jersey. Before establishing himself as an accomplished entertainer, Renoly started singing, acting, dancing and writing early on, following his calling while very young; earning a dance scholarship to the Ballet Hispanico." },
                    { 63, "Bronx, NYC", "Don't know", "Male", "English", "Laurence Mason", "LaurenceMasonPhoto.jpg", false, "Laurence Mason, is an American actor born in the Bronx, NYC to hard working Caribbean couple who wanted more for their son. He made his break into the world of the arts at age 10 after being recruited by The First All Children's Theatre." },
                    { 62, "Lansing, Michigan, USA", "January 24, 1970", "Male", "English", "Matthew Lillard", "MatthewLillardPhoto.jpg", false, "Matthew Lillard was born in Lansing, Michigan, to Paula and Jeffrey Lillard. He lived with his family in Tustin, California, from first grade to high school graduation. The summer after high school, he was hired as an extra for Ghoulies Go to College (1990)." },
                    { 61, "Norwalk, Connecticut, USA", "May 28, 1979", "Male", "English", "Jesse Bradford", "JesseBradfordPhoto.jpg", false, "Jesse Bradford was born Jesse Bradford Watrouse in Norwalk, Connecticut. Both of his parents, Curtis Watrouse and Terry Porter, are actors who have appeared in many television commercials. Jesse has been acting almost constantly since his big debut in a Q-Tip commercial when he was an 8-month-old baby." },
                    { 60, "Kingston upon Thames, Surrey,England,UK", "November 15, 1972", "Male", "English", "Jonny Lee Miller", "JonnyLeeMillerPhoto.jpg", false, "Jonny (sometimes credited as Johnny) Lee Miller was born on November 15, 1972, in Kingston, England, UK. He is the son of actors Anna Lee and Alan Miller and the grandson of actor Bernard Lee." },
                    { 67, "Reading, Berkshire, England, UK", "October 5, 1975", "Female", "English", "Kate Winslet", "KateWinsletPhoto.jpg", false, "Ask Kate Winslet what she likes about any of her characters, and the word \"ballsy\" is bound to pop up at least once. The British actress has made a point of eschewing straightforward pretty-girl parts in favor of more devilish damsels; as a result, she's built an eclectic resume that runs the gamut from Shakespearean tragedy to modern-day" },
                    { 33, "Columbia, South Carolina, USA", "March 12, 1984", "Female", "English", "Jaimie Alexander", "JaimieAlexanderPhoto.jpg", false, "Jaimie Alexander was born in Greenville, South Carolina, but moved with her family to Grapevine, Texas, when she was four years old. She took theatre classes in grade school as a hobby but was kicked out in high school because she could not sing, and so she took up sports instead. At age 17 she substituted for a friend at a meeting with a scouting agency and she met her manager, Randy James, who sent her some scripts. After graduating from high school she moved to Los Angeles, California, to pursue acting." },
                    { 58, "Berlin, Germany", "February 10, 1982", "Male", "German", "Tom Schilling", "TomSchillingPhoto.jpeg", false, "Tom Schilling was born on February 10, 1982 in Berlin, Germany. He is an actor, known for A Coffee in Berlin (2012), Before the Fall (2004) and Who Am I (2014)." },
                    { 56, "Los Angeles, California, USA", "June 4, 1975", "Female", "English", "Angelina Jolie", "AngelinaJoliePhoto.jpg", true, "Angelina Jolie is an Academy Award-winning actress who rose to fame after her role in Girl, Interrupted (1999), playing the title role in the \"Lara Croft\" blockbuster movies, as well as Mr. & Mrs. Smith (2005), Wanted (2008), Salt (2010) and Maleficent (2014). Off-screen, Jolie has become prominently involved in international charity projects,." },
                    { 55, "Thal, Styria, Austria", "July 30, 1947", "Male", "English", "Arnold Schwarcneger", "ArnoldSchwarcnegerPhoto.jpg", false, "With an almost unpronounceable surname and a thick Austrian accent, who would have ever believed that a brash, quick talking bodybuilder from a small European village would become one of Hollywood's biggest stars, marry into the prestigious Kennedy family, amass a fortune via shrewd investments and one day be the Governor of California!" },
                    { 54, "Syracuse, New York, USA", "July 3, 1962", "Male", "English", "Tom Cruse", "TomCrusePhoto.jpg", false, "In 1976, if you had told fourteen-year-old Franciscan seminary student Thomas Cruise Mapother IV that one day in the not too distant future he would be Tom Cruise, one of the top 100 movie stars of all time, he would have probably grinned and told you that his ambition was to join the priesthood. Nonetheless, this sensitive, deeply religious youngster who was born in 1962 in Syracuse, New York, was destined to become one of the highest paid and most sought after actors in screen history." },
                    { 53, "Los Angeles, California", "November 11, 1974", "Male", "English", "Leonardo Di Caprio", "LeonardoDiCaprioPhoto.jfif", true, "Few actors in the world have had a career quite as diverse as Leonardo DiCaprio's. DiCaprio has gone from relatively humble beginnings, as a supporting cast member of the sitcom Growing Pains (1985) and low budget horror movies." },
                    { 52, "New York City", "July 6, 1946", "Male", "English", "Sylvester Stallone", "SylvesterStallonePhoto.jpg", false, "Sylvester Stallone is a athletically built, dark-haired American actor/screenwriter/director/producer, the movie fans worldwide have been flocking to see Stallone's films for over 40 years, making \"Sly\" one of Hollywood's biggest-ever box office draws." },
                    { 51, "Los Angeles, California, USA", "December 19, 1980", "Male", "English", "Jake Gyllenhaal", "JakeGyllenhaalPhoto.jpg", false, "Jacob Benjamin Gyllenhaal was born in Los Angeles, California, to producer/screenwriter Naomi Foner (née Achs) and director Stephen Gyllenhaal. He is the brother of actress Maggie Gyllenhaal, who played his sister in Donnie Darko (2001). His godmother is actress Jamie Lee Curtis. His mother is from a Jewish family, and his father's ancestry includes Swedish, English and Swiss-German." },
                    { 57, "New York City, New York, USA", "October 5, 1983", "Male", "English", "Jesse Eisenberg", "JesseEisenbergPhoto.jpg", false, "Curly haired and with a fast-talking voice, Jesse Eisenberg is a movie actor, known for his Academy Award nominated role as Mark Zuckerberg in the 2010 film The Social Network. He has also starred in the films The Squid and the Whale, Adventureland, The Education of Charlie Banks, 30 Minutes or Less, Now You See Me and Zombieland." },
                    { 32, "Margam, Port Talbot, West Glamorgan, Wales, UK", "December 31, 1937", "Male", "English", "Anthony Hopkins", "AnthonyHopkinsPhoto.jfif", false, "Anthony Hopkins was born on December 31, 1937, in Margam, Wales, to Muriel Anne (Yeats) and Richard Arthur Hopkins, a baker. His parents were both of half Welsh and half English descent. Influenced by Richard Burton, he decided to study at College of Music and Drama and graduated in 1957. In 1965, he moved to London and joined the National Theatre, invited by Laurence Olivier, who could see the talent in Hopkins. In 1967, he made his first film for television, A Flea in Her Ear (1967)." },
                    { 31, "Philadelphia, Pennsylvania, USA", "June 13, 1986", "Female", "English", "Kat Dennings", "KatDenningsPhoto.jfif", false, "Kat Dennings was born Katherine Victoria Litwack in Bryn Mawr, Pennsylvania, near Philadelphia, to Ellen (Schatz), a speech therapist and poet, and Gerald Litwack, a molecular pharmacologist. She is the youngest of five children. Her family is of Russian Jewish descent. Kat was predominantly home-schooled, graduating at the age of fourteen. Her family subsequently moved to Los Angeles, California to support Kat acting full-time." },
                    { 30, "Yokohama, Japan", "November 27, 1973", "Male", "Japanese", "Tadanobu Asano", "TadanobuAsanoPhoto.jfif", false, "Tadanobu Asano's a Japanese film actor. His father suggested he take on what became his first role in the TV show \"Kimpachi Sensei,\" at 16. His film debut was in the 1990 Swimming Upstream (Swimming Upstream (1990)), though his first major critical success was in Shunji Iwai's Fried Dragon Fish (1993). His first critical success in the West was in Hirokazu Koreeda's Maborosi (1995), in which he played a man who inexplicably throws himself in front of a train, widowing his wife and orphaning his infant son." },
                    { 11, "Washington, District of Columbia, USA", "December 21, 1948", "Male", "English", "Samuel L. Jackson", "SamuelJacksonPhoto.jpg", false, "Samuel L. Jackson is an American producer and highly prolific actor, having appeared in over 100 films, including Die Hard with a Vengeance (1995), Unbreakable (2000), Shaft (2000), Formula 51 (2001), Black Snake Moan (2006), Snakes on a Plane (2006), and the Star Wars prequel trilogy (1999-2005), as well as the Marvel Cinematic Universe." },
                    { 10, "Gothenburg, Västra Götalands län, Sweden", "June 13, 1951", "Male", "Swedish,English", "Stellan John Skarsgard", "StellanJohnSkarsgardPhoto.jpg", false, "Stellan Skarsgård was born in Gothenburg, Västra Götalands län, Sweden, to Gudrun (Larsson) and Jan Skarsgård. He became a star in his teens through the title role in the TV-series Bombi Bitt och jag (1968). Between the years 1972-88 he was employed at The Royal Dramatic Theatre in Stockholm, where he participated in \"Vita rum\" (1988), August Strindberg's \"Ett drömspel\" (1986) and \"Mäster Olof\" (1988)." },
                    { 9, "Vancouver, British Columbia, Canada", "April 3, 1982", "Female", "English", "Cobie Smulders", "CobieSmuldersPhoto.jpg", false, "Cobie Smulders was born on April 3, 1982, in Vancouver, British Columbia, to a Dutch father and an English mother. As a girl, Cobie had set her sights on becoming a doctor or a marine biologist. In fact, it wasn't until high school that Cobie started to explore acting after appearing in several school productions. As a teenager, Cobie caught the eye of a modeling agency, which led to several years of world travel to places such as France, Japan, Italy, Greece, and Germany. Yet even as Cobie's modeling career was on the rise, she still managed to attend school, graduating from high school in 2000 with honors." },
                    { 8, "Boston, Massachusetts, USA", "April 2, 1962", "Male", "English", "Robert Clark Gregg", "RobertClarkGreggPhoto.jfif", false, "Clark Gregg was born on April 2, 1962 in Boston, Massachusetts, USA as Robert Clark Gregg. He is an actor and director, known for The Avengers (2012), Agents of S.H.I.E.L.D. (2013) and The New Adventures of Old Christine (2006)." },
                    { 7, "Westminster, London, England, UK", "February 9, 1981", "Male", "English", "Tom Hiddleston", "TomHiddlestonPhoto.jpg", false, "Thomas William Hiddleston was born in Westminster, London, to English-born Diana Patricia (Servaes) and Scottish-born James Norman Hiddleston. His mother is a former stage manager, and his father, a scientist, was the managing director of a pharmaceutical company. He started off at the preparatory school, The Dragon School in Oxford, and by the time he was 13, he boarded at Eton College, at the same time that his parents were going through a divorce. He continued on to the University of Cambridge, where he earned a double first in Classics. He continued to study acting at the Royal Academy of Dramatic Art, from which he graduated in 2005." },
                    { 6, "Modesto, California, USA", "January 7, 1971", "Male", "English", "Jeremy Lee Renner", "JeremyLeeRennerPhoto.jpg", false, "Jeremy Lee Renner was born in Modesto, California, the son of Valerie (Tague) and Lee Renner, who managed a bowling alley. After a tumultuous yet happy childhood with his four younger siblings, Renner graduated from Beyer High School and attended Modesto Junior College. He explored several areas of study, including computer science, criminology, and psychology, before the theater department, with its freedom of emotional expression, drew him in." },
                    { 12, "Inverness, Scotland, UK", "November 28, 1987", "Female", "English", "Karen Gillan", "KarenGillanPhoto.jpg", false, "Karen Sheila Gillan was born and raised in Inverness, Scotland, as the only child of Marie Paterson and husband John Gillan, who is a singer and recording artist. She developed a love for acting very early on, attending several youth theatre groups and taking part in a wide range of productions at her school, Charleston Academy." },
                    { 5, "Kenosha, Wisconsin, USA", "November 22, 1967", "Male", "English", "Mark Ruffalo", "MarkRuffaloPhoto.jpg", false, "Award-winning actor Mark Ruffalo was born on November 22, 1967, in Kenosha, Wisconsin, of humble means to father Frank Lawrence Ruffalo, a construction painter and Marie Rose (Hebert), a stylist and hairdresser; his father's ancestry is Italian and his mother is of half French-Canadian and half Italian descent. Mark moved with his family to Virginia Beach, Virginia, where he lived out most of his teenage years. Following high school, Mark moved with his family to San Diego and soon migrated north, eventually settling in Los Angeles." },
                    { 3, "Boston, Massachusetts, USA", "June 13, 1981", "Male", "English", "Chris Evans", "ChrisEvansPhoto.jpg", false, "Christopher Robert Evans began his acting career in typical fashion: performing in school productions and community theatre. He was born in Boston, Massachusetts, the son of Lisa (Capuano), who worked at the Concord Youth Theatre, and G. Robert Evans III, a dentist. His uncle is former U.S. Representative Mike Capuano. " },
                    { 2, "Manhattan, New York City, New York, USA", "April 4, 1965", "Male", "English", "Robert Downey Jr.", "RobertDowneyJrPhoto.jpg", false, "Downey was born April 4, 1965 in Manhattan, New York, the son of writer, director and filmographer Robert Downey Sr. and actress Elsie Downey (née Elsie Ann Ford). Robert's father is of half Lithuanian Jewish, one quarter Hungarian Jewish, and one quarter Irish, descent, while Robert's mother was of English, Scottish, German, and Swiss-German ancestry." },
                    { 1, "Melbourne, Victoria, Australia", "August 11, 1983", "Male", "English,", "Chris Hemsworth", "ChrisHemsworthPhoto.jpg", false, "Christopher Hemsworth was born on August 11, 1983 in Melbourne, Victoria, Australia to Leonie Hemsworth (née van Os), an English teacher & Craig Hemsworth, a social-services counselor. His brothers are actors, Liam Hemsworth & Luke Hemsworth; he is of Dutch (from his immigrant maternal grandfather), Irish, English, Scottish, and German ancestry. His uncle, by marriage, was Rod Ansell, the bushman who inspired the comedy film Crocodile Dundee (1986)." },
                    { 68, "Chicago, Illinois, USA", "February 24, 1966", "Male", "English", "Billy Zane", "BillyZanePhoto.jpg", false, "William George Zane, better known as Billy Zane, was born on February 24, 1966 in Chicago, Illinois, to Thalia (Colovos) and William Zane, both of Greek ancestry. His parents were amateur actors and managed a medical technical school. Billy has an older sister, actress and singer Lisa Zane. Billy was bitten by the acting bug early on." },
                    { 69, "West Covina, California, USA", "October 16, 1958", "Male", "English", "Tim Robbins", "https://m.media-amazon.com/images/M/MV5BMTI1OTYxNzAxOF5BMl5BanBnXkFtZTYwNTE5ODI4._V1_UY1200_CR151,0,630,1200_AL_.jpg", false, "Born in West Covina, California, but raised in New York City, Tim Robbins is the son of former The Highwaymen singer Gil Robbins and actress Mary Robbins (née Bledsoe). Robbins studied drama at UCLA, where he graduated with honors in 1981." },
                    { 70, "Newport Beach, California, USA", "July 9, 1957", "Male", "English", "Kelly McGillis", "https://m.media-amazon.com/images/M/MV5BMjA0OTg5ODY3Ml5BMl5BanBnXkFtZTgwNzkxOTU3MDI@._V1_.jpg", false, "Kelly Ann McGillis was born in Newport Beach, California, to Virginia Joan (Snell), a homemaker, and Donald Manson McGillis, a general practitioner of medicine. She has English, Welsh, Scots-Irish, and German ancestry." },
                    { 4, "Manhattan, New York City, New York, USA", "November 22, 1984", "Female", "English", "Scarlett Johansson", "ScarlettJohanssonPhoto.jpg", false, "Scarlett Ingrid Johansson was born on November 22, 1984 in Manhattan, New York City, New York. Her mother, Melanie Sloan is from a Jewish family from the Bronx and her father, Karsten Johansson is a Danish-born architect from Copenhagen. She has a sister, Vanessa Johansson, who is also an actress, a brother, Adrian, a twin brother, Hunter Johansson, born three minutes after her, and a paternal half-brother, Christian. Her grandfather was writer Ejner Johansson." },
                    { 65, "Pittsburgh, Pennsylvania, USA", "May 1, 1972", "Female", "English", "Julie Benz", "JulieBenzPhoto.jpg", false, "Julie Benz was born in Pittsburgh, Pennsylvania, USA on May 1, 1972. Julie's father is a Pittsburgh surgeon and her mother is a figure skater. The family settled in nearby Murrysville, when Julie was two, and she started ice skating at age three." },
                    { 13, "Sacramento, California, USA", "October 1, 1989", "Female", "English", "Brie Larson", "BrieLarsonPhoto.jpg", false, "Brie Larson has built an impressive career as an acclaimed television actress, rising feature film star and emerging recording artist. A native of Sacramento, Brie started studying drama at the early age of 6, as the youngest student ever to attend the American Conservatory Theater in San Francisco. She starred in one of Disney Channel's most watched original movies, Right on Track (2003), as well as the WB's Raising Dad (2001) and MGM's teen comedy Sleepover (2004) - all before graduating from middle school." },
                    { 15, "Philadelphia, Pennsylvania, USA", "January 5, 1975", "Male", "English", "Bradley Cooper", "BradleyCooperPhoto.jpg", false, "Bradley Charles Cooper was born on January 5, 1975 in Philadelphia, Pennsylvania. His mother, Gloria (Campano), is of Italian descent, and worked for a local NBC station. His father, Charles John Cooper, who was of Irish descent, was a stockbroker. Immediately after Bradley graduated from the Honors English program at Georgetown University in 1997, he moved to New York City to enroll in the Masters of Fine Arts program at the Actors Studio Drama School at New School University. There, he developed his stage work, culminating with his thesis performance as John Merrick in Bernard Pomerance's \"The Elephant Man\", performed in New York's Circle in the Square." },
                    { 29, "Hackney, London, England, UK", "September 6, 1972", "Male", "English", "Idris Elba", "IdrisElbaPhoto.jpg", false, "An only child, Idrissa Akuna Elba was born and raised in London, England. His father, Winston, is from Sierra Leone and worked at Ford Dagenham; his mother, Eve, is from Ghana and had a clerical duty. Idris attended school in Canning Town, where he first became involved in acting, before he dropped out. He gained a place in the National Youth Music Theatre - thanks to a £1,500 Prince's Trust grant." },
                    { 28, "Burbank, California, USA", "February 17, 1954", "Female", "English", "Rene Russo", "ReneRussoPhoto.jpg", false, "Rene Russo was born in Burbank, California, to Shirley (Balocca), a barmaid and factory laborer, and Nino Russo. Her father, a sculptor and mechanic, left the family when Rene was just two, and thus her mother raised Rene and her sister, Toni, as a single mom. Her father was of Italian descent, and her mother was of Italian and German-English-Irish ancestry." },
                    { 27, "Jerusalem, Israel", "June 9, 1981", "Female", "Hebrew", "Natalie Portman", "NataliePortmanPhoto.jpg", false, "Natalie was born Natalie Hershlag on June 9, 1981, in Jerusalem, Israel. She is the only child of Avner Hershlag, a Israeli-born doctor, and Shelley Stevens, an American-born artist (from Cincinnati, Ohio), who also acts as Natalie's agent. Her parents are both of Ashkenazi Jewish descent. Natalie's family left Israel for Washington, D.C., when she was still very young. After a few more moves, her family finally settled in New York, where she still lives to this day. She graduated with honors, and her academic achievements allowed her to attend Harvard University. She was discovered by an agent in a pizza parlor at the age of 11. " },
                    { 26, "Schenectady, New York, USA", "September 16, 1952", "Male", "English", "Mickey Rourke", "MickeyRourkePhoto.jpg", false, "Mickey Rourke was born Phillip Andre Rourke, Jr. on September 16, 1952, in Schenectady, New York, the son of Annette (Cameron) and Phillip Andre Rourke. His father was of Irish and German descent, and his mother was of French-Canadian, English, and German ancestry. When he was six years old, his parents divorced." },
                    { 25, "New York City, New York, USA", "July 1, 1977", "Male", "English", "Liv Tyler", "LivTylerPhoto.jpg", false, "Liv Tyler is an actress of international renown and has been a familiar face on our screens for over two decades and counting. She began modelling at the age of fourteen before pursuing a career in acting. After making her film debut in Bruce Beresford's Silent Fall, she was cast by fledgling director James Mangold (who would go on to direct such hits as Girl, Interrupted, Walk the Line and Logan) in his first feature Heavy, a critical and commercial success that went on to gain cult status. This was followed by another indie cult hit, Empire Records, but it was the leading role in Bernardo Bertolucci's Stealing Beauty that catapulted her to stardom at the age of eighteen." },
                    { 24, "Dulwich, London, England, UK", "May 14, 1961", "Male", "English", "Tim Roth", "TimRothPhoto.jpg", false, "Often mistaken for an American because of his skill at imitating accents, actor Tim Roth was born Timothy Simon Roth on May 14, 1961 in Lambeth, London, England. His mother, Ann, was a teacher and landscape painter. His father, Ernie, was a journalist who had changed the family name from \"Smith\" to \"Roth\"; Ernie was born in Brooklyn, New York, to an immigrant family of Irish ancestry." },
                    { 14, "Queens, New York City, New York, USA", "October 19, 1966", "Male", "English", "Jon Favreau", "JonFavreauPhoto.jpg", false, "The amiable, husky-framed actor with the tight, crinkly hair was born in Queens, New York on October 19, 1966, the only child of Madeleine (Balkoff), an elementary school teacher, and Charles Favreau, a special education teacher. His father has French-Canadian, German, and Italian ancestry, and his mother was from a Russian Jewish family. He attended the Bronx High School of Science before furthering his studies at Queens College in 1984. Dropping out just credits away from receiving his degree, Jon moved to Chicago where he focused on comedy and performed at several Chicago improvisational theaters, including the ImprovOlympic and the Improv Institute. He also found a couple of bit parts in films." },
                    { 23, "Boston, Massachusetts, USA", "August 18, 1969", "Male", "English", "Edward Norton", "EdwardNortonPhoto.jpg", false, "American actor, filmmaker and activist Edward Harrison Norton was born on August 18, 1969, in Boston, Massachusetts, and was raised in Columbia, Maryland.His mother,Lydia Robinson \"Robin\"(Rouse),was a foundation executive and teacher of English,and a daughter of famed real estate developer James Rouse,who developed Columbia,MD; she passed away of brain cancer on March 6, 1997.His father, Edward Mower Norton, Jr., was an environmental lawyer and conservationist, who works for the National Trust for Historic Preservation. Edward has two younger siblings, James and Molly." },
                    { 21, "Los Angeles, California, USA", "December 4, 1949", "Male", "English", "Jeff Bridges", "JeffBridgesPhoto.jpg", false, "Jeffrey Leon Bridges was born on December 4, 1949 in Los Angeles, California, the son of well-known film and TV star Lloyd Bridges and his long-time wife Dorothy Dean Bridges (née Simpson). He grew up amid the happening Hollywood scene with big brother Beau Bridges. Both boys popped up, without billing, alongside their mother in the film The Company She Keeps (1951), and appeared on occasion with their famous dad on his popular underwater TV series Sea Hunt (1958) while growing up." },
                    { 20, "Chicago, Illinois, USA", "March 11, 1969", "Male", "English", "Terrence Howard", "TerrenceHowardPhoto.jfif", false, "Terrence Howard was born in Chicago, Illinois, to Anita Jeanine Williams (née Hawkins) and Tyrone Howard. He was raised in Cleveland, Ohio. His love for acting came naturally, through summers spent with his great-grandmother, New York stage actress Minnie Gentry. He later began his acting career after being discovered on a New York City street by a casting director. Soon, he followed with several notable TV appearances on shows such as Living Single (1993), NYPD Blue (1993) and Soul Food (2000). He became well known for his lead role in the UPN TV series Sparks (1996)." },
                    { 19, "Los Angeles, California, USA", "September 27, 1972", "Female", "English", "Gwyneth Paltrow", "GwynethPaltrowPhoto.jpg", false, "A tall, wafer thin, delicate beauty, Gwyneth Kate Paltrow was born in Los Angeles, the daughter of noted producer and director Bruce Paltrow and Tony Award-winning actress Blythe Danner. Her father was from a Jewish family, while her mother is of mostly German descent. When Gwyneth was eleven, the family moved to Massachusetts, where her father began working in summer stock productions in the Berkshires." },
                    { 18, "Harlesden, London, England, UK", "May 27, 1971", "Male", "English", "Paul Bettany", "PaulBettanyPhoto.jpg", false, "Paul Bettany is an English actor. He first came to the attention of mainstream audiences when he appeared in the British film Gangster No. 1 (2000), and director Brian Helgeland's film A Knight's Tale (2001). He has gone on to appear in a wide variety of films, including A Beautiful Mind (2001), Master and Commander: The Far Side of the World (2003), Dogville (2003), Wimbledon (2004), and the adaptation of the novel The Da Vinci Code (2006). He is also known for his voice role as J.A.R.V.I.S. in the Marvel Cinematic Universe, specifically the films Iron Man (2008), Iron Man 2 (2010), The Avengers (2012), Iron Man 3 (2013), and Avengers: Age of Ultron (2015), in which he also portrayed the Vision, for which he garnered praise. He reprised his role as the Vision in Captain America: Civil War (2016)." },
                    { 17, "Boston, Massachusetts, USA", "April 2, 1962", "Male", "English", "Clark Gregg", "ClarkGreggPhoto.jpg", false, "Clark Gregg was born on April 2, 1962 in Boston, Massachusetts, USA as Robert Clark Gregg. He is an actor and director, known for The Avengers (2012), Agents of S.H.I.E.L.D. (2013) and The New Adventures of Old Christine (2006)." },
                    { 16, "Santa Monica, California, USA", "February 12, 1968", "Male", "English", "Josh Brolin", "JoshBrolinPhoto.jpg", false, "Brolin was born February 12, 1968 in Santa Monica, California, to Jane Cameron (Agee), a Texas-born wildlife activist, and James Brolin. Josh was not interested at first in the lifestyle of the entertainment business, in light of his parents' divorce, and both of them being actors. However, during junior year in high school, he took an acting class to see what it was like. He played Stanley in \"A Streetcar Named Desire\" and became hooked. His first major screen role was as the older brother in the film The Goonies (1985), based on a story by Steven Spielberg. He then immediately moved on to work on television, taking roles on such series as Private Eye: Pilot (1987) and The Young Riders (1989). \"Private Eye\" was a chance for Brolin to play a detective. \"The Young Riders\" was set just before the Civil War, and was co-directed by Brolin's father, James Brolin." },
                    { 22, "Kansas City, Missouri, USA", "November 29, 1964", "Male", "English", "Don Cheadle", "DonCheadlePhoto.jpg", false, "Donald Frank Cheadle was born in Kansas City, Missouri, on November 29, 1964. His childhood found him moving from city to city with his family: mother Bettye (née North), a teacher; father Donald Frank Cheadle Sr., a clinical psychologist; sister Cindy; and brother Colin." },
                    { 66, "West Bromwich, West Midlands, England, UK", "March 3, 1973", "Male", "English", "Matthew Marsden", "MatthewMarsdenPhoto.jpg", false, "British actor/singer/Producer Matthew Marsden began his acting career in the UK and rose to stardom from his role on the long-running ITV series Coronation Street (1960), as Chris Collins. He left the show to pursue a music and acting career in the US and hasn't looked back since." }
                });

            migrationBuilder.InsertData(
                table: "AspNetRoles",
                columns: new[] { "Id", "ConcurrencyStamp", "Name", "NormalizedName" },
                values: new object[,]
                {
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "169800ac-0e27-4e4b-841b-6c3b82cee398", "admin", "ADMIN" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e75", "8e68b5c1-59c2-493d-b6dd-f9044471e274", "guest", "GUEST" },
                    { "b4280b6a-0613-4cbd-a9e6-f1701e926e74", "67683133-148b-4266-b85f-cb2bb9689b20", "editor", "EDITOR" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUsers",
                columns: new[] { "Id", "AccessFailedCount", "ConcurrencyStamp", "Email", "EmailConfirmed", "LockoutEnabled", "LockoutEnd", "NormalizedEmail", "NormalizedUserName", "PasswordHash", "PhoneNumber", "PhoneNumberConfirmed", "SecurityStamp", "TwoFactorEnabled", "UserName" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", 0, "c8554266-b401-4519-9aeb-a9283053fc58", "Test@test.com", true, false, null, "TEST@TEst.COM", "Test@TEST.COM", "AQAAAAEAACcQAAAAEPCwIu6j3fiIyBQK90UvPpfVOFDwgw5oapZv1yNl1uM45NflzD4GGgKKd+JSTs2bjg==", null, false, "", false, "Test@test.com" });

            migrationBuilder.InsertData(
                table: "Category",
                columns: new[] { "ID", "Name" },
                values: new object[,]
                {
                    { 14, "Uncategorised" },
                    { 13, "Mystery" },
                    { 11, "Sci-Fi" },
                    { 10, "Comedy" },
                    { 9, "Horror" },
                    { 8, "General" },
                    { 12, "Biography" },
                    { 6, "Fantasy" },
                    { 5, "Drama" },
                    { 4, "Adventure" },
                    { 3, "Crime" },
                    { 2, "Action" },
                    { 1, "Fiction" },
                    { 7, "Thriller" }
                });

            migrationBuilder.InsertData(
                table: "Directors",
                columns: new[] { "Id", "Country", "DateBirth", "Gender", "Name", "ShortDescription" },
                values: new object[,]
                {
                    { 17, "USA", "", "Male", "Taika Waititi", "" },
                    { 18, "USA", "", "Male", "Alan Taylor", "" },
                    { 19, "USA", "", "Male", "Joss Whedon", "" },
                    { 20, "USA", "", "Male", "Joe Johnston", "" },
                    { 21, "USA", "", "Male", "James Gunn", "" },
                    { 25, "USA", "", "Male", "Ryan Coogler", "" },
                    { 23, "USA", "", "Male", "Jon Watts", "" },
                    { 24, "USA", "", "Male", "Scott Derrickson", "" },
                    { 26, "Ireland", "", "Male", "Kenneth Branagh", "" },
                    { 27, "USA", "", "Male", "Kevin Feige", "" },
                    { 16, "USA", "", "Male", "Louis Leterrier", "" },
                    { 22, "USA", "", "Male", "Peyton Reed", "" },
                    { 15, "USA", "", "Male", "Shane Black", "" },
                    { 10, "London, England, UK", "July 30, 1970", null, "Christopher Nolan", null },
                    { 13, "USA", "", "Female", "Anna Boden", "" },
                    { 1, "Belfast, Northern Ireland, UK", "December 10, 1960", null, "Kenneth Branagh", null },
                    { 14, "USA", "", "Male", "Jon Favreau", "" },
                    { 3, "Kapusaksing, Ontario, Canada", "August 16, 1954", null, "James Cameron", null },
                    { 4, "North Shields, Northumberland, England, UK", "June 21, 1944", null, "Tony Scott", null },
                    { 5, "Ireland", "2012", null, "Pixar", null },
                    { 6, "London, England, UK", "1958", null, "Iain Softley", null },
                    { 2, "USA", "July 6, 1946", null, "Sylvester Stallone", null },
                    { 8, "Bergen, Norway", "May 19, 1967", null, "Morten Tyldum", null },
                    { 9, "Olten, Switzerland", "April 18, 1978", null, "Baran bo Odar", null },
                    { 11, "USA", "", "Male", "Joe Russo", "" },
                    { 12, "USA", "", "Male", "Anthony Russo", "" },
                    { 7, "Denver, Colorado, USA", "August 28, 1962", null, "David Fincher", null }
                });

            migrationBuilder.InsertData(
                table: "Publisher",
                columns: new[] { "Id", "Country", "Gender", "Name", "ShortDescription", "Year" },
                values: new object[,]
                {
                    { 10, "USA", null, "Legendary Entertainment", null, "2000" },
                    { 1, "USA", null, "20th Century Fox", null, "1935" },
                    { 2, "Vancouver, British Columbia", null, "Lionsgate", null, "July 10, 1997" },
                    { 4, "USA", null, "Paramount Pictures", null, "1916" },
                    { 5, "Not known", null, "Cinema '84", null, "Not known" },
                    { 6, "USA", null, "United Artists", null, "1919" },
                    { 7, "USA", null, "Columbia Pictures", null, "1974" },
                    { 8, "Santa Monica, California", null, "Black Bear Pictures", null, "2011" },
                    { 9, "Germany", null, "Wiedemann & Berg Film Production", null, "2003" },
                    { 11, "USA", null, "Marvel Studios", null, "1996" }
                });

            migrationBuilder.InsertData(
                table: "AspNetUserRoles",
                columns: new[] { "UserId", "RoleId" },
                values: new object[] { "b4280b6a-0613-4cbd-a9e6-f1701e926e73", "b4280b6a-0613-4cbd-a9e6-f1701e926e73" });

            migrationBuilder.InsertData(
                table: "Movies",
                columns: new[] { "Id", "ActorNames", "Categories", "Country", "CountryOfOrigin", "DirectorId", "DirectorName", "Language", "PhotoURL", "Popularity", "PublisherId", "PublisherName", "Rating", "ReleaseDate", "ShortDescription", "Title", "TrailerURL", "WatchTime" },
                values: new object[,]
                {
                    { 30, "Chris Hemsworth,Mark Ruffalo,Scarlet Johannson,Karen Gillan,Robert Downey Jr.,Samuel L. Jackson,Jeremy Lee Renner,Tom Hiddleston,Chris Evans,Brie Larson,Josh Brolin,Chadwick Boseman,Elizabeth Olsen,Chris Pratt,Zoe Saldana,Benedict Cumberbatch,Paul Bettany,Anthony Mackie,Sebastian Bach,Vin Diesel,Tom Holland", "Action, Adventure, Sci-Fi", "USA", null, 3, "Anthony Russo", "English", "AvengersInfinityWar.jpg", false, 11, "Marvel Studios", 8.4000000000000004, "April 27, 2018", "The Avengers and their allies must be willing to sacrifice all in an attempt to defeat the powerful Thanos before his blitz of devastation and ruin puts an end to the universe.", "Avengers: Infinity War", null, "149min" },
                    { 29, "Chris Hemsworth,Idris Elba,Anthony Hopkins,Ray Stevenson,Tadanobu Asano,Tom Hiddleston", "Action, Adventure, Comedy", "USA", null, 8, "Taika Waititi", "English", "ThorRagnarok.jpg", false, 11, "Marvel Studios", 7.9000000000000004, "November 3, 2017", "Imprisoned on the planet Sakaar, Thor must race against time to return to Asgard and stop Ragnarök, the destruction of his world, at the hands of the powerful and ruthless villain Hela.", "Thor: Ragnarok", null, "130min" },
                    { 28, "Chadwick Boseman,Michael B. Jordan", "Action, Adventure, Sci-Fi", "USA", null, 16, "Ryan Coogler", "English", "BlackPanther.jpg", false, 11, "Marvel Studios", 7.2999999999999998, "February 16, 2018", "T'Challa, heir to the hidden but advanced kingdom of Wakanda, must step forward to lead his people into a new future and must confront a challenger from his country's past.", "Black Panther", null, "134min" },
                    { 25, "Chris Evans,Samuel L. Jackson,Robert Downey Jr.,Sebastian Bach,Anthony Mackie,Elizabeth Olsen,Scarlet Johansson,Jeremy Lee Renner,Paul Rudd,Tom Holland,Paul Bettany", "Action, Adventure, Sci-Fi", "USA", null, 2, "Joe Russo", "English", "CaptainAmericaCivilWar.jpg", false, 11, "Marvel Studios", 7.7999999999999998, "May 6, 2016", "Political involvement in the Avengers' affairs causes a rift between Captain America and Iron Man.", "Captain America: Civil War", null, "147min" },
                    { 24, "Paul Rudd,Michael Douglas", "Action, Adventure, Comedy", "USA", null, 13, "Peyton Reed", "English", "AntMan.jpg", false, 11, "Marvel Studios", 7.2999999999999998, "Jyly 17, 2015", "Armed with a super-suit with the astonishing ability to shrink in scale but increase in strength, cat burglar Scott Lang must embrace his inner hero and help his mentor, Dr. Hank Pym, plan and pull off a heist that will save the world.", "Ant-Man", null, "117min" },
                    { 23, "Chris Hemsworth,Mark Ruffalo,Robert Downey Jr.,Jeremy Lee Renner,Tom Hiddleston,Chris Evans,Elizabeth Olsen,Paul Bettany,Scarlet Johansson,Samuel L. Jackson", "Action, Adventure, Sci-Fi", "USA", null, 10, "Joss Whedon", "English", "AvengersAgeOfUltron.jpg", false, 11, "Marvel Studios", 7.2999999999999998, "May 1, 2015", "When Tony Stark and Bruce Banner try to jump-start a dormant peacekeeping program called Ultron, things go horribly wrong and it's up to Earth's mightiest heroes to stop the villainous Ultron from enacting his terrible plan.", "Avengers: Age of Ultron", null, "141min" },
                    { 22, "Chris Pratt,Zoe Saldana,Vin Diesel,Bradley Cooper,Karen Gillan,Dave Bautista,Kurt Russel", "Action, Adventure, Comedy", "USA", null, 12, "James Gunn", "English", "GuardiansOfTheGalaxyVol2.jpg", false, 11, "Marvel Studios", 7.5999999999999996, "May 5, 2017", "The Guardians struggle to keep together as a team while dealing with their personal family issues, notably Star-Lord's encounter with his father the ambitious celestial being Ego.", "Guardians of the Galaxy Vol.2", null, "136min" },
                    { 21, "Chris Pratt,Zoe Saldana,Vin Diesel,Bradley Cooper,Karen Gillan,Dave Bautista", "Action, Adventure, Comedy", "USA", null, 12, "James Gunn", "English", "GuardiansOfTheGalaxy.jpg", false, 11, "Marvel Studios", 8.0, "August 1, 2014", "A group of intergalactic criminals must pull together to stop a fanatical warrior with plans to purge the universe.", "Guardians of the Galaxy", null, "121min" },
                    { 20, "Chris Evans,Samuel L. Jackson,Hayley Atwell,Sebastian Bach,Anthony Mackie", "Action, Adventure, Sci-Fi", "USA", null, 3, "Anthony Russo", "English", "CaptainAmericaWinterSoldier.jpg", false, 11, "Marvel Studios", 7.7000000000000002, "April 4, 2014", "As Steve Rogers struggles to embrace his role in the modern world, he teams up with a fellow Avenger and S.H.I.E.L.D agent, Black Widow, to battle a new threat from history: an assassin known as the Winter Soldier.", "Captain America: Winter Soldier", null, "136min" },
                    { 19, "Chris Hemsworth,Natalie Portman,Jaimie Alexander,Idris Elba,Anthony Hopkins,Kat Dennings,Rene Russo,Ray Stevenson,Stellan Skarsgard,Tadanobu Asano,Tom Hiddleston", "Action, Adventure, Fantasy", "USA", null, 9, "Alan Taylor", "English", "ThorTheDarkWorld.jpg", false, 11, "Marvel Studios", 6.9000000000000004, "November 8, 2013", "When the Dark Elves attempt to plunge the universe into darkness, Thor must embark on a perilous and personal journey that will reunite him with doctor Jane Foster.", "Thor: The Dark World", null, "112min" },
                    { 17, "Chris Hemsworth,Mark Ruffalo,Robert Downey Jr.,Jeremy Lee Renner,Tom Hiddleston,Chris Evans,Elizabeth Olsen,Paul Bettany,Scarlet Johansson,Samuel L. Jackson", "Action, Adventure, Sci-Fi", "USA", null, 2, "Joe Russo", "English, Russian, Hindi", "Avengers.jpg", false, 11, "Marvel Studios", 8.0, "May 4, 2012", "Earth's mightiest heroes must come together and learn to fight as a team if they are going to stop the mischievous Loki and his alien army from enslaving humanity.", "The Avengers", null, "143min" },
                    { 15, "Edward Norton,Tim Roth", "Action, Adventure, Sci-Fi", "USA", null, 7, "Louis Leterrier", "English", "TheIncredibleHulk.jpg", false, 11, "Marvel Studios", 6.7000000000000002, "June 13, 2008", "Bruce Banner, a scientist on the run from the U.S. Government, must find a cure for the monster he turns into whenever he loses his temper.", "The Incredible Hulk", null, "112min" },
                    { 12, "Brie Larson,Samuel L. Jackson,Clark Gregg", "Action, Adventure, Sci-Fi", "USA", null, 4, "Anna Boden", "English", "CaptainMarvel.jpg", false, 11, "Marvel Studios", 6.7999999999999998, "March 8, 2019", "Carol Danvers becomes one of the universe's most powerful heroes when Earth is caught in the middle of a galactic war between two alien races.", "Captain Marvel", null, "123min" },
                    { 6, "Benedict Cumberbatch,Chiwetel Ejiofor,Rachel McAdams", "Action, Adventure, Fanstasy", "USA", null, 15, "Scott Derrickson", "English", "DrStrange.jpg", false, 11, "Marvel Studios", 7.5, "4 November, 2016", "While on a journey of physical and spiritual healing, a brilliant neurosurgeon is drawn into the world of the mystic arts.", "Doctor Strange", null, "115min" },
                    { 10, "Leonardo DiCaprio,Joseph Gordon-Levitt,Elliot Page,Ken Watanabe,Tom Hardy,Dileep Rao,Cillian Murphy,Tom Berenger,Marion Cotillard,Michael Caine", "Action, Adventure, Sci-Fi", "USA, UK", null, 10, "Christopher Nolan", "English, Japanese, French", "Inception2010Image.jpg", false, 10, "Legendary Entertainment", 8.8000000000000007, "16 July 2010", "A thief who steals corporate secrets through the use of dream-sharing technology is given the inverse task of planting an idea into the mind of a C.E.O.", "Inception", "Inception (2010) Official Trailer.mp4", "148min" },
                    { 9, "Tom Schilling,Elyas M'Barek,Wotan Wilke Möhring", "Crime, Drama, Mystery", "Germany", null, 9, "Baran bo Odar", "German, English", "WhoAmI2014Image.jpg", false, 9, "SevenPictures Film", 7.5, "25 September 2014", "Benjamin, a young German computer whiz, is invited to join a subversive hacker group that wants to be noticed on the world's stage.", "Who Am I", "Who Am I Official Trailer.mp4", "102min" },
                    { 8, "Benedict Cumberbatch,Keira Knightley,Matthew Goode", "Drama, Biography, Thriller", "UK, USA", null, 8, "Morten Tyldum", "English, German", "TheImitationGame2014Image.jpg", false, 8, "Black Bear Pictures", 8.0, "25 December 2014", "During World War II, the English mathematical genius Alan Turing tries to crack the German Enigma code with help from fellow mathematicians.", "The Imitation Game", "The Imitation Game Official Trailer.mp4", "114min" },
                    { 3, "Leonardo Di Caprio,Kate Winslet,Billy Zane", "Drama, Romance", "USA, Mexico, Australia, Canada", null, 3, "James Cameron", "English, Swedish, Italian, French", "Titanic1997Image.jpg", false, 1, "20th Century Fox", 7.7999999999999998, "19 December 1997", "A seventeen-year-old aristocrat falls in love with a kind but poor artist aboard the luxurious, Ill-fated R.M.S Titanic.", "Titanic", "Titanic  Official Trailer.mp4", "194min" },
                    { 27, "Kenneth Branagh,Penélope Cruz,Willem Dafoe", "Crime, Drama, Mystery", " Malta, USA, UK", null, 1, "Kenneth Branagh", "English, French, Arabic, German", "MurderOnTheOrientExpress2017Image.jpg", false, 1, "20th Century Fox", 6.5, "10 November 2017", "When a murder occurs on the train on which he's travelling, celebrated detective Hercule Poirot is recruited to solve the case.", "Murder On The Orient Express", "Murder on the Orient Express Official Trailer.mp4", "114min" },
                    { 2, "Sylvester Stallone,Julie Benz,Matthew Marsden", "Action, Thriller", "Germany,USA,Thailand", null, 2, "Sylvester Stallone", "English, Burmese, Thai", "Rambo2008Image.jpg", false, 2, "Lionsgate", 7.0, "25 January 2008", "In Thailand, John Rambo joins a group of mercenaries to venture into war-torn Burma, and rescue a group of Christian aid workers who were kidnapped by the ruthless local infantry unit.", "Rambo", "Rambo (2008) - Official Trailer.mp4", "92min" },
                    { 4, "Tom Cruise,Tim Robbins,Kelly McGillis", "Action, Drama", "USA", null, 4, "Tony Scott", "English", "TopGun1986Image.jpg", false, 4, "Paramount Pictures", 6.9000000000000004, "16 May 1986", "As students at the United States Navy's elite fighter weapons school compete to be best in the class, one daring young pilot learns a few things from a civilian instructor that are not taught in the classroom.", "Top Gun", "Top Gun (1986) Official Trailer.mp4", "110min" },
                    { 11, "Chris Evans,Samuel L. Jackson,Hayley Atwell,Sebastian Bach", "Action, Adventure, Sci-Fi", "USA", null, 11, "Joe Johnston", "English", "CaptainAmerica.jpg", false, 4, "Paramount Pictures", 6.9000000000000004, "Jyly 22, 2011", "Steve Rogers, a rejected military soldier, transforms into Captain America after taking a dose of a \"Super - Soldier serum\". But being Captain America comes at a price as he attempts to take down a war monger and a terrorist organization.", "Captain America: The First Avenger", null, "124min" },
                    { 13, "Robert Downey Jr.,Gwyneth Paltrow,Jon Favreau,Samuel L. Jackson,Jeff Bridges,Terrence Howard,Paul Bettany,Clark Gregg", "Action, Adventure, Sci-Fi", "USA", null, 5, "Jon Favreau", "English", "IronMan.jpg", false, 4, "Paramount Pictures", 7.9000000000000004, "May 2, 2008", "After being held captive in an Afghan cave, billionaire engineer Tony Stark creates a unique weaponized suit of armor to fight evil.", "Iron Man", null, "126min" },
                    { 31, "Paul Rudd,Evangeline Lilly,Michael Douglas", "Action, Adventure, Comedy", "USA", null, 13, "Peyton Reed", "English", "AntManAndTheWasp.jpg", false, 11, "Marvel Studios", 7.0, "Jyly 6, 2018", "As Scott Lang balances being both a superhero and a father, Hope van Dyne and Dr. Hank Pym present an urgent new mission that finds the Ant-Man fighting alongside The Wasp to uncover secrets from their past.", "Ant-Man and The Wasp", null, "118min" },
                    { 14, "Robert Downey Jr.,Gwyneth Paltrow,Jon Favreau,Samuel L. Jackson,Don Cheadle,Paul Bettany,Clark Gregg,Mickey Rourke", "Action, Adventure, Sci-Fi", "USA", null, 5, "Jon Favreau", "English", "IronMan2.jpg", false, 4, "Paramount Pictures", 7.0, "May 7, 2010", "With the world now aware of his identity as Iron Man, Tony Stark must contend with both his declining health and a vengeful mad man with ties to his father's legacy.", "Iron Man 2", null, "124min" },
                    { 18, "Robert Downey Jr.,Gwyneth Paltrow,Jon Favreau,Samuel L. Jackson,Don Cheadle,Paul Bettany,Clark Gregg", "Action, Adventure, Sci-Fi", "USA", null, 6, "Shane Black", "English", "IronMan3.jpg", false, 4, "Paramount Pictures", 7.0999999999999996, "May 3, 2013", "When Tony Stark's world is torn apart by a formidable terrorist called the Mandarin, he starts an odyssey of rebuilding and retribution.", "Iron Man 3", null, "130min" },
                    { 5, "Arnold Schwarzenegger,Linda Hamilton,Michael Biehn", "Action, Sci-Fi", "UK", null, 3, "James Cameron", "English", "TheTerminator1984Image.jpg", false, 5, "Cinema '84", 8.0, "26 October 1984", "A human soldier is sent from 2029 to 1984 to stop an almost indestructible cyborg killing machine, sent from the same year, which has been programmed to execute a young woman whose unborn son is the key to humanity's future salvation.", "The Terminator", "The Terminator (1984) Official Trailer.mp4", "107min" },
                    { 1, "Jonny Lee Miller,Angelina Jolie,Jesse Bradford,Matthew Lillard,Laurence Mason,Renoly Santiago", "Crime, Comedy, Drama", "United States", null, 6, "Iain Softley", "English, Italian, Japanese, Russian", "Hackers1995Image.jpg", false, 6, "United Artists", 6.2000000000000002, "15 September 1995", "Hackers are blamed for making a virus that will capsize five oil tankers.", "Hackers", "Hackers Official Trailer.mp4", "105min" },
                    { 7, "Jesse Eisenberg,Andrew Garfield,Justin Timberlake,Rooney Mara", "Drama, Biography", "USA", null, 7, "David Fincher", "English, French", "TheSocialNetwork2010Image.png", false, 7, "Columbia Pictures", 7.7000000000000002, "1 October 2010 ", "As Harvard student Mark Zuckerberg creates the social networking site that would become known as Facebook, he is sued by the twins who claimed he stole their idea, and by the co-founder who was later squeezed out of the business.", "The Social Network", "THE SOCIAL NETWORK - Official Trailer.mp4", "120min" },
                    { 26, "Tom Holland,Robert Downey Jr.,Jon Favreau,Zendaya", "Action, Adventure, Sci-Fi", "USA", null, 14, "Jon Watts", "English", "SpidermanHomecoming.jpg", false, 7, "Columbia Pictures", 7.4000000000000004, "Jyly 17, 2017", "Peter Parker balances his life as an ordinary high school student in Queens with his superhero alter-ego Spider-Man, and finds himself on the trail of a new menace prowling the skies of New York City.", "Spider-Man: Homecoming", null, "133min" },
                    { 33, "Tom Holland,Jon Favreau,Zendaya,Samuel L. Jackson,Cobie Smulders,Jake Gyllenhaal", "Action, Adventure, Sci-Fi", "USA", null, 14, "Jon Watts", "English", "SpidermanFarFromHome.jpg", false, 7, "Columbia Pictures", 7.5, "Jyly 2, 2019", "Following the events of Avengers: Endgame (2019), Spider-Man must step up to take on new threats in a world that has changed forever.", "Spider-Man: Far From Home", null, "129min" },
                    { 16, "Chris Hemsworth,Natalie Portman,Jaimie Alexander,Idris Elba,Anthony Hopkins,Kat Dennings,Rene Russo,Ray Stevenson,Stellan Skarsgard,Tadanobu Asano,Clark Gregg,Samuel L. Jackson,Jeremy Lee Renner,Tom Hiddleston", "Action, Adventure, Fanstasy", "USA", null, 17, "Kenneth Branagh", "English", "Thor.jpg", false, 4, "Paramount Pictures", 7.0, "May 6, 2011", "The powerful but arrogant god Thor is cast out of Asgard to live amongst humans in Midgard (Earth), where he soon becomes one of their finest defenders.", "Thor", null, "115min" },
                    { 32, "Chris Hemsworth,Mark Ruffalo,Scarlet Johannson,Karen Gillan,Robert Downey Jr.,Samuel L. Jackson,Jeremy Lee Renner,Tom Hiddleston,Chris Evans,Brie Larson,Josh Brolin,Chadwick Boseman,Elizabeth Olsen,Chris Pratt,Zoe Saldana,Benedict Cumberbatch,Paul Bettany,Anthony Mackie,Sebastian Bach,Vin Diesel,Tom Holland", "Action, Adventure, Drama", "USA", null, 3, "Anthony Russo", "English", "AvengersEndGame.jpg", false, 11, "Marvel Studios", 8.4000000000000004, "April 26, 2019", "After the devastating events of Avengers: Infinity War (2018), the universe is in ruins. With the help of remaining allies, the Avengers assemble once more in order to reverse Thanos' actions and restore balance to the universe.", "Avengers: Endgame", null, "181min" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_MovieActors_ActorID",
                table: "MovieActors",
                column: "ActorID");

            migrationBuilder.CreateIndex(
                name: "IX_MovieCategories_CategoryID",
                table: "MovieCategories",
                column: "CategoryID");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_DirectorId",
                table: "Movies",
                column: "DirectorId");

            migrationBuilder.CreateIndex(
                name: "IX_Movies_PublisherId",
                table: "Movies",
                column: "PublisherId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "MovieActors");

            migrationBuilder.DropTable(
                name: "MovieCategories");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "ShoppingCart");

            migrationBuilder.DropTable(
                name: "WishLists");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "Actors");

            migrationBuilder.DropTable(
                name: "Category");

            migrationBuilder.DropTable(
                name: "Movies");

            migrationBuilder.DropTable(
                name: "Directors");

            migrationBuilder.DropTable(
                name: "Publisher");
        }
    }
}
