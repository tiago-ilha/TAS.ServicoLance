using System;
using System.Collections.Generic;
using System.Text;

namespace TAS.SL.Dominio.DTO
{
    public class DetalheLanceDTO
    {
        public Guid IdLance { get; set; }
        public decimal Valor { get; set; }
        public bool Fechado { get; set; }
    }
}
