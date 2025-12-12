using System;

namespace CourseManagement;

public class OnlineCourse : Course
{
  public string Platform { get; }
  public string Url { get; }

  public OnlineCourse(int id, string title, string platform, string url)
      : base(id, title)
  {
    Platform = platform;
    Url = url;
  }

  public override string GetCourseInfo()
  {
    return "Онлайн-курс \"" + Title + "\" на платформе " + Platform + ", ссылка: " + Url;
  }
}
