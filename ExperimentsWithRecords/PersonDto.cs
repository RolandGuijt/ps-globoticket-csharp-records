namespace ExperimentsWithRecords
{
    public record PersonDto(string Name)
    {
        public PersonDto(): this("Empty")
        {

        }

        public void Deconstruct(out string name, out string city)
        {
            name = Name;
            city = City;
        }

        public string City { get; init; }

        public void SomeMethod()
        {

        }
    }
}
