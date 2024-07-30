// See https://aka.ms/new-console-template for more information
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Refit;
using Refit.Demo;

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices((_, services) =>
    {
        services
            .AddRefitClient<IUsersClient>()
            .ConfigureHttpClient(c => c.BaseAddress = new Uri("https://jsonplaceholder.typicode.com/"));
    }).Build();

//Create User
var usersClient = host.Services.GetRequiredService<IUsersClient>();
var user = new User
{
    Name = "alan farhadi",
    Email = "alan.f@marcopacs.com"
};
var userId = (await usersClient.CreateUser(user)).Id;
Console.WriteLine($"User with Id: {userId} created");

//Get User 
var existingUser = await usersClient.GetUser(1);
Console.WriteLine(existingUser);

//Update User
existingUser.Email = "alan.f@gmail.com";
var updatedUser = await usersClient.UpdateUser(existingUser.Id, existingUser);
Console.WriteLine($"User email updated to {updatedUser.Email}");

//Delete User
await usersClient.DeleteUser(userId);
Console.WriteLine($"Delete User {userId}Id's Succeeded!");

//GetAll
var users = await usersClient.GetAll();
foreach (var usr in users)
{
    Console.WriteLine(usr);
}
Console.WriteLine("CRUD By Relif Finished!");
