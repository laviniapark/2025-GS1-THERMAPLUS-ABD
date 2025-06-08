using Microsoft.AspNetCore.Mvc;
using Therma_Plus_DotNet.DTOs;
using Therma_Plus_DotNet.Service;

namespace Therma_Plus_DotNet.Controllers;

[Route("usuario")]
public class UsuarioController : Controller
{
    private readonly UsuarioService _usuarioService;

    public UsuarioController(UsuarioService usuarioService)
    {
        _usuarioService = usuarioService;
    }

    [HttpGet("")]
    public async Task<IActionResult> Index()
    {
        // id mockado para fins de testes
        int id = 2;
        var usuario = await _usuarioService.GetInfoUsuarioRegiao(id);

        if (usuario == null)
            return RedirectToAction("Create", "regiao");

        return View(usuario);
    }

    [HttpGet("create")]
    public IActionResult Create(int regiaoId)
    {
        var model = new UsuarioDTO() { RegiaoId = regiaoId };
        return View(model);
    }

    [HttpPost("create")]
    public async Task<IActionResult> Create(UsuarioDTO usuarioDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                Console.WriteLine(usuarioDto.RegiaoId);
                await _usuarioService.AddUsuarioAsync(usuarioDto);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao cadastrar usuario");
            }
        }
        return View(usuarioDto);
    }

    [HttpGet("edit/{id}")]
    public async Task<IActionResult> Edit(int id)
    {
        var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    [HttpPost("edit/{id}")]
    public async Task<IActionResult> Edit(UsuarioDTO usuarioDto)
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _usuarioService.UpdateUsuarioAsync(usuarioDto);
                return RedirectToAction("Index");
            }
            catch
            {
                ModelState.AddModelError(string.Empty, "Erro ao editar usuario");
            }
        }
        return View(usuarioDto);
    }

    [HttpGet("delete/{id}")]
    public async Task<IActionResult> Delete(int id)
    {
        var usuario = await _usuarioService.GetInfoUsuarioRegiao(id);
        if (usuario == null)
        {
            return NotFound();
        }
        return View(usuario);
    }

    [HttpPost]
    public async Task<IActionResult> DeleteConfirmed(int UsuarioId)
    {
        Console.WriteLine($"Recebido UsuarioId: {UsuarioId}");
        try
        {
            await _usuarioService.DeleteUsuarioAsync(UsuarioId);
            return RedirectToAction("Index");
        }
        catch(Exception ex)
        {
            return Content("Erro ao excluir: " + ex.Message);
        }
    }
    
    
}