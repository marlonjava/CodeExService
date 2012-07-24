using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HoiioWCFService
{
    public class PhoneBook
    {
        private string keyBind;

        public string KeyBind
        {
            get { return keyBind; }
            set { keyBind = value; }
        }
        private string mobileNumber;

        public string MobileNumber
        {
            get { return mobileNumber; }
            set { mobileNumber = value; }
        }
        private string mobileOwner;

        public string MobileOwner
        {
            get { return mobileOwner; }
            set { mobileOwner = value; }
        }
        
    }
}