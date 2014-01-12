using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Script.Serialization;
using System.Xml.Serialization;
using JsonMinDatas;


namespace JsonMinConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Func<int, int, double> PercentLoss = (first, sec) => (first - sec) *100/ first;
            var ld = new LoadData();
            var d= ld.LoadAllDepartments();


            #region xml
            var ser = new XmlSerializer(typeof(List<Department>));            
            var sb = new StringBuilder();
            using (var sw = new StringWriter(sb))
            {
                ser.Serialize(sw, d);
            }
 //           Console.WriteLine(sb.ToString());
            var nrXML = sb.Length;
            #endregion

            #region javascript
            var jss = new JavaScriptSerializer();
            int nrJss = jss.Serialize(d).Length;
            #endregion

            Console.WriteLine("Jss:{0}, XML:{1}", nrJss, nrXML); 
            
            var min = LoadData.Minimize(d);
            #region xml
            ser = new XmlSerializer(typeof(List<DSmall>));
            sb.Clear();            
            using (var sw = new StringWriter(sb))
            {
                ser.Serialize(sw, min);
            }
//            Console.WriteLine(sb.ToString());
            var nrXML2 = sb.Length;
            #endregion
            
            
            
            #region javascript
            var nrJss2 = jss.Serialize(min).Length;
            #endregion
            
            
            Console.WriteLine("Jss:{0}, XML:{1}", nrJss2, nrXML2);
            Console.WriteLine("Percent Jss:{0}, PercentXML:{1}", PercentLoss(nrJss, nrJss2), PercentLoss(nrXML, nrXML2));
            Console.WriteLine("Example from Andrei Ignat, http://msprogrammer.serviciipeweb.ro/");
            
        }
        
    }
}
