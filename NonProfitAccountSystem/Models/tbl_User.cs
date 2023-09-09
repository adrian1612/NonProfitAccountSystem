using NonProfitAccountSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;

namespace NonProfitAccountSystem.Models
{
    public static class SystemSession
    {
        public static tbl_User User { get { return (tbl_User)HttpContext.Current.Session["User"]; } }
    }

    public class tbl_User
    {
        dbcontrol s = new dbcontrol();
        [Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public Int32 ID { get; set; }

        [Display(Name = "Username")]
        [Required]
        public String Username { get; set; }

        [Display(Name = "Password")]
        [Required]
        public String Password { get; set; }

        [Display(Name = "Encoder")]
        [ScaffoldColumn(false)]
        public Int32 Encoder { get; set; }

        [Display(Name = "Timestamp")]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? Timestamp { get; set; }

        public tbl_User()
        {
        }
        public List<tbl_User> List()
        {

            return s.Query<tbl_User>("tbl_User_Proc", p => { p.Add("@Type", "Search"); }, CommandType.StoredProcedure)
            .Select(r =>
            {

                return r;
            }).ToList();
        }

        public tbl_User Find(int ID)
        {

            return s.Query<tbl_User>("tbl_User_Proc", p => { p.Add("@Type", "Find"); p.Add("@ID", ID); }, CommandType.StoredProcedure)
            .Select(r =>
            {

                return r;
            }).SingleOrDefault();
        }

        public void Create(tbl_User obj)
        {
            s.Query("tbl_User_Proc", p =>
            {
                p.Add("@Type", "Create");
                p.Add("@Username", obj.Username);
                p.Add("@Password", obj.Password);

            }, CommandType.StoredProcedure);
        }

        public void Update(tbl_User obj)
        {
            s.Query("tbl_User_Proc", p =>
            {
                p.Add("@Type", "Update");
                p.Add("@ID", obj.ID);
                p.Add("@Password", obj.Password);

            }, CommandType.StoredProcedure);
        }

        public tbl_User Login(string usr, string pwd)
        {
            var result = s.Query<tbl_User>("tbl_User_Proc", p =>
            {
                p.Add("@Type", "Login");
                p.Add("@Username", usr);
                p.Add("@Password", pwd);

            }, CommandType.StoredProcedure);
            return result.SingleOrDefault();
        }

        public void Delete(tbl_User obj)
        {
            s.Query("DELETE FROM [tbl_User] WHERE ID = @ID", p =>
            {
                p.Add("@ID", obj.ID);
            });
        }
    }


}