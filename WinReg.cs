using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FYP
{
    class WinReg
    {
        public void SetRegistry()
        {
            RegistryKey crk1 = Registry.CurrentUser.CreateSubKey(@"KEY\MAC");
            //RegistryKey crk2 = Registry.CurrentUser.CreateSubKey(@"KEY\KEY");
            RegistryKey crk2 = Registry.CurrentUser.CreateSubKey(@"MAC_PASS\Pass");
            crk2.SetValue("Pass", "abc");
            crk1.Close();
        }
        public void Set_Registry_of_Mac(string mac)
        {
            RegistryKey crk1 = Registry.CurrentUser.CreateSubKey(@"KEY\MAC");
            crk1.SetValue("MAC", mac);
            crk1.Close();
        }

        public string Get_Registry(string pass, string key)
        {
            RegistryKey check_key = Registry.CurrentUser.OpenSubKey(pass);
            string Rkey = "";
            if (check_key != null)
            {

                Rkey = check_key.GetValue(key).ToString();
                return Rkey;
            }
            else
            {
                return "No key";
            }
        }




    }
}
