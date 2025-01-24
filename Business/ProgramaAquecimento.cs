using System;

public class ProgramaAquecimento
{
    public string Nome { get; }
    public string Alimento { get; }
    public int TempoSegundos { get; }
    public int Potencia { get; }
    public char CaractereAquecimento { get; }
    public string Instrucoes { get; }
    public bool IsCustomizado { get; } // Flag para identificar programas customizados

    public ProgramaAquecimento(string nome, string alimento, int tempo, int potencia,
                              char caractere, string instrucoes = "", bool isCustomizado = false)
    {
        ValidarParametros(tempo, potencia, caractere);

        Nome = nome;
        Alimento = alimento;
        TempoSegundos = tempo;
        Potencia = potencia;
        CaractereAquecimento = caractere;
        Instrucoes = instrucoes;
        IsCustomizado = isCustomizado;
    }

    private void ValidarParametros(int tempo, int potencia, char caractere)
    {
        if (tempo < 1)
            throw new ArgumentException("Tempo inválido");

        if (potencia < 1 || potencia > 10)
            throw new ArgumentException("Potência inválida");

        if (caractere == '.' || char.IsWhiteSpace(caractere))
            throw new ArgumentException("Caractere inválido para programas pré-definidos");
    }
}
