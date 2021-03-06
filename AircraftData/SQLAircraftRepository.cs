﻿using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AircraftData
{
    public class SQLAircraftRepository : IAircraftRepository
    {
        private readonly AppDbContext context;

        public SQLAircraftRepository(AppDbContext context)
        {
            this.context = context;
        }
        // async savings will be implemented later on.
        public Aircraft AddAC(Aircraft NewAC)
        {
            context.Aircrafts.Add(NewAC);
            context.SaveChanges();
            return NewAC;
        }
        public Aircraft UpdateAC(Aircraft changedAC)
        {
            Aircraft ac = GetAircraftbyRegistration(changedAC.Registration);
            FillACInfo(ref ac, changedAC);
            //var ac = context.Aircrafts.Attach(changedAC);
            //ac.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            context.SaveChanges();
            return changedAC;
        }
        public Aircraft DeleteAC(Aircraft ac)
        {
            context.Aircrafts.Remove(ac);
            context.SaveChanges();
            return ac;
        }
        public Aircraft GetAircraftbyID(int Id)
        {
            return context.Aircrafts.FirstOrDefault(acc => acc.Id == Id);
        }
        public Aircraft GetAircraftbyRegistration(string Registration)
        {
            return context.Aircrafts.FirstOrDefault(acc => acc.Registration == Registration);
        }
        public IEnumerable<Aircraft> GetAllAircrafts()
        {
            return context.Aircrafts;
        }
        public void FillACInfo(ref Aircraft ac, Aircraft model)
        {
            ac.Id = model.Id;
            ac.Registration = model.Registration;
            ac.Model = model.Model;
            ac.ModelType = model.ModelType;
            ac.Effectivity = model.Effectivity;
            ac.BodyNo = model.BodyNo;
            ac.LineNo = model.LineNo;
            ac.SerialNo = model.SerialNo;
            ac.Engine = model.Engine;
            ac.DeliveryDate = model.DeliveryDate;
        }

    }

}
