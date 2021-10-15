namespace ELibrary.API.Model.DTO.RequestDTO
{
    public class AddReviewDTO
    {
        public string BookId { get; set; }
        public string Comment { get; set; }
        public string UserId { get; set; }
    }
}