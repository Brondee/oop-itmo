namespace CourseManagement.Models;

public class OnlineCourse : Course
{
  public string Platform { get; private set; }
  public string Url { get; private set; }

  public OnlineCourse(int id, string title, string platform, string url)
      : base(id, title)
  {
    if (string.IsNullOrWhiteSpace(platform))
      throw new ArgumentException("Платформа не может быть пустой", nameof(platform));
    if (string.IsNullOrWhiteSpace(url))
      throw new ArgumentException("Url не может быть пустым", nameof(url));

    Platform = platform;
    Url = url;
  }

  public override string GetCourseInfo()
  {
    return $"Онлайн-курс \"{Title}\" на платформе {Platform}, ссылка: {Url}";
  }
}