using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace SellCamera.Models
{
    public partial class Account
    {
        SellCameraDataModel db = new SellCameraDataModel();
        public void Update_Account(Account user, int MaKH)
        {
            SqlParameter[] param = new SqlParameter[]
            {       
                new SqlParameter("Hoten",user.Hoten),
                new SqlParameter("Email",user.Email),
                new SqlParameter("Phonenumber",user.Phonenumber),
                new SqlParameter("address",user.Address),
                new SqlParameter("idKH",MaKH)
            };
            db.Database.ExecuteSqlCommand("update_checkout_user @Hoten,@Email,@Phonenumber,@address,@idKH", param);
        }
    }
}