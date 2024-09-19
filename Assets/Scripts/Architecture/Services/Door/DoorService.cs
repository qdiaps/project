using Architecture.Factory;

namespace Architecture.Services.Door
{
    public class DoorService : IDoorService
    {
        private readonly DoorFactory _factory;
        
        private Door _door;

        public DoorService(DoorFactory factory)
        {
            _factory = factory;
            CreateDoor();
        }

        public void Open() => 
            _door.Open();

        private void CreateDoor() => 
            _door = _factory.Create().GetComponent<Door>();
    }
}