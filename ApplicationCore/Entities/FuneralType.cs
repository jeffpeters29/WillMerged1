using ApplicationCore.Entities.Common;

namespace ApplicationCore.Entities
{
    public class FuneralType : EntityBaseWithGuid
    {
        public string Description { get; set; }

        public Will Will { get; set; }
    }
}
