using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class ChecklistsController : ControllerBase
{
    private readonly ChecklistService _checklistService;
    public ChecklistsController(ChecklistService checklistService) => _checklistService = checklistService;

    [HttpGet]
    public List<ChecklistDto> Checklist()
    {
        return _checklistService.GetAllChecklists();
    }

    [HttpGet("{id}")]
    public ChecklistDto ChecklistWithId(int id)
    {
        return _checklistService.GetChecklistWithId(id);
    }

    [HttpPost]
    public ChecklistDto Checklist(AddChecklistDto addChecklistDto)
    {
        return _checklistService.AddNewChecklist(addChecklistDto);
    }

    [HttpPut]
    public ChecklistDto Checklist(ChecklistDto checklistDto)
    {
        return _checklistService.EditChecklist(checklistDto);
    }

    [HttpDelete]
    public ChecklistDto Checklist(int id) => _checklistService.DeleteChecklist(id);
}
