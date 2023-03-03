using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gems.Enterprise.WebApp.FirstApplication.Models
{
    internal class Options3
    {
        private bool option1 = false;
        private bool option2 = false;
        private bool option3 = false;
        private bool option4 = false;
        private bool option5 = false;

        // Properties
        public bool Option1
        {
            get { return option1; }   // get method
            set { option1 = value; }
        }
        public bool Option2
        {
            get { return option2; }   // get method
            set { option2 = value; }
        }
        public bool Option3
        {
            get { return option3; }   // get method
            set { option3 = value; }
        }
        public bool Option4
        {
            get { return option4; }   // get method
            set { option4 = value; }
        }
        public bool Option5
        {
            get { return option5; }   // get method
            set { option5 = value; }
        }
    }
}

