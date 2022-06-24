using DBFirstAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace DBFirstAssignment
{
    public class CrudTrainMaster
    {
        DBFirstContext dBFirstContext = new DBFirstContext();
        TrainRunDay trainRunDay = new TrainRunDay();
        public void Insert(TrainMaster trainMaster)
        {
            dBFirstContext.TrainMasters.Add(trainMaster);   
            dBFirstContext.SaveChanges();
        }
       
            public void Update(int trainNo, TrainMaster modifiedTrainMaster)
            {
                var trainMaster = dBFirstContext.TrainMasters.Where(x => x.TrainNo == trainNo).FirstOrDefault();
                if (trainMaster == null)
                {
                    Console.WriteLine($"Train with ID:{trainNo} Not Found");
                }
                else
                {
                trainMaster.TrainName = modifiedTrainMaster.TrainName;
                trainMaster.FromStation = modifiedTrainMaster.FromStation;
                trainMaster.ToStation = modifiedTrainMaster.ToStation;
                dBFirstContext.TrainMasters.Update(trainMaster);
                dBFirstContext.SaveChanges();
                }
            }
        public void Delete(decimal TrainNo)
        {
            var trainMaster = dBFirstContext.TrainMasters.Where(x => x.TrainNo == TrainNo).FirstOrDefault();
            if (trainMaster == null)
            {
                Console.WriteLine($"Train with number:{TrainNo} Not Found");
            }
            else
            {
                //delete
                dBFirstContext.TrainMasters.Remove(trainMaster);
                dBFirstContext.SaveChanges();
            }
           

        }

        public void SearchByTrainNo(decimal TrainNo)
        {

            var trainMaster = dBFirstContext.TrainMasters.Where(x => x.TrainNo == TrainNo)
                            .AsNoTracking().FirstOrDefaultAsync().Result;

            if (trainMaster == null)
            {
                Console.WriteLine($"Train with TrainNo:{TrainNo} Not Found");
            }
            else
            {
              Console.WriteLine($"Train details of {trainMaster.TrainNo} are\n Train Name: {trainMaster.TrainName}" +
              $"\n Train FromStation: {trainMaster.FromStation}\n Train ToStation: {trainMaster.ToStation}\n " +
              $"Train Journey Start Time: {trainMaster.JourneyStartTime}\n Train Journey Start Time: {trainMaster.JourneyEndTime}");
            }
            
        }

        public void SearchTrainByFromAndToStations(string FromStation,string ToStation)
        {
            var trainMaster = dBFirstContext.TrainMasters.Where(x => x.FromStation == FromStation || x.ToStation== ToStation)
                            .AsNoTracking().FirstOrDefaultAsync().Result;

            if (trainMaster == null)
            {
                Console.WriteLine($"Train with FromStation:{FromStation} and ToStation:{ToStation} Not Found");
            }
            else
            {
                Console.WriteLine($"Train details of from station {trainMaster.FromStation} and to station {trainMaster.ToStation} are\n Train No:{trainMaster.TrainNo}\n Train Name: {trainMaster.TrainName}" +
                $"\n Train FromStation: {trainMaster.FromStation}\n Train ToStation: {trainMaster.ToStation}\n " +
                $"Train Journey Start Time: {trainMaster.JourneyStartTime}\n Train Journey Start Time: {trainMaster.JourneyEndTime}");
            }
        }
        public void PrintAllTraindetails()
        {
            var trainMaster = dBFirstContext.TrainMasters.Include(x => x.TrainRunDays).ToList();
            if (trainMaster != null)
            {
                foreach (TrainMaster train in trainMaster)
                {
                    Console.WriteLine("Train Number  :" + train.TrainNo);
                    Console.WriteLine("Train Name  :" + train.TrainName);
                    Console.WriteLine("Train From Station  :" + train.FromStation);
                    Console.WriteLine("Train To Station  :" + train.ToStation);
                    Console.WriteLine("Train Journey starts Time :" + train.JourneyStartTime);
                    Console.WriteLine("Train Journey Ends Time :" + train.JourneyEndTime);
                    
                    foreach (TrainRunDay trainRunDays in train.TrainRunDays)
                    {
                        Console.WriteLine("Train ID :" + trainRunDays.TrainId);
                        Console.WriteLine("Train Run Days :" + trainRunDays.RunDays);
                    }
                    Console.WriteLine();
                    Console.WriteLine("Train  Details");
                }
            }
            else
            {
                Console.WriteLine(" Record not Found with Id :");
            }
        }
    }
}
