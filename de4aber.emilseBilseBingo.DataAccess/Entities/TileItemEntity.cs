using System.Data.Common;

namespace de4aber.emilseBilseBingo.DataAcess.Entities
{
    public class TileItemEntity
    {
        public TileItemEntity(string condition, int ofPersonId)
        {
            Condition = condition;
            OfPersonId = ofPersonId;
        }

        public int Id { get; set; }
        public string Condition { get; set; }
        public int OfPersonId { get; set; }
    }
}