using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain;
using System.Data.SqlClient;
using System.Data;

namespace Service
{
    public class Entry
    {
        //------------- Purchase Item Related --------------------------
        public string PurchaseInvoiceI(int vno, string owner, DateTime edate, string usercode, string acode, double extdisc, string hasnote, string paytype, string note, DataTable itemsdetails, string bdate, string billno)
        {
            SqlParameter[] param = new SqlParameter[13];
            param[0] = new SqlParameter("@VNo", vno);
            param[1] = new SqlParameter("@Owner", owner);
            param[2] = new SqlParameter("@EDate", edate);
            param[3] = new SqlParameter("@UserCode", usercode);
            param[4] = new SqlParameter("@ACode", acode);
            param[5] = new SqlParameter("@ExtDisc", extdisc);
            param[6] = new SqlParameter("@HasNote", hasnote);
            param[7] = new SqlParameter("@PayType", paytype);
            param[8] = new SqlParameter("@Note", note);
            param[9] = new SqlParameter("@ItemsDetails", itemsdetails);
            param[10] = new SqlParameter("@BDate", bdate);
            param[11] = new SqlParameter("@BillNo", billno);
            param[12] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
            param[12].Direction = ParameterDirection.Output;
            DataAccessLayer.ExecuteProc("PurchaseInvoiceI", param);
            return (param[12].Value.ToString()).Trim();
        }

        public string PurchaseReturnI(int vno, string owner, DateTime edate, string usercode, string acode, double extdisc, string hasnote, string paytype, string note, DataTable itemsdetails)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@VNo", vno);
            param[1] = new SqlParameter("@Owner", owner);
            param[2] = new SqlParameter("@EDate", edate);
            param[3] = new SqlParameter("@UserCode", usercode);
            param[4] = new SqlParameter("@ACode", acode);
            param[5] = new SqlParameter("@ExtDisc", extdisc);
            param[6] = new SqlParameter("@HasNote", hasnote);
            param[7] = new SqlParameter("@PayType", paytype);
            param[8] = new SqlParameter("@Note", note);
            param[9] = new SqlParameter("@ItemsDetails", itemsdetails);
            param[10] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
            param[10].Direction = ParameterDirection.Output;
            DataAccessLayer.ExecuteProc("PurchaseReturnI", param);
            return (param[10].Value.ToString()).Trim();
        }

        public string SalesInvoiceI(int vno, string owner, DateTime edate, string usercode, string acode, double extdisc, string hasnote, string paytype, string note, DataTable itemsdetails)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@VNo", vno);
            param[1] = new SqlParameter("@Owner", owner);
            param[2] = new SqlParameter("@EDate", edate);
            param[3] = new SqlParameter("@UserCode", usercode);
            param[4] = new SqlParameter("@ACode", acode);
            param[5] = new SqlParameter("@ExtDisc", extdisc);
            param[6] = new SqlParameter("@HasNote", hasnote);
            param[7] = new SqlParameter("@PayType", paytype);
            param[8] = new SqlParameter("@Note", note);
            param[9] = new SqlParameter("@ItemsDetails", itemsdetails);
            param[10] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
            param[10].Direction = ParameterDirection.Output;
            DataAccessLayer.ExecuteProc("SalesInvoiceI", param);
            return (param[10].Value.ToString()).Trim();
        }

        public string SalesReturnI(int vno, string owner, DateTime edate, string usercode, string acode, double extdisc, string hasnote, string paytype, string note, DataTable itemsdetails)
        {
            SqlParameter[] param = new SqlParameter[11];
            param[0] = new SqlParameter("@VNo", vno);
            param[1] = new SqlParameter("@Owner", owner);
            param[2] = new SqlParameter("@EDate", edate);
            param[3] = new SqlParameter("@UserCode", usercode);
            param[4] = new SqlParameter("@ACode", acode);
            param[5] = new SqlParameter("@ExtDisc", extdisc);
            param[6] = new SqlParameter("@HasNote", hasnote);
            param[7] = new SqlParameter("@PayType", paytype);
            param[8] = new SqlParameter("@Note", note);
            param[9] = new SqlParameter("@ItemsDetails", itemsdetails);
            param[10] = new SqlParameter("@IfErrorMsg", SqlDbType.NChar, 254);
            param[10].Direction = ParameterDirection.Output;
            DataAccessLayer.ExecuteProc("SalesReturnI", param);
            return (param[10].Value.ToString()).Trim();
        }
    }
}
