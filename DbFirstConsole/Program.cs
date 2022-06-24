using DBFirstAssignment;
using DBFirstAssignment.Models;
using DbFirstConsole;

public class program
{
    public static void Main()
    {
        CrudTrainMaster obj = new CrudTrainMaster();

        //Insert Train details in TrainMaster 
        //obj.Insert(new TrainMaster
        //{
        //    TrainNo = 1001,
        //    TrainName = "Rajdhani Express",
        //    FromStation = "Hazrat Nizamuddin",
        //    ToStation = "	Mumbai Central",
        //    JourneyStartTime = new TimeSpan(4, 00, 00),
        //    JourneyEndTime = new TimeSpan(9, 00, 00)
        //});

        //obj.Insert(new TrainMaster
        //{
        //    TrainNo = 1002,
        //    TrainName = "Sampark Kranti Express",
        //    FromStation = "Hazrat Nizamuddin",
        //    ToStation = "Tirupati",
        //    JourneyStartTime = new TimeSpan(1, 00, 00),
        //    JourneyEndTime = new TimeSpan(7, 00, 00)
        //});
        //obj.Insert(new TrainMaster
        //{
        //    TrainNo = 1003,
        //    TrainName = "ANUVRAT Express",
        //    FromStation = "Madurai Junction",
        //    ToStation = "Bikaner",
        //    JourneyStartTime = new TimeSpan(4, 00, 00),
        //    JourneyEndTime = new TimeSpan(9, 00, 00)
        //});
        //Console.WriteLine("Added a new Train Details....");

        ////Delete Train records from TrainMaster
        //obj.Delete(1002);
        //Console.WriteLine("Deleted a  Train Details....");

        ////Update Train Details In TrainMaster
        //obj.Update(1001, new TrainMaster { TrainName = "Arunachal Express", FromStation = "Naharlagun", ToStation = "Anand Vihar Terminal" });
        //Console.WriteLine("updated a Train Details....");

        ////Get all Details of Train from TrainMaster by Train Number
        //Console.WriteLine("Geeting the all details of the train..");
        //obj.SearchByTrainNo(1001);

        ////Get all Details of Train from TrainMaster by From station and To station
        //Console.WriteLine("Geeting the all details of the train by From station and To station..");
        //obj.SearchTrainByFromAndToStations("Naharlagun", "Anand Vihar Terminal");



        ////CrudTrainRunDay executon
        //CrudTrainRunDay crudTrainRunDay = new CrudTrainRunDay();
        ////Inserting trainMaster and Run Days
        //List<TrainRunDay> trainRunDays = new List<TrainRunDay>();
        //TrainMaster trainMaster = new TrainMaster();

        //trainRunDays.Add(new TrainRunDay { TrainNo = 1004, RunDays = "Monday" });
        //trainRunDays.Add(new TrainRunDay { TrainNo = 1004, RunDays = "Tuesday" });

        //crudTrainRunDay.InsertTrainMasterAndTrainRunDays(new TrainMaster
        //{
        //    TrainNo = 1004,
        //    TrainName = "Vishaka Express",
        //    FromStation = "Kachiguda",
        //    ToStation = "Vishakapatnam",
        //    JourneyStartTime = new TimeSpan(9, 00, 00),
        //    JourneyEndTime = new TimeSpan(7, 00, 00)
        //}, trainRunDays);
        //Console.WriteLine("Inserted Train details in TrainMaster and Run days in TrainRunDays.. ");

        //////Inserting Train run days for existing train
        ////List<TrainRunDay> trainRunDays1 = new List<TrainRunDay>();
        ////Console.WriteLine("Inserting Train Run Days details for existing train.");
        ////trainRunDays.Add(new TrainRunDay { RunDays = "Monday" });
        ////crudTrainRunDay.InsertRunDaysofExistingTrain(1001, trainRunDays1);

        //////pint all the Train Details 
        obj.PrintAllTraindetails();


        Console.ReadKey();
    }
}
