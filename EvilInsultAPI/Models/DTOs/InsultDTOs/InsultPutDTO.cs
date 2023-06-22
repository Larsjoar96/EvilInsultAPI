namespace EvilInsultAPI.Models.DTOs.InsultDTOs
{
    public class InsultPutDTO
    {
        public int Id { get; set; }
        public string InsultName { get; set; } = null!;
        public string AuthorName { get; set; } = null!;
        public string Language { get; set; } = null!;
        public string InsultText { get; set; } = null!;
    }
}

