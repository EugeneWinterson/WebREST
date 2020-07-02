using System;
using System.Runtime.InteropServices.ComTypes;

public class User
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string SurName { get; set; }

    public User(int id, string name, string surName)
    {
        Id = id;
        Name = name;
        SurName = surName;
    }

    public User() { }
}
