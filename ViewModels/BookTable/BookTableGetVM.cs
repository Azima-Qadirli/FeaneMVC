namespace Feane.ViewModels.BookTable;

public class BookTableGetVM
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;
    public int PersonNumber { get; set; }
    public DateTime Date { get; set; }
}
