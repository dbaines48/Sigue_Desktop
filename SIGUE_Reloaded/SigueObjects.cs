using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SIGUE_Reloaded
{
    class SigueObjets
    {
        public class Profile
        {
            public string name { get; set; }
            public string image { get; set; }
            public string email { get; set; }
        }

        public class login
        {
            public string email { get; set; }
            public string password { get; set; }
            public bool remember_me { get; set; }
        }
        public class tkn
        {
            public string token { get; set; }
            public string role { get; set; }
        }
        public class recovery
        {
            public string email { get; set; }
        }
        public class fail
        {
            public string error { get; set; }
        }
        public class alert
        {
            public string notice { get; set; }
        }
        public class Grade
        {
            public string grade { get; set; }
            public string percent { get; set; }
            public string period { get; set; }
        }
        public class matters
        {
            public string name { get; set; }
            public string course { get; set; }
            public string finalGrade { get; set; }
            public List<Grade> grades { get; set; }
        }
        public class Aplications
        {
            public int id { get; set; }
            public int school_id { get; set; }
            public string applicant_email { get; set; }
            public string applicant_names { get; set; }
            public string applicant_father_surname { get; set; }
            public string applicant_mother_surname { get; set; }
            public string applicant_sex { get; set; }
            public string applicant_address { get; set; }
            public string applicant_birth_day { get; set; }
            public string applicant_id_type { get; set; }
            public string applicant_id_number { get; set; }
            public string father_email { get; set; }
            public string father_names { get; set; }
            public string father_father_surname { get; set; }
            public string father_mother_surname { get; set; }
            public string father_id_type { get; set; }
            public string father_id_number { get; set; }
            public string father_phone { get; set; }
            public string father_cell_phone { get; set; }
            public string mother_email { get; set; }
            public string mother_names { get; set; }
            public string mother_father_surname { get; set; }
            public string mother_mother_surname { get; set; }
            public string mother_id_type { get; set; }
            public string mother_id_number { get; set; }
            public string mother_phone { get; set; }
            public string mother_cell_phone { get; set; }
            public string parent_email { get; set; }
            public string parent_names { get; set; }
            public string parent_father_surname { get; set; }
            public string parent_mother_surname { get; set; }
            public string parent_id_type { get; set; }
            public string parent_id_number { get; set; }
            public string parent_phone { get; set; }
            public string parent_relationship { get; set; }
            public string aspiration_grade { get; set; }
            public string last_grade { get; set; }
            public string last_school { get; set; }
            public string state { get; set; }
            public string created_at { get; set; }
            public string updated_at { get; set; }
        }
        public class Acepter
        {
            public string token { get; set; }
            public int id { get; set; }
        }
    }
}
