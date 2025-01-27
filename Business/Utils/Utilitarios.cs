using System;

public static class Utilitarios
{
    public static void ValidarTempo(int tempo)
    {
        if (tempo < 1 || tempo > 120)
            throw new ArgumentException("Tempo deve ser entre 1 e 120 segundos.");
    }

    public static void ValidarPotencia(int potencia)
    {
        if (potencia < 1 || potencia > 10)
            throw new ArgumentException("Potência deve ser entre 1 e 10.");
    }
}