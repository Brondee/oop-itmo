using CourseManagement.Models;
using CourseManagement.Services;

namespace CourseManagement;

public class Program
{
  public static void Main(string[] args)
  {
    var manager = new CourseManager();

    var teacher = new Teacher(1, "Иванов Иван");
    var student = new Student(1, "Петров Петр");

    var onlineCourse = new OnlineCourse(1, "Основы C#", "Moodle", "https://university.example.com/csharp");
    onlineCourse.AssignTeacher(teacher);
    onlineCourse.EnrollStudent(student);

    manager.AddCourse(onlineCourse);

    var teacherCourses = manager.GetCoursesByTeacher(teacher);

    Console.WriteLine("Курсы преподавателя " + teacher.Name + ":");
    foreach (var course in teacherCourses)
    {
      Console.WriteLine(course.GetCourseInfo());
    }
  }
}