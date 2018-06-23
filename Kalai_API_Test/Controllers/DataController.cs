using Kalai_API_Test.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;

namespace Kalai_API_Test.Controllers
{

    public class DataController : ApiController
    {
        private static List<mdldata> lstdata = new List<mdldata>();
        [HttpGet]
        public string read()
        {
            try
            {
                result rslt = new result();
                rslt.status_code = "1";
                rslt.Result = JsonConvert.SerializeObject(lstdata);
                return JsonConvert.SerializeObject(rslt);

            }
            catch (Exception e)
            {
                throw e;
            }
        }


        [HttpGet]
        [Route("")]
        public string welcome()
        {
            try
            {
                result rslt = new result();
                rslt.status_code = "1";
                rslt.Result = "Kalai Test Api is Running";
                return JsonConvert.SerializeObject(rslt);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        [HttpPut]

        public string create(List<mdldata> body_data)
        {
            try
            {

                foreach (mdldata data in body_data)
                {
                    lstdata.Add(data);
                }

                result rslt = new result();
                rslt.status_code = "1";
                rslt.Result = "Successfully Inserted";
                return JsonConvert.SerializeObject(rslt);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]
        public string update(List<mdldata> body_data)
        {
            try
            {
                result rslt = new result();
                if (lstdata.Count == 0)
                {
                    rslt.status_code = "0";
                    rslt.Result = "No Data found";
                    return JsonConvert.SerializeObject(rslt);
                }
                foreach (mdldata data in lstdata)
                {
                    foreach (mdldata data1 in body_data)
                    {
                        if (data.Id == data1.Id)
                        {
                            lstdata.Remove(data);
                            lstdata.Add(data1);
                            rslt.status_code = "1";
                            rslt.Result = "Successfully update";
                            return JsonConvert.SerializeObject(rslt);
                        }
                        else
                        {
                            rslt.status_code = "0";
                            rslt.Result = "failure to update";
                            return JsonConvert.SerializeObject(rslt);
                        }
                    }

                }
                rslt.status_code = "1";
                rslt.Result = "Successfully update";
                return JsonConvert.SerializeObject(rslt);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

        [HttpPost]       
        public string delete(List<mdldata> body_data)
        {
            try
            {
                result rslt = new result();
                if (lstdata.Count == 0)
                {
                    rslt.status_code = "0";
                    rslt.Result = "No Data found";
                    return JsonConvert.SerializeObject(rslt);
                }
               
                foreach (mdldata data in lstdata)
                {
                    foreach (mdldata data1 in body_data)
                    {
                        if (data.Id == data1.Id)
                        {
                            lstdata.Remove(data);
                           
                            rslt.status_code = "1";
                            rslt.Result = "Successfully delete";
                            return JsonConvert.SerializeObject(rslt);
                        }
                        else
                        {
                            rslt.status_code = "0";
                            rslt.Result = "failure to delete";
                            return JsonConvert.SerializeObject(rslt);
                        }
                    }

                }
                rslt.status_code = "1";
                rslt.Result = "Successfully deleted";
                return JsonConvert.SerializeObject(rslt);

            }
            catch (Exception e)
            {
                throw e;
            }
        }

    }
}
