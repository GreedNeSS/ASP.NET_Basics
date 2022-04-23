using System.Text.Json;
using System.Text.Json.Serialization;

namespace SendJSON
{
    public record Person(string Name, int Age);
    public class PersonConverter : JsonConverter<Person>
    {
        public override Person? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            string personName = "Undefined";
            int personAge = 0;

            while (reader.Read())
            {
                if (reader.TokenType == JsonTokenType.PropertyName)
                {
                    var propertyName = reader.GetString();
                    reader.Read();

                    switch (propertyName)
                    {
                        case "age" or "Age" when reader.TokenType == JsonTokenType.Number:
                            personAge = reader.GetInt32();
                            break;
                        case "age" or "Age" when reader.TokenType == JsonTokenType.String:
                            string? stringValue = reader.GetString();

                            if (int.TryParse(stringValue, out int value))
                            {
                                personAge = value;
                            }

                            break;
                        case "name" or "Name":
                            string? name = reader.GetString();

                            if (name != null)
                            {
                                personName = name;
                            }

                            break;
                    }
                }
            }

            return new Person(personName, personAge);
        }

        public override void Write(Utf8JsonWriter writer, Person value, JsonSerializerOptions options)
        {
            writer.WriteStartObject();
            writer.WriteString("name", value.Name);
            writer.WriteNumber("age", value.Age);

            writer.WriteEndObject();
        }
    }
}
