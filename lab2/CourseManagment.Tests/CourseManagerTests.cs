using System;
using CourseManagement.Models;
using CourseManagement.Services;
using Xunit;

namespace CourseManagement.Tests;

public class CourseManagerTests
{
  [Fact]
  public void AddCourse_ShouldAddCourse()
  {
    var manager = new CourseManager();
    var course = new OnlineCourse(1, "C#", "Moodle", "https://example.com");

    manager.AddCourse(course);

    Assert.Single(manager.Courses);
    Assert.Equal(course, manager.GetCourseById(1));
  }

  [Fact]
  public void AddCourse_WithDuplicateId_ShouldThrow()
  {
    var manager = new CourseManager();
    var c1 = new OnlineCourse(1, "C# 1", "Moodle", "https://example.com/1");
    var c2 = new OfflineCourse(1, "C# 2", "Корпус A", "101");

    manager.AddCourse(c1);

    Assert.Throws<InvalidOperationException>(() => manager.AddCourse(c2));
  }

  [Fact]
  public void RemoveCourse_ShouldReturnTrue_WhenCourseExists()
  {
    var manager = new CourseManager();
    var course = new OnlineCourse(1, "C#", "Moodle", "https://example.com");
    manager.AddCourse(course);

    var result = manager.RemoveCourse(1);

    Assert.True(result);
    Assert.Empty(manager.Courses);
  }

  [Fact]
  public void RemoveCourse_ShouldReturnFalse_WhenCourseDoesNotExist()
  {
    var manager = new CourseManager();

    var result = manager.RemoveCourse(42);

    Assert.False(result);
  }

  [Fact]
  public void GetCoursesByTeacher_ShouldReturnOnlyCoursesOfThatTeacher()
  {
    var manager = new CourseManager();

    var teacher1 = new Teacher(1, "Иванов");
    var teacher2 = new Teacher(2, "Петров");

    var course1 = new OnlineCourse(1, "C#", "Moodle", "https://example.com/1");
    var course2 = new OfflineCourse(2, "Java", "Корпус B", "202");
    var course3 = new OnlineCourse(3, "Python", "Moodle", "https://example.com/3");

    course1.AssignTeacher(teacher1);
    course2.AssignTeacher(teacher1);
    course3.AssignTeacher(teacher2);

    manager.AddCourse(course1);
    manager.AddCourse(course2);
    manager.AddCourse(course3);

    var teacher1Courses = manager.GetCoursesByTeacher(teacher1);

    Assert.Equal(2, teacher1Courses.Count);
    Assert.Contains(course1, teacher1Courses);
    Assert.Contains(course2, teacher1Courses);
    Assert.DoesNotContain(course3, teacher1Courses);
  }
}