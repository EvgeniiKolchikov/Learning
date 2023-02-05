

using DiApp3;

var pl  = new Player{Age = 15};
var post = Factory.SelectDb(1);
var sql = Factory.SelectDb(2);

post.Save(pl);
sql.Save(pl);
