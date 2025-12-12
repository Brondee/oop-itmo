using System;
using System.Collections.Generic;

namespace CourseManagement;

public class CourseManager
{
  public List<Course> Courses { get; } = new List<Course>();

  public void AddCourse(Course course)
  {
    foreach (Course existing in Courses)
    {
      if (existing.Id == course.Id)
      {
        throw new InvalidOperationException("Курс с Id=" + course.Id + " уже существует");
      }
    }

    Courses.Add(course);
  }

  public bool RemoveCourse(int courseId)
  {
    for (int i = 0; i < Courses.Count; i++)
    {
      if (Courses[i].Id == courseId)
      {
        Courses.RemoveAt(i);
        return true;
      }
    }

    return false;
  }

  public Course GetCourseById(int id)
  {
    foreach (Course course in Courses)
    {
      if (course.Id == id)
      {
        return course;
      }
    }

    return null;
  }

  public List<Course> GetCoursesByTeacher(Teacher teacher)
  {
    List<Course> result = new List<Course>();

    foreach (Course course in Courses)
    {
      if (course.Teacher != null && course.Teacher.Id == teacher.Id)
      {
        result.Add(course);
      }
    }

    return result;
  }
}
