namespace ApplicationCore.Entities.Common
{
    public class Person : EntityBaseWithGuid
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public Will Will { get; set; }
    }
}
