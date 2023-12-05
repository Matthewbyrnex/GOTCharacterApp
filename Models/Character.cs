namespace GOTCharacterApp.Models
{
    public class Character
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get; set; }
        public string Title { get; set; }
        public string Family { get; set; }
        public string Image { get; set; }
        public string ImageUrl { get; set; }
    }

        public class IceAndFireCharacter
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Gender { get; set; }
        public string Culture { get; set; }
        public string Born { get; set; }
        public string Died { get; set; }
        public List<string> Titles { get; set; }
        public List<string> Aliases { get; set; }
        public string Spouse { get; set; }
        public List<string> Allegiances { get; set; }
        public List<string> Books { get; set; }
        public List<string> PovBooks { get; set; }
        public List<string> TvSeries { get; set; }
        public List<string> PlayedBy { get; set; }
    }
}
