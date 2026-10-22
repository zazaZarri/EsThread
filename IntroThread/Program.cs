using System;
using System.Threading;


    class Program
    {
        static void SimulaSensore (object dati)
        {
            var sensore = (string[])dati;
            string nome = sensore[0];
            int intervallo = int.Parse(sensore[1]);

            Thread corrente = Thread.CurrentThread;

            Console.WriteLine($"Sensore {nome} in esecuzione sul thread {corrente.ManagedThreadId}");

            for (int i = 0; i <= 5; i++)
            {
                Console.WriteLine($"Sensore {nome} - lettura {i}");
                Thread.Sleep(intervallo);
            }

            Console.WriteLine($"Sensore {nome} terminato");


        }
        

        static void Main()
        {
            Console.WriteLine("Avvio sensori");

            //creazione dei thread 
            Thread sensore1 = new Thread(SimulaSensore);
            Thread sensore2 = new Thread(SimulaSensore);
            Thread sensore3 = new Thread(SimulaSensore);

            sensore1.Name = "Temperatura";
            sensore2.Name = "Umidità";
            sensore3.Name = "Pressione";

            sensore1.IsBackground = false;
            sensore2.IsBackground = false;
            sensore3.IsBackground = false;


            //avvio dei thread

            sensore1.Start(new string[] { "Temperatura", "1000" });
            sensore2.Start(new string[] { "Umidità", "2000" });
            sensore3.Start(new string[] { "Pressione", "3000" });

            Console.WriteLine("Sensori avviati");

            Console.WriteLine($"Sensore1 attivo: {sensore1.IsAlive}");
            Console.WriteLine($"Sensore2 attivo: {sensore2.IsAlive}");
            Console.WriteLine($"Sensore3 attivo: {sensore3.IsAlive}");


            Console.WriteLine($"stato di sensore1: {sensore1.ThreadState}");
            Console.WriteLine($"stato di sensore2: {sensore2.ThreadState}");
            Console.WriteLine($"stato di sensore3: {sensore3.ThreadState}");

            sensore1.Join();
            sensore2.Join();    
            sensore3.Join();

            Console.WriteLine("Sensori terminati");
        }
    }
