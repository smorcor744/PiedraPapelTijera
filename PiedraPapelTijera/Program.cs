

public class GestorPiedraPapelTijera
{
    static List<Movimientos> movimientos = new List<Movimientos>();
    static object lockObj = new object(); 

    static void Main()
    {
        int numeroJugadores = 2; 
        List<Thread> hilos = new List<Thread>();

        for (int i = 0; i < numeroJugadores; i++)
        {
            Thread t = new Thread(() =>
            {
                Movimientos movimiento = Movimiento();
                lock (lockObj)
                {
                    movimientos.Add(movimiento);
                }
            });
            hilos.Add(t);
            t.Start();
        }

        foreach (var hilo in hilos)
        {
            hilo.Join();
        }

        if (movimientos.Count == numeroJugadores)
        {
            Compare();
        }
        else
        {
            Console.WriteLine("No se generaron todos los movimientos.");
        }
    }

    static void Jugar()
    {
        
    }

    static void Compare()
    {
        var jugador1 = movimientos[0];
        var jugador2 = movimientos[1];

        Console.WriteLine($"Jugador 1: {jugador1}");
        Console.WriteLine($"Jugador 2: {jugador2}");

        if (jugador1 == jugador2)
        {
            Console.WriteLine("Es un empate.");
        }
        else if ((jugador1 == Movimientos.Piedra && jugador2 == Movimientos.Tijera) ||
                 (jugador1 == Movimientos.Papel && jugador2 == Movimientos.Piedra) ||
                 (jugador1 == Movimientos.Tijera && jugador2 == Movimientos.Papel))
        {
            Console.WriteLine("Jugador 1 gana.");
        }
        else
        {
            Console.WriteLine("Jugador 2 gana.");
        }
    }

    static Movimientos Movimiento()
    {
        Random random = new Random();
        int movimientoAleatorio = random.Next(0, 3); 
        return (Movimientos)movimientoAleatorio;
    }

    enum Movimientos
    {
        Piedra,
        Papel,
        Tijera
    }
}
