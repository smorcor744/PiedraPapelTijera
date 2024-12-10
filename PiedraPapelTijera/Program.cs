// See https://aka.ms/new-console-template for more information



public class GestorPridraPapelTijera
{
    static List<Movimientos> movimientos = new List<Movimientos>();

    static void Main()
    {
        GetMovement(2);

    }

    static void GetMovement(int jugadores)
    {
        for (int i = 0; i < jugadores; i++)
        {
            Thread t = new Thread(() =>
                {
                    movimientos.Add(Movimiento());
                }
                );
            t.Start();
        }
    }

    static Movimientos Movimiento()
    {
        Random random = new Random();

        int movimientoAleatorio = random.Next(0, 2);
        return (Movimientos)movimientoAleatorio;
    }

    enum Movimientos
    {
        Papel,
        Piedra,
        Tijera
    }
}