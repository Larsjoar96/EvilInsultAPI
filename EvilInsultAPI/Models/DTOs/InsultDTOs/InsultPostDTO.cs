namespace EvilInsultAPI.Models.DTOs.InsultDTOs
{
    public class InsultPostDTO
    {
        public string InsultName { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string InsultText { get; set; } = null!;
    }
}
