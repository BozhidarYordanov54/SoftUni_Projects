namespace Stealer
{
    public class Hacker
    {
        public string username = "securityGod82";
        private string password = "mySuperSecretPassw0rd";

        public string Password
        {
            get { return password; }
            set
            {
                password = value;
            }
        }

        public int Id { get; set; }
        public double BankAccountBalance { get; private set; }

        public void DownloadAllBankAccountsInTheWorld()
        {

        }
    }
}