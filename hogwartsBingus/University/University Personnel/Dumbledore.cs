using System;
using System.Collections.Generic;
using hogwartsBingus.DataStorage;
using hogwartsBingus.Execptions;
using hogwartsBingus.University;

namespace hogwartsBingus.Base_Classes
{
    public sealed class Dumbledore : AuthorizedPerson
    {
        public static Dumbledore Instance;

        /*
         Needs to be Public so it can be serialized by the Json convertor class. cant find another solution
         so it will be this for now
         */
        
        // ReSharper disable once MemberCanBePrivate.Global
        public Dumbledore(string firstName,
            string lastName,
            int birthYear,
            gender gender,
            Race race,
            LoginData login,
            int id)
            : base(firstName, lastName, birthYear, gender, race, login, id)
        {
            AuthType = AuthorizationType.Dumbledore;
            FullName = "Albus Dumbledore";
        }
    }
}