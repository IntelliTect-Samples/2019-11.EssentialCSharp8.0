namespace EssemtialCSharp8
{
    public class Address
    {
        public string Street1 { get; set; }
        public string? Street2 { get; set; }
        public string City { get; set; }
        public string Zip { get; set; }
        public string State { get; set; }
        public string Country { get; set; }

        public Address(
            string street1,
            string? street2,
            string city,
            string zip,
            string state,
            string country
        )
        {
            Street1 = street1;
            Street2 = street2;
            City = city;
            Zip = zip;
            State = state;
            Country = country;
        }

        public Address(
            string street1,
            string city,
            string zip,
            string state,
            string country
        ) : this(street1, null, city, zip, state, country)
        { }
    }
}
