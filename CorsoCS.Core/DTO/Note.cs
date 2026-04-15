namespace CorsoCS.Core.DTO;

public class Note
{
  public Guid Id { get; set; }
  public DateTime Date { get; set; }
  public string Title { get; set; }
  public string Body { get; set; }
  public bool Flagged { get; set; }
}