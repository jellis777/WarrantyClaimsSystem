using Microsoft.AspNetCore.Mvc;
using Warranty.Api.Dto;
using Warranty.Application.Interfaces;
using Warranty.Application.Services;
using Warranty.Domain.Entities;
using Warranty.Domain.ValueObjects;

namespace Warranty.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ClaimsController : ControllerBase
{
    private readonly SubmitClaimService _submitService;
    private readonly IClaimRepository _repository;

    public ClaimsController(
        SubmitClaimService submitService,
        IClaimRepository repository)
    {
        _submitService = submitService;
        _repository = repository;
    }

    [HttpPost]
    public IActionResult Create()
    {
        var claim = new Claim();
        claim.AddLineItem("Engine Repair", new Money(100));

        _repository.SaveAsync(claim);

        return Ok(new CreateClaimResponseDto
        {
            Id = claim.Id
        });
    }

    [HttpPost("{id}/submit")]
    public async Task<IActionResult> Submit(Guid id)
    {
        await _submitService.SubmitAsync(id);
        return Ok("Claim submitted.");
    }
}