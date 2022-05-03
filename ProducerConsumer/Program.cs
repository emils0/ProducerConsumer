namespace ProducerConsumer;

internal static class Program {
    public static readonly bool[] Products = new bool[3];

    public static void Main() {
        Thread producer = new Thread(Producer.StartProducer);
        Thread consumer = new Thread(Consumer.StartConsumer);

        producer.Start();
        consumer.Start();
    }
}

internal static class Producer {
    internal static void StartProducer() {
        Random rnd = new Random();
        while (true) {
            for (int i = 0; i < Program.Products.Length; i++) {
                if (Program.Products[i] == false) {
                    Program.Products[i] = true;
                    Console.WriteLine($"Producer: Product {i + 1} has been produced!");
                }
                else {
                    Console.WriteLine($"Producer: Failed to produce product {i + 1}.");
                }
            }

            if (rnd.Next(0, 3) == 0) {
                Thread.Sleep(100 / 15);
            }
        }
    }
}

internal static class Consumer {
    internal static void StartConsumer() {
        Random rnd = new Random();
        while (true) {
            for (int i = 0; i < Program.Products.Length; i++) {
                if (Program.Products[i] == true) {
                    Program.Products[i] = false;
                    Console.WriteLine($"Consumer: Product {i + 1} has been consumed!");
                }
                else {
                    Console.WriteLine($"Consumer: Failed to consume product {i + 1}.");
                }
            }

            if (rnd.Next(0, 3) == 0) {
                Thread.Sleep(100 / 15);
            }
        }
    }
}