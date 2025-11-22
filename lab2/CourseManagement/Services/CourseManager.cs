using CourseManagement.Models;

namespace CourseManagement.Services;

public class CourseManager
{
  private readonly List<Course> _courses = new();

  public IReadOnlyCollection<Course> Courses => _courses.AsReadOnly();

  public void AddCourse(Course course)
  {
    if (course == null) throw new ArgumentNullException(nameof(course));

    if (_courses.Any(c => c.Id == course.Id))
      throw new InvalidOperationException($"Курс с Id={course.Id} уже существует");

    _courses.Add(course);
  }

  public bool RemoveCourse(int courseId)
  {
    var course = _courses.FirstOrDefault(c => c.Id == courseId);
    if (course == null)
      return false;

    _courses.Remove(course);
    return true;
  }

  public Course? GetCourseById(int id)
  {
    return _courses.FirstOrDefault(c => c.Id == id);
  }

  public List<Course> GetCoursesByTeacher(Teacher teacher)
  {
    if (teacher == null) throw new ArgumentNullException(nameof(teacher));

    return _courses
        .Where(c => c.Teacher != null && c.Teacher.Id == teacher.Id)
        .ToList();
  }
}