// See https://aka.ms/new-console-template for more information
using EF_CORE_2_DbContext;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
Console.WriteLine("Hello, World!");



// Internal Configration
using (var context = new InternalDbContext())
{
    Console.WriteLine("Internal ");

    foreach (var wallet in context.Wallets)
    {

        Console.WriteLine(wallet);
    }
    Console.WriteLine("iiii");


}


// External Configration
var config = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .Build();
var constr = config.GetSection("constr").Value;

var optionBuilder = new DbContextOptionsBuilder();
    optionBuilder.UseSqlServer(constr);
var options = optionBuilder.Options;

using (var context = new ExternalDbContext(options))
{
    foreach (var wallet in context.Wallets)
    {

        Console.WriteLine(wallet);
    }
    Console.WriteLine();

}



// Dependency Injection using IserviceCollection 


var services = new ServiceCollection();

services.AddDbContext<ExternalDbContext>(options =>
options.UseSqlServer(constr)
);

IServiceProvider serviceProvider = services.BuildServiceProvider();

using (var context = serviceProvider.GetService<ExternalDbContext>())
{
    foreach (var wallet in context.Wallets)
    {

        Console.WriteLine(wallet);
    }

}

// ddcontext by using context factory
var servicess = new ServiceCollection();
servicess.AddDbContextFactory<ExternalDbContext>(options =>
options.UseSqlServer(constr)
// i can use logger here 
.LogTo(Console.WriteLine ,LogLevel.Information)
);
IServiceProvider serviceProvider1 = servicess.BuildServiceProvider();

var contextFactory = serviceProvider1
    .GetRequiredService<IDbContextFactory<ExternalDbContext>>();

using (var context = contextFactory.CreateDbContext())
{
    foreach (var wallet in context.Wallets)
    {

        Console.WriteLine(wallet);
    }

}



// context pooling


