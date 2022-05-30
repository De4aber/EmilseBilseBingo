namespace de4aber.emilseBilseBingo.Core.Models
{
    public class TileItem
    {
        public TileItem(string condition, int ofPersonId)
        {
            Condition = condition;
            OfPersonId = ofPersonId;
        }

        public int Id { get; set; } = -1;
        public string Condition { get; set; }
        public int OfPersonId { get; set; }

        public Person? OfPerson { get; set; }


    }
}