namespace ManagementSystem.Common.GenericModels
{
    public class TPagination<TModel> where TModel : class
    {
        public int TotalItems { get; set; }

        public IList<TModel> Items { get; set; }
    }
}
