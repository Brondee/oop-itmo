using CourseManagement;
using Xunit;

public class CourseTests
{
  [Fact]
  public void ShouldAddStudent()
  {
    OnlineCourse course = new OnlineCourse(1, "C#", "Moodle", "https://example.com");
    Student student = new Student(1, "Петров");

    course.EnrollStudent(student);

    Assert.Equal(1, course.Students.Count);
    Assert.Equal(student, course.Students[0]);
  }

  [Fact]
  public void ShouldNotAddDuplicates()
  {
    OnlineCourse course = new OnlineCourse(1, "C#", "Moodle", "https://example.com");
    Student student = new Student(1, "Петров");

    course.EnrollStudent(student);
    course.EnrollStudent(student);

    Assert.Equal(1, course.Students.Count);
  }

  [Fact]
  public void ShouldRemoveExistingStudent()
  {
    OfflineCourse course = new OfflineCourse(1, "Java", "Корпус A", "101");
    Student student = new Student(1, "Петров");

    course.EnrollStudent(student);
    course.RemoveStudent(student.Id);

    Assert.Equal(0, course.Students.Count);
  }

  [Fact]
  public void ShouldReturnDifferentTextForDifferentTypes()
  {
    Course online = new OnlineCourse(1, "C#", "Moodle", "https://example.com");
    Course offline = new OfflineCourse(2, "Java", "Корпус A", "101");

    string onlineText = online.GetCourseInfo();
    string offlineText = offline.GetCourseInfo();

    Assert.Contains("Онлайн-курс", onlineText);
    Assert.Contains("Офлайн-курс", offlineText);
  }
}
