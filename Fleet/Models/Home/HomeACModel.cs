using AircraftData;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Fleet.Models.Home
{
    public class HomeACModel
    {
        public Aircraft aircraft { get; set; }
        public Model ACmodel { get; set; }
        public ModelType ACmodelType { get; set; }
        public EngineType ACengineType { get; set; }

        // Variables only available for the Details will be implemented later on.

        public Aircraft FillACInfo(HomeACModel model)
        {
            Aircraft ac = new Aircraft();
            ac.Id = model.aircraft.Id;
            ac.Registration = model.aircraft.Registration;
            ac.Effectivity = model.aircraft.Effectivity;
            ac.Model = model.ACmodel.ToString();
            ac.ModelType = model.ACmodelType.DisplayName();
            ac.Engine = model.ACengineType.DisplayName();
            ac.Engine = model.aircraft.Engine;
            ac.BodyNo = model.aircraft.BodyNo;
            ac.LineNo = model.aircraft.LineNo;
            ac.SerialNo = model.aircraft.SerialNo;
            ac.DeliveryDate = model.aircraft.DeliveryDate;
            return ac;
        }
        public static HomeACModel FillACModelInfo(Aircraft ac)
        {
            HomeACModel model = new HomeACModel();
            model.aircraft = ac;
            model.ACmodel = (Model)System.Enum.Parse(typeof(Model), ac.Model);
            model.ACmodelType = HomeACModel.EnumHelper<ModelType>.GetValueFromName(ac.ModelType);
            model.ACengineType = HomeACModel.EnumHelper<EngineType>.GetValueFromName(ac.Engine);
            return model;
        }
        public static class EnumHelper<T>
        {
            public static T GetValueFromName(string name)
            {
                var type = typeof(T);
                foreach (var field in type.GetFields())
                {
                    var attribute = Attribute.GetCustomAttribute(field,
                        typeof(DisplayAttribute)) as DisplayAttribute;
                    if (attribute != null)
                    {
                        if (attribute.Name == name)
                        {
                            return (T)field.GetValue(null);
                        }
                    }
                    else
                    {
                        if (field.Name == name)
                            return (T)field.GetValue(null);
                    }
                }
                throw new ArgumentOutOfRangeException("name");

            }

        }
    }
    public enum Model
    {
        B737,
        A321,
        A330,
        B777,
        B787
    }
    public enum ModelType
    {
        [Display(Name = "A321")]
        A321,
        [Display(Name = "B737-700")]
        B7377,
        [Display(Name = "B737-800")]
        B7378,
        [Display(Name = "B737-900")]
        B7379,
        [Display(Name = "B777-300ER")]
        B777,
        [Display(Name = "B777-F")]
        B777F,
        [Display(Name = "B787-9")]
        B7879,
        [Display(Name = "A330-203")]
        A330203,
        [Display(Name = "A330-303")]
        A330303
    }
    public enum EngineType
    {
        [Display(Name = "V2533-A5")]
        A321,
        [Display(Name = "CFM56-7B24")]
        B7377,
        [Display(Name = "CFM56-7B26")]
        B7378,
        [Display(Name = "CFM56-7B27/F")]
        B7379,
        [Display(Name = "GE90-115BL")]
        B777,
        [Display(Name = "GE90-110B")]
        B777F,
        [Display(Name = "GEnx-1B74/75")]
        B7879,
        [Display(Name = "CF6-80E1A3")]
        A330203,
        [Display(Name = "CF6-80E1A3")]
        A330303
    }
    public static class MyEnumExtensions
    {
        public static string DisplayName(this object val)
        {
            DisplayAttribute[] attributes = (DisplayAttribute[])val
               .GetType()
               .GetField(val.ToString())
               .GetCustomAttributes(typeof(DisplayAttribute), false);
            return attributes.Length > 0 ? attributes[0].Name : string.Empty;
        }

    }

}
