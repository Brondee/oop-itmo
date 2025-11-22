namespace CourseManagement.Models;

public class Teacher
{
  public int Id { get; }
  public string Name { get; }

  public Teacher(int id, string name)
  {
    if (string.IsNullOrWhiteSpace(name))
      throw new ArgumentException("Имя преподавателя не может быть пустым", nameof(name));

    Id = id;
    Name = name;
  }

  public override string ToString() => Name;
}