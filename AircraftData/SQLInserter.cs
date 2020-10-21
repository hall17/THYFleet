using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Text;

namespace AircraftData
{
    public class SQLInserter
    {
        public List<Aircraft> _ACList;
        public SQLInserter()
        {
            _ACList = new List<Aircraft>()
            {
                new Aircraft() { Registration = "TC-JJE", Effectivity ="001", Model="B777", ModelType ="B777-300ER", Engine="GE90-115BL", BodyNo="WE126", LineNo="895", SerialNo="40707", DeliveryDate =DateTime.Today },
                new Aircraft() { Registration = "TC-JNA", Effectivity ="201", Model="A330", ModelType ="A330-203", Engine="CF6-80E1A3", BodyNo=null, LineNo=null, SerialNo="697", DeliveryDate =DateTime.Today },
                new Aircraft() { Registration = "TC-JRA", Effectivity ="303", Model="A321", ModelType ="A321-231", Engine="V2533-A5", BodyNo=null, LineNo=null, SerialNo="2823", DeliveryDate =DateTime.Today },
                new Aircraft() { Registration = "TC-JYA", Effectivity ="201", Model="B737", ModelType ="B737-900ER", Engine="CFM56-7B27/F", BodyNo="YH611", LineNo="3669", SerialNo="40973", DeliveryDate =DateTime.Today },
                new Aircraft() { Registration = "TC-LLA", Effectivity ="001", Model="B787", ModelType ="B787-9", Engine="GEnx-1B74/75", BodyNo="ZE220", LineNo="0865", SerialNo="65801", DeliveryDate =DateTime.Today },

            };
        }
    }
}
