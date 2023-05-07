using hogwartsBingus.Factions;

namespace hogwartsBingus.University.Excercies
{
    public interface IExercise
    {
        void PrepareExercise();
        void PerformExercise();
        void AwardPoints(Faction faction, int amount);
    }
}