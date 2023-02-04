
using DiApp2;


var factory = new Factory();
factory.Save(new User{Name = "Max"},2);

var custom = new CustomDb();
factory.Save(custom,new User{Name = "Tom"});