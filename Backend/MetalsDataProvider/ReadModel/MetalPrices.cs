﻿using Model;
using System.Collections.Generic;

namespace MetalsDataProvider.ReadModel
{
    public class MetalPrices
    {
        public DataSource DataSource { get; set; }
        public Currency Currency { get; set; }
        public List<MetalPriceDate> Prices { get; set; }
    }
}
