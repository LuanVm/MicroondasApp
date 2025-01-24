using System;
using System.Drawing;
using Newtonsoft.Json;

public class ProgramaAquecimento
{
    public string Nome { get; }
    public string Alimento { get; }
    public int TempoSegundos { get; }
    public int Potencia { get; }
    public char CaractereAquecimento { get; }
    public string Instrucoes { get; }
    public bool IsCustomizado { get; }

    [JsonIgnore]
    public Image Imagem { get; set; }

    [JsonConstructor]
    public ProgramaAquecimento(
        string nome,
        string alimento,
        int tempoSegundos,
        int potencia,
        char caractereAquecimento,
        string instrucoes = "",
        bool isCustomizado = false)
    {
        Nome = nome;
        Alimento = alimento;
        TempoSegundos = tempoSegundos;
        Potencia = potencia;
        CaractereAquecimento = caractereAquecimento;
        Instrucoes = instrucoes;
        IsCustomizado = isCustomizado;

        ValidarParametros();
    }

    private void ValidarParametros()
    {
        if (IsCustomizado)
        {
            // Validação corrigida para 6000 segundos
            if (TempoSegundos < 1 || TempoSegundos > 6000)
                throw new ArgumentException("Tempo inválido para programa customizado (1-6000 segundos)");
        }
        else
        {
            if (TempoSegundos < 1)
                throw new ArgumentException("Tempo inválido para pré-definido (mínimo 1 segundo)");
        }

        if (Potencia < 1 || Potencia > 10)
            throw new ArgumentException("Potência inválida (1-10)");

        if (IsCustomizado && (CaractereAquecimento == '.' || char.IsWhiteSpace(CaractereAquecimento)))
            throw new ArgumentException("Caractere inválido para customizados");
        else if (CaractereAquecimento == '.')
            throw new ArgumentException("Caractere '.' reservado para uso padrão");
    }
}