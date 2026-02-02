using System;
using System.Collections.Generic;
using System.Text;

namespace ZooApp.Core.Interfaces
{
    public interface IVaccinable
    {
        void Vaccinate(string vaccine);
        DateTime lastVaccinateDate { get; set; }
    }
}