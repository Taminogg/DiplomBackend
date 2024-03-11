using ContainerToolDBDb;
using TippsBackend.Services;

namespace TippsBackend.Controllers;

[Route("[controller]")]
[ApiController]
public class TlinquiriesController : ControllerBase
{
    private readonly TlinquiryService _tlinquiryService;
    public TlinquiriesController(TlinquiryService tlinquiryService) => _tlinquiryService = tlinquiryService;

    [HttpGet]
    public List<TlinquiryDto> Tlinquiries()
    {
        var tlinquiries = _tlinquiryService.GetAllTlinquirys();
        if (tlinquiries == null) return new List<TlinquiryDto>();
        return tlinquiries.Select(x => ToTlinquiryDto(x)).ToList();
    }

    [HttpGet("{id}")]
    public TlinquiryDto? GetTlinquiryWithId(int id)
    {
        var tlinquiry = _tlinquiryService.GetTlinquiryWithId(id);
        if (tlinquiry == null) return null;
        return ToTlinquiryDto(tlinquiry);
    }

    [HttpPost]
    public TlinquiryDto? Tlinquiry()
    {
        var tlinquiry = _tlinquiryService.AddTlinquiry();
        if (tlinquiry == null) return null;
        return ToTlinquiryDto(tlinquiry);
    }

    [HttpPut]
    public TlinquiryDto? Tlinquiry(EditTlInqueryDto editTlinquiry)
    {
        var tlinquiry = _tlinquiryService.EditTlinquiry(editTlinquiry);
        if (tlinquiry == null) return null;
        return ToTlinquiryDto(tlinquiry);
    }

    [HttpPut("ApproveCrTl")]
    public TlinquiryDto? TlinquiryApproveCrTl(EditStatusDto editApproveDto)
    {
        var tlinquiry = _tlinquiryService.ApproveCrTl(editApproveDto);
        if (tlinquiry == null) return null;
        return ToTlinquiryDto(tlinquiry);
    }

    [HttpDelete]
    public TlinquiryDto? Tlinquiry(int id)
    {
        var tlinquiry = _tlinquiryService.DeleteTlinquiry(id);
        if (tlinquiry == null) return null;
        return ToTlinquiryDto(tlinquiry);
    }

    private TlinquiryDto ToTlinquiryDto(Tlinquiry tlinquiry)
    {
        return new TlinquiryDto
        {
            DebtCapitalGeneralForerunEur = tlinquiry.DebtCapitalGeneralForerunEur,
            DebtCapitalMainDol = tlinquiry.DebtCapitalMainDol,
            DebtCapitalTrailingDol = tlinquiry.DebtCapitalTrailingDol,
            PortOfDeparture = tlinquiry.PortOfDeparture,
            RetrieveDate = tlinquiry.RetrieveDate?.ToString("yyyy-MM-dd") ?? "",
            AcceptingPort = tlinquiry.AcceptingPort,
            Boat = tlinquiry.Boat,
            Country = tlinquiry.Country,
            Eta = tlinquiry.Eta?.ToString("yyyy-MM-dd") ?? "",
            Ets = tlinquiry.Ets?.ToString("yyyy-MM-dd") ?? "",
            ExpectedRetrieveWeek = tlinquiry.ExpectedRetrieveWeek?.ToString("yyyy-MM-dd") ?? "",
            InquiryNumber = tlinquiry.InquiryNumber,
            InvoiceOn = tlinquiry.InvoiceOn?.ToString("yyyy-MM-dd") ?? "",
            IsContainer40 = tlinquiry.IsContainer40,
            IsContainerHc = tlinquiry.IsContainerHc,
            RetrieveLocation = tlinquiry.RetrieveLocation,
            Sped = tlinquiry.Sped,
            WeightInKg = tlinquiry.WeightInKg,
            Id = tlinquiry.Id,
            ApprovedByCrTl = tlinquiry.ApprovedByCrTl,
            ApprovedByCrTlTime = tlinquiry.ApprovedByCrTlTime?.ToString("yyyy-MM-dd") ?? ""
    };
    }
}
