namespace CorsoCS.Core.DTO;

public class PagedResults<T>
{
  public int Count { get; set; }
  public int CurrentPage { get; set; }
  
  public IEnumerable<T> Items { get; set; }
  
  
}