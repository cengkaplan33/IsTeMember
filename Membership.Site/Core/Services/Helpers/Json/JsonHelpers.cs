namespace Membership.Site.Services
{
    public static class JsonHelpers
    {
        public static JsonNetResult ToJsonResult(this ServiceResponse response)
        {
            Newtonsoft.Json.JsonConvert.SerializeObject(response);
            return new JsonNetResult(response);
        }

        //public static void SetSkipTakeTotal<T>(this ListResponse<T> response, SqlSelect query)
        //{
        //    response.Skip = query.Skip();
        //    response.Take = query.Take();
        //    if (response.Take == 0)
        //        response.TotalCount = response.Entities.Count + response.Skip;
        //}
    }
}