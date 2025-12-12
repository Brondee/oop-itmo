using System;
using System.Collections.Generic;

namespace CourseManagement;

public abstract class Course
{
  public List<Student> Students { get; private set; } = new List<Student>();

  public int Id { get; }
  public string Title { get; }
  public Teacher Teacher { get; private set; }

  public Course(int id, string title)
  {
    Id = id;
    Title = title;
  }

  public void AssignTeacher(Teacher teacher)
  {
    Teacher = teacher;
  }

  public void EnrollStudent(Student student)
  {
    foreach (Student current in Students)
    {
      if (current.Id == student.Id)
      {
        return;
      }
    }

    Students.Add(student);
  }

  public void RemoveStudent(int studentId)
  {
    for (int i = 0; i < Students.Count; i++)
    {
      if (Students[i].Id == studentId)
      {
        Students.RemoveAt(i);
        break;
      }
    }
  }

  public void PrintStudents()
  {
    Console.WriteLine("Студенты курса:");

    if (Students.Count == 0)
    {
      Console.WriteLine("Студентов пока нет.");
      return;
    }

    foreach (Student s in Students)
    {
      Console.WriteLine($"- {s.Id}: {s.Name}");
    }
  }
  public abstract string GetCourseInfo();
}
