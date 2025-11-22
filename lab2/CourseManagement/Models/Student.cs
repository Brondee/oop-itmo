namespace CourseManagement.Models;

public class Student
{
  public int Id { get; }
  public string Name { get; }

  public Student(int id, string name)
  {
    if (string.IsNullOrWhiteSpace(name))
      throw new ArgumentException("Имя студента не может быть пустым", nameof(name));

    Id = id;
    Name = name;
  }

  public override string ToString() => Name;
}