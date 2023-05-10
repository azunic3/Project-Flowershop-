using Microsoft.VisualBasic;

namespace Ayana.Models
{
    public class Employee: Person
    {
        int id;
        string phoneNumber;
        string homeAddress;
        DateAndTime dateOfBirth;

        public Employee()
        {

        }

        public int Id { get => id; set => id = value; }
        public string PhoneNumber { get => phoneNumber; set => phoneNumber = value; }
        public string HomeAddress { get => homeAddress; set => homeAddress = value; }
        public DateAndTime DateOfBirth { get => dateOfBirth; set => dateOfBirth = value; }
    }
}
