using Scheduler.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Scheduler.ServiceFilters
{
    public class SOViewClass
    {
    }
    public class BothSOView
    {
        public List<ManageViewModelNew> SomeModel { get; set; }
        [Key]
        public Guid uId;
        public int eventId;

        [Display(Name = "Department")]
        public string etDept;

        [Display(Name = "Event Title")]
        public string title;

        [DataType(DataType.Date)]
        [Display(Name = "Event Start Date")]
        public System.DateTime startt;
        [DataType(DataType.Date)]
        [Display(Name = "Event End Date")]
        public System.DateTime endt;
        [Display(Name = "Customer Name")]
        public string proCustomer;
        public bool allDay;
        public string color;

        [Display(Name = "Description")]
        public string eDesc;
        public string trigPerson;

        public string PoNo;
        public string PoStatus;
        [Display(Name = "S.O. Number")]
        
        public string SONo;

        public string SoStatus;
        public string JoNo;
        [Display(Name = "Now at Station")]
        public string nowAtStatn;

        public int TotpartNo;
        public string comments;
        public string EventsStatus;
        public string backgColor;
        public string borderColor;
        public string textColor;
        [DataType(DataType.Date)]
        [Display(Name = "Date Created")]
        //public DateTime? DeliveryDate;
        public System.DateTime dtCreated;
        [DataType(DataType.Date)]
        public System.DateTime RescDated;
       
        public int id;
        public Guid uUid;
        [Required]
        public string SoNo;
        public bool AddNewPartNo;
        [Display(Name = "Part No.")]
        public IList<String> MultiplePartNo;
        [Required]
        [Display(Name = "Quantity")]
        public IList<Int16> MultiplePartQtyNo;
        [Required]
        [Display(Name = "Category")]
        public  IList<String> HCategory;
        [Required]
        [Display(Name = "Diameter")]
        public  IList<Decimal> HDia;
        [Required]
        [Display(Name = "Length")]
        public  IList<Decimal> HLength;
        [Required]
        [Display(Name = "Accessories")]
        public  IList<String> Accessr;
        [Required]
        [Display(Name = "Lead Length")]
        public  IList<Decimal> HLLength;
        [Required]
        [Display(Name = "Potting")]
        public  IList<String> Potting;
        [Required]
        [Display(Name = "Lead Protection")]
        public  IList<String> LeadProtect;
        [Display(Name = "Description")]
        public  IList<String> Hdesc;
        [Required]
        [Display(Name = "Now At Station")]
        public  IList<String> StatnUpdt;
    }
}