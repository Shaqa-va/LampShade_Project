using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopManagement.Application.Contracts.Comment
{
    public class CommentViewModel
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public bool IsConfirmed { get; set; }
        public bool IsCanceled { get; set; }
        public string Message { get; set; }
        public long ProductId { get; set; }
        public string ProductName { get; set; }
        public string CommentData { get; set; }
    }
}
