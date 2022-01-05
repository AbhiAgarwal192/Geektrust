using War.Contracts;

namespace War.Entities
{
    public class Planet
    {
        private string _name;
        private Army _army;
        private IRules _rules;
        public string Name
        {
            get
            {
                return this._name;
            }
        }
        public Planet(string name, int horses, int elephants, int tanks, int guns, IRules rules)
        {
            this._name = name;
            this._army = new Army(horses,elephants,tanks,guns);
            this._rules = rules;
        }
        public string Defends(Army enemyArmy)
        {
            var deployedArmy = this._rules.DetermineTroopsToDeploy(this._army, enemyArmy, out string result);
            return $"{result} {deployedArmy.Horses}H {deployedArmy.Elephants}E {deployedArmy.Tanks}AT {deployedArmy.Guns}SG";
        }
    }
}
