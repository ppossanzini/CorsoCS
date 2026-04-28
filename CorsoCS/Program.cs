
using System.Reflection;
using System.Text.Json.Serialization;
using CorsoCS.API.Hubs;
using CorsoCS.Handlers;
using CorsoCS.Handlers.Model;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

public partial class Program
{
	private static void Main(string[] args)
	{
		var builder = WebApplication.CreateBuilder(args);

		// Add services to the container.
		// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
		builder.Services.AddOpenApi();
		builder.Services.AddCors(o => o.AddDefaultPolicy(p =>
				p.AllowAnyHeader()
				 .AllowAnyMethod()
				 .SetIsOriginAllowed(_ => true)
				 .AllowCredentials()
		));
		builder.Services.AddControllers();
		builder.Services.AddAxon(cfg =>
				cfg.RegisterServicesFromAssemblies([
								typeof(MappingProfile).Assembly,
						typeof(NotesHub).Assembly
				]));
		builder.Services.AddMapZilla([typeof(MappingProfile)]);
		builder.Services.AddDbContext<DB>(
				opt => opt.UseSqlite(builder.Configuration.GetConnectionString("DefaultConnection"))
		);

		builder.Services.AddSignalR();

		var app = builder.Build();

		using (var scope = app.Services.CreateScope())
		{
			using var db = scope.ServiceProvider.GetRequiredService<DB>();
			// db.Database.EnsureCreated();
			db.Database.Migrate();
		}


		// Configure the HTTP request pipeline.
		if (app.Environment.IsDevelopment())
		{
			app.MapOpenApi();
		}

		//app.UseHttpsRedirection();
		app.UseCors();
		app.MapScalarApiReference();
		app.MapControllers();
		app.MapHub<NotesHub>("hubs/notes");
		app.Run();
	}
}