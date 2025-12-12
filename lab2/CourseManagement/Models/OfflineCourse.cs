using System;

namespace CourseManagement;

public class OfflineCourse : Course
{
  public string Building { get; }
  public string Classroom { get; }

  public OfflineCourse(int id, string title, string building, string classroom)
      : base(id, title)
  {
    Building = building;
    Classroom = classroom;
  }

  public override string GetCourseInfo()
  {
    return "Офлайн-курс \"" + Title + "\" в здании " + Building + ", аудитория " + Classroom;
  }
}
