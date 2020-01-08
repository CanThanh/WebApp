namespace Common
{
    public class SearchModel<T>
    {
        /// <summary>
        /// Tiêu chí tìm kiếm
        /// </summary>
        public T Cretia { get; set; }
        public int PageIndex { get; set; }
        public int PageSize { get; set; }
        public string ColumnOrder { get; set; }
        //public int DirectionOrder { get; set; }
    }
}
