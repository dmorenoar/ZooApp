using System;
using System.Collections.Generic;
using System.Text;

namespace Zoo.Core.Interfaces
{
    public interface IFeedable
    {
        void Feed(string food);
        bool IsHungry { get; set; }
    }
}