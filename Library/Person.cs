using System;
using System.Collections.Generic;
namespace CollegeConsole
{
    [Serializable]
    public class Person
    {
        static int regNo = 0;
        int registrationNumber = 0;
        string name;
        DateTime dateOfBirth;
        Address address = new Address();                    // object for the address struct
        uint telephoneNumber;

        // Properties

        public int RegistrationNumber
        {
            get { return registrationNumber; }
            // set { registrationNumber = value; }
        }

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public DateTime DOB
        {
            get { return dateOfBirth; }
            set { dateOfBirth = value; }
        }

        public uint TelephoneNumber
        {
            get { return telephoneNumber; }
            set { telephoneNumber = value; }
        }

        public Address Address
        {
            get { return address; }
            set { address = value; }
        }


        //Default constructor    

        public Person()
        {
            // RegistrationNumber = GetHashCode();
            registrationNumber = ++regNo;
            Name = null;
            DOB = new DateTime(01 / 01 / 1990);
            address.city = null;
            address.street = null;
            address.province = null;
            TelephoneNumber = 1234567890;
        }

        //The specified constructor

        public Person(string name, DateTime dob)
        {
            // RegistrationNumber = GetHashCode();
            registrationNumber = ++regNo;
            Name = name;
            DOB = dob;
            address.city = null;
            address.street = null;
            address.province = null;


        }

        // GetInfo method

        public override string ToString()
        {
            return string.Format("\nRegistration Number: {0} \tName: {1} \tDate Of Birth: {2}  \nAddress:  Street: {4} \tCity: {5} \tState: {6} \tTelephone Phone: {3}", RegistrationNumber, Name, DOB, TelephoneNumber, Address.street, Address.city, Address.province);

        }



    }




}
