using System;
using System.Collections.Generic;
using System.Text;

namespace ApplicationCore.Helpers
{
    public static class ExtensionHelpers
    {
        public static bool IsGuid(this Guid guid)
        {
            return guid != Guid.Parse("{00000000-0000-0000-0000-000000000000}");
        }

        public static bool IsGuidEmpty(this Guid guid)
        {
            return guid == Guid.Parse("{00000000-0000-0000-0000-000000000000}");
        }

    }
}
