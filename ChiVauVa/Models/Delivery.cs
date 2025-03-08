using System;
using System.Collections.Generic;

namespace ChiVauVa.Models;

public partial class Delivery
{
    public int DeliveryId { get; set; }

    public int SupplierId { get; set; }

    public int PartId { get; set; }

    public int Quantity { get; set; }

    public DateOnly DeliveryDate { get; set; }

    public decimal Price { get; set; }

    public virtual Part Part { get; set; } = null!;

    public virtual Supplier Supplier { get; set; } = null!;
}
