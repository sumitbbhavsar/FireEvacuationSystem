using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
namespace DataPusherApp
{
    #region Program class
    class Program
    {
        #region Main Method

       public static void Main()
        {
            var OemployeeList =new EmployeeList();

            int NoOfRouters = 3;//dB values (select top 3 router from tableRouter order by SignalStrength desc)
            double[] freqInMHz  = new double[]{2412,2412,2412}; //mHz from DB values

            var jsonData = System.IO.File.ReadAllText(@"D:/Users/akchavda/OneDrive - Capgemini\DataPusherApp/data/EmployeeSignalStrength.json");
            EmployeeList empList = JsonConvert.DeserializeObject<EmployeeList>(jsonData);

            #region looping through each employee and getting x & y from signal strength
            foreach (var employeeItem in empList.lstEmployee)
            {
                double[] SignalStrengthInDb = new double[]{employeeItem.SignalStrength1,employeeItem.SignalStrength2,employeeItem.SignalStrength3};
                double[] radii = new double[]{0,0,0};
                for(int i = 0; i < NoOfRouters; i++)
                {
                    double exp = (27.55 - (20 * Math.Log10(freqInMHz[i])) + Math.Abs(SignalStrengthInDb[i])) / 20.0;
                    double d = (double) Math.Pow(10.0, exp);
                    radii[i] = Math.Round(d,1); //add value to radii array
                }
                
                double[] EmpLocation = GetEmpLocationByRadii(radii);
                // using (var client = new HttpClient())
                // {
                //     client.BaseAddress = new Uri("http://localhost:60464/api/");
                //     //HTTP GET
                //     var responseTask = client.GetAsync("student");
                //     responseTask.Wait();

                //     var result = responseTask.Result;
                //     if (result.IsSuccessStatusCode)
                //     {

                //         var readTask = result.Content.ReadAsAsync<Student[]>();
                //         readTask.Wait();

                //         var students = readTask.Result;

                //         foreach (var student in students)
                //         {
                //             Console.WriteLine(student.Name);
                //         }
                //     }
                // }
            }
            #endregion
        }
         #endregion
        
        #region get x & y of location
        public static double[] GetEmpLocationByRadii(double[] radii)
        {
            //Test
		double dbX=10;//get from DB for dynamic Room Size
		double dbY=10;//get from DB for dynamic Room Size
		
		double[] locate = new double[]{0,0};
		double r1 = radii[0]; //Radius of Circle 1 Origin
		double r2 = radii[1]; //Radius of Circle 2 X-Axis
		double r3 = radii[2]; //Radius of Circle 3 X-Axis
		double x; // Emp Location Co-Ordinate X
		double y;// Emp Location Co-Ordinate Y
		//add X Cordiante
		
		x = Math.Abs(((r1*r1)-(r2*r2)+(dbX*dbX))/(2*dbX));
		
		//add Y Cordiante
		y = Math.Abs(((r1*r1)-(r3*r3)+(dbY*dbY))/(2*dbY));
		
		locate[0]=Math.Round(x,1);
		locate[1]=Math.Round(y,1);
		return locate;
        }
        #endregion
    }
   #endregion
    
    #region EmployeeList
    public class EmployeeList
    {
        public List<Employee> lstEmployee { get; set; }
    }
    #endregion
    
    #region Employee Class
    public class  Employee{
        public int EmpID { get; set; }
        public double SignalStrength1 { get; set; }
        public double SignalStrength2 { get; set; }
        public double SignalStrength3 { get; set; }
    }
    #endregion

    #region EmployeeRoutesRequest
    public class EmployeeRoutesRequest
    {
    /// <summary>
    /// Get or sets X
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Get or sets Y
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Get or sets NearByRouteId
    /// </summary>
    public int NearByRouteId { get; set; }

    /// <summary>
    /// Get or sets EmployeeId
    /// </summary>
    public int EmployeeId { get; set; }

    /// <summary>
    /// Get or sets TimeStamp 
    /// </summary>
    public DateTime TimeStamp {get;set;}
    } 
    #endregion
}
