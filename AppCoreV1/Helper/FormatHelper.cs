using AppCoreV1.Interfaces;
using System.Globalization;
using System.Text;
using System.Xml.Linq;

namespace AppCoreV1.Helper
{
    public static class FormatHelper
    {
        public static string ConvertToCamelCase(string input)
        {
            TextInfo textInfo = new CultureInfo("en-US", false).TextInfo;
            string[] words = input.Split(' ');
            string camelCase = "";
            foreach (string word in words)
            {
                camelCase += textInfo.ToTitleCase(word);
            }
            camelCase = char.ToLowerInvariant(camelCase[0]) + camelCase.Substring(1);
            //Console.WriteLine(camelCase);

            return camelCase;
        }

        public static List<string> ParseXML(string strxml)
        {
            List<string> words = new List<string>();
            if(strxml == "")
            {
                strxml = System.IO.File.ReadAllText(@"C:\Temp\Notes.txt");
            }

            try
            {
                XElement element = XElement.Parse(strxml);

                foreach (XElement element2 in element.Elements())
                {
                    string strname = element2!.Element("name")!.Value;
                    string strprompt = element2!.Element("prompt")!.Value;
                    string strvalue = element2!.Element("value")!.Value;

                    if(strname != "" && strprompt != "" && strvalue != "")
                    {
                        string txt = strprompt + "@@" + strvalue;
                        words.Add(txt);
                    }

                    //foreach (XElement element3 in element2.Elements())
                    //{
                    //    string txt = element3.Name + "@@" + element3.Value;
                    //    words.Add(txt);
                    //    Console.WriteLine(txt);
                    //}
                }

                //foreach(XElement el in element.Descendants())
                //{
                //    foreach (XElement el1 in el.Descendants())
                //    {
                //        Console.WriteLine(el.Name);
                //        Console.WriteLine();
                //        Console.WriteLine(el.Value);
                //        Console.WriteLine();
                //    }
                //}

            }
            catch
            {
                words = new List<string>();
            }

            return words;
        }

        public static string ParseXML1(string strxml)
        {
            StringBuilder sb = new StringBuilder(); 

            sb.Append("<table id=\"tabldata\" class=\"table\">");
            sb.AppendLine();
            sb.Append("<thead class=\"thead-dark\">");
            sb.AppendLine();
            sb.Append("<tr>");
            sb.AppendLine();
            sb.Append("<th scope=\"col\">Attribute</th>");
            sb.AppendLine();
            sb.Append("<th scope=\"col\">Value</th>");
            sb.AppendLine();
            sb.Append("</tr>");
            sb.AppendLine();
            sb.Append("</thead>");
            sb.AppendLine();
            sb.Append("<tbody>");
            sb.AppendLine();

            try
            {
                if (!string.IsNullOrEmpty(strxml))
                {

                    XElement element = XElement.Parse(strxml);

                    foreach (XElement element2 in element.Elements())
                    {
                        string strname = element2!.Element("name")!.Value;
                        string strprompt = element2!.Element("prompt")!.Value;
                        string strvalue = element2!.Element("value")!.Value;

                        if (strname != "" && strprompt != "" && strvalue != "")
                        {
                            sb.Append("<tr>");
                            sb.AppendLine();
                            sb.Append("<td>" + element2!.Element("prompt")!.Value + "</td>");
                            sb.AppendLine();
                            sb.Append("<td>" + element2!.Element("value")!.Value + "</td>");
                            sb.AppendLine();
                            sb.Append("</tr>");
                            sb.AppendLine();

                        }
                    }
                }
                sb.Append("</tbody>");
                sb.AppendLine();
                sb.Append("</table>");
                sb.AppendLine();
            }
            catch(Exception ex)
            {
                sb.Append(ex.ToString());
            }

            return sb.ToString();
        }

        public static string ParseXML2(string strxml, string? cols, string? values)
        {
            StringBuilder sb = new StringBuilder();
            string[] _cols = cols!.Split(',');
            string[] _values = values!.Split(',');

            sb.Append("<table id=\"tabldata\" class=\"table\">");
            sb.AppendLine();
            sb.Append("<thead class=\"thead-dark\">");
            sb.AppendLine();
            sb.Append("<tr>");
            sb.AppendLine();
            sb.Append("<th scope=\"col\">Attribute</th>");
            sb.AppendLine();
            sb.Append("<th scope=\"col\">Value</th>");
            sb.AppendLine();
            sb.Append("</tr>");
            sb.AppendLine();
            sb.Append("</thead>");
            sb.AppendLine();
            sb.Append("<tbody>");
            sb.AppendLine();

            try
            {
                if (!string.IsNullOrEmpty(strxml))
                {

                    XElement element = XElement.Parse(strxml);

                    foreach (XElement element2 in element.Elements())
                    {
                        string strname = element2!.Element("name")!.Value;
                        string strprompt = element2!.Element("prompt")!.Value;
                        string strvalue = element2!.Element("value")!.Value;

                        if (strname != "" && strprompt != "" && strvalue != "")
                        {
                            sb.Append("<tr>");
                            sb.AppendLine();
                            sb.Append("<td>" + element2!.Element("prompt")!.Value + "</td>");
                            sb.AppendLine();
                            sb.Append("<td>" + element2!.Element("value")!.Value + "</td>");
                            sb.AppendLine();
                            sb.Append("</tr>");
                            sb.AppendLine();

                        }
                    }

                    for (int i = 0; i < _cols.Length; i++)
                    {
                        sb.Append("<tr>");
                        sb.AppendLine();
                        sb.Append("<td>" + _cols[i] + "</td>");
                        sb.AppendLine();
                        sb.Append("<td>" + _values[i] + "</td>");
                        sb.AppendLine();
                        sb.Append("</tr>");
                        sb.AppendLine();
                    }
                }
                sb.Append("</tbody>");
                sb.AppendLine();
                sb.Append("</table>");
                sb.AppendLine();
            }
            catch (Exception ex)
            {
                sb.Append(ex.ToString());
            }

            return sb.ToString();
        }
    }
}
