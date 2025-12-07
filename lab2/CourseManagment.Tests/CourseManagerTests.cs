using System;
using System.Collections.Generic;
using CourseManagement.Models;
using CourseManagement.Services;
using Xunit;

namespace CourseManagement.Tests;

public class CourseManagerTests
{
  [Fact]
  public void ShouldAddCourse()
  {
    CourseManager manager = new CourseManager();
    OnlineCourse course = new OnlineCourse(1, "C#", "Moodle", "https://example.com");

    manager.AddCourse(course);

    Assert.Equal(1, manager.Courses.Count);
    Assert.Equal(course, manager.GetCourseById(1));
  }

  [Fact]
  public void WithDuplicateId_ShouldThrowError()
  {
    CourseManager manager = new CourseManager();
    OnlineCourse c1 = new OnlineCourse(1, "C# 1", "Moodle", "https://example.com/1");
    OfflineCourse c2 = new OfflineCourse(1, "C# 2", "Корпус A", "101");

    manager.AddCourse(c1);

    Assert.Throws<InvalidOperationException>(() => manager.AddCourse(c2));
  }

  [Fact]
  public void RemoveCourse_ShouldReturnTrue()
  {
    CourseManager manager = new CourseManager();
    OnlineCourse course = new OnlineCourse(1, "C#", "Moodle", "https://example.com");
    manager.AddCourse(course);

    bool result = manager.RemoveCourse(1);

    Assert.True(result);
    Assert.Equal(0, manager.Courses.Count);
  }

  [Fact]
  public void RemoveCourse_ShouldReturnFalse()
  {
    CourseManager manager = new CourseManager();

    bool result = manager.RemoveCourse(42);

    Assert.False(result);
  }

  [Fact]
  public void GetCoursesByTeacher_ShouldReturnOnlyCoursesOfThatTeacher()
  {
    CourseManager manager = new CourseManager();

    Teacher teacher1 = new Teacher(1, "Иванов");
    Teacher teacher2 = new Teacher(2, "Петров");

    OnlineCourse course1 = new OnlineCourse(1, "C#", "Moodle", "https://example.com/1");
    OfflineCourse course2 = new OfflineCourse(2, "Java", "Корпус B", "202");
    OnlineCourse course3 = new OnlineCourse(3, "Python", "Moodle", "https://example.com/3");

    course1.AssignTeacher(teacher1);
    course2.AssignTeacher(teacher1);
    course3.AssignTeacher(teacher2);

    manager.AddCourse(course1);
    manager.AddCourse(course2);
    manager.AddCourse(course3);

    List<Course> teacher1Courses = manager.GetCoursesByTeacher(teacher1);

    Assert.Equal(2, teacher1Courses.Count);
    Assert.Contains(course1, teacher1Courses);
    Assert.Contains(course2, teacher1Courses);
    Assert.DoesNotContain(course3, teacher1Courses);
  }
}
