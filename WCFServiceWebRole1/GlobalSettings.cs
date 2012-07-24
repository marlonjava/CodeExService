using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;
using System.Text;

namespace HoiioWCFService
{
    public class GlobalSettings
    {
        private static GlobalSettings _instance = null;

        Dictionary<String, PhoneBook> phoneBookDictionary = new Dictionary<string, PhoneBook>();

        private string transferMessage;

        private string otherMessage;

        public string TransferMessage
        {
            get { 
                return transferMessage; }
            set { transferMessage = value; }
        }

        public string GetMobileNumber(string digitKey)
        {
            PhoneBook p = phoneBookDictionary[digitKey];
            return p.MobileNumber;
        }

        private String welcomeMessage = "";

        public String WelcomeMessage
        {
            get {
               
                return welcomeMessage;
            }
            set { welcomeMessage = value; }
        }
        private String gatherMessage = "";

        public String GatherMessage
        {
            get {
               
                return gatherMessage; }
            set { gatherMessage = value; }
        }
        private String byeMessage = "";

        public String ByeMessage
        {
            get {
                
                return byeMessage;
            }
            set { byeMessage = value; }
        }

        private GlobalSettings()
        {
            RefreshSettings();
        }

        public void RefreshSettings()
        {
            reloadMessageSettings();
            reloadPhoneBookSettings();
        }

        private void reloadMessageSettings()
        {

  
            string strSql = "select * from HOIIO_IVRMessages";
            SqlConnection con = null;
            SqlDataAdapter dadapter = null;
            DataSet dset = null;
            string constr = "Server=tcp:wozgxd956r.database.windows.net,1433;Database=WMSDB;User ID=dev@wozgxd956r;Password=ctr@n123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

            try
            {
                // setup the database connection
                con = new SqlConnection(constr);
                con.Open();

                dadapter = new SqlDataAdapter();
                dadapter.SelectCommand = new SqlCommand(strSql, con);
                dset = new DataSet();
                dadapter.Fill(dset);

                foreach (DataRow r in dset.Tables[0].Rows)
                {
                    if (r["Code"].ToString() == "WELCOME")
                    {
                        welcomeMessage =r["Msg"].ToString();
                    }

                    if (r["Code"].ToString() == "GATHER")
                    {
                        gatherMessage = r["Msg"].ToString();
                    }

                    if (r["Code"].ToString() == "BYE")
                    {
                        byeMessage = r["Msg"].ToString();
                    }
                    if (r["Code"].ToString() == "TRANSFER")
                    {
                        transferMessage = r["Msg"].ToString();
                    }
                    if (r["Code"].ToString() == "OTHER")
                    {
                        otherMessage = r["Msg"].ToString();
                    }

                    


                    
                }

                dset.Dispose();
                dadapter.Dispose();


            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                dadapter.Dispose();
                dset.Dispose();

                // dispose of open objects
                if (con != null)
                    con.Close();
            } //fi

        }


        private void reloadPhoneBookSettings()
        {


            string strSql = "select * from HOIIO_IVRPhoneBook";
            SqlConnection con = null;
            SqlDataAdapter dadapter = null;
            DataSet dset = null;
            string constr = "Server=tcp:wozgxd956r.database.windows.net,1433;Database=WMSDB;User ID=dev@wozgxd956r;Password=ctr@n123;Trusted_Connection=False;Encrypt=True;Connection Timeout=30;";

            try
            {
                // setup the database connection
                con = new SqlConnection(constr);
                con.Open();

                dadapter = new SqlDataAdapter();
                dadapter.SelectCommand = new SqlCommand(strSql, con);
                dset = new DataSet();
                dadapter.Fill(dset);
                int rowsCnt = 0;

                StringBuilder sb = new StringBuilder();
                sb.Append(gatherMessage);

                phoneBookDictionary.Clear();

                foreach (DataRow r in dset.Tables[0].Rows)
                {
                    rowsCnt++;

                    PhoneBook p = new PhoneBook ();
                    p.KeyBind = r["DigitKey"].ToString();
                    p.MobileNumber = r["PhoneNo"].ToString();
                    p.MobileOwner = r["PhoneOwner"].ToString();
                    phoneBookDictionary.Add(p.KeyBind, p);

                    sb.Append(string.Format ("Press {0} to call {1}. ", p.KeyBind, p.MobileOwner));
                   


                }

                //sb.Append("Or press 0 to call the police. Ha ha ha ha. I'm just kidding. Don't be mad please. Ok, i'm serious now. Press 0 for other massage services. We offer Thai massage. Chinese. Filipino. And indonesian massage.  ");
                sb.Append(otherMessage);


                gatherMessage = sb.ToString ().Replace("{0}", rowsCnt.ToString());

                dset.Dispose();
                dadapter.Dispose();


            }
            catch (Exception ex)
            {
                //
            }
            finally
            {
                dadapter.Dispose();
                dset.Dispose();

                // dispose of open objects
                if (con != null)
                    con.Close();
            } //fi

        }

        public static GlobalSettings Instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new GlobalSettings();
                }

                

                return _instance;
            }
        }

        public String AppID
        {
            get
            {
                return "BoyzncRUaIw8fIRx";
            }
        }

        public String AppToken
        {
            get
            {
                return "Ef3FcqRvnMWwbcGM";
            }
        
        }

        public String CallBackURL
        {
            get
            {
                return "http://codex2012.cloudapp.net/CommService/";
            }

        }
    }
}