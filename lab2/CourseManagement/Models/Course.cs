namespace CourseManagement.Models;

public abstract class Course
{
  private readonly List<Student> _students = new();

  public int Id { get; }
  public string Title { get; private set; }
  public Teacher? Teacher { get; private set; }

  public IReadOnlyCollection<Student> Students => _students.AsReadOnly();

  protected Course(int id, string title)
  {
    if (string.IsNullOrWhiteSpace(title))
      throw new ArgumentException("Название курса не может быть пустым", nameof(title));

    Id = id;
    Title = title;
  }

  public void AssignTeacher(Teacher teacher)
  {
    Teacher = teacher ?? throw new ArgumentNullException(nameof(teacher));
  }

  public void EnrollStudent(Student student)
  {
    if (student == null) throw new ArgumentNullException(nameof(student));

    if (_students.Any(s => s.Id == student.Id))
      return;

    _students.Add(student);
  }

  public void RemoveStudent(int studentId)
  {
    var student = _students.FirstOrDefault(s => s.Id == studentId);
    if (student != null)
    {
      _students.Remove(student);
    }
  }

  public abstract string GetCourseInfo();
}