using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DataLayer.EfClasses
{
    public class ConcurrencyBook
    {
        public int ConcurrencyBookId { get; set; }
        public string Title { get; set; }

        [Timestamp]
        public byte[] ChangeCheck { get; set; }
    }
}