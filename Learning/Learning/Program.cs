using System.Text.Json.Nodes;
using Learning;



var warrior = new Warrior(120, 35);
var slayer = new Slayer(80, 24);
var archer = new Archer(50, 30);

var units = new Unit[] { warrior, slayer, archer };
foreach (var unit in units)
{
    unit.Attack();
}
