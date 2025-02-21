
using Business.Interfaces;
using Business.Services;
using Data.Context;
using Data.Interfaces;
using Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Presentation_ConsoleApp.Dialogs;
using Presentation_ConsoleApp.Interfaces;

var serviceCollection = new ServiceCollection()
.AddDbContext<DataContext>(options => options.UseSqlServer("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=C:\\Projects\\DataStorage_Assignment\\Data\\Databases\\local_database.mdf;Integrated Security=True;Connect Timeout=30"))

// alla repos
.AddScoped<ICustomerRepository, CustomerRepository>()
.AddScoped<IProductRepository, ProductRepository>()
.AddScoped<IProjectRepository, ProjectRepository>()
.AddScoped<IStatusTypeRepository, StatusTypeRepository>()
.AddScoped<IUserRepository, UserRepository>()

// alla services
.AddScoped<ICustomerService, CustomerService>()
.AddScoped<IProductService, ProductService>()
.AddScoped<IProjectService, ProjectService>()
.AddScoped<IStatusTypeService, StatusTypeService>()
.AddScoped<IUserService, UserService>()

// alla menyer
.AddScoped<IMenuDialog, MenuDialog>()


.BuildServiceProvider();

var menuDialogs = serviceCollection.GetRequiredService<IMenuDialog>();
await menuDialogs.ShowMenu();
