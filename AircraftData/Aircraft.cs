﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace AircraftData
{
    public class Aircraft
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Model { get; set; }
        [Required]
        [Display(Name = "Model Type")]
        public string ModelType { get; set; }
        [Required]
        public string Registration { get; set; }
        [Required]
        public string Effectivity { get; set; }
        [Display(Name = "Body Number")]
        public string BodyNo { get; set; }
        [Display(Name = "Line Number")]

        public string LineNo { get; set; }
        [Display(Name = "Serial Number")]

        public string SerialNo { get; set; }
        [Required]
        public string Engine { get; set; }
        public DateTime DeliveryDate { get; set; }

    }
}
