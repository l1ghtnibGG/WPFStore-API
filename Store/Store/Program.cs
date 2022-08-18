using Newtonsoft.Json;
using Store;
using System.Net;

internal class Program
{
    public static StoreData Data = new();
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        // Add services to the container.

        builder.Services.AddControllers();
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        LoadData();

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }

    private static void LoadData()
    {
        try
        {
            string str;
            using (StreamReader sr = new("data.json"))
            {
                str = sr.ReadToEnd();
            }

            Data = JsonConvert.DeserializeObject<StoreData>(str);
        }
        catch (IOException ex)
        {
           Console.WriteLine(ex.ToString());
        }
    }
}