namespace _01._Initial_Setup.SQL_Queries
{
    public class SqlQuries
    {
        public const string GetVilliansWithNumberOfMinions = @"SELECT [Name], COUNT(*)[TotalMinions]
                                                        FROM Villains AS v
                                                        JOIN MinionsVillains AS mv ON mv.VillainId = v.Id
                                                        GROUP BY [Name]
                                                        HAVING COUNT(*) > 3
                                                        ORDER BY TotalMinions";
    }
}
