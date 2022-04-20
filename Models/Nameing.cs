using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Name.Models
{
    class Nameing
    {
        private string _lastname;
       

        public string lastname
        {
            get { return _lastname; }
            set { _lastname = value; }
        }
        private string _firstnme;

        public string firstname
        {
            get { return _firstnme; }
            set { _firstnme = value; }
        }
        private string _otchestvo;

        public string otchestvo
        {
            get { return _otchestvo; }
            set { _otchestvo = value; }
        }
        private int _age;

        public int age
        {
            get { return _age; }
            set { _age = value; }
        }



    }
}
