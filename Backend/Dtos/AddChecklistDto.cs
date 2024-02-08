namespace ContainerToolDBDb;

public class AddChecklistDto
{
    [RegularExpression(@"[\w������\-_\.]+$")] [Required] public string Checklistname { get; set; } = null!;
}