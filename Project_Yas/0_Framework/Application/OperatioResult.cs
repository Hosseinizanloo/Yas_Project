using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _0_Framework.Applicatio
{
    public class OperatioResult
    {
        public bool IsSuccedded { get; set; } //باید بای دیفالت فالس باشه  زمانی که میخوایم اینیشیال کنیم ، فراخونی کنیم
        public string Message { get; set; }

        public OperatioResult()
        {
            IsSuccedded = false;
        }
        public OperatioResult Succedded(string message = "عملیات با موفقیت انجام شد")
        {
            IsSuccedded = true;
            Message = message;
            return this;// همین کلاس ریترن بشه بره 
        }
        public OperatioResult Failed(string message)
        {
            IsSuccedded = false;
            Message = message;
            return this;
        }
    }
}
