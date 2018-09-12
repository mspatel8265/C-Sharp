using System;
namespace CollegeConsole
{
    [Serializable]
    public struct Address
    {
        public string street;
        public string city;
        public string province;

        public Address(string street, string city, string province)
        {
            this.street = street;
            this.city = city;
            this.province = province;
        }

    }
}
