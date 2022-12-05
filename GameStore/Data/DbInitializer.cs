using GameStore.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace GameStore.Data
{
    public static class DbInitializer
    {
        public static void Initialize(GameStoreContext context)
        {
            context.Database.EnsureCreated();


            if (context.Games.Count() > 0)
            {
                return;
            }
            var games = new GameModel[]
             {
                new GameModel{GameName="Witcher 3", GameDescription="Witcher 3 game", GameDeveloper="CD PROJEKT RED", GamePublisher="CD PROJEKT RED", GameReleaseDate=DateTime.Parse("2008-09-16"), GamePrice=10},
                new GameModel{GameName="God Of War", GameDescription="God Of War 2 game", GameDeveloper="Santa Monica Studio", GamePublisher="Sony Interactive Entertainment", GameReleaseDate=DateTime.Parse("2022-11-9"), GamePrice=49.99},
                new GameModel{GameName="League of Legends", GameDescription="League Of Legends game", GameDeveloper="Riot Games", GamePublisher="Riot Games", GameReleaseDate=DateTime.Parse("2009-10-27"), GamePrice=0},
                new GameModel{GameName="PayDay", GameDescription="Payday 2 game", GameDeveloper="Overkill Software", GamePublisher="505 Games", GameReleaseDate=DateTime.Parse("2009-10-27"), GamePrice=9.99},
                new GameModel{GameName="Witcher 3", GameDescription="Minecraft", GameDeveloper="Microsoft Mojang", GamePublisher="Sony Interactive Entertainment", GameReleaseDate=DateTime.Parse("2008-09-16"), GamePrice=29.99},
             };
            foreach (GameModel g in games)
            {
                context.Games.Add(g);
            }
            context.SaveChanges();

            var users = new UserModel[]
            {
            new UserModel{UserName="DavitJ1",FirstName="Daviti",LastName="Janjalia", Email = "D@gmail.com",Country="Georgia"},
            new UserModel{UserName="DavitA1",FirstName="Davti",LastName="Abesalashvili", Email = "Davit@gmail.com",Country="Georgia"},
            new UserModel{UserName="LevaniS1",FirstName="Levani",LastName="Shengelia" , Email = "Levani@gmail.com",Country="Georgia"},
            new UserModel{UserName="Gelsona5",FirstName="Gela",LastName="Samsonadze", Email = "gelasamsona@gmail.com",Country="Georgia"},
            new UserModel{UserName="Pavlovichi",FirstName="Petre",LastName="Xachapuridze",Email="xachapura@yahoo.com",Country="Georgia"},
            new UserModel{UserName="Zouraba22",FirstName="Salome",LastName="Zurabishvili",Email="prezidenta@gmail.com",Country="Georgia"},
            new UserModel{UserName="DWill",FirstName="Luffy",LastName="Monkey D",Email="Luffytaro@OnePiece.com",Country="Goa Kingdom"}
            };
            foreach (UserModel c in users)
            {
                context.Users.Add(c);
            }
            context.SaveChanges();

            var currency = new CurrencyModel[]
             {
                new CurrencyModel{CurrencyName="GEL"},
                new CurrencyModel{CurrencyName="USD"}
             };
            foreach (CurrencyModel c in currency)
            {
                context.Currencys.Add(c);
            }
            context.SaveChanges();


            var roles = new RoleModel[]
             {
                new RoleModel{RoleName="Administrator" },
                new RoleModel{RoleName="Customer" },
             };
            foreach (RoleModel g in roles)
            {
                context.Roles.Add(g);
            }
            context.SaveChanges();

            var genders = new GenderModel[]
            {
                new GenderModel{GenderName="Male" },
                new GenderModel{GenderName="Female" },
                new GenderModel{GenderName="Other" },
            };
            foreach (GenderModel g in genders)
            {
                context.Genders.Add(g);
            }
            context.SaveChanges();

            var payMentTypes = new PaymentTypeModel[]
            {
                new PaymentTypeModel{PaymentTypeName="Debit Card" },
                new PaymentTypeModel{PaymentTypeName="Credit Card" },
                new PaymentTypeModel{PaymentTypeName="Bank Transfer" },
                new PaymentTypeModel{PaymentTypeName="PayPal" },
            };
            foreach (PaymentTypeModel g in payMentTypes)
            {
                context.PaymentTypes.Add(g);
            }
            context.SaveChanges();


            var genres = new GenreModel[]
            {
            new GenreModel{GenreName="Strategy",Children = new List<GenreModel>
            {
                new GenreModel{GenreName="FPS"},
                new GenreModel{GenreName="TPS"}
            }},
            new GenreModel{GenreName="Chxubebi"},
            new GenreModel{GenreName="Action"},
            new GenreModel{GenreName="Simulation"},
            new GenreModel{GenreName="Arcade"},
            new GenreModel{GenreName="Puzzle"},
            };
            foreach (GenreModel c in genres)
            {
                context.Genres.Add(c);
            }
            context.SaveChanges();

            var gamesAndGenres = new GamesAndGenresModel[]
{
            new GamesAndGenresModel{GameId=3,GenreId=6},
            new GamesAndGenresModel{GameId=2,GenreId=8},
            new GamesAndGenresModel{GameId=1,GenreId=1},
            new GamesAndGenresModel{GameId=4,GenreId=4},
            new GamesAndGenresModel{GameId = 5,GenreId = 4},
};
            foreach (GamesAndGenresModel c in gamesAndGenres)
            {
                context.GamesAndGenres.Add(c);
            }
            context.SaveChanges();
        }
    }
}