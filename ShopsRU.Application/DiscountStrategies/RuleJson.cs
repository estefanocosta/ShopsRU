using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopsRU.Application.DiscountStrategies
{
    public class RuleJson
    {
        public List<int> ExcludeCategories { get; set; }
        public int CustomerAgeMinYear { get; set; }
        public int SubLimit { get; set; }
        public decimal SubLimitApplyDiscountAmount { get; set; }
    }
}
