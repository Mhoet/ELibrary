namespace ELibrary.API.Model.DTO.RequestDTO
{
    public class SearchBookRequestDTO
    {
        public string SearchWord { get; set; }
        public int PageNo { get; set; }
        public int PageCount { get; set; }
    }
}