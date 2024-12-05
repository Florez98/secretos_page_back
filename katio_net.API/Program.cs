using katio.Business.Interfaces;
using katio.Business.Services;
using katio_net.Data;
using katio.Data;
using Microsoft.EntityFrameworkCore;
using katio.Data.Models;
using System.Runtime.InteropServices;
using katio_net.Data.Models;
using Katio.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddDbContext<katioContext>(opt => //opt.UseInMemoryDatabase("katio"));
                                            opt.UseNpgsql(builder.Configuration.GetConnectionString("KatioDBPSQL")));
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddControllers();
builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IGenresService, GenresService>();
builder.Services.AddScoped<INarratorService, NarratorService>();
builder.Services.AddScoped<IRoleService, RoleService>();
builder.Services.AddScoped<IAudioBookService, AudioBookService>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

var app = builder.Build();
//PopulateDB(app);

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    
    }

app.UseHttpsRedirection();
app.MapControllers();

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast =  Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast")
.WithOpenApi();

app.Run();


//PopulateDB(app);

//...

app.Run();

async void PopulateDB(WebApplication app)
{
    using(var scope = app.Services.CreateAsyncScope())
    {

        #region Genres service
         var GenresService = scope.ServiceProvider.GetService<IGenresService>();
        await GenresService.CreateGenres(new katio.Data.Models.Genres{
            name="Novela",
            Id =1
        });

        await GenresService.CreateGenres(new katio.Data.Models.Genres{
            name="Terror",
            Id =2
        });
        #endregion

        #region author service
        var AuthorService = scope.ServiceProvider.GetService<IAuthorService>();
        await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Gabriel",
            LastName = "García Márquez",
            Country = "Colombia",
            BirthDate = new DateOnly(1940, 03, 03)
        });

         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Jorge",
            LastName = "Isaacs",
            Country = "Colombia",
            BirthDate = new DateOnly(1836, 04, 01)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Germán",
            LastName = "Castro-Caycedo",
            Country = "Colombia",
            BirthDate = new DateOnly(1940, 03, 03)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Silvia",
            LastName = "Moreno García",
            Country = "México",
            BirthDate = new DateOnly(1981, 04, 25)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Irene",
            LastName = "Vallejo",
            Country = "España",
            BirthDate = new DateOnly(1979, 06, 06)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Sarah J",
            LastName = "Maas",
            Country = "EEUU",
            BirthDate = new DateOnly(1986, 03, 05)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Mario",
            LastName = "Mendoza",
            Country = "Colombia",
            BirthDate = new DateOnly(1964, 01, 10)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Hector",
            LastName = "Abad Faciolince",
            Country = "Colombia",
            BirthDate = new DateOnly(1958, 10, 01)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Laura",
            LastName = "Restrepo",
            Country = "Colombia",
            BirthDate = new DateOnly(1950, 01, 01)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Piedad",
            LastName = "Bonnet",
            Country = "Colombia",
            BirthDate = new DateOnly(1951, 01, 01)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Fernando",
            LastName = "Vallejo",
            Country = "Colombia",
            BirthDate = new DateOnly(1942, 10, 24)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Antonio",
            LastName = "Caballero",
            Country = "Colombia",
            BirthDate = new DateOnly(1945, 05, 15)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "William",
            LastName = "Ospina",
            Country = "Colombia",
            BirthDate = new DateOnly(1954, 03, 02)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Juan Gabriel",
            LastName = "Vasquez",
            Country = "Colombia",
            BirthDate = new DateOnly(1973, 01, 01)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Santiago",
            LastName = "Gamboa",
            Country = "Colombia",
            BirthDate = new DateOnly(1965, 01, 01)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Angela",
            LastName = "Becerra",
            Country = "Colombia",
            BirthDate = new DateOnly(1957, 07, 17)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Stephen",
            LastName = "King",
            Country = "EEUU",
            BirthDate = new DateOnly(1947, 09, 21)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Anne",
            LastName = "Rice",
            Country = "EEUU",
            BirthDate = new DateOnly(1941, 10, 04)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Jeff",
            LastName = "Vandermeer",
            Country = "EEUU",
            BirthDate = new DateOnly(1968, 07, 07)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Liu",
            LastName = "Cixin",
            Country = "China",
            BirthDate = new DateOnly(1963, 06, 30)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Fyodor",
            LastName = "Dvostoesky",
            Country = "Rusia",
            BirthDate = new DateOnly(1821, 11, 11)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Leo",
            LastName = "Tolstoy",
            Country = "Rusia",
            BirthDate = new DateOnly(1928, 09, 09)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Anton",
            LastName = "Chekhov",
            Country = "Rusia",
            BirthDate = new DateOnly(1860, 01, 29)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Issac",
            LastName = "Asimov",
            Country = "Rusia, EEUU",
            BirthDate = new DateOnly(1920, 01, 02)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Rudyard",
            LastName = "Kipling",
            Country = "India",
            BirthDate = new DateOnly(1865, 12, 30)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Jon Ronald Reuel",
            LastName = "Tolkien",
            Country = "Surafrica",
            BirthDate = new DateOnly(1892, 01, 03)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Clive Staples",
            LastName = "Lewis",
            Country = "Reino Unido",
            BirthDate = new DateOnly(1898, 11, 29)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "George Raymond Richard",
            LastName = "Martin",
            Country = "EEUU",
            BirthDate = new DateOnly(1948, 09, 20)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Frank",
            LastName = "Herbert",
            Country = "EEUU",
            BirthDate = new DateOnly(1920, 10, 28)
        });
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Albert",
            LastName = "Camus",
            Country = "Francia",
            BirthDate = new DateOnly(1913, 11, 07)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Margaret",
            LastName = "Atwood",
            Country = "Canadá",
            BirthDate = new DateOnly(1939, 11, 18)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Mary",
            LastName = "Shelley",
            Country = "Inglaterra",
            BirthDate = new DateOnly(1890, 09, 15)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Agatha",
            LastName = "Christie",
            Country = "Inglaterra",
            BirthDate = new DateOnly(1890, 09, 15)
        });
        
         await AuthorService.CreateAuthor(new katio.Data.Models.Author{
            Name = "Ursula K",
            LastName = "Le Guin",
            Country = "EEUU",
            BirthDate = new DateOnly(1929, 10, 21)
        });
        #endregion

        #region bookservice
        
        var bookService = scope.ServiceProvider.GetRequiredService<IBookService>();
        await bookService.CreateBook(new katio.Data.Models.Book{
            Title = "Cien años de soledad",
            ISBN10 = "8420471836",
            ISBN13 = "978-8420471839",
            Published = new DateTime(1967, 06, 05),
            Edition = "RAE Obra Académica",
            DeweyIndex = "800",
            AuthorId =1,
            Genre ="Novela"
        });

        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Huellas",
            ISBN10 = "9584277278",
            ISBN13 = "978-958427275",
            Published = new DateTime(2019, 01, 01),
            Edition = "1ra Edicion",
            DeweyIndex = "800",
            AuthorId = 3,
            Genre ="Novela"
        });

        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "María",
            ISBN10 = "14802722922",
            ISBN13 = "978-148027292",
            Published = new DateTime(1867, 01, 01),
            Edition = "1ra edición",
            DeweyIndex = "800",
            AuthorId = 2,
            Genre ="Novela"
        });

        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Mexico Gothic",
            ISBN10 = "8420471836",
            ISBN13 = "978-05256620785",
            Published = new DateTime(2020, 06, 30),
            Edition = "Del Rey",
            DeweyIndex = "800",
            AuthorId = 4,
            Genre ="Novela"
        });

        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Sin remedio",
            ISBN10 = "3161484100",
            ISBN13 = "978-3161484100",
            Published = new DateTime(1984, 01, 01),
            Edition = "Alfaguara",
            DeweyIndex = "800",
            AuthorId = 12,
            Genre ="Novela"
        });

        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Delirio",
            ISBN10 = "9587041453",
            ISBN13 = "978-9587041453",
            Published = new DateTime(2004, 01, 01),
            Edition = "Alfaguara",
            DeweyIndex = "800",
            AuthorId = 9,
            Genre ="Novela"
        });

        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Infinito en un junco",
            ISBN10 = "8417860790",
            ISBN13 = "9788417860790",
            Published = new DateTime(2019, 01, 01),
            Edition = "Siruela",
            DeweyIndex = "800",
            AuthorId = 5,
            Genre ="Novela"
        });

        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El olvido que seremos",
            ISBN10 = "8420426402",
            ISBN13 = "978-8420426402",
            Published = new DateTime(2017, 10, 16),
            Edition = "Alfaguara",
            DeweyIndex = "800",
            AuthorId = 8,
            Genre ="Novela"
        });        
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El país de la canela",
            ISBN10 = "8439738831",
            ISBN13 = "978-8439738831",
            Published = new DateTime(2020, 08, 22),
            Edition = "ndom House",
            DeweyIndex = "800",
            AuthorId = 13,
            Genre ="Novela"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Lo que no tiene nombre",
            ISBN10 = "6287659216",
            ISBN13 = "978-6287659216",
            Published = new DateTime(2024, 03, 19),
            Edition = "Alfaguara",
            DeweyIndex = "800",
            AuthorId = 10,
            Genre ="Novela"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El ruido de las cosas al caer",
            ISBN10 = "6073137515",
            ISBN13 = "978-6073137515",
            Published = new DateTime(2015, 12, 29),
            Edition = "ebolsillo",
            DeweyIndex = "800",
            AuthorId = 14,
            Genre ="Novela"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El síndrome de Ulises",
            ISBN10 = "9584211903",
            ISBN13 = "978-9584211903",
            Published = new DateTime(2005, 03, 30),
            Edition = "Planeta",
            DeweyIndex = "800",
            AuthorId = 15,
            Genre ="Novela"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "La puta de Babilonia",
            ISBN10 = "6073158855",
            ISBN13 = "978-6073158855",
            Published = new DateTime(2018, 01, 30),
            Edition = "ebolsillo",
            DeweyIndex = "800",
            AuthorId = 11,
            Genre ="Novela"

        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Memorias de un sinvergüenza de siete suelas",
            ISBN10 = "9504932611",
            ISBN13 = "978-9504932611",
            Published = new DateTime(2012, 01, 01),
            Edition = "Planeta",
            DeweyIndex = "800",
            AuthorId = 16,
            Genre ="Novela"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Satanás",
            ISBN10 = "9584273543",
            ISBN13 = "978-9584273543",
            Published = new DateTime(2018, 01, 01),
            Edition = "Planeta DeAgostini Comic",
            DeweyIndex = "800",
            AuthorId = 7,
            Genre ="Novela"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "It (Eso)",
            ISBN10 = "0525566267",
            ISBN13 = "978-0525566267",
            Published = new DateTime(2019, 01, 27),
            Edition = "Vinntage Espanol",
            DeweyIndex = "800",
            AuthorId = 17,
            Genre ="Novela"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El Resplandor",
            ISBN10 = "0593311233",
            ISBN13 = "978-0593311233",
            Published = new DateTime(2005, 08, 25),
            Edition = "Vintage",
            DeweyIndex = "800",
            AuthorId = 17,
            Genre ="Novela"

        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Cujo",
            ISBN10 = "1501192241",
            ISBN13 = "978-1501192241",
            Published = new DateTime(2018, 02, 20),
            Edition = "Scribner",
            DeweyIndex = "800",
            AuthorId = 17,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Trono de Cristal",
            ISBN10 = "8890981547",
            ISBN13 = "979-8890981547",
            Published = new DateTime(2022, 05, 13),
            Edition = "Alfaguara",
            DeweyIndex = "800",
            AuthorId = 6,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Entrevista con el Vampiro",
            ISBN10 = "6073198929",
            ISBN13 = "978-6073198929",
            Published = new DateTime(2021, 05, 18),
            Edition = "de Bolsillo",
            DeweyIndex = "800",
            AuthorId = 18,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Anniquilación",
            ISBN10 = "0374104092",
            ISBN13 = "978-0374104092",
            Published = new DateTime(2014, 02, 04),
            Edition = "G Originals",
            DeweyIndex = "800",
            AuthorId = 19,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Autoridad",
            ISBN10 = "0374104108",
            ISBN13 = "978-0374104108",
            Published = new DateTime(2014, 05, 06),
            Edition = "G Originals",
            DeweyIndex = "800",
            AuthorId = 19,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Aceptación",
            ISBN10 = "374104115",
            ISBN13 = "978-0374104115",
            Published = new DateTime(2014, 09, 02),
            Edition = "G Originals",
            DeweyIndex = "800",
            AuthorId = 19,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Historia de Colombia y sus oligarquias",
            ISBN10 = "9584268754",
            ISBN13 = "978-9584268754",
            Published = new DateTime(2019, 01, 01),
            Edition = "Crítica",
            DeweyIndex = "800",
            AuthorId = 12,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El problema de los tres cuerpos",
            ISBN10 = "8466659734",
            ISBN13 = "978-8466659734",
            Published = new DateTime(2016, 11, 01),
            Edition = "Nova",
            DeweyIndex = "800",
            AuthorId = 20,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El Bosque Oscuro",
            ISBN10 = "978-8413146454",
            ISBN13 = "978-8413146454",
            Published = new DateTime(2024, 05, 01),
            Edition = "Nova",
            DeweyIndex = "800",
            AuthorId = 20,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El fin de la muerte",
            ISBN10 = "8417347017",
            ISBN13 = "978-8417347017",
            Published = new DateTime(2018, 08, 01),
            Edition = "1",
            DeweyIndex = "800",
            AuthorId = 20,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Crimen y Castigo",
            ISBN10 = "8872132677",
            ISBN13 = "979-8872132677",
            Published = new DateTime(1866, 12, 01),
            Edition = "dependiente",
            DeweyIndex = "800",
            AuthorId = 21,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Las obras de Leo Tolstoy",
            ISBN10 = "1016243247",
            ISBN13 = "978-1016243247",
            Published = new DateTime(2022, 10, 27),
            Edition = "CLassic",
            DeweyIndex = "800",
            AuthorId = 22,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Historias Cortas",
            ISBN10 = "9389717105",
            ISBN13 = "978-9389717105",
            Published = new DateTime(2019, 01, 12),
            Edition = "Finngerprint",
            DeweyIndex = "800",
            AuthorId = 23,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Trilogía Fundación",
            ISBN10 = "8499083209",
            ISBN13 = "978-8499083209",
            Published = new DateTime(2023, 03, 23),
            Edition = "debolsillo",
            DeweyIndex = "800",
            AuthorId = 24,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El libro de la selva",
            ISBN10 = "8467871029",
            ISBN13 = "978-8467871029",
            Published = new DateTime(1894, 01, 01),
            Edition = "Classic",
            DeweyIndex = "800",
            AuthorId = 25,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El señor de los anillos",
            ISBN10 = "8445013830",
            ISBN13 = "978-8445013830",
            Published = new DateTime(2023, 11, 02),
            Edition = "Fantasia epica",
            DeweyIndex = "800",
            AuthorId = 26,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Juego de tronos",
            ISBN10 = "1644736135",
            ISBN13 = "978-1644736135",
            Published = new DateTime(2022, 06, 21),
            Edition = "Vintage",
            DeweyIndex = "800",
            AuthorId = 28,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Duna",
            ISBN10 = "6073194648",
            ISBN13 = "978-6073194648",
            Published = new DateTime(2020, 11, 07),
            Edition = "Classic",
            DeweyIndex = "800",
            AuthorId = 29,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El extranjero",
            ISBN10 = "1518660016",
            ISBN13 = "978-1518660016",
            Published = new DateTime(2015, 10, 06),
            Edition = "Ciencia ficcion",
            DeweyIndex = "800",
            AuthorId = 30,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "El cuento de la criada",
            ISBN10 = "8498388015",
            ISBN13 = "978-8498388015",
            Published = new DateTime(2017, 06, 17),
            Edition = "Salamandra",
            DeweyIndex = "800",
            AuthorId = 31,
            Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Asesinato en el Orient Express",
            ISBN10 = "6070743986",
            ISBN13 = "978-6070743986",
            Published = new DateTime(2022, 02, 15),
            Edition = "Planeta",
            DeweyIndex = "800",
            AuthorId = 33,
           Genre ="Terror"
        });
        await bookService.CreateBook(new katio.Data.Models.Book
        {
            Title = "Cuentos de Terramar",
            ISBN10 = "8467437560",
            ISBN13 = "978-8467437560",
            Published = new DateTime(2007, 01, 01),
            Edition = "Planeta",
            DeweyIndex = "800",
            AuthorId = 34,
            Genre ="Terror"
        });
        #endregion
    }

}


record WeatherForecast(DateOnly Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}
