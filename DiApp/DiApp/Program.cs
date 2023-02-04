
using System.Security.Cryptography;
using DiApp;
using DiApp.models;

var user = new User{Name = "Tom"};
var factory = new Factory();

var dbContext = factory.CreateDBContext(1);
dbContext.Save(user);
var dbContext2 = factory.CreateDBContext(2);
dbContext2.Save(user);