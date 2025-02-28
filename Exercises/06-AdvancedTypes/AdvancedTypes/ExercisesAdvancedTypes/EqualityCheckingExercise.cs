﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdvancedTypes.ExercisesAdvancedTypes
{
    public class FullName
    {
        public string First { get; init; }
        public string Last { get; init; }

        public override string ToString() => $"{First} {Last}";

        public override bool Equals(object? obj)
        {
            return obj is FullName other &&
                    First == other.First &&
                    Last == other.Last;
        }
    }
}
