using System.Collections.Generic;

namespace AlumacSystem
{
    internal class Registration
    {
       
        public long UserId { set; get; }
        public string UserName { set; get; }
        public string FirstName { set; get; }
        public string LastName { set; get; }
        public string Email { set; get; }
        private List<Registration> RegistrationCollectionList = new List<Registration>();

        public List<Registration> RegistrationListCollectionList
        {
            get { return RegistrationCollectionList; }
            set { RegistrationCollectionList = value; }
        }
        string[] RegistrationArray { get; set; }
        public int[] MyNumbers { get; private set; }
    public Registration()
        {
            long UserId = 0;
            string UserName = "";
            string FirstName = "";
            string LastName = "";
            string Email = "";
        }
    }
}