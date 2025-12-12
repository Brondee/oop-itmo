using System;

namespace CourseManagement;

public class Teacher
{
  public int Id { get; }
  public string Name { get; }

  public Teacher(int id, string name)
  {
    Id = id;
    Name = name;
  }
}
