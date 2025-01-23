using System;

public class ProgramaAquecimento
{
    public string Nome { get; }
    public string Alimento { get; }
    public int TempoSegundos { get; }
    public int Potencia { get; }
    public string CaractereAquecimento { get; }
    public string Instrucoes { get; }
    public bool Customizado { get; }

    public ProgramaAquecimento(string nome, string alimento, int tempo, int potencia,
                              string caractere, string instrucoes = "", bool customizado = false)
    {
        ValidarCaractere(caractere);

        Nome = nome;
        Alimento = alimento;
        TempoSegundos = tempo;
        Potencia = potencia;
        CaractereAquecimento = caractere;
        Instrucoes = instrucoes;
        Customizado = customizado;
    }

    private static void ValidarCaractere(string caractere)
    {
        if (caractere.Length != 1 || caractere == ".")
            throw new ArgumentException("Caractere inválido! Deve ser único e diferente de '.'");
    }
}