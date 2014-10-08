using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Sockets;
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

        public String GetDurationString(int seconds)
        {
            int hours = seconds / 3600;
            int minutes = (seconds % 3600) / 60;
            seconds = seconds % 60;

            return TwoDigitString(hours) + ":" + TwoDigitString(minutes) + ":"
                    + TwoDigitString(seconds);
        }

        public String TwoDigitString(int number)
        {
            if (number == 0)
            {
                return "00";
            }

            if (number / 10 == 0)
            {
                return "0" + number;
            }

            return number.ToString(CultureInfo.InvariantCulture);
        }

 
        public object Nulo(int valor)
        {
            if (valor == 0)
                return DBNull.Value;
            return valor;
        }

        public object Nulo(object valor)
        {
            if (valor == null)
                return DBNull.Value;
            if (string.IsNullOrEmpty(valor.ToString()))
                return DBNull.Value;
            return valor;
        }

        public string GetRandomHash()
        {
            const int tamanho = 7; // Numero de digitos da senha
            string senha = string.Empty;
            for (int i = 0; i < tamanho; i++)
            {
                var random = new Random();
                int codigo = Convert.ToInt32(random.Next(48, 122).ToString(CultureInfo.InvariantCulture));

                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                    string _char = ((char)codigo).ToString(CultureInfo.InvariantCulture);
                    if (!senha.Contains(_char))
                    {
                        senha += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
                {

                }
            }

            return senha;
        }

        public void SendData(string zpl, string impressora)
        {
            NetworkStream ns = null;
            Socket socket = null;
            var ip = impressora;
            try
            {
                var printerIp = new IPEndPoint(IPAddress.Parse(ip), 9100);


                socket = new Socket(AddressFamily.InterNetwork,
                    SocketType.Stream,
                    ProtocolType.Tcp);
                socket.Connect(printerIp);

                ns = new NetworkStream(socket);

                byte[] toSend = Encoding.ASCII.GetBytes(zpl);
                ns.Write(toSend, 0, toSend.Length);
            }
            catch (SocketException ex)
            {
                MessageBox.Show(ex.Message, "Erro de Comunicação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception e)
            {
                MessageBox.Show("Ocorreu um erro de comunicação, verifique se a impressora está online ou se o IP está correto, DETALHES: " + e.Message, "Erro de Comunicação", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            finally
            {
                if (ns != null)
                    ns.Close();

                if (socket != null && socket.Connected)
                    socket.Close();
            }
        }
    }
}
