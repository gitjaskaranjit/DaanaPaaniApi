﻿using System;

namespace DaanaPaaniApi.infrastructure
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class SortableAttribute : Attribute
    {
    }
}