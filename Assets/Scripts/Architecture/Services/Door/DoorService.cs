using Architecture.Factory;
using Core.Hint;

namespace Architecture.Services.Door
{
    public class DoorService : IDoorService
    {
        private readonly DoorFactory _factory;
        private readonly HintWriter _hintWriter;

        private Door _door;

        public DoorService(DoorFactory factory, HintWriter hintWriter)
        {
            _factory = factory;
            _hintWriter = hintWriter;
            CreateDoor();
        }

        public void Open()
        {
            _door.Open();
            _hintWriter.Write(HintType.DoorOpen);
        }

        private void CreateDoor() => 
            _door = _factory.Create().GetComponent<Door>();
    }
}