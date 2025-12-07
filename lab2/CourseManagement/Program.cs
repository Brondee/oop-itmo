using System;
using System.Collections.Generic;
using CourseManagement.Models;
using CourseManagement.Services;

namespace CourseManagement;

public class Program
{
  public static void Main(string[] args)
  {
    CourseManager manager = new CourseManager();

    Teacher teacher = new Teacher(1, "Иванов Иван");
    Student student = new Student(1, "Петров Петр");

    OnlineCourse onlineCourse = new OnlineCourse(
        1,
        "Основы C#",
        "Backboost",
        "https://backboost.courses.itmo.ru/csharp");

    onlineCourse.AssignTeacher(teacher);
    onlineCourse.EnrollStudent(student);

    manager.AddCourse(onlineCourse);

    List<Course> teacherCourses = manager.GetCoursesByTeacher(teacher);

    Console.WriteLine("Курсы преподавателя " + teacher.Name + ":");
    foreach (Course course in teacherCourses)
    {
      Console.WriteLine(course.GetCourseInfo());
      course.PrintStudents();
    }
  }
}
