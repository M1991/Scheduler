using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Data;
using System.Web;
using System.Web.Mvc;
using Scheduler.Models;
using System.Data.Entity;


namespace Scheduler.ServiceFilters
{
    public class CheckServicesAll 
    {
        ApplicationDbContext apd = new ApplicationDbContext();
        

        public enum NextStations
        {
            [Display(Name = "Not Started")]
            NotStarted =1,
            [Display(Name = "Launching")]
            Launching = 2,
            [Display(Name = "Tube Cutting")]
            TubeCutting = 3,
            [Display(Name = "Ceramic Cutting")]
            CeramicCutting = 4,
            [Display(Name = "Winding Core")]
            WindingCore = 5,
            [Display(Name = "Assembly")]
            Assembly = 6,
            [Display(Name = "Sand Filling")]
            SandFilling = 7,
            [Display(Name = "End Cap Weilding")]
            EndCapWeilding = 8,
            [Display(Name = "Swagging")]
            Swagging = 9,
            [Display(Name = "Grinding")]
            Grinding = 10,
            [Display(Name = "Lathe")]
            Lathe = 11,
            [Display(Name = "End Product")]
            EndProduct = 12,
            [Display(Name = "Potting")]
            Potting = 13,
            [Display(Name = "Final Inspection")]
            FinalInspection = 14,
            [Display(Name = "Q.C.")]
            QC = 15
        };

       public enum NextTCStations
        {
            ///Thermocouples
            [Display(Name = "Not Started")]
            NotStarted = 1,
            [Display(Name = "Cable Preparation")]
            CablePreparation = 2,
            [Display(Name = "Tip Preparation")]
            TipPreparation = 3,
            [Display(Name = "Assembly")]
            Assembly = 4,
            [Display(Name = "Sealing")]
            Sealing = 5,          
            [Display(Name = "Termination")]
            Termination = 6,
            [Display(Name = "Calibration")]
            Calibration = 7,          
            [Display(Name = "Final Inspection")]
            FinalInspection = 8,
            [Display(Name = "Q.C.")]
            QC = 9
        }; 

        public int value { get; set; }

        public void GetProgValue(Guid somVal)
        {
            //var val = apd.DbEvents.Where()
        ManageViewModelNew mbvM = new ManageViewModelNew();
           // var totNo = apd.DbEvents.Where(m => m.endt > DateTime.Now).Select(m => m.TotpartNo).FirstOrDefault();
            //var totSoNo = apd.DbEvents.Where(m => m.endt > DateTime.Now).Select(m => m.SONo).FirstOrDefault();
            /// Can check the statn for Events, if not started else change when updating start and end
        //    mbvM.EventsEnu = apd.DbEvents.Where(m => m.endt > DateTime.Now).ToList();
            mbvM.EventsEnu = apd.DbEvents.Where(m => m.uId.Equals(somVal)).ToList();
            foreach (var item in mbvM.EventsEnu)
            {
                if (item.SONo != null)
                {
                    var totPrts = apd.DbEvents.Where(m => m.SONo.Equals(item.SONo)).Select(m => m.nowAtStatn).FirstOrDefault();
                    var totNo = apd.DbEvents.Where(m => m.SONo.Equals(item.SONo)).Select(m => m.TotpartNo).FirstOrDefault();
                    mbvM.SoNoEventdsList = apd.DbSoNosEvents.Where(m => m.SoNo.Equals(item.SONo)).ToList();
                    foreach (var item2 in mbvM.SoNoEventdsList)
                    {
                        if (item2.HCategory.Equals("TC-OTH") || item2.HCategory.Equals("TC-RTD"))
                        {
                            switch (item2.StatnUpdt)
                            {
                               
                                case "Cable Preparation":
                                    value += (10 / totNo);
                                    updateDatabase(item2.uUid, value);
                                    break;

                                case "Tip Preparation":
                                    value += (20 / totNo);
                                    updateDatabase(item2.uUid, value);
                                    break;

                                case "Assembly":
                                    value += (30 / totNo);
                                    updateDatabase(item2.uUid, value);
                                    break;
                                case "Sealing":
                                    value += (40 / totNo);
                                    updateDatabase(item2.uUid, value);
                                    break;

                                case "Termination":
                                    value += (60 / totNo);
                                    updateDatabase(item2.uUid, value);
                                    break;

                                case "Calibration":
                                    value += (70 / totNo);
                                    updateDatabase(item2.uUid, value);
                                    break;
                                
                                case "Final Inspection":
                                    value += (90 / totNo);
                                    updateDatabase(item2.uUid, value);
                                    break;
                                case "QC":
                                    value += (100 / totNo);
                                    updateDatabase(item2.uUid, value);
                                    break;

                                default:
                                    value += 0;
                                    updateDatabase(item2.uUid, value);
                                    break;
                            }
                        }
                        else
                        {
                            switch (item2.StatnUpdt)
                        {
                            case "Tube Cutting":
                            case "Ceramic Cutting" : value += (10 / totNo);
                                                updateDatabase(item2.uUid, value);
                                                break;

                            case "Winding Core": value += (20 / totNo);
                                updateDatabase(item2.uUid, value);
                                break;

                            case "Assembly":
                            case "Sand Filling": value += (30 / totNo);
                                        updateDatabase(item2.uUid, value);
                                        break;
                            case "End Cap Weilding": value += (40 / totNo);
                                updateDatabase(item2.uUid, value);
                                break;

                            case "Swagging": value += (50 / totNo);
                                updateDatabase(item2.uUid, value);
                                break;

                            case "Grinding": value += (60 / totNo);
                                updateDatabase(item2.uUid, value);
                                break;
                            case "Lathe": value += (70 / totNo);
                                updateDatabase(item2.uUid, value);
                                break;
                            case "End Product": value += (80 / totNo);
                                updateDatabase(item2.uUid, value);
                                break;
                            case "Potting": value += (90 / totNo);
                                updateDatabase(item2.uUid, value);
                                break;
                            case "Final Inspection": value += (100 / totNo);
                                updateDatabase(item2.uUid, value);
                                break;
                            case "QC": value += (100 / totNo);
                                updateDatabase(item2.uUid, value);
                                break;

                            default: value += 0;
                                updateDatabase(item2.uUid, value);
                                break;
                        }
                        }

                        #region IF-ELSE for above code
                        //if((item2.StatnUpdt.Equals("Tube Cutting")) || item2.StatnUpdt.Equals("Ceramic Cutting"))
                        //{
                        //    value += (10/totNo);
                        //    updateDatabase(item2.uUid, value);
                        //}
                        //else if(item2.StatnUpdt.Equals("Winding Core"))
                        //{
                        //    value += (20 / totNo);
                        //    updateDatabase(item2.uUid, value);
                        //}
                        //else if ((item2.StatnUpdt.Equals("Assembly")) || item2.StatnUpdt.Equals("Sand Filling"))
                        //{
                        //    value += (30 / totNo);
                        //    updateDatabase(item2.uUid, value);
                        //}
                        //else if (item2.StatnUpdt.Equals("End Cap Weilding"))
                        //{
                        //    value += (40 / totNo);
                        //    updateDatabase(item2.uUid, value);
                        //}
                        //else if (item2.StatnUpdt.Equals("Swagging"))
                        //{
                        //    value += (50 / totNo);
                        //    updateDatabase(item2.uUid, value);
                        //}
                        //else if (item2.StatnUpdt.Equals("Grinding"))
                        //{
                        //    value += (60 / totNo);
                        //    updateDatabase(item2.uUid, value);
                        //}
                        //else if (item2.StatnUpdt.Equals("Lathe"))
                        //{
                        //    value += (70 / totNo);
                        //    updateDatabase(item2.uUid, value);
                        //}
                        //else if (item2.StatnUpdt.Equals("End Product"))
                        //{
                        //    value += (80 / totNo);
                        //    updateDatabase(item2.uUid, value);
                        //}
                        //else if (item2.StatnUpdt.Equals("Potting"))
                        //{
                        //    value += (90 / totNo);
                        //    updateDatabase(item2.uUid, value);
                        //}
                        //else if (item2.StatnUpdt.Equals("Final Inspection"))
                        //{
                        //    value += (100 / totNo);
                        //    updateDatabase(item2.uUid, value);
                        //}
                        //else
                        //{
                        //    value += 0;
                        //    updateDatabase(item2.uUid, value);
                        //}
#endregion
                    }

                }

            }
        }

        public void updateDatabase(Guid uId, int val)
        {
            try
            {
                var dbUser = apd.DbEvents.Find(uId);
                dbUser.value = val;
                apd.Entry(dbUser).State = EntityState.Modified;
                apd.SaveChanges();
            }
            catch (Exception ex)
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                //ModelState.AddModelError(String.Empty, "Unable to add to scheduler. Some error occured");
                throw ex;
                
            }           
        }

       // public void updateNotfDatabase(ApplicationDbContext.Notification_Access nac)
        public void updateNotfDatabase()
        { ///  Not NEEDED    ---    UPDATING  DATABASE  FROM  SERVICE
            try
            {
                //Db value last
              // ApplicationDbContext.Notification_Access nac = new ApplicationDbContext.Notification_Access();
            //   var nac = apd.notificationAccess.Where(d => d.lastEvCnt > 0).FirstOrDefault();
               var nac = apd.notificationAccess.Find(2);
                var nottf = apd.DbEvents.Where(m => m.TotpartNo > 0).Count();
                string soStat = apd.DbEvents.Where(s => s.SONo.Equals(nac.evLsono)).Select(g => g.SONo).ToString();
                List<ApplicationDbContext.SoNosEvent> ev = new List<ApplicationDbContext.SoNosEvent>();
                ev = apd.DbSoNosEvents.Where(m => m.SoNo.Equals(soStat)).ToList();
                foreach (var item in ev)
                {
                    if (item.Hdesc.Equals("Not Open"))
                    {

                    }
                }
                //Count last value
                var nowValue = apd.notificationAccess.Where(d => d.lastEvCnt > 0).Select(d => d.lastEvCnt).FirstOrDefault();
                // var dbNotfUser = apd.DbEvents.Find(uId);
                if(nottf > nowValue)
                {
                    nac.lastEvCnt = nottf;
                    apd.Entry(nac).State = EntityState.Modified;                    
                    apd.SaveChanges();
                }                
            }
            catch (Exception ex)
            {
                //var errors = ModelState.Values.SelectMany(v => v.Errors);
                //ModelState.AddModelError(String.Empty, "Unable to add to scheduler. Some error occured");
                throw ex;

            }
        }
    }
}