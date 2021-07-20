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
        public List<Registration> RegistrationCollectionList = new List<Registration>();

        public List<Registration> RegistrationListCollectionList
        {
            get { return RegistrationCollectionList; }
            set { RegistrationCollectionList = value; }
        }
        string[] RegistrationArray { get; set; }
        public int[] MyNumbers { get; private set; }
    }
}