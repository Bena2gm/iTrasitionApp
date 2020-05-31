using iTrasitionApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace iTrasitionApp.ViewModel
{
    public class CompanyViewModel
    {
        public IEnumerable<Company> Company { get; set; }
        public PageViewModel PageViewModel { get; set; }
    }
}
