using System;
using System.Collections.Generic;

namespace ChiVauVa.Models;

public partial class PriceHistory
{
    public int PriceId { get; set; }

    public int PartId { get; set; }

    public decimal Price { get; set; }

    public DateOnly EffectiveDate { get; set; }

    public DateOnly? EndDate { get; set; }

    public virtual Part Part { get; set; } = null!;
}
