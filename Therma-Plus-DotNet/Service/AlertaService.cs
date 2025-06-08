using Therma_Plus_DotNet.DTOs;

namespace Therma_Plus_DotNet.Service;

public class AlertaService
{
    public AlertaDTO GerarAlerta(int temperatura, int umidade, int nivelGas)
    {
        var dto = new AlertaDTO();

        if (temperatura > 30)
        {
            dto.mensagem = "Temperatura muito elevada\nEvite exposição ao sol";
        }

        if (umidade > 70)
        {
            dto.mensagem = "Umidade muito elevada\nVa para um local mais arejado";
        }

        if (nivelGas > 2731)
        {
            dto.mensagem = "Nível de gases muito elevado\nMude para um local mais aberto";
        }
        
        return dto;
    }
}