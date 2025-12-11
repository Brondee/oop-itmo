using System;

namespace CourseManagement;

public class OnlineCourse : Course
{
  public string Platform { get; }
  public string Url { get; }

  public OnlineCourse(int id, string title, string platform, string url)
      : base(id, title)
  {
    if (string.IsNullOrWhiteSpace(platform))
    {
      throw new ArgumentNullException(nameof(platform));
    }

    if (string.IsNullOrWhiteSpace(url))
    {
      throw new ArgumentNullException(nameof(url));
    }

    Platform = platform;
    Url = url;
  }

  public override string GetCourseInfo()
  {
    return "Онлайн-курс \"" + Title + "\" на платформе " + Platform + ", ссылка: " + Url;
  }
}
