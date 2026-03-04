using System.ComponentModel.DataAnnotations;

namespace BizSecureDemo22180035.ViewModels
{
    public class CreateOrderVm
    {
        [Required, MaxLength(300)]
        public string Title { get; set; } = "";
        [Required]
        public decimal Amount { get; set; }

    }
}
