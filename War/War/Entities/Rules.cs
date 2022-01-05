namespace War.Entities
{
    using War.Constants;
    using War.Contracts;
    public class Rules : IRules
    {
        private int Lengaburu_To_Falicornia_Battalion_Strength_Ratio = 2;

        private Army DetermineMinimumArmyRequiredToWinUsingPowerRule(Army defendingArmy, Army attackingArmy)
        {
            var armyToDeploy = new Army(0, 0, 0, 0)
            {
                Horses = attackingArmy.Horses % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? attackingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : attackingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1,
                Elephants = attackingArmy.Elephants % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? attackingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : attackingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1,
                Tanks = attackingArmy.Tanks % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? attackingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : attackingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1,
                Guns = attackingArmy.Guns % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? attackingArmy.Guns / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : attackingArmy.Guns / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1
            };

            return armyToDeploy;
        }
        private void DetermineBattalionForHorses(Army defendingArmy, Army armyToDeploy, Army minimumTroopsNeededToWin)
        {
            if (minimumTroopsNeededToWin.Horses <= defendingArmy.Horses)
            {
                defendingArmy.Horses -= minimumTroopsNeededToWin.Horses;
                armyToDeploy.Horses = minimumTroopsNeededToWin.Horses;
            }
            else
            {
                int numberOfHorsesShortBy = minimumTroopsNeededToWin.Horses - defendingArmy.Horses;
                armyToDeploy.Horses = defendingArmy.Horses;
                defendingArmy.Horses = 0;
                minimumTroopsNeededToWin.Elephants += numberOfHorsesShortBy % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? numberOfHorsesShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : numberOfHorsesShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;
            }

        }
        private void DetermineBattalionForElephants(Army defendingArmy, Army armyToDeploy, Army minimumTroopsNeededToWin)
        {
            if (minimumTroopsNeededToWin.Elephants <= defendingArmy.Elephants)
            {
                defendingArmy.Elephants -= minimumTroopsNeededToWin.Elephants;
                armyToDeploy.Elephants = minimumTroopsNeededToWin.Elephants;
            }
            else
            {

                int numberOfElephantsShortBy = minimumTroopsNeededToWin.Elephants - defendingArmy.Elephants;
                armyToDeploy.Elephants = defendingArmy.Elephants;
                defendingArmy.Elephants = 0;

                if (defendingArmy.Horses > 0)
                {
                    //use horses to replace elephants.
                    if (defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio >= numberOfElephantsShortBy) //horses can cover for elephants
                    {
                        armyToDeploy.Horses += Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfElephantsShortBy;
                        defendingArmy.Horses -= Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfElephantsShortBy;
                        numberOfElephantsShortBy = 0;
                    }
                    else
                    {
                        //use remaining horse.
                        numberOfElephantsShortBy -= defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                        armyToDeploy.Horses += (defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                        defendingArmy.Horses -= (defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                    }
                }

                minimumTroopsNeededToWin.Tanks += numberOfElephantsShortBy % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? numberOfElephantsShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : numberOfElephantsShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;
            }

        }
        private void DetermineBattalionForTanks(Army defendingArmy, Army armyToDeploy, Army minimumTroopsNeededToWin)
        {
            if (minimumTroopsNeededToWin.Tanks <= defendingArmy.Tanks)
            {
                defendingArmy.Tanks -= minimumTroopsNeededToWin.Tanks;
                armyToDeploy.Tanks = minimumTroopsNeededToWin.Tanks;
            }
            else //not enough tanks.
            {
                int numberOfTanksShortBy = minimumTroopsNeededToWin.Tanks - defendingArmy.Tanks;
                armyToDeploy.Tanks = defendingArmy.Tanks;
                defendingArmy.Tanks = 0;

                if (defendingArmy.Elephants > 0)
                {
                    //use elephants to replace tanks.
                    if (defendingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio >= numberOfTanksShortBy) //elephants can cover for tanks
                    {
                        armyToDeploy.Elephants += Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfTanksShortBy;
                        defendingArmy.Elephants -= Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfTanksShortBy;
                        numberOfTanksShortBy = 0;
                    }
                    else
                    {
                        //use remaining elephants.
                        numberOfTanksShortBy -= defendingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                        armyToDeploy.Elephants += (defendingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                        defendingArmy.Elephants -= (defendingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                    }
                }

                minimumTroopsNeededToWin.Guns += numberOfTanksShortBy % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? numberOfTanksShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : numberOfTanksShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;
            }

        }
        private void DetermineBattalionForGuns(Army defendingArmy, Army armyToDeploy, Army minimumTroopsNeededToWin)
        {
            if (minimumTroopsNeededToWin.Guns <= defendingArmy.Guns)
            {
                defendingArmy.Guns -= minimumTroopsNeededToWin.Guns;
                armyToDeploy.Guns = minimumTroopsNeededToWin.Guns;
            }
            else //not enough Guns.
            {
                numberOfGunsShortBy = minimumTroopsNeededToWin.Guns - defendingArmy.Guns;
                armyToDeploy.Guns = defendingArmy.Guns;
                defendingArmy.Guns = 0;

                if (defendingArmy.Tanks > 0)
                {
                    //use Tanks to replace guns.
                    if (defendingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio >= numberOfGunsShortBy) //Tanks can cover for guns
                    {
                        armyToDeploy.Tanks += Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfGunsShortBy;
                        defendingArmy.Tanks -= Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfGunsShortBy;
                        numberOfGunsShortBy = 0;
                    }
                    else
                    {
                        //use remaining Tanks.
                        numberOfGunsShortBy -= defendingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                        if (numberOfGunsShortBy == 1)
                        {
                            armyToDeploy.Tanks += 1;
                            defendingArmy.Tanks -= 1;
                        }
                        else
                        {
                            armyToDeploy.Tanks += (defendingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                            defendingArmy.Tanks -= (defendingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                        }
                    }
                }
            }

        }
        
        private void DetermineBattalion(Army defendingArmy, Army attackingArmy, Army minimumTroopsNeededToWin, BattalionType type)
        {

            var defendingBattalion = new Battalion();
            foreach (var troop in defendingArmy.Battalions)
            {
                if (troop.Type == type)
                {
                    defendingBattalion = troop;
                    break;
                }
            }

            var attackingBattalion = new Battalion();
            foreach (var troop in attackingArmy.Battalions)
            {
                if (troop.Type == type)
                {
                    attackingBattalion = troop;
                    break;
                }
            }


            if (minimumTroopsNeededToWin.Elephants <= defendingArmy.Elephants)
            {
                defendingArmy.Elephants -= minimumTroopsNeededToWin.Elephants;
                armyToDeploy.Elephants = minimumTroopsNeededToWin.Elephants;
            }
            else
            {

                int numberOfElephantsShortBy = minimumTroopsNeededToWin.Elephants - defendingArmy.Elephants;
                armyToDeploy.Elephants = defendingArmy.Elephants;
                defendingArmy.Elephants = 0;

                if (defendingArmy.Horses > 0)
                {
                    //use horses to replace elephants.
                    if (defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio >= numberOfElephantsShortBy) //horses can cover for elephants
                    {
                        armyToDeploy.Horses += Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfElephantsShortBy;
                        defendingArmy.Horses -= Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfElephantsShortBy;
                        numberOfElephantsShortBy = 0;
                    }
                    else
                    {
                        //use remaining horse.
                        numberOfElephantsShortBy -= defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                        armyToDeploy.Horses += (defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                        defendingArmy.Horses -= (defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
                    }
                }

                minimumTroopsNeededToWin.Tanks += numberOfElephantsShortBy % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? numberOfElephantsShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : numberOfElephantsShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;
            }
        }

        public Army DetermineTroopsToDeploy(Army defendingArmy, Army attackingArmy, out string warResult)
        {
            var armyToDeploy = new Army(0, 0, 0, 0);
            warResult = Result.WINS;

            var minimumTroopsNeededToWin = DetermineMinimumArmyRequiredToWinUsingPowerRule(defendingArmy, attackingArmy);
            DetermineBattalionForHorses(defendingArmy, armyToDeploy, minimumTroopsNeededToWin);
            DetermineBattalionForElephants(defendingArmy, armyToDeploy, minimumTroopsNeededToWin);
            DetermineBattalionForTanks(defendingArmy, armyToDeploy, minimumTroopsNeededToWin);
            DetermineBattalionForGuns(defendingArmy, armyToDeploy, minimumTroopsNeededToWin);

            int numberOfGunsShortBy = 0;
            if (numberOfGunsShortBy > 0)
            {
                warResult = Result.LOSES;
            }

            return armyToDeploy;

        }

        //public Army DetermineTroopsToDeploy(Army defendingArmy, Army attackingArmy, out string warResult)
        //{
        //    var armyToDeploy = new Army(0,0,0,0);
        //    warResult = Result.WINS;

        //    //Determine using Power Rule.
        //    int minimumHorsesRequiredToWin = attackingArmy.Horses % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? attackingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : attackingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;
        //    int minimumElephantRequiredToWin = attackingArmy.Elephants % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? attackingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : attackingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;
        //    int minimumTanksRequiredToWin = attackingArmy.Tanks % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? attackingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : attackingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;
        //    int minimumGunsRequiredToWin = attackingArmy.Guns % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? attackingArmy.Guns / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : attackingArmy.Guns / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;

        //    int numberOfGunsShortBy = 0;

        //    if (minimumHorsesRequiredToWin <= defendingArmy.Horses)
        //    {
        //        defendingArmy.Horses -= minimumHorsesRequiredToWin;
        //        armyToDeploy.Horses = minimumHorsesRequiredToWin;
        //    }
        //    else
        //    {
        //        int numberOfHorsesShortBy = minimumHorsesRequiredToWin - defendingArmy.Horses;
        //        armyToDeploy.Horses = defendingArmy.Horses;
        //        defendingArmy.Horses = 0;
        //        minimumElephantRequiredToWin += numberOfHorsesShortBy % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? numberOfHorsesShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : numberOfHorsesShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;
        //    }

        //    if (minimumElephantRequiredToWin <= defendingArmy.Elephants)
        //    {
        //        defendingArmy.Elephants -= minimumElephantRequiredToWin;
        //        armyToDeploy.Elephants = minimumElephantRequiredToWin;
        //    }
        //    else
        //    {

        //        int numberOfElephantsShortBy = minimumElephantRequiredToWin - defendingArmy.Elephants;
        //        armyToDeploy.Elephants = defendingArmy.Elephants;
        //        defendingArmy.Elephants = 0;

        //        if (defendingArmy.Horses > 0)
        //        {
        //            //use horses to replace elephants.
        //            if (defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio >= numberOfElephantsShortBy) //horses can cover for elephants
        //            {
        //                armyToDeploy.Horses += Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfElephantsShortBy;
        //                defendingArmy.Horses -= Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfElephantsShortBy;
        //                numberOfElephantsShortBy = 0;
        //            }
        //            else
        //            {
        //                //use remaining horse.
        //                numberOfElephantsShortBy -= defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
        //                armyToDeploy.Horses += (defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
        //                defendingArmy.Horses -= (defendingArmy.Horses / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
        //            }
        //        }

        //        minimumTanksRequiredToWin += numberOfElephantsShortBy % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? numberOfElephantsShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : numberOfElephantsShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;
        //    }

        //    if (minimumTanksRequiredToWin <= defendingArmy.Tanks)
        //    {
        //        defendingArmy.Tanks -= minimumTanksRequiredToWin;
        //        armyToDeploy.Tanks = minimumTanksRequiredToWin;
        //    }
        //    else //not enough tanks.
        //    {
        //        int numberOfTanksShortBy = minimumTanksRequiredToWin - defendingArmy.Tanks;
        //        armyToDeploy.Tanks = defendingArmy.Tanks;
        //        defendingArmy.Tanks = 0;

        //        if (defendingArmy.Elephants > 0)
        //        {
        //            //use elephants to replace tanks.
        //            if (defendingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio >= numberOfTanksShortBy) //elephants can cover for tanks
        //            {
        //                armyToDeploy.Elephants += Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfTanksShortBy;
        //                defendingArmy.Elephants -= Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfTanksShortBy;
        //                numberOfTanksShortBy = 0;
        //            }
        //            else
        //            {
        //                //use remaining elephants.
        //                numberOfTanksShortBy -= defendingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
        //                armyToDeploy.Elephants += (defendingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
        //                defendingArmy.Elephants -= (defendingArmy.Elephants / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
        //            }
        //        }

        //        minimumGunsRequiredToWin += numberOfTanksShortBy % Lengaburu_To_Falicornia_Battalion_Strength_Ratio == 0 ? numberOfTanksShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio : numberOfTanksShortBy / Lengaburu_To_Falicornia_Battalion_Strength_Ratio + 1;
        //    }

        //    if (minimumGunsRequiredToWin <= defendingArmy.Guns)
        //    {
        //        defendingArmy.Guns -= minimumGunsRequiredToWin;
        //        armyToDeploy.Guns = minimumGunsRequiredToWin;
        //    }
        //    else //not enough Guns.
        //    {
        //        numberOfGunsShortBy = minimumGunsRequiredToWin - defendingArmy.Guns;
        //        armyToDeploy.Guns = defendingArmy.Guns;
        //        defendingArmy.Guns = 0;

        //        if (defendingArmy.Tanks > 0)
        //        {
        //            //use Tanks to replace guns.
        //            if (defendingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio >= numberOfGunsShortBy) //Tanks can cover for guns
        //            {
        //                armyToDeploy.Tanks += Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfGunsShortBy;
        //                defendingArmy.Tanks -= Lengaburu_To_Falicornia_Battalion_Strength_Ratio * numberOfGunsShortBy;
        //                numberOfGunsShortBy = 0;
        //            }
        //            else
        //            {
        //                //use remaining Tanks.
        //                numberOfGunsShortBy -= defendingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
        //                if (numberOfGunsShortBy == 1)
        //                {
        //                    armyToDeploy.Tanks += 1;
        //                    defendingArmy.Tanks -= 1;
        //                }
        //                else
        //                {
        //                    armyToDeploy.Tanks += (defendingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
        //                    defendingArmy.Tanks -= (defendingArmy.Tanks / Lengaburu_To_Falicornia_Battalion_Strength_Ratio) * Lengaburu_To_Falicornia_Battalion_Strength_Ratio;
        //                }
        //            }
        //        }
        //    }

        //    if (numberOfGunsShortBy>0)
        //    {
        //        warResult = Result.LOSES;
        //    }

        //    return armyToDeploy;

        //}
    }
}
