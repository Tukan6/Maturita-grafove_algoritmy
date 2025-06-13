using System;
using System.Collections.Generic;

class Hrana
{
    public int Zdroj, Cil, Vaha;

    public Hrana(int zdroj, int cil, int vaha)
    {
        Zdroj = zdroj;
        Cil = cil;
        Vaha = vaha;
    }
}

class Graf
{
    public int PocetVrcholu;
    public List<Hrana> Hrany;

    public Graf(int vrcholy)
    {
        PocetVrcholu = vrcholy;
        Hrany = new List<Hrana>();
    }

    public void PridejHranu(int u, int v, int w)
    {
        Hrany.Add(new Hrana(u, v, w));
    }

    public void BellmanFord(int start)
    {
        int[] vzdalenosti = new int[PocetVrcholu];
        for (int i = 0; i < PocetVrcholu; i++)
            vzdalenosti[i] = int.MaxValue;

        vzdalenosti[start] = 0;

        for (int i = 1; i < PocetVrcholu; i++)
        {
            foreach (var hrana in Hrany)
            {
                int u = hrana.Zdroj, v = hrana.Cil, w = hrana.Vaha;
                if (vzdalenosti[u] != int.MaxValue && vzdalenosti[u] + w < vzdalenosti[v])
                    vzdalenosti[v] = vzdalenosti[u] + w;
            }
        }

        foreach (var hrana in Hrany)
        {
            int u = hrana.Zdroj, v = hrana.Cil, w = hrana.Vaha;
            if (vzdalenosti[u] != int.MaxValue && vzdalenosti[u] + w < vzdalenosti[v])
            {
                Console.WriteLine("Graf obsahuje záporný cyklus.");
                return;
            }
        }

        Console.WriteLine($"Vzdálenosti od vrcholu {start}:");
        for (int i = 0; i < PocetVrcholu; i++)
            Console.WriteLine($"Vrchol {i}: {(vzdalenosti[i] == int.MaxValue ? "nedosažitelný" : vzdalenosti[i].ToString())}");
    }
}

class Program
{
    static void Main()
    {
        Graf g = new Graf(4);
        g.PridejHranu(0, 1, 4);
        g.PridejHranu(0, 2, 5);
        g.PridejHranu(1, 2, -2);
        g.PridejHranu(2, 3, 3);

        g.BellmanFord(0);
    }
}

