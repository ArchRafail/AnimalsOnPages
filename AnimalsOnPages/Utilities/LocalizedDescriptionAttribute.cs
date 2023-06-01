using System.ComponentModel;

namespace AnimalsOnPages.Utilities
{
    public class LocalizedDescriptionAttribute : DescriptionAttribute
    {
        private readonly string _resourceKey;
        private readonly ComponentResourceManager _resource;
        public LocalizedDescriptionAttribute(string resourceKey, Type resourceType)
        {
            _resource = new ComponentResourceManager(resourceType);
            _resourceKey = resourceKey;
        }

        public override string Description
        {
            get
            {
                string displayName = _resource.GetString(_resourceKey);

                return string.IsNullOrEmpty(displayName)
                    ? string.Format("[[{0}]]", _resourceKey)
                    : displayName;
            }
        }
    }
}
