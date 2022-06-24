using DBFirstAssignment.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DbFirstConsole
{
    public class CrudTrainRunDay
    {
        DBFirstContext dBFirstContext = new DBFirstContext();

        public void InsertTrainMasterAndTrainRunDays(TrainMaster trainMaster, List<TrainRunDay> trainRunDay)
        {
            var objTrainMaster = new TrainMaster
            {
                TrainNo = trainMaster.TrainNo,
                TrainName = trainMaster.TrainName,
                FromStation = trainMaster.FromStation,
                ToStation = trainMaster.ToStation,
                JourneyStartTime = trainMaster.JourneyStartTime,
                JourneyEndTime = trainMaster.JourneyEndTime,
                TrainRunDays = trainRunDay

            };
            dBFirstContext.TrainMasters.Add(objTrainMaster);
            dBFirstContext.SaveChanges();
        }
        public void InsertRunDaysofExistingTrain(decimal TrainNo, List<TrainRunDay> trainRunDay)
        {
            var objTrainMaster = dBFirstContext.TrainMasters.Where(x => x.TrainNo == TrainNo).Include(e => e.TrainRunDays).First();

            foreach (TrainRunDay runDays in trainRunDay)
            {
                objTrainMaster.TrainRunDays.Add(runDays);
            }

            dBFirstContext.TrainMasters.Update(objTrainMaster);
            dBFirstContext.SaveChanges();
        }
    }
}
