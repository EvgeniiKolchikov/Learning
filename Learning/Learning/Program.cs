using System.Text.Json.Nodes;
using Learning;



var warrior = new Warrior(120, 30);
var slayer = new Slayer(80, 24);
var archer = new Archer(50, 12);
var player = new Player(250, 29, WeaponTypeEnum.Axe);

var enemies = new Unit[] { warrior, slayer, archer };

var battle = new BattleField(enemies, player);

Console.WriteLine("Press Enter To Next Step");
battle.Fight();

Console.Read();



