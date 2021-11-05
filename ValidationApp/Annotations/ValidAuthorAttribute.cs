using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ValidationApp.Annotations
{
    public class ValidAuthorAttribute : ValidationAttribute
    {
        private string[] myAuthors;
        public ValidAuthorAttribute(string[] authors)
        {
            myAuthors = authors;
        }
        public override bool IsValid(object value)
        {
            if(value != null)
            {
                string strval = value.ToString();
                for(int i = 0; i<myAuthors.Length; i++)
                {
                    if (strval == myAuthors[i])
                        return true;
                }
            }
            return false;
        }
    }
}