using NonProfitAccountSystem.Classes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace NonProfitAccountSystem.Models
{
    public class tbl_Subscriber
    {
        dbcontrol s = new dbcontrol();
        [Display(Name = "ID")]
        [ScaffoldColumn(false)]
        public Int32 ID { get; set; }

        [Display(Name = "Subscriber")]
        public String Subscriber { get; set; }

        [Display(Name = "Encoder")]
        [ScaffoldColumn(false)]
        public Int32 Encoder { get; set; }

        [Display(Name = "Timestamp")]
        [ScaffoldColumn(false)]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:yyyy-MM-dd}")]
        [DataType(DataType.Date)]
        public DateTime? Timestamp { get; set; }

        public tbl_Subscriber()
        {
        }
        public List<tbl_Subscriber> List()
        {

            return s.Query<tbl_Subscriber>("SELECT * FROM [tbl_Subscriber]")
            .Select(r =>
            {

                return r;
            }).ToList();
        }

        public SelectList ListSubscriber()
        {
            var list = new SelectList(List(), "ID", "Subscriber");
            return list;
        }

        public tbl_Subscriber Find(int ID)
        {

            return s.Query<tbl_Subscriber>("SELECT * FROM tbl_Subscriber where ID = @ID", p => p.Add("@ID", ID))
            .Select(r =>
            {

                return r;
            }).SingleOrDefault();
        }

        public int Create(tbl_Subscriber obj)
        {
            var ID = s.Insert("[tbl_Subscriber]", p =>
            {
                p.Add("Subscriber", obj.Subscriber);
                p.Add("Encoder", SystemSession.User.ID);

            });
            return ID;
        }

        public void Update(tbl_Subscriber obj)
        {
            s.Update("[tbl_Subscriber]", obj.ID, p =>
            {
                p.Add("Subscriber", obj.Subscriber);
                p.Add("Encoder", SystemSession.User.ID);

            });
        }
        public void Delete(tbl_Subscriber obj)
        {
            s.Query("DELETE FROM [tbl_Subscriber] WHERE ID = @ID", p =>
            {
                p.Add("@ID", obj.ID);
            });
        }
    }


}