using FreeCourse.Services.Catalog.Services;
using FreeCourse.Services.Catalog.Settings;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(Program));

//Icategory ile karsilasildiginda Categoryservice nesnesi donecek.
builder.Services.AddScoped<ICategoryService, CategoryService>();
builder.Services.AddScoped<ICourseService, CourseService>();

//appsettting datasini okumayi sagliyor.
//DtatabaseSettings nereden hangi sectiondan gelecek ""DatabaseSettings"
builder.Services.Configure<DatabaseSettings>(builder.Configuration.GetSection("DatabaseSettings"));

// bir servisin constructurinda IdatabaseSettings gorunce databaseSettingsin degerini don
builder.Services.AddSingleton<IDatabaseSettings>(serviceprovider => {
    return serviceprovider.GetRequiredService<IOptions<DatabaseSettings>>().Value;
    //gertservice ile farki ilgili servisi bulamayinca hata firlatmasi
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseAuthorization();

app.MapControllers();

app.Run();

