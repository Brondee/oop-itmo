using System;

namespace CourseManagement;

public class Student
{
  public int Id { get; }
  public string Name { get; }

  public Student(int id, string name)
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
