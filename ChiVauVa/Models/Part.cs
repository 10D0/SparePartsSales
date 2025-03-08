using System;
using System.Collections.Generic;

namespace ChiVauVa.Models;

public partial class Part
{
    public int PartId { get; set; }

    public string Name { get; set; } = null!;

    public string? ArticleNumber { get; set; }

    public string? Notes { get; set; }

    public int? Quantity { get; set; }

    public DateTime? LastUpdated { get; set; }

    public virtual ICollection<Delivery> Deliveries { get; set; } = new List<Delivery>();

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<PriceHistory> PriceHistories { get; set; } = new List<PriceHistory>();
}
