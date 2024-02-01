namespace ContainerToolDBDb;

public class AddChecklistDto
{
    [RegularExpression(@"[\w������\-_\.]+$")] [Required] public string CustomerName { get; set; } = null!;
}