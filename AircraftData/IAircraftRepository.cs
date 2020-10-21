using System;
using System.Collections.Generic;
using System.Text;

namespace AircraftData
{
    public interface IAircraftRepository
    {
        Aircraft GetAircraftbyRegistration(string Registration);
        Aircraft GetAircraftbyID(int Id);
        IEnumerable<Aircraft> GetAllAircrafts();
        Aircraft AddAC(Aircraft ac);
        Aircraft UpdateAC(Aircraft ac);
        Aircraft DeleteAC(Aircraft ac);
    }
}
