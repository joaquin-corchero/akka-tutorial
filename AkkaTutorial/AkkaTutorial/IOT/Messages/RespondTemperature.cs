using System;
using System.Collections.Generic;
using System.Text;

namespace AkkaTutorial.IOT.Messages
{
    internal sealed class RespondTemperature
    {
        public RespondTemperature(double? value)
        {
            Value = value;
        }

        public double? Value { get; }
    }
}
