namespace BirthdayCelebrations
{
    public class StartUp
    {
        public static void Main(string[] args)
        {
            List<INameBirthday> birthdates = new List<INameBirthday>();

            string command = string.Empty;
            while((command = Console.ReadLine()) != "End")
            {
                string[] cmdArgs = command.Split(' ');

                if (cmdArgs[0] == "Citizen")
                {
                    string name = cmdArgs[1];
                    int age = int.Parse(cmdArgs[2]);
                    string id = cmdArgs[3];
                    string bithdate = cmdArgs[4];

                    Citizen citizen = new Citizen(name, age, id, bithdate);
                    birthdates.Add(citizen);

                }
                else if (cmdArgs[0] == "Pet")
                {
                    string dogName = cmdArgs[1];
                    string dogId = cmdArgs[2];

                    Pet pet = new Pet(dogName, dogId);
                    birthdates.Add(pet);
                }
                else if (cmdArgs[0] == "Robot")
                {
                    string robotName = cmdArgs[1];
                    string robotId = cmdArgs[2];

                    Robot robot = new Robot(robotName, robotId);
                }
            }

            string yearToPrint = Console.ReadLine();

            foreach (INameBirthday birthdate in birthdates.Where(x => x.Birthdate.EndsWith(yearToPrint)))
            {
                Console.WriteLine(birthdate.Birthdate);
            }
        }
    }
}