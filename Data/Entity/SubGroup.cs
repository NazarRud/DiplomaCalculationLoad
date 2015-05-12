namespace Data.Entity
{
    public class SubGroup
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CountStudent { get; set; }

        public virtual Flow Flow { get; set; }

    }
}
