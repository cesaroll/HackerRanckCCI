using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Algorithms1
{
    class Program
    {
        class Delivery : IComparable<Delivery>
        {
            public int DeliveryId { get; set; }
            public int BeginTime { get; set; }
            public int EndTime { get; set; }

            public int CompareTo(Delivery other)
            {
                return DeliveryId.CompareTo(other.DeliveryId);
            }
        }

        static List<Delivery> Deliveries = new List<Delivery>();
        static SortedDictionary<int, List<Delivery>> DeliveryTimes = new SortedDictionary<int, List<Delivery>>();

        
        static void Main(string[] args)
        {
            var input = new string[] {"1 5", "3 6", "7 8", "2 10", "5 7"};
            
            var timeAndWeight = new SortedDictionary<int, int>(); // Time and weight
            

            for (int deliveryId = 0; deliveryId < input.Length; deliveryId++)
            {
                var item = input[deliveryId];

                var split = item.Split(' ');
                var beginTime = int.Parse(split[0]);
                var endTime = int.Parse(split[1]);

                var delivery = new Delivery()
                {
                    DeliveryId = deliveryId,
                    BeginTime = beginTime,
                    EndTime = endTime
                };

                Deliveries.Add(delivery);
                
                

                for (int time = beginTime; time <= endTime; time++)
                {
                    int weight = 0;
                    timeAndWeight.TryGetValue(time, out weight);

                    timeAndWeight[time] = ++weight;

                    List<Delivery> deliveries;
                    if (DeliveryTimes.TryGetValue(time, out deliveries) )
                    {
                        if(!deliveries.Contains(delivery))
                            deliveries.Add(delivery);
                    }
                    else
                    {
                        deliveries = new List<Delivery>() { delivery };

                        DeliveryTimes[time] = deliveries;
                    }
                    
                }

            }


            setDeliveries(timeAndWeight, Deliveries);



        }


        static void setDeliveries(SortedDictionary<int, int> timeAndWeight, List<Delivery> missingDeliveries)
        {
            foreach (var item in timeAndWeight.OrderByDescending(x => x.Value).ThenBy(x => x.Key))
            {
                var deliveries = DeliveryTimes[item.Key];

                Console.WriteLine($"Time: [{item.Key}], Weight: [{item.Value}], DeliveryIds: [{GetDeliveryIds(deliveries)}]");

                missingDeliveries = Deliveries.Where(x => !deliveries.Contains(x)).ToList();

            }
        }


        static string GetDeliveryIds(List<Delivery> deliveries)
        {
            return string.Join(", ", deliveries.Select(x => x.DeliveryId.ToString()));
        }

    }


   

}
