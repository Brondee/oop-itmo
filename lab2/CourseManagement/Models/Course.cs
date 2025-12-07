using System;
using System.Collections.Generic;

namespace CourseManagement.Models;

public abstract class Course
{
  public List<Student> Students { get; } = new List<Student>();

  public int Id { get; }
  public string Title { get; }
  public Teacher Teacher { get; private set; }

  protected Course(int id, string title)
  {
    if (string.IsNullOrWhiteSpace(title))
    {
      throw new ArgumentException("Название курса не может быть пустым", nameof(title));
    }

    Id = id;
    Title = title;
  }

  public void AssignTeacher(Teacher teacher)
  {
    if (teacher == null)
    {
      throw new ArgumentNullException(nameof(teacher));
    }

    Teacher = teacher;
  }

  public void EnrollStudent(Student student)
  {
    if (student == null)
    {
      throw new ArgumentNullException(nameof(student));
    }

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
