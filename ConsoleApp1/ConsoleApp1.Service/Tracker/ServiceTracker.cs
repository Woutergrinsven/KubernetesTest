namespace ConsoleApp1.Service.Tracker
{
    public class ServiceTracker
    {
        private Dictionary<string, TrackedObject> trackedObjects = new Dictionary<string, TrackedObject>();

        public TrackedObject GetOrAddObject(string objectName)
        {
            trackedObjects.TryAdd(objectName, new TrackedObject());

            return trackedObjects[objectName];
        }
    }


    public class TrackedObject
    {
        public Guid Id { get; set; }
        public int Count { get; set; }

        public TrackedObject()
        {
            Id = Guid.NewGuid();
            Count = 0;
        }
    }
}
