using System.Collections.ObjectModel;
using System.Text;
using UsingWPF;

namespace DataModel
{
    public class EmpDataModel
    {        
        public IEnumerable<EmpModel> ReadCSV(string fileName)
        {            
            string[] lines = File.ReadAllLines(fileName);
            
            return lines.Select(line =>
            {
                string[] data = line.Split(',');
                
                return new EmpModel()
                {
                    ID = data[0].Trim('"'),
                    EmpName = data[1].Trim('"'),
                    Grade = data[2].Trim('"'),
                    Department = data[3].Trim('"')                   
                };
            });
        }

        public void AddToCSV(string fileName, string InsData)
        {
            if (File.Exists(fileName))
            {                
                File.WriteAllText(fileName, InsData);
            }
        }        
    }
}