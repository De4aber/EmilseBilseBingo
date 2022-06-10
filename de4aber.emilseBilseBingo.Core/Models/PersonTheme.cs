namespace de4aber.emilseBilseBingo.Core.Models
{
    public class PersonTheme
    {
        public PersonTheme(string color)
        {
            Color = color;
        }

        public int Id { get; set; } = -1;
        public string Color { get; set; }
        public int TakenByPersonId { get; set; } = -1;
        
        public Person? TakenBy { get; set; }

        public bool GetIsTaken()
        {
            return TakenByPersonId >= 0;
        }

    }
}