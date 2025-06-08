using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Therma_Plus_DotNet.DTOs;
using Therma_Plus_DotNet.Models;
using Therma_Plus_DotNet.Service;

namespace Therma_Plus_DotNet.Controllers;

[Route("regiao")]
public class RegiaoController : Controller
{
    private readonly RegiaoService _regiaoService;

    public RegiaoController(RegiaoService regiaoService)
    {
        _regiaoService = regiaoService;
    }

    [HttpGet("")]
    public IActionResult Index()
    {
        return RedirectToAction("Create");
    }

    [HttpGet("create")]
    public IActionResult Create()
    {
        ViewBag.Estados = Enum.GetValues(typeof(Estado))
                          .Cast<Estado>()
                          .Select(e => new SelectListItem
                          {
                              Text = e.ToString(),
                              Value = e.ToString()
                          }).ToList();
        return View();
    }
    
    [HttpPost("create")]
    public async Task<IActionResult> Create(RegiaoDTO regiaoDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                var regiaoId = await _regiaoService.AddRegiaoAsync(regiaoDto);
                return RedirectToAction("Create", "usuario", new { regiaoId });
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Erro ao criar regiao");
            }
        }
        return  View(regiaoDto);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var regiao = await _regiaoService.GetRegiaoByIdAsync(id);
        if (regiao == null)
        {
            return NotFound();
        }
        ViewBag.Estados = Enum.GetValues(typeof(Estado))
                          .Cast<Estado>()
                          .Select(e => new SelectListItem
                          {
                              Text = e.ToString(),
                              Value = e.ToString()
                          }).ToList();
        return View(regiao);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(int id, RegiaoDTO regiaoDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                regiaoDto.RegiaoId = id;
                await _regiaoService.UpdateRegiaoAsync(regiaoDto);
                return RedirectToAction("Index", "Usuario");
            }
            catch
            {
                ModelState.AddModelError(String.Empty, "Erro ao editar regiao");
            }
        }
        return View(regiaoDto);
    }
}