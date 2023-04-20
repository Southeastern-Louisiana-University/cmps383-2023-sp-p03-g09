using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SP23.P03.Web.Features.Authorization;
using SP23.P03.Web.Features.TrainStations;

namespace SP23.P03.Web.Data;

public static class SeedHelper
{
    public static async Task MigrateAndSeed(IServiceProvider serviceProvider)
    {
        var dataContext = serviceProvider.GetRequiredService<DataContext>();

        await dataContext.Database.MigrateAsync();

        await AddRoles(serviceProvider);
        await AddUsers(serviceProvider);

        await AddTrainStation(dataContext);
    }

    private static async Task AddUsers(IServiceProvider serviceProvider)
    {
        const string defaultPassword = "Password123!";
        var userManager = serviceProvider.GetRequiredService<UserManager<User>>();

        if (userManager.Users.Any())
        {
            return;
        }

        var adminUser = new User
        {
            UserName = "galkadi"
        };
        await userManager.CreateAsync(adminUser, defaultPassword);
        await userManager.AddToRoleAsync(adminUser, RoleNames.Admin);

        var bob = new User
        {
            UserName = "bob"
        };
        await userManager.CreateAsync(bob, defaultPassword);
        await userManager.AddToRoleAsync(bob, RoleNames.User);

        var sue = new User
        {
            UserName = "sue"
        };
        await userManager.CreateAsync(sue, defaultPassword);
        await userManager.AddToRoleAsync(sue, RoleNames.User);
    }

    private static async Task AddRoles(IServiceProvider serviceProvider)
    {
        var roleManager = serviceProvider.GetRequiredService<RoleManager<Role>>();
        if (roleManager.Roles.Any())
        {
            return;
        }
        await roleManager.CreateAsync(new Role
        {
            Name = RoleNames.Admin
        });

        await roleManager.CreateAsync(new Role
        {
            Name = RoleNames.User
        });
    }

    private static async Task AddTrainStation(DataContext dataContext)
    {
        var trainStations = dataContext.Set<TrainStation>();

        if (await trainStations.AnyAsync())
        {
            return;
        }

        for (int i = 0; i < 3; i++)
        {
            dataContext.Set<TrainStation>()
                .Add(new TrainStation
                {
                    Name = "EnTrack Hammond",
                    Address = "Hammond LA"
                });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
              {
                  Name = "EnTrack New Orleans",
                  Address = "New Orleans LA"
              });
            dataContext.Set<TrainStation>()
               .Add(new TrainStation
               {
                   Name = "EnTrack Slidell ",
                   Address = "Slidell LA"
               });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Picayune",
                Address = "Picayune MS"
            });
            dataContext.Set<TrainStation>()
                 .Add(new TrainStation
                 {
                     Name = "EnTrack Hattiesburg",
                     Address = "Hattiesburg MS"
                 });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Laurel",
                Address = "Laurel MS"
            });
            dataContext.Set<TrainStation>()
               .Add(new TrainStation
               {
                   Name = "EnTrack Biloxi",
                   Address = "Biloxi MS"
               });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Mobile",
                Address = "Mobile MS"
            });
            dataContext.Set<TrainStation>()
         .Add(new TrainStation
         {
             Name = "EnTrack Meridian",
             Address = "Meridian MS"
         });
            dataContext.Set<TrainStation>()
                 .Add(new TrainStation
                 {
                     Name = "EnTrack Yazoo City",
                     Address = "Yazoo City MS"
                 });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Jackson",
                Address = "Jackson MS"
            });
            dataContext.Set<TrainStation>()
               .Add(new TrainStation
               {
                   Name = "EnTrack Hazelhurst",
                   Address = "Hazelhurst MS"
               });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Brookhaven",
                Address = "Brookhaven MS"
            });
            dataContext.Set<TrainStation>()
         .Add(new TrainStation
         {
             Name = "EnTrack McComb",
             Address = "McComb MS"
         });
            dataContext.Set<TrainStation>()
                 .Add(new TrainStation
                 {
                     Name = "EnTrack Schriever",
                     Address = "Schriever LA"
                 });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack New Iberia",
                Address = "New Iberia LA"
            });
            dataContext.Set<TrainStation>()
               .Add(new TrainStation
               {
                   Name = "EnTrack Lafayette",
                   Address = "Lafayette LA"
               });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Lake Charles",
                Address = "Lake Charles LA"
            });


            dataContext.Set<TrainStation>()
           .Add(new TrainStation
           {
               Name = "EnTrack Beaumont",
               Address = "Beaumont TX "
           });
            dataContext.Set<TrainStation>()
         .Add(new TrainStation
         {
             Name = "EnTrack Houston",
             Address = "Houston TX"
         });
            dataContext.Set<TrainStation>()
                 .Add(new TrainStation
                 {
                     Name = "EnTrack Galveston",
                     Address = "Galveston TX"
                 });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Nacogdoches",
                Address = "Nacogodoches TX"
            });
            dataContext.Set<TrainStation>()
               .Add(new TrainStation
               {
                   Name = "EnTrack Prairie View",
                   Address = "Prairie View TX"
               });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Bryan",
                Address = "Bryan TX"
            });
            dataContext.Set<TrainStation>()
                       .Add(new TrainStation
                       {
                           Name = "EnTrack McGregor",
                           Address = "McGregor Tx"
                       });
            dataContext.Set<TrainStation>()
         .Add(new TrainStation
         {
             Name = "EnTrack Waco",
             Address = "Waco TX"
         });
            dataContext.Set<TrainStation>()
                 .Add(new TrainStation
                 {
                     Name = "EnTrack San Antonio",
                     Address = "San Antonio TX"
                 });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack San Marcos",
                Address = "San Marcos TX"
            });
            dataContext.Set<TrainStation>()
               .Add(new TrainStation
               {
                   Name = "EnTrack Austin ",
                   Address = "Austin TX"
               });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Temple",
                Address = "Temple TX"
            });



            dataContext.Set<TrainStation>()
     .Add(new TrainStation
     {
         Name = "EnTrack Killeen",
         Address = "Killen TX"
     });
            dataContext.Set<TrainStation>()
                 .Add(new TrainStation
                 {
                     Name = "EnTrack Cleburne",
                     Address = "Cleburne TX"
                 });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Forth Worth",
                Address = "Forth Worth TX"
            });
            dataContext.Set<TrainStation>()
               .Add(new TrainStation
               {
                   Name = "EnTrack Dalals",
                   Address = "Dallas TX"
               });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Mesquite",
                Address = "Mesquite TX"
            });
            dataContext.Set<TrainStation>()
                       .Add(new TrainStation
                       {
                           Name = "EnTrack Mineola",
                           Address = "Mineola Tx"
                       });
            dataContext.Set<TrainStation>()
         .Add(new TrainStation
         {
             Name = "EnTrack Longview",
             Address = "Longview TX"
         });
            dataContext.Set<TrainStation>()
                 .Add(new TrainStation
                 {
                     Name = "EnTrack Marshall",
                     Address = "Marshall TX"
                 });
            dataContext.Set<TrainStation>()
            .Add(new TrainStation
            {
                Name = "EnTrack Texarkana",
                Address = "Texarkana AK"
            });
            dataContext.Set<TrainStation>()
               .Add(new TrainStation
               {
                   Name = "EnTrack Shreveport ",
                   Address = "Shreveport lA"
               });
            



        }

        await dataContext.SaveChangesAsync();
    }
}