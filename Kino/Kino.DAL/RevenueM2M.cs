namespace Kino.DAL
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RevenueM2M
    {
        public Guid id { get; set; }

        public Guid RevenueItemId { get; set; }

        public Guid MemberHistoryId { get; set; }

        public virtual MemberHistory MemberHistory { get; set; }

        public virtual RevenueItem RevenueItem { get; set; }
    }
}
