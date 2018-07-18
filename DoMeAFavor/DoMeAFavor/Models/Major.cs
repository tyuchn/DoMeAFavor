using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoMeAFavor.Models
{
   public class Major
    {
        private string _majorName = "";
       

        public string Name
        {
            get { return _majorName; }
            set
            {
                _majorName = value;
            }
        }

    }
}
