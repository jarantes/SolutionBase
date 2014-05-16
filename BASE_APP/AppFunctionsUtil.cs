using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BASE_APP
{
    public class AppFunctionsUtil
    {
        public string GetMd5Hash(string input)
        {
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();
            byte[] inputBytes = Encoding.ASCII.GetBytes(input);
            byte[] hash = md5.ComputeHash(inputBytes);
            var sb = new StringBuilder();
            foreach (byte t in hash)
            {
                sb.Append(t.ToString("X2"));
            }
            return sb.ToString();
        }

        //Popular o combo---------------------------------------------------------------------------------------------------------------------------
        public void Combo(ref ComboBox combo, DataTable dt, string strText, string strValue, string strLabel = "")
        {
            if (!string.IsNullOrEmpty(strLabel))
            {

                if (dt.Rows.Count > 0)
                {
                    DataRow ln = dt.NewRow();
                    ln[strText] = strLabel;
                    ln[strValue] = "0";
                    dt.Rows.InsertAt(ln, 0);
                }
            }

            combo.ValueMember = strValue;
            combo.DisplayMember = strText;
            combo.DataSource = dt;

            if (!string.IsNullOrEmpty(strLabel))
            {
                combo.SelectedValue = "0";
            }
            else
            {
                combo.SelectedIndex = -1;
            }
        }

        public DataTable ToDataTable<T>(List<T> items)
        {
            var tb = new DataTable(typeof(T).Name);

            PropertyInfo[] props = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);

            foreach (var prop in props)
            {
                tb.Columns.Add(prop.Name, prop.PropertyType);
            }

            foreach (var item in items)
            {
                var values = new object[props.Length];
                for (var i = 0; i < props.Length; i++)
                {
                    values[i] = props[i].GetValue(item, null);
                }

                tb.Rows.Add(values);
            }

            return tb;
        }
    }
}
