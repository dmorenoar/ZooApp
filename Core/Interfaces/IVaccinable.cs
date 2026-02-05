using System;
using System.Collections.Generic;
using System.Text;

namespace ZooApp.Core.Interfaces
{
    public interface IVaccinable
    {
        void Vaccinate(string vaccine);
        DateTime? LastVaccinateDate { get; set; }
        bool NeedsVaccination => LastVaccinateDate is not DateTime date || (DateTime.Now - date).TotalDays > 30;
    }
}