using System.Collections.Generic;
using System.Linq;

namespace Algorithm
{
    public class Finder
    {
        private readonly List<Person> _pPersons;

        public Finder(List<Person> pPersons)
        {
            _pPersons = pPersons;
        }

        //Loop through the list of people to find the people who have the closest or furthest apart birthdays.
        public Comparison FindBirthdaySpreadByType(BirthdaySpreadType birthdaySpreadType)
        {
            if (_pPersons.Count < 2)
            {
                return new Comparison();
            }

            var lstComparisons = new List<Comparison>();

            //Loop through each person in the list.
            for(var intPersonIndex = 0; intPersonIndex < _pPersons.Count - 1; intPersonIndex++)
            {
                //Loop through each person in the list and compare birthdates to the parent person index to get age differences.
                for(var pPersonCompare = intPersonIndex + 1; pPersonCompare < _pPersons.Count; pPersonCompare++)
                {
                    var cResult = new Comparison();

                    if(_pPersons[intPersonIndex].dtBirthDate < _pPersons[pPersonCompare].dtBirthDate)
                    {
                        cResult.pOlderPerson = _pPersons[intPersonIndex];
                        cResult.pYoungerPerson = _pPersons[pPersonCompare];
                    }
                    else
                    {
                        cResult.pOlderPerson = _pPersons[pPersonCompare];
                        cResult.pYoungerPerson = _pPersons[intPersonIndex];
                    }
                    cResult.tsAgeDifference = cResult.pYoungerPerson.dtBirthDate - cResult.pOlderPerson.dtBirthDate;
                    lstComparisons.Add(cResult);
                }
            }

            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //This would only run if there were a single person in the list. So that situation is handled in the if statement in the beginning of the method. Normally I'd just delete this code. --
            //--------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
            //if(lstComparisons.Count < 1)
            //{
            //    return new Comparison();
            //}

            return birthdaySpreadType == BirthdaySpreadType.Widest ? lstComparisons.OrderByDescending(compare => compare.tsAgeDifference).FirstOrDefault() : lstComparisons.OrderBy(compare => compare.tsAgeDifference).FirstOrDefault();

            //------------------------------------------------------------------------------
            //Replaced with a ternary LINQ statment. Normally I'd just delete this code. ---
            //------------------------------------------------------------------------------

            //foreach (var result in lstComparisons)
            //{
            //    switch(birthdaySpreadType)
            //    {
            //        case BirthdaySpreadType.Narrowest:
            //            if(result.tsAgeDifference < answer.tsAgeDifference)
            //            {
            //                answer = result;
            //            }
            //            break;

            //        case BirthdaySpreadType.Widest:
            //            if(result.tsAgeDifference > answer.tsAgeDifference)
            //            {
            //                answer = result;
            //            }
            //            break;
            //    }
            //}

        }
    }
}