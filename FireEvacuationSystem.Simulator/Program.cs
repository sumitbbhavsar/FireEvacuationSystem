using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
// using System.Net.Http.Formatting;
namespace DataPusherApp
{
    #region Program class
    class Program
    {
        #region Main Method

       public static void Main()
        {
            string isCordinate="0";
            isCordinate = Console.ReadLine();
            var OemployeeList =new EmployeeList();

            int NoOfRouters = 3;//dB values (select top 3 router from tableRouter order by SignalStrength desc)
            double[] freqInMHz  = new double[]{2412,2412,2412}; //mHz from DB values

           

            if (isCordinate=="0")
            {
                #region 
                var jsonData = System.IO.File.ReadAllText(@"D:\Akshay\FireEvacuationSystem\FireEvacuationSystem.Simulator\data\EmployeeSignalStrength.json");
            
                List<Employee> empList = JsonConvert.DeserializeObject<List<Employee>>(jsonData);
                for (int i = 0; i < empList.Count; i++)
                {
                    empList[i].s1List=empList[i].SignalStrength1.Split(",").ToList();
                    empList[i].s2List=empList[i].SignalStrength2.Split(",").ToList();
                    empList[i].s3List=empList[i].SignalStrength3.Split(",").ToList();                            
                }

            
                for (int j=0; j < empList[0].s1List.Count;j++)
                {
                    for (int emp=0; emp < empList.Count;emp++)
                    {
                     double s1=Convert.ToDouble(empList[emp].s1List[j]);
                     double s2=Convert.ToDouble(empList[emp].s2List[j]);
                     double s3=Convert.ToDouble(empList[emp].s3List[j]);
                     int  empId=(empList[emp].EmpID);

                    double[] SignalStrengthInDb = new double[]{s1,s2,s3};
                    double[] radii = new double[]{0,0,0};
                    for(int i = 0; i < NoOfRouters; i++)
                    {
                        double exp = (27.55 - (20 * Math.Log10(freqInMHz[i])) + Math.Abs(SignalStrengthInDb[i])) / 20.0;
                        double d = (double) Math.Pow(10.0, exp);
                        radii[i] = Math.Round(d,1); //add value to radii array
                    }
                    
                    double[] EmpLocation = GetEmpLocationByRadii(radii);
                    
                    using (HttpClient client = new HttpClient())
                    {
                        
                        EmployeeRoutesRequest request =  new  EmployeeRoutesRequest();
                        request.X=EmpLocation[0];
                        request.Y=EmpLocation[1];
                        request.EmployeeId=empId;
                        request.NearByRouteId=8;
                        StringContent content = new StringContent (JsonConvert.SerializeObject(request),Encoding.UTF8,"application/json");
                        

                        HttpResponseMessage response =  client.PostAsync("http://localhost:5000/api/EmployeeRoutes", content).Result;

                        if(response.IsSuccessStatusCode)
                        {
                            Console.WriteLine("API called " + response.StatusCode)   ;
                        }
                        else
                        {
                                Console.WriteLine("API called " + response.StatusCode)   ;
                        }
                    }
                    System.Threading.Thread.Sleep(1000);
                }

            }
            #endregion
            }
            else
            {
               var jsonData = System.IO.File.ReadAllText(@"D:\Akshay\FireEvacuationSystem\FireEvacuationSystem.Simulator\data\EmployeeSignalStrength_Cordinates.json");
            
                List<EmployeeRoutesRequestWithCordinate> empList = JsonConvert.DeserializeObject<List<EmployeeRoutesRequestWithCordinate>>(jsonData);
                for (int i = 0; i < empList.Count; i++)
                {
                    empList[i].XList=empList[i].X.Split(",").ToList();
                    empList[i].YList=empList[i].Y.Split(",").ToList();
                }
            
                for (int j=0; j < empList[0].XList.Count;j++)
                {
                    for (int emp=0; emp < empList.Count;emp++)
                    {
                        double s1=Convert.ToDouble(empList[emp].XList[j]);
                        double s2=Convert.ToDouble(empList[emp].YList[j]);
                        int  empId=(empList[emp].EmployeeId);

                        double[] SignalStrengthInDb = new double[]{s1,s2};
                        using (HttpClient client = new HttpClient())
                        {
                            
                            EmployeeRoutesRequest request =  new  EmployeeRoutesRequest();
                            request.X=SignalStrengthInDb[0];
                            request.Y=SignalStrengthInDb[1];
                            request.EmployeeId=empId;
                            request.NearByRouteId=8;
                            Console.WriteLine("API called " + empId);
                            StringContent content = new StringContent (JsonConvert.SerializeObject(request),Encoding.UTF8,"application/json");
                            HttpResponseMessage response =  client.PostAsync("http://localhost:5000/api/EmployeeRoutes", content).Result;

                            if(response.IsSuccessStatusCode)
                            {
                                Console.WriteLine("API called " + request.X);
                                Console.WriteLine("API called " + request.Y);
                                Console.WriteLine("API called " + response.StatusCode);
                            }
                            else
                            {
                                Console.WriteLine("API called " + request.X);
                                Console.WriteLine("API called " + request.Y);
                                Console.WriteLine("API called " + response.StatusCode);
                            }
                        }
                    }
                    System.Threading.Thread.Sleep(1000);
                }
            }
        }
            
            

            
            // #region looping through each employee and getting x & y from signal strength
            // foreach (var employeeItem in empList)
            // {
            //     for (int j = 0; j < employeeItem.SignalStrength1.Split(",").Length; j++)
            //     {
                    
            //         double[] SignalStrengthInDb = new double[]{employeeItem.SignalStrength1[j],employeeItem.SignalStrength2[j],employeeItem.SignalStrength3[j]};
            //         double[] radii = new double[]{0,0,0};
            //         for(int i = 0; i < NoOfRouters; i++)
            //         {
            //             double exp = (27.55 - (20 * Math.Log10(freqInMHz[i])) + Math.Abs(SignalStrengthInDb[i])) / 20.0;
            //             double d = (double) Math.Pow(10.0, exp);
            //             radii[i] = Math.Round(d,1); //add value to radii array
            //         }
                    
            //         double[] EmpLocation = GetEmpLocationByRadii(radii);

            //         using (HttpClient client = new HttpClient())
            //         {
                        
            //             EmployeeRoutesRequest request =  new  EmployeeRoutesRequest();
            //             request.X=EmpLocation[0];
            //             request.Y=EmpLocation[1];
            //             request.EmployeeId=employeeItem.EmpID;
            //             request.NearByRouteId=8;
            //             StringContent content = new StringContent (JsonConvert.SerializeObject(request),Encoding.UTF8,"application/json");
                        

            //             HttpResponseMessage response =  client.PostAsync("http://localhost:5000/api/EmployeeRoutes", content).Result;

            //             if(response.IsSuccessStatusCode)
            //             {
            //                 Console.WriteLine("API called " + response.StatusCode)   ;
            //             }
            //         }
            //         System.Threading.Thread.Sleep(2000);
            //     }
               
            // }
            // #endregion
        //  }
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
        public string SignalStrength1 { get; set; }
        public string SignalStrength2 { get; set; }
        public string SignalStrength3 { get; set; }  
        public List<string> s1List {get;set;}
        public List<string> s2List {get;set;}
        public List<string> s3List {get;set;}
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
     #region EmployeeRoutesRequest
    public class EmployeeRoutesRequestWithCordinate
    {
        /// <summary>
        /// Get or sets X
        /// </summary>
        public string X { get; set; }

        /// <summary>
        /// Get or sets Y
        /// </summary>
        public string Y { get; set; }

        /// <summary>
        /// Get or sets NearByRouteId
        /// </summary>
        public int NearByRouteId { get; set; }

        /// <summary>
        /// Get or sets EmployeeId
        /// </summary>
        public int EmployeeId { get; set; }
        /// <summary>
        /// Get or sets EmployeeId
        /// </summary>
        public int EmpID { get; set; }

        /// <summary>
        /// Get or sets TimeStamp 
        /// </summary>
        public DateTime TimeStamp {get;set;}
        public List<string> XList {get;set;}
        public List<string> YList {get;set;}
    } 
    #endregion
}
