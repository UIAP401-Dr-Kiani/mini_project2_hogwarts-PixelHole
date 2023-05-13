using System.Collections.Generic;

namespace hogwartsBingus.Base_Classes.SaveReadyPersonnel
{
    public class SaveReadyProfessor : SaveReadyAuthorizedPerson
    {
        public bool CanTeachAtMultipleClasses { get; protected set; }

        public SaveReadyProfessor(string firstName, string lastName, int birthYear, gender gender, Race race, List<string> subjectNames, LoginData login, int id, petType pet, bool hasBaggage, Location currentLocation, AuthorizationType authType, bool canTeachAtMultipleClasses) : base(firstName, lastName, birthYear, gender, race, subjectNames, login, id, pet, hasBaggage, currentLocation, authType)
        {
            CanTeachAtMultipleClasses = canTeachAtMultipleClasses;
        }
    }
}