namespace BirthdayCelebrations
{
    public class Robot : IId
    {
        public Robot(string model, string Id)
        {
            Model = model;
            this.Id = Id;
        }
        public string Model { get; }
        public string Id { get; } 
    
    }
}