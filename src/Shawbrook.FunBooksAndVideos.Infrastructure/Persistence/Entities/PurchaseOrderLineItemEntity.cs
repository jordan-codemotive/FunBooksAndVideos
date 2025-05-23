﻿using System.ComponentModel.DataAnnotations;

namespace Shawbrook.FunBooksAndVideos.Infrastructure.Persistence.Entities
{
    internal class PurchaseOrderLineItemEntity
    {
        [Key]
        public int Id { get; set; }
        public int PurchaseOrderId { get; set; }
        public int Quantity { get; set; }
        public double Price { get; set; }
        public byte? MembershipType { get; set; }
        public int? ProductId { get; set; }

        public PurchaseOrderEntity? PurchaseOrder { get; set; }
    }
}
