using System.Linq;
using CourseManagement.Models;
using Xunit;

namespace CourseManagement.Tests;

public class CourseTests
{
  [Fact]
  public void EnrollStudent_ShouldAddStudent()
  {
    var course = new OnlineCourse(1, "C#", "Moodle", "https://example.com");
    var student = new Student(1, "Петров");

    course.EnrollStudent(student);

    Assert.Single(course.Students);
    Assert.Equal(student, course.Students.First());
  }

  [Fact]
  public void EnrollStudent_ShouldNotAddDuplicates()
  {
    var course = new OnlineCourse(1, "C#", "Moodle", "https://example.com");
    var student = new Student(1, "Петров");

    course.EnrollStudent(student);
    course.EnrollStudent(student);

    Assert.Single(course.Students);
  }

  [Fact]
  public void RemoveStudent_ShouldRemoveExistingStudent()
  {
    var course = new OfflineCourse(1, "Java", "Корпус A", "101");
    var student = new Student(1, "Петров");

    course.EnrollStudent(student);
    course.RemoveStudent(student.Id);

    Assert.Empty(course.Students);
  }

  [Fact]
  public void GetCourseInfo_ShouldReturnDifferentText_ForDifferentTypes()
  {
    Course online = new OnlineCourse(1, "C#", "Moodle", "https://example.com");
    Course offline = new OfflineCourse(2, "Java", "Корпус A", "101");

    var onlineText = online.GetCourseInfo();
    var offlineText = offline.GetCourseInfo();

    Assert.Contains("Онлайн-курс", onlineText);
    Assert.Contains("Офлайн-курс", offlineText);
  }
}