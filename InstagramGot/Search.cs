using InstagramGot.QueryExecutor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using InstagramGot.Parameters;

namespace InstagramGot
{
    public static class Search
    {
        private static ISearchQueryExecutor searchQueryExecutor = new SearchQueryExecutor();

        /// <summary>
        /// Get list of users(with minified data) who match with specified query.
        /// </summary>
        /// <exception cref="Exceptions.InstagramAPICallException">Instagram api exception.</exception>
        public static List<Models.IMinifiedUser> GetUsers(ISearchUserParameters _params)
        {
            try
            {
                return searchQueryExecutor.SearchUsers(_params);
            }
            catch (Exceptions.InstagramAPICallException e)
            {
                throw e;
            }
        }
    }
}
