using System;

namespace CertificatesModel.ExcelService
{
    static class FIO
    {
        static public string MakeGenitiveCase(string word)
        {
            string name = "", secondName = "", io = "", family = "";

            var fio = word.Split(' ');
            // получаем фамилию
            family = fio[0];

            if (fio.Length == 2)
            {
                io = fio[1];
            }
            // указаны фамилия и полное имя и отчество
            if (fio.Length >= 3)
            {
                name = fio[1];
                secondName = fio[2];
            }

            // типичные мужские фамилии
            try
            {
                if (family.EndsWith("ов"))
                    family += "а";
                else if (family.EndsWith("ин"))
                    family += "а";
                else if (family.EndsWith("ын"))
                    family += "а";
                else if (family.EndsWith("ев"))
                    family += "а";
                else if (family.EndsWith("ёв"))
                    family += "а";
                else if (family.EndsWith("ий"))
                    family = family.Replace("ий", "ого");
                else if (family.EndsWith("ый"))
                    family = family.Replace("ый", "ого");

                // типичные женские фамилии
                else if (family.EndsWith("ова"))
                    family = family.Replace("ова", "овой");
                else if (family.EndsWith("ева"))
                    family = family.Replace("ева", "евой");
                else if (family.EndsWith("ина"))
                    family = family.Replace("ина", "иной");
                else if (family.EndsWith("ая"))
                    family = family.Replace("ая", "ой");
            }
            catch (Exception e)
            {
                var asd = e.Message;
            }

            if (fio.Length == 2)
            {
                family += " " + io;
            }
            else if (fio.Length >= 3)
            {
                family += " " + name + " " + secondName;
            }

            return family;
        }
    }
}
