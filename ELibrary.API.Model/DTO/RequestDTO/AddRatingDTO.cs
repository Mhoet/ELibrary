namespace ELibrary.API.Model.DTO.RequestDTO
{
    public class AddRatingDTO
    {
        public string UserId { get; set; }
        public string BookId { get; set; }
        public int RatedValue { get; set; }
    }
}