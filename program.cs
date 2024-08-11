using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SydneyHotel
{
    class Program
    {
        

        class PriceCalculator
        {
            public static double Price(int nights, string isRoomService)
            {
                double price = 0;
                if (nights > 0 && nights <= 3)
                    price = 100 * nights;
                else if (nights > 3 && nights <= 10)
                    price = 80.5 * nights;
                else if (nights > 10 && nights <= 20)
                    price = 75.3 * nights;

                if (isRoomService.ToLower() == "yes")
                    return price + price * 0.1;
                else
                    return price;
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine(".................Welcome to Sydney Hotel...............");
            Console.Write("\nEnter no. of Customers: ");
            int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("\n--------------------------------------------------------------------\n");

            List<ReservationDetail> reservations = new List<ReservationDetail>();

            for (int i = 0; i < n; i++)
            {
                ReservationDetail detail = new ReservationDetail();
                Console.Write("Enter customer name: ");
                detail.CustomerName = Console.ReadLine();

                Console.Write("Enter the number of nights: ");
                detail.Nights = Convert.ToInt32(Console.ReadLine());
                while (!(detail.Nights > 0) && (detail.Nights <= 20))
                {
                    Console.Write("Number of nights must be between 1 to 20: ");
                    Console.Write("Enter the number of nights: ");
                    detail.Nights = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("Enter yes/no to indicate whether you want room service: ");
                detail.RoomService = Console.ReadLine();

                detail.TotalPrice = PriceCalculator.Price(detail.Nights, detail.RoomService);
                Console.WriteLine($"The total price for {detail.CustomerName} is ${detail.TotalPrice}");
                Console.WriteLine("\n--------------------------------------------------------------------");

                reservations.Add(detail);
            }

            DisplayReservations(reservations);
            DisplaySummary(reservations);
        }

        static void DisplayReservations(List<ReservationDetail> reservations)
        {
            foreach (var detail in reservations)
            {
                Console.WriteLine($"{detail.CustomerName}: {detail.TotalPrice}");
            }
        }

        static void DisplaySummary(List<ReservationDetail> reservations)
        {
            var minReservation = reservations.OrderBy(r => r.TotalPrice).First();
            var maxReservation = reservations.OrderBy(r => r.TotalPrice).Last();

            



            
        }
    }
}
