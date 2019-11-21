namespace System.Text.Json.Serialization
{
    public class JsonEnumNameAttribute : JsonAttribute
    {
        public JsonEnumNameAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; }
    }
}