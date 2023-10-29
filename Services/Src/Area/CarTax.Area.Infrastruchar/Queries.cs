

using Dapper;
using static CarTax.Area.Message.Projections.ReadModels;
using static CarTax.Area.Message.Projections.QueryModels;
using System.Data;

namespace CarTax.Area.Message
{
    public static class Queries
    {
        public static async Task<IEnumerable<V1.IsChackAreaId>> Query(this IDbConnection connection, ExistsAreaId query)
        => await connection.QueryAsync<V1.IsChackAreaId>(
                         " SELECT TOP 1 1 as \"Exists\" FROM Area WHERE Id = @id ",
                         new
                         {
                             id = query.AreaId
                         });


      
        private static int Offset(int PageNo, int RowCountPerPage) => (PageNo - 1) * RowCountPerPage;
    }
}