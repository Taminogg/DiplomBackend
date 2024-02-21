namespace ContainerToolDBDb;

public class AddChecklistDto
{
    [RegularExpression(@"[\w������\-_\.]+$")] [Required] public string Checklistname { get; set; } = null!;
    [Required] public bool GeneratedByAdmin { get; set; }
    public int? Id { get; set; }
}