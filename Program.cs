using System;

namespace MobileCommunicationServices
{
    class Program
    {
        static void Main(string[] args)
        {
            Tariffs? name = null;
            string? number = null;
            double? costPerMinute = null;
            double? balance = null;
            Services[]? services = new Services[] { };


            while (name == null)
                try
                {
                    Console.WriteLine("Будь ласка виберіть, назву тарифу: \n0 - simpleLife \n1 - freeLife \n2 - schoolLife \n3 - smartLife");
                    string? consoleRead = Console.ReadLine();
                    int num = Convert.ToInt32(consoleRead);
                    switch (num)
                    {
                        case 0:
                            name = Tariffs.simpleLife; break;
                        case 1:
                            name = Tariffs.freeLife; break;
                        case 2:
                            name = Tariffs.schoolLife; break;
                        case 3:
                            name = Tariffs.smartLife; break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Будь ласка виберіть, із запропонованих значень"); break;

                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Будь ласка вводьте лише цифри");
                }

            while (costPerMinute == null)
                try
                {
                    Console.WriteLine("Уведіть вартість за хвилину розмови");
                    string? consoleRead = Console.ReadLine();
                    costPerMinute = Convert.ToDouble(consoleRead);
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Будь ласка вводьте лише цифри");
                }

            while (balance == null)
                try
                {
                    Console.WriteLine("Уведіть баланс на рахунку");
                    string? consoleRead = Console.ReadLine();
                    balance = Convert.ToDouble(consoleRead);
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Будь ласка вводьте лише цифри");
                }

            while (number == null)
                try
                {
                    Console.WriteLine("Уведіть мобільний номер");
                    string? consoleRead = Console.ReadLine();
                    Convert.ToInt32(consoleRead);
                    number = consoleRead;
                    if ((number != null) && (number.Length != 10))
                    {
                        Console.Clear();
                        Console.WriteLine("Будь ласка уведіть коректний номер, що складається із 10 цифр");
                        number = null;
                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Будь ласка вводьте лише цифри");
                }

            Console.Clear();
            string? consoleReadServices = null;
            while (consoleReadServices != "q")
                try
                {
                    Console.WriteLine("Будь ласка виберіть, виберіть послуги: \n0 - інтернет \n1 - роумінг \n2 - SMS \nабо q - щоб вийти");
                    consoleReadServices = Console.ReadLine();

                    if (consoleReadServices == "q")
                    {
                        break;
                    }

                    int num = Convert.ToInt32(consoleReadServices);
                    switch (num)
                    {
                        case 0:
                            services = services.Concat(new Services[] { Services.internet }).ToArray(); break;
                        case 1:
                            services = services.Concat(new Services[] { Services.roaming }).ToArray(); break;
                        case 2:
                            services = services.Concat(new Services[] { Services.sms }).ToArray(); break;
                        default:
                            Console.Clear();
                            Console.WriteLine("Будь ласка виберіть, із запропонованих значень"); break;

                    }
                }
                catch (FormatException)
                {
                    Console.Clear();
                    Console.WriteLine("Будь ласка вводьте лише цифри, й запропоновані букви");
                }

            Tariff tariff = new Tariff(
                name: name ?? Tariffs.simpleLife, costPerMinute: costPerMinute ?? 0, balance: balance ?? 0, number: number ?? "0123456789", services: services ?? new Services[] { }
            );
            Console.WriteLine(tariff.toString());

            Console.WriteLine(tariff.changeTariff(Tariffs.smartLife));
            Console.WriteLine("Вартість дзвінка " + tariff.addCall(10, "0931234567"));
            Console.WriteLine("Вартість дзвінка " + tariff.addCall(5, "0931234568"));
            Console.WriteLine(tariff.addService(Services.internet));
            Console.WriteLine(tariff.addService(Services.sms));
            Console.WriteLine(tariff.replenishBalance(10));
            Console.WriteLine(tariff.getBalance());
            Console.WriteLine(tariff.getCalls());

            Console.WriteLine(tariff.toString());
     
            Console.WriteLine(tariff.removeService(Services.sms));
            Console.WriteLine(tariff.toString());
        }
    }
}


