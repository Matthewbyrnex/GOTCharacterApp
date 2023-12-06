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

        public class Book
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Isbn { get; set; }
        public List<string> Authors { get; set; }
        public int NumberOfPages { get; set; }
        public string Publisher { get; set; }
        public string Country { get; set; }
        public string MediaType { get; set; }
        public DateTime Released { get; set; }
        public List<string> Characters { get; set; }
        public List<string> PovCharacters { get; set; }
    }

        public class House
    {
        public string Url { get; set; }
        public string Name { get; set; }
        public string Region { get; set; }
        public string CoatOfArms { get; set; }
        public string Words { get; set; }
        public List<string> Titles { get; set; }
        public List<string> Seats { get; set; }
        public string CurrentLord { get; set; }
        public string Heir { get; set; }
        public string Overlord { get; set; }
        public string Founded { get; set; }
        public string Founder { get; set; }
        public string DiedOut { get; set; }
        public List<string> AncestralWeapons { get; set; }
        public List<string> CadetBranches { get; set; }
        public List<string> SwornMembers { get; set; }
    }
    
}
