using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Delve{
    internal class ExploreResult{
        public StringBuilder sb;
        public enum ExploreResultType{
            Resources=1,
            TradeGoods,
            NaturalFormations,
            Remnants
        }
        public ExploreResultType Type;
        public int Resources=0;
        public int TradeGoods=0;
        public NaturalFormation? Naturalformation=null;
        public Remnant? Remnants=null;
        public string Log{
            get { return sb.ToString(); }
            set { sb.AppendLine(value); }
        }
        public ExploreResult(){
         sb=new StringBuilder();
        }
    }
}
