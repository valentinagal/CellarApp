namespace WineCellar.API.Models.Wines
{
    public class CreateWine
    {
        public string Name { get; set; }
        public string WineMaker { get; set; }
        public int Year { get; set; }
        public int Score { get; set; }
        public string Description { get; set; }

        public string ImageURL { get; set; }
    }
}
