using NonProfitAccountSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace NonProfitAccountSystem.Models
{
    public class tbl_Accounts
    {
        dbcontrol s = new dbcontrol();
        [Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public Int32 ID { get; set; }

        [Display(Name = "Account Name")]
        public String AccountName { get; set; }

        [Display(Name = "Birthday")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? AccountBday { get; set; }

        [Display(Name = "Medicaid Recertification Date")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime? MedicaidDate { get; set; }

        [Display(Name = "AddressLine")]
        public String AddressLine { get; set; }

        [Display(Name = "City")]
        public String City { get; set; }

        [Display(Name = "State/Province")]
        public String State { get; set; }

        [Display(Name = "Zip/Postal Code")]
        public String Zipcode { get; set; }

        [Display(Name = "Phone Home")]
        public String PhoneHome { get; set; }

        [Display(Name = "Language")]
        public String Language { get; set; }

        [Display(Name = "HouseHold Indicator")]
        public String HouseHoldIndicator { get; set; }

        [Display(Name = "Subscriber")]
        [Required]
        public Int32? Subscriber { get; set; }
        public string SubscriberName { get; set; }

        [Display(Name = "Country Code")]
        public String CountryCode { get; set; }

        [Display(Name = "NonProfit Staff")]
        public String NonProfitStaff { get; set; }
        public String NonProfitStaffName { get; set; }

        [Display(Name = "CallAttemDateTime1")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? CallAttemDateTime1 { get; set; }

        [Display(Name = "Comment1")]
        public String Comment1 { get; set; }

        [Display(Name = "CallAttemDateTime2")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? CallAttemDateTime2 { get; set; }

        [Display(Name = "Comment2")]
        public String Comment2 { get; set; }

        [Display(Name = "CallAttemDateTime3")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? CallAttemDateTime3 { get; set; }

        [Display(Name = "Comment3")]
        public String Comment3 { get; set; }

        [Display(Name = "HomeVisitAttempDate")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? HomeVisitAttempDate { get; set; }

        [Display(Name = "HomeVisitComment")]
        public String HomeVisitComment { get; set; }

        [Display(Name = "Unreachable")]
        public Boolean? Unreachable { get; set; }

        [Display(Name = "ACA")]
        public Boolean? ACA { get; set; }

        [Display(Name = "PersonalNotes")]
        public String PersonalNotes { get; set; }

        [Display(Name = "Encoder")]
        [ScaffoldColumn(false)]
        public Int32 Encoder { get; set; }

        [Display(Name = "Timestamp")]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? Timestamp { get; set; }

        public HttpPostedFileBase ExcelFile { get; set; }

        public tbl_Accounts()
        {
        }
        public List<tbl_Accounts> List()
        {

            return s.Query<tbl_Accounts>("tbl_Accounts_Proc", p => { p.Add("@Type", "Search"); }, CommandType.StoredProcedure)
            .Select(r =>
            {

                return r;
            }).ToList();
        }

        public tbl_Accounts Find(int ID)
        {

            return s.Query<tbl_Accounts>("tbl_Accounts_Proc", p => { p.Add("@Type", "Find"); p.Add("@ID", ID); }, CommandType.StoredProcedure)
            .Select(r =>
            {

                return r;
            }).SingleOrDefault();
        }

        public void Create(tbl_Accounts obj)
        {
            s.Query("tbl_Accounts_Proc", p =>
            {
                p.Add("@Type", "Create");
                p.Add("@AccountName", obj.AccountName);
                p.Add("@AccountBday", obj.AccountBday);
                p.Add("@MedicaidDate", obj.MedicaidDate);
                p.Add("@AddressLine", obj.AddressLine);
                p.Add("@City", obj.City);
                p.Add("@State", obj.State);
                p.Add("@Zipcode", obj.Zipcode);
                p.Add("@PhoneHome", obj.PhoneHome);
                p.Add("@Language", obj.Language);
                p.Add("@HouseHoldIndicator", obj.HouseHoldIndicator);
                p.Add("@Subscriber", obj.Subscriber);
                p.Add("@CountryCode", obj.CountryCode);
                p.Add("@NonProfitStaff", SystemSession.User.ID);
                p.Add("@CallAttemDateTime1", obj.CallAttemDateTime1);
                p.Add("@Comment1", obj.Comment1);
                p.Add("@CallAttemDateTime2", obj.CallAttemDateTime2);
                p.Add("@Comment2", obj.Comment2);
                p.Add("@CallAttemDateTime3", obj.CallAttemDateTime3);
                p.Add("@Comment3", obj.Comment3);
                p.Add("@HomeVisitAttempDate", obj.HomeVisitAttempDate);
                p.Add("@HomeVisitComment", obj.HomeVisitComment);
                p.Add("@Unreachable", obj.Unreachable);
                p.Add("@ACA", obj.ACA);
                p.Add("@PersonalNotes", obj.PersonalNotes);
                p.Add("@Encoder", SystemSession.User.ID);

            }, CommandType.StoredProcedure);
        }

        public void Update(tbl_Accounts obj)
        {
            s.Query("tbl_Accounts_Proc", p =>
            {
                p.Add("@Type", "Update");
                p.Add("@ID", obj.ID);
                p.Add("@AccountName", obj.AccountName);
                p.Add("@AccountBday", obj.AccountBday);
                p.Add("@MedicaidDate", obj.MedicaidDate);
                p.Add("@AddressLine", obj.AddressLine);
                p.Add("@City", obj.City);
                p.Add("@State", obj.State);
                p.Add("@Zipcode", obj.Zipcode);
                p.Add("@PhoneHome", obj.PhoneHome);
                p.Add("@Language", obj.Language);
                p.Add("@HouseHoldIndicator", obj.HouseHoldIndicator);
                p.Add("@Subscriber", obj.Subscriber);
                p.Add("@CountryCode", obj.CountryCode);
                p.Add("@NonProfitStaff", SystemSession.User.ID);
                p.Add("@CallAttemDateTime1", obj.CallAttemDateTime1);
                p.Add("@Comment1", obj.Comment1);
                p.Add("@CallAttemDateTime2", obj.CallAttemDateTime2);
                p.Add("@Comment2", obj.Comment2);
                p.Add("@CallAttemDateTime3", obj.CallAttemDateTime3);
                p.Add("@Comment3", obj.Comment3);
                p.Add("@HomeVisitAttempDate", obj.HomeVisitAttempDate);
                p.Add("@HomeVisitComment", obj.HomeVisitComment);
                p.Add("@Unreachable", obj.Unreachable);
                p.Add("@ACA", obj.ACA);
                p.Add("@PersonalNotes", obj.PersonalNotes);
                p.Add("@Encoder", SystemSession.User.ID);

            }, CommandType.StoredProcedure);
        }
        public void Delete(tbl_Accounts obj)
        {
            s.Query("DELETE FROM [tbl_Accounts] WHERE ID = @ID", p =>
            {
                p.Add("@ID", obj.ID);
            });
        }
    }


}