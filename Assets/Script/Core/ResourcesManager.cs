using UnityEngine;

namespace Jam
{
    public static class ResourcesManager
    {
        public static T Load<T>(string path) where T : Object
        {
            return Resources.Load<T>(path);
        }

        public static ResourceRequest LoadAsync<T>(string path) where T : Object
        {
            return Resources.LoadAsync<T>(path);
        }
    }
}