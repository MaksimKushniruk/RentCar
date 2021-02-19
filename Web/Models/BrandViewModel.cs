using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Web.Models
{
    public class BrandViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<CarViewModel> Cars { get; set; }
        public BrandViewModel()
        {
            Cars = new List<CarViewModel>();
        }
    }
}
