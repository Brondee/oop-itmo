using System;

namespace CourseManagement;

public class Teacher
{
  public int Id { get; }
  public string Name { get; }

  public Teacher(int id, string name)
  {
    if (string.IsNullOrWhiteSpace(name))
    {
      throw new ArgumentNullException(nameof(name));
    }

    Id = id;
    Name = name;
  }

  public override string ToString()
  {
    return Name;
  }
}
