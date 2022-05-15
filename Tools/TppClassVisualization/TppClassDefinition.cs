public class Class
{
    public string category { get; set; }
    public Function[] functions { get; set; }
    public int id { get; set; }
    public string name { get; set; }
    public string _namespace { get; set; }
    public string parent { get; set; }
    public Property[] properties { get; set; }
    public int version { get; set; }
}

public class Function
{
    public string name { get; set; }
    public string type { get; set; }
}

public class Property
{
    public int arraySize { get; set; }
    public string container { get; set; }
    public string _enum { get; set; }
    public string exportFlag { get; set; }
    public string name { get; set; }
    public int offset { get; set; }
    public string ptrType { get; set; }
    public int size { get; set; }
    public string type { get; set; }
    public object _default { get; set; }
}
