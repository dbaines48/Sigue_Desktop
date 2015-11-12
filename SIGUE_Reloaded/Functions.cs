using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace SIGUE_Reloaded
{
    class SigueFunctions
    {
        String token;
        public String error;

        public String get(String url, String getData)
        {
            WebRequest request = WebRequest.Create(url);
            request.Method = "GET";
            return sender(request, null);
        }

        public String post(String url, String postData)
        {
            WebRequest request;
            byte[] byteArray;
            Stream response;

            byteArray = Encoding.UTF8.GetBytes(postData);
            request = WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "application/json;charset=utf-8";
            request.ContentLength = byteArray.Length;

            response = request.GetRequestStream();
            response.Write(byteArray, 0, byteArray.Length);

            return sender(request, response);
        }

        public String put(String url, String postData)
        {
            WebRequest request;
            byte[] byteArray;
            Stream response;

            byteArray = Encoding.UTF8.GetBytes(postData);
            request = WebRequest.Create(url);
            request.Method = "PUT";
            request.ContentType = "application/json;charset=utf-8";
            request.ContentLength = byteArray.Length;

            response = request.GetRequestStream();
            response.Write(byteArray, 0, byteArray.Length);

            return sender(request, response);
        }

        public String sender(WebRequest @request, Stream @response)
        {
            StreamReader reader;
            String responseFromServer;
            //request.ContentType = "application/json;charset=utf-8";
            try
            {
                response = request.GetResponse().GetResponseStream();
                /*Leyendo Respuesta del Servidor*/
                reader = new StreamReader(response);
                /*Cerrando todos los Stream de datos*/
                responseFromServer = reader.ReadToEnd();
                response.Close();
                reader.Close();
                return responseFromServer;
            }
            catch (System.Net.WebException ex)
            {
                reader = new System.IO.StreamReader(ex.Response.GetResponseStream());
                try
                {
                    SigueObjets.fail fail = JsonConvert.DeserializeObject<SigueObjets.fail>(reader.ReadToEnd());
                    error = fail.error;
                    //MessageBox.Show(error);
                }
                catch (Exception)
                {
                    SigueObjets.alert alert = JsonConvert.DeserializeObject<SigueObjets.alert>(reader.ReadToEnd());
                    //MessageBox.Show(alert.notice);
                }
                throw new Exception("Se ha producido un error. " + ex.Message, ex);
            }
        }

        public String secret(String @pass)
        {
            String pss = pass;
            byte[] toEncodeAsBytes;
            for (int i = 0; i < 7; i++)
            {
                toEncodeAsBytes = System.Text.UTF8Encoding.UTF8.GetBytes(pss);
                pss = System.Convert.ToBase64String(toEncodeAsBytes);
            }
            return pss;
        }

        public SigueObjets.tkn trylogin(String @user, String @pass)
        {
            SigueObjets.login log = new SigueObjets.login();
            log.email = user;
            log.password = secret(@pass);
            log.remember_me = false;
            String data = JsonConvert.SerializeObject(log);
            String response = post("https://sigue.herokuapp.com/api/v1/sessions", @data);
            SigueObjets.tkn token = JsonConvert.DeserializeObject<SigueObjets.tkn>(response);
            this.token = token.token;
            return token;
        }

        public String getStatistics()
        {
            return "some statistics about students";
        }

        public SigueObjets.Profile getProfile()
        {
            SigueObjets.Profile p = new SigueObjets.Profile();
            p.email = "alguien@algo.com";
            p.image = "imagen.png";
            p.name = "Fulanito de Tal";
            return p;
        }

        public SigueObjets.matters getMatters()
        {
            String response = get("https://sigue.herokuapp.com/api/v1/sessions", this.token);
            return JsonConvert.DeserializeObject<SigueObjets.matters>(response);
        }

        public SigueObjets.Aplications[] getAplications(string token)
        {
            String response = get(" http://sigue.herokuapp.com/api/v1/applications?token=" + token, token);
            return JsonConvert.DeserializeObject<SigueObjets.Aplications[]>(response);
        }

        public SigueObjets.alert aceptAplication(int id)
        {
            SigueObjets.Acepter acep = new SigueObjets.Acepter();
            acep.token = this.token;
            acep.id = id;
            String data = JsonConvert.SerializeObject(acep);
            String response = put("http://sigue.herokuapp.com/api/v1/applications/accept", data);
            return JsonConvert.DeserializeObject<SigueObjets.alert>(response);
        }

        public void resetPass(String email)
        {
            SigueObjets.recovery mail = new SigueObjets.recovery();
            mail.email = email;
            String data = JsonConvert.SerializeObject(mail);
            String response = post("https://sigue.herokuapp.com/api/v1/sessions", data);
            SigueObjets.alert alert = JsonConvert.DeserializeObject<SigueObjets.alert>(response);
        }
    }
}
 