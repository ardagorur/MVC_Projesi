﻿using System;
using System.Collections.Generic;

#nullable disable

namespace Ilk_MVC_Projesi.Models
{
    public partial class OrderSubtotal
    {
        public int OrderId { get; set; }
        public decimal? Subtotal { get; set; }
    }
}
