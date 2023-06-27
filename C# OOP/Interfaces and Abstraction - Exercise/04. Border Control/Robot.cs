namespace BorderControl
{
    public class Robot : IId, IRobot
    {
        public Robot(string model, string id)
        {
            Model = model;
            Id = id;
        }
        public string Id { get; }

        public string Model { get; }
    }
}