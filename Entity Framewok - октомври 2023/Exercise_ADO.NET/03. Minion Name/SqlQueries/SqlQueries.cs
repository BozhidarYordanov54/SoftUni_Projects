namespace _03._Minion_Name.SqlQueries
{
    public class SqlQueries
    {
        public const string GetVillianById = @"SELECT [Name] From Villains WHERE Id = @Id";

        public const string GetOrderedMinionsByVillainId = @" SELECT ROW_NUMBER() OVER (ORDER BY m.[Name]) AS RowNum,
                          m.[Name],
                          m.[Age]
                          FROM MinionsVillains AS mv
                          JOIN Minions AS m ON mv.MinionId = m.Id
                          WHERE mv.VillainId = @Id
                          ORDER BY m.[Name]";
    }
}
