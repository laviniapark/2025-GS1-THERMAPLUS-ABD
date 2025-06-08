using Microsoft.AspNetCore.Mvc;
using Therma_Plus_DotNet.Service;

namespace Therma_Plus_DotNet.Controllers;

[Route("alertas")]
public class AlertaController : Controller
{
    private readonly AlertaService _alertaService;

    public AlertaController(AlertaService alertaService)
    {
        _alertaService = alertaService;
    }

    [HttpGet("gerar")]
    public IActionResult Gerar(int temperatura, int umidade, int nivelGas)
    {
        var alerta = _alertaService.GerarAlerta(temperatura, umidade, nivelGas);
        return View(alerta);
    }
}