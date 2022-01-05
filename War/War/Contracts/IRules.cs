using System.Diagnostics.CodeAnalysis;
using War.Entities;

namespace War.Contracts
{
    public interface IRules
    {
        Army DetermineTroopsToDeploy(Army defendingArmy, Army attackingArmy, out string warResult);
    }
}
