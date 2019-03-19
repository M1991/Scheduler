using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using static Scheduler.Models.ApplicationDbContext;

namespace Scheduler.ServiceFilters
{
    public class LoginTrapper
    {

        public string GetUser_IPss()
        {
            string VisitorsIPAddr = string.Empty;
            //if (HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"] != null)
            if (HttpContext.Current.Request.ServerVariables["HTTP_X_CLUSTER_CLIENT_IP"] != null)
            {
              return  VisitorsIPAddr = HttpContext.Current.Request.ServerVariables["HTTP_X_CLUSTER_CLIENT_IP"].ToString();
            }
            else if (HttpContext.Current.Request.UserHostAddress.Length != 0)
            {
             return VisitorsIPAddr = HttpContext.Current.Request.UserHostAddress;
            }
            //  uip.Text = "Your IP is: " + VisitorsIPAddr;
            Console.WriteLine(VisitorsIPAddr);
            return VisitorsIPAddr;
        }

        public string GetUser_IP()
        {
            /* string hostName = Dns.GetHostName(); // Retrive the Name of HOST  
             //HttpWebRequest httpReq = new HttpWebRequest.Connection;
             Console.WriteLine(hostName);
             // Get the IP  
 #pragma warning disable CS0618 // Type or member is obsolete
             string myIP = Dns.GetHostByName(hostName).AddressList[0].ToString();
 #pragma warning restore CS0618 // Type or member is obsolete
             //Console.WriteLine("My IP Address is :" + myIP);
             //Console.ReadKey();
             return myIP; */

            string ipList = HttpContext.Current.Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            string gtHost = HttpContext.Current.Request.Url.AbsolutePath;
            if (!string.IsNullOrEmpty(ipList))
            {
                return ipList.Split(',')[0];
            }

            return HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];
        }
    }
}